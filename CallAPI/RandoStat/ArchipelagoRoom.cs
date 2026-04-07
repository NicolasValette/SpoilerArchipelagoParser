using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NoNiDev.CallAPI.RandoStat
{
    public enum State
    {
        Finie,
        EnCours,
        Release
    }
    public class ArchipelagoRoom
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
        [JsonPropertyName("nbJoueurs")]
        public int PlayerNumber { get; set; }
        [JsonPropertyName("nbJeux")]
        public int GameNumber { get; set; }
        [JsonPropertyName("etat")]
        public string ArchipelagoStateString 
        { 
            get
            {
                return ArchState.ToString();
            }
            set
            {
                ArchState = value switch
                {
                    "Finie" => State.Finie,
                    "Release" => State.Release,
                    _ => State.EnCours,
                };
                ;
            }
        }
        [JsonIgnore]
        public State ArchState { get; set; }
        [JsonPropertyName("checks")]
        public int CheckNumber { get; set; }
    }
}
