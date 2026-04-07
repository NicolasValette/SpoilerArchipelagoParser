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
       addJeu,
       addArchipel,
       editArchipel,
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
        public RandoStatPayload Payload { get; set; }
    }

    [JsonDerivedType(typeof(RandoStatPayload), "base")]
    [JsonDerivedType(typeof(PayloadAddArchipel), "add_archipel")]
    [JsonDerivedType(typeof(PayloadEditArchipel), "edit_archipel")]
    public class RandoStatPayload
    {
        public string Name { get; set; }
    }
    public class PayloadAddArchipel : RandoStatPayload
    {
        public string Url { get; set; }
        [JsonPropertyName("games")]
        public List<ArchippelagoSlot> Slots { get; set; }
    }
    public class PayloadEditArchipel : RandoStatPayload
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Etat { get; set; }
    }
}
