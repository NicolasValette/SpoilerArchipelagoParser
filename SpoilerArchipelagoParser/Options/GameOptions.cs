using NoNiDev.SpoilerArchipelagoParser.Attributes;
using NoNiDev.SpoilerArchipelagoParser.Enums;
using NoNiDev.SpoilerArchipelagoParser.Options.Converter;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace NoNiDev.SpoilerArchipelagoParser.Options
{
    public class GameOptions
    {
        [SpoilerName("Game")]
        public string Game { get; set; } = string.Empty;
        [NotParserValue]
        [JsonPropertyName("joueur")]
        public string PlayerName { get; set; } = string.Empty;
        [NotParserValue]
        public DateTime Date { get; set; }
        [NotParserValue]
        [JsonIgnore]
        public Dictionary<string, string> GameOptionsDictionnary { get; protected set; } = [];
        [NotParserValue]
        [JsonIgnore]
        public Dictionary<string, Field> Prop { get; protected set; } = [];
        [NotParserValue]
        [JsonIgnore]
        public Dictionary<string, ComboField> ComboProp { get; protected set; } = [];

       
        
        public GameOptions(string name, Dictionary<string, string> opt, string? gameName=null)
        {
            if (gameName != null)
            {
                Game = gameName;
            }
            GameOptionsDictionnary = opt;
            PlayerName = name;
            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop.GetCustomAttribute<NotParserValueAttribute>() != null) continue;
                var comboAttributes = prop.GetCustomAttribute<ComboConverterAttribute<int>>();
                if (comboAttributes != null)
                {
                    ComboField comboField = new ComboField();
                    comboField.Property = prop;
                    comboField.SpoilerNames = comboAttributes.Values;
                    comboField.Converter = comboAttributes.Converter;
                    ComboProp.Add(prop.Name, comboField);
                    continue;
                }
                var attributes = prop.GetCustomAttribute<SpoilerNameAttribute>();
                Field field = new Field();
                if (attributes != null)
                {
                    field.SpoilerName = attributes.SpoilerName;
                }
                else
                {
                    field.SpoilerName = prop.Name;
                }

                var convertAttributes = prop.GetCustomAttribute<ConvertValueAttribute>();
                if (convertAttributes != null)
                {
                    field.ConverterAttribute = convertAttributes;
                }

                field.Property = prop;

                var validAttributes = prop.GetCustomAttribute<RestrictValuesBaseAttribute>();
                if (validAttributes != null)
                {
                    field.IsValid = validAttributes.IsValid;
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    RestrictValuesBaseAttribute boolValidAttribute = new RestrictEnumValuesAttribute<EYesNo>();
                    field.IsValid = boolValidAttribute.IsValid;
                }
                else if (prop.PropertyType == typeof(int))
                {
                    RestrictValuesBaseAttribute boolValidAttribute = new RestrictIntValuesAttribute();
                    field.IsValid = boolValidAttribute.IsValid;
                }
                Prop.Add(prop.Name, field);
            }
        }
        public void Process()
        {
            foreach (var item in Prop)
            {
                string spoilerName = item.Value.SpoilerName.Replace("_", " ");
                var key = item.Key.Replace(" ", string.Empty);
                if (key == null)
                    continue;
                GameOptionsDictionnary.TryGetValue(spoilerName, out string? spoilerValue);
                object spoilerValueCast = spoilerValue;
                if (!item.Value.IsValid(spoilerValue ?? string.Empty))
                {
                    string val = spoilerValue == null ? "null" : spoilerValue;
                    throw new SpoilerDataValidationException($"The value '{val}' is not valid for the field '{spoilerName}'.");
                }
                if (item.Value.ConverterAttribute != null)
                {
                    Type converterType = item.Value.ConverterAttribute.ConverterType;
                    var converterInterface = converterType.GetInterfaces().FirstOrDefault
                        (i => i.IsGenericType &&
                                i.GetGenericTypeDefinition() == typeof(IConverter<,>) &&
                                i.GetGenericArguments()[0] == spoilerValue?.GetType());
                    if (converterInterface != null)
                    {
                        object instance = Activator.CreateInstance(converterType);
                        MethodInfo method = converterInterface.GetMethod("Convert");
                        spoilerValueCast = method.Invoke(instance, new object[] { spoilerValue });
                    }
                }
                this.GetType().GetProperty(item.Key.Replace(" ", string.Empty))?.SetValue(this, spoilerValueCast);
            }
            foreach (var item in ComboProp)
            {
                string[] spoilerNames = item.Value.SpoilerNames;
                Dictionary<string, object> values = new Dictionary<string, object>();
                foreach (var spoilerName in spoilerNames)
                {
                    GameOptionsDictionnary.TryGetValue(spoilerName, out string? spoilerValue);
                    values.Add(spoilerName, spoilerValue ?? string.Empty);
                }
                int? convertedValue = item.Value.Converter?.Convert(values);
                this.GetType().GetProperty(item.Key.Replace(" ", string.Empty))?.SetValue(this, convertedValue);
            }
        }
    }
}
