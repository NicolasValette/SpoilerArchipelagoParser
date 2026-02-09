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
        public DateTime Date { get; set; }
        [JsonIgnore]
        public Dictionary<string, string> GameOptionsDictionnary { get; protected set; } = [];
        public Dictionary<string, Field> Prop { get; protected set; } = [];

        public GameOptions()
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                var attributes = prop.GetCustomAttribute<SpoilerNameAttribute>();
                if (attributes != null)
                {
                    string n = attributes.SpoilerName;
                }
                string name = attributes is not null ? attributes.SpoilerName : prop.Name;
                Prop.Add(name, new Field { Property = prop, SpoilerName = name, IsValid = () => true });
            }
        }
        public void Process()
        {
            foreach (var item in GameOptionsDictionnary)
            {
                this.GetType().GetProperty(item.Key.Replace(" ", string.Empty))?.SetValue(this, item.Value);
            }
        }

    }
}
