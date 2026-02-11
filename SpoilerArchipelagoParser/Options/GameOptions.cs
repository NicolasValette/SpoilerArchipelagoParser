using NoNiDev.SpoilerArchipelagoParser.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace NoNiDev.SpoilerArchipelagoParser.Options
{
    public abstract class GameOptions
    {
        
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

        public GameOptions()
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop.GetCustomAttribute<NotParserValueAttribute>() != null) continue;
                var comboAttributes = prop.GetCustomAttribute<ComboConverterAttribute<string>>();
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

                var convertAttributes = prop.GetCustomAttribute<ConvertValueAttribute<string,string>>();
                if (convertAttributes != null)
                {
                    field.Converter = convertAttributes.Converter;
                }

                field.Property = prop;
                //string name = attributes is not null ? attributes.SpoilerName : prop.Name;
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
                spoilerValue = item.Value.Converter?.Convert(spoilerValue) ?? spoilerValue;
               // string value  = GameOptionsDictionnary[spoilerName]?? string.Empty;
                this.GetType().GetProperty(item.Key.Replace(" ", string.Empty))?.SetValue(this, spoilerValue);
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
                string convertedValue = item.Value.Converter?.Convert(values) ?? string.Empty;
                this.GetType().GetProperty(item.Key.Replace(" ", string.Empty))?.SetValue(this, convertedValue);
            }
        }
    }
}
