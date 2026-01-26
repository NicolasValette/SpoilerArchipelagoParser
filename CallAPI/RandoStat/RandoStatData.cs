using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using NoNiDev.SpoilerArchipelagoParser.RandoStats;

namespace NoNiDev.CallAPI.RandoStat
{
    public enum RandoStatAction
    {
       addJoueur,
       AddJeu,
       addArchipel,
       ping
    }

    public class RandoStatDataGeneric
    {
        [JsonIgnore]
        public RandoStatAction Action { get; set; }
        [JsonPropertyName("action")]
        public string ActionStr => Action.ToString();
        public PayloadGeneric Payload { get; set; }
    }
    public class PayloadGeneric
    {
        public string Name { get; set; }
    }

    public class RandoStatData
    {
        [JsonIgnore]
        public RandoStatAction Action { get; set; }
        [JsonPropertyName("action")]
        public string ActionStr => Action.ToString();
        public PayloadAddArchipel Payload { get; set; }
    }
    public class PayloadAddArchipel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        [JsonPropertyName("games")]
        public List<ArchippelagoSlot> Slots { get; set; }
    }
}
