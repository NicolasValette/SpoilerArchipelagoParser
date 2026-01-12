using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NoNiDev.SpoilerArchipelagoParser.SOHOptions
{
    public class SOHPlayerOptions
    {
        [JsonPropertyName("joueur")]
        public string PlayerName { get; init; }
        [JsonIgnore]
        public Dictionary<string, string> Options { get; init; }
        public string Goal { get; init; }
        public int TriforcePieces { get; init; }
        public string Accessibility { get; init; }
        #region World Doors
        /*
        public string KokiriForest { get; init; }
        public string DekuTree { get; init; }
        public string DoorOfTime { get; init; }
        public string ZoraFountain { get; init; }
        public string JabuJabuMouth { get; init; }
        public string OverworldsDoors { get; init; }
        #endregion
        #region Game Requirements
        public string StartAge { get; init; }
        public string RainbowBridgeCondition { get; init; }
        public int RainbowBridgeValue { get; init; }
        public string GanonTrials { get; init; }
        public string GanonBossKeyCondition { get; init; }
        public int GanonBossKeyValue { get; init; }
        #endregion
        #region Dungeons
        public bool DungeonKeyRings { get; init; }
        public string MapAndCompasses { get; init; }
        public string FortressCarpenters { get; init; }
        #endregion
        #region Sanity
        public string Mastersanity { get; init; }
        public string Tokensanity { get; init; }
        public string Freestandingsanity { get; init; }
        public string Cratesanity { get; init; }
        public string Grasssanity { get; init; }
        public string Scrubsanity { get; init; }
        public string Fishsanity { get; init; }
        public string Beehivesanity { get; init; }
        public string Cowsanity { get; init; }
        public string Treesanity { get; init; }
        public string Bosssanity { get; init; }
        public string Merchantsanity { get; init; }
        public string Frogsanit { get; init; }
        public string Ocarinasanity { get; init; }
        public string FairysanityFountains { get; init; }
        public string FairysanityStones { get; init; }
        public string FairysanityBeans { get; init; }
        public string FairysanitySongs { get; init; }
        #endregion
        #region Items
        */
        #endregion
        public SOHPlayerOptions(string playerName, Dictionary<string, string> options)
        {
            PlayerName = playerName; Options = options;

            if (string.Compare(options["Triforce Hunt"],"Yes", true) == 0)
            {
                Goal = "Triforce Hunt"; 
            }
            else
            {
                Goal = "Ganon";
            }
            TriforcePieces = int.Parse(options["Triforce Hunt Pieces Total"]);
            Accessibility = options["Accessibility"];
        }
    }
}
