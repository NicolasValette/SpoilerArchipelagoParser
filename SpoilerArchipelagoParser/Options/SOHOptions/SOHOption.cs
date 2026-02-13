using NoNiDev.SpoilerArchipelagoParser.Attributes;
using NoNiDev.SpoilerArchipelagoParser.Options.Converter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NoNiDev.SpoilerArchipelagoParser.Options.SOHOptions
{
    public class SOHOption : GameOptions
    {
        #region GREEN
        [NotParserValue]
        public string Goal
        {
            get => TriforceHunt ? "Triforce Hunt" : "Ganon";
            set;
        } = string.Empty;
        [SpoilerName("Triforce Hunt"), ConvertValue(typeof(StringToBool))]
        [JsonIgnore]
        public bool TriforceHunt { get; set; } = false;
        [SpoilerName("Triforce Hunt Pieces Total"), ConvertValue(typeof(StringToInt))]
        public int TriforcePieces { get; set; } = 0;
        [SpoilerName("Triforce Hunt Pieces Required Percentage"), ConvertValue(typeof(StringToInt))]
        public int TriforcePercentage { get; set; } = 0;
        public string Accessibility { get; set; } = string.Empty;
        [SpoilerName("Progression Balancing"), ConvertValue(typeof(StringToInt))]
        public int ProgressionBalancing { get; set; } = 50;
        #endregion
        /*
        #region DOORS
        public string Closed_Forest
        {
            get
            {
                if (field == "Open")
                    return "AAA";
                else
                    return "BBB";
            }
            set;
        } = string.Empty;
        [SpoilerName("Closed Forest"), ConvertValue<string, string>(typeof(ClosedForestToKokiri))]
        public string DekuTree { get; set; } = string.Empty;
        public string AAAAAAAAAA { get; set; } = string.Empty;
        [SpoilerName("Kakariko Gate")]
        public string KakarikoGate { get; set; } = string.Empty;
        public string Door_of_Time { get; set; } = string.Empty;
        public string Sleeping_Waterfall { get; set; } = string.Empty;
        public string Zoras_Domain { get; set; } = string.Empty;
        public string Jabu_Jabu { get; set; } = string.Empty;
        public string Lock_Overworld_Doors { get; set; } = string.Empty;
        #endregion
        #region CONDITIONS
        public string Starting_Age { get; set; } = string.Empty;
        public string Rainbow_Bridge { get; set; } = string.Empty;
        [ComboConverter<string>(["Rainbow Bridge",
            "Rainbow Bridge Stones Required", 
            "Rainbow Bridge Medallions Required", 
            "Rainbow Bridge Dungeon Rewards Required", 
            "Rainbow Bridge Dungeons Required", 
            "Rainbow Bridge Skull Tokens Required", 
            "Rainbow Bridge Greg Modifier"],
            typeof(RainbowBridgeComboConverter))]
        public string Rainbow_Bridge_Values { get; set; } = string.Empty;
        public string Skip_Ganons_Trials { get; set; } = string.Empty;

        public string Ganons_Castle_Boss_Key { get; set; } = string.Empty;
        [ComboConverter<string>(["Ganons Castle Boss Key",
            "Ganons Castle Boss Key Stones Required",
            "Ganons Castle Boss Key Medallions Required",
            "Ganons Castle Boss Key Dungeon Rewards Required",
            "Ganons Castle Boss Key Dungeons Required",
            "Ganons Castle Boss Key Skull Tokens Required",
            "Ganons Castle Boss Key Greg Wildcard"],
            typeof(GanonCastleBossKeyComboConverter))]
        public string Ganons_Castle_Boss_Key_Values { get; set; } = string.Empty;
        #endregion
        #region DUNGEONS
        public string Maps_And_Compasses { get; set; } = string.Empty;
        public string Bottom_of_the_Well_Keyring { get; set; } = string.Empty;
        public string Forest_Temple_Keyring { get; set; } = string.Empty;
        public string Fire_Temple_Keyring { get; set; } = string.Empty;
        public string Water_Temple_Keyring { get; set; } = string.Empty;
        public string Shadow_Temple_Keyring { get; set; } = string.Empty;
        public string Spirit_Temple_Keyring { get; set; } = string.Empty;
        public string Gerudo_Fortress_Keyring { get; set; } = string.Empty;
        public string Gerudo_Training_Ground_Keyring { get; set; } = string.Empty;
        public string Ganons_Castle_Keyring { get; set; } = string.Empty;
        public string Fortress_Carpenters { get; set; } = string.Empty;
        #endregion
        #region SANITY
        public string Shuffle_Master_Sword { get; set; } = string.Empty;
        public string Shuffle_Kokiri_Sword { get; set; } = string.Empty;
        public string Shuffle_Tokens { get; set; } = string.Empty;
        public string Shuffle_Freestanding_Items { get; set; } = string.Empty;
        public string Shuffle_Pots { get; set; } = string.Empty;
        public string Shuffle_Crates { get; set; } = string.Empty;
        public string Shuffle_Grass { get; set; } = string.Empty;
        public string Shuffle_Fish { get; set; } = string.Empty;
        public string Shuffle_Beehives { get; set; } = string.Empty;
        public string Shuffle_Cows { get; set; } = string.Empty;
        public string Shuffle_Trees { get; set; } = string.Empty;
        public string Shuffle_Boss_Souls { get; set; } = string.Empty;
        public string Shuffle_Frog_Song_Rupees { get; set; } = string.Empty;
        public string Shuffle_Ocarinas { get; set; } = string.Empty;
        public string Shuffle_Ocarina_Buttons { get; set; } = string.Empty;
        public string Shuffle_Fairies_in_Fountains { get; set; } = string.Empty;
        public string Shuffle_Gossip_Stone_Fairies { get; set; } = string.Empty;
        public string Shuffle_Bean_Fairies { get; set; } = string.Empty;
        public string Shuffle_Fairy_Spots { get; set; } = string.Empty;
        #endregion
        #region ITEMS
        public string Item_Pool { get; set; } = string.Empty;
        public string Shuffle_Childs_Wallet { get; set; } = string.Empty;
        public string Shuffle_Tycoon_Wallet { get; set; } = string.Empty;
        public string Shuffle_Swim { get; set; } = string.Empty;
        public string Shuffle_Deku_Nut_Bag { get; set; } = string.Empty;
        public string Shuffle_Bombchu_Bag { get; set; } = string.Empty;
        public string Shuffle_Weird_Egg { get; set; } = string.Empty;
        public string Shuffle_Adult_Trade_Items { get; set; } = string.Empty;
        public string Shuffle_Gerudo_Membership_Card { get; set; } = string.Empty;
        public string Shuffle_Fishing_Pole { get; set; } = string.Empty;
        public string Skeleton_Key { get; set; } = string.Empty;
        public string Rocs_Feather { get; set; } = string.Empty;
        public string Shuffle_Dungeon_Rewards { get; set; } = string.Empty;
        #endregion
        #region SHOPS
        public string Shuffle_Shops { get; set; } = string.Empty;
        public string Shuffle_Shops_Item_Amount { get; set; } = string.Empty;
        public string Shuffle_Scrubs { get; set; } = string.Empty;
        public string Shuffle_Merchants { get; set; } = string.Empty;
        #endregion
        #region SKIP&TRAPS
        public string Shuffle_100_GS_Reward { get; set; } = string.Empty;
        public string Skip_Child_Zelda { get; set; } = string.Empty;
        public string Skip_Epona_Race { get; set; } = string.Empty;
        public string Ice_Trap_Count { get; set; } = string.Empty;
        public string Ice_Trap_Filler_Replacement_Count { get; set; } = string.Empty;
        #endregion
        #region MISC
        public string Full_Wallets { get; set; } = string.Empty;
        public string Infinite_Upgrades { get; set; } = string.Empty;
        #endregion
        */
        public static string ConvertFromForestToDekuTreeColumn(string spoilerValue) => spoilerValue switch
        { 
            "on" => "Closed",
            "deku only" => "Open",
            "off" => "Open",
            _ => "unknown"
        };

        public SOHOption(Dictionary<string, string> opt)
        {
            GameOptionsDictionnary = opt;
        }
    }
}
