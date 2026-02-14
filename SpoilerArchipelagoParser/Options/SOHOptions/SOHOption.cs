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
        [SpoilerName("Triforce Hunt"), ConvertValue(typeof(YesNoToBool))]
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
        #region DOORS
        [JsonIgnore]
        public string ClosedForest
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
        [NotParserValue]
        [ConvertValue(typeof(ClosedForestToDekuTree))]
        public string DekuTree { get; set; } = string.Empty;
        [NotParserValue]
        [ConvertValue(typeof(ClosedForestToKokiri))]
        public string KokiriForest { get; set; } = string.Empty;
        [SpoilerName("Kakariko Gate")]
        public string KakarikoGate { get; set; } = string.Empty;
        [SpoilerName("Door of Time")]
        public string DoorOfTime { get; set; } = string.Empty;
        [SpoilerName("Sleeping Waterfall")]
        public string SleepingWaterfall { get; set; } = string.Empty;
        [SpoilerName("Zora's Domain")]
        public string ZorasDomain { get; set; } = string.Empty;
        [SpoilerName("Jabu-Jabu")]
        public string JabuJabu { get; set; } = string.Empty;
        [SpoilerName("Lock Overworld Doors")]
        public string LockOverworldDoors { get; set; } = string.Empty;
        #endregion
        #region CONDITIONS
        [SpoilerName("Starting Age")]
        public string StartingAge { get; set; } = string.Empty;
        [SpoilerName("Rainbow Bridge")]
        public string RainbowBridge { get; set; } = string.Empty;
        [ComboConverter<string>(["Rainbow Bridge",
            "Rainbow Bridge Stones Required", 
            "Rainbow Bridge Medallions Required", 
            "Rainbow Bridge Dungeon Rewards Required", 
            "Rainbow Bridge Dungeons Required", 
            "Rainbow Bridge Skull Tokens Required", 
            "Rainbow Bridge Greg Modifier"],
            typeof(RainbowBridgeComboConverter))]
        public string RainbowBridgeValues { get; set; } = string.Empty;
        [SpoilerName("Skip Ganon's Trials")]
        public string SkipGanonsTrials { get; set; } = string.Empty;
        [SpoilerName("Ganons Castle Boss Key")]
        public string GanonsCastleBossKey { get; set; } = string.Empty;
        [ComboConverter<string>(["Ganons Castle Boss Key",
            "Ganons Castle Boss Key Stones Required",
            "Ganons Castle Boss Key Medallions Required",
            "Ganons Castle Boss Key Dungeon Rewards Required",
            "Ganons Castle Boss Key Dungeons Required",
            "Ganons Castle Boss Key Skull Tokens Required",
            "Ganons Castle Boss Key Greg Wildcard"],
            typeof(GanonCastleBossKeyComboConverter))]
        public string GanonsCastleBossKeyValues { get; set; } = string.Empty;
        #endregion
        #region DUNGEONS
        [SpoilerName("Maps and Compasses")]
        public string MapsAndCompasses { get; set; } = string.Empty;
        [SpoilerName("Bottom of the Well Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool BottomOfTheWellKeyring { get; set; } = false;
        [SpoilerName("Forest Temple Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool ForestTempleKeyring { get; set; } = false;
        [SpoilerName("Fire Temple Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool FireTempleKeyring { get; set; } = false;
        [SpoilerName("Water Temple Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool WaterTempleKeyring { get; set; } = false;
        [SpoilerName("Shadow Temple Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool ShadowTempleKeyring { get; set; } = false;
        [SpoilerName("Spirit Temple Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool SpiritTempleKeyring { get; set; } = false;
        [SpoilerName("Gerudo Fortress Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool GerudoFortressKeyring { get; set; } = false;
        [SpoilerName("Gerudo Training Ground Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool GerudoTrainingGroundKeyring { get; set; } = false;
        [SpoilerName("Ganon's Castle Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool GanonsCastleKeyring { get; set; } = false;
        [SpoilerName("Fortress Carpenters")]
        public string FortressCarpenters { get; set; } = string.Empty;
        #endregion
        #region SANITY
        [SpoilerName("Shuffle Master Sword")]
        public string ShuffleMasterSword { get; set; } = string.Empty;
        [SpoilerName("Shuffle Kokiri Sword")]
        public string ShuffleKokiriSword { get; set; } = string.Empty;
        [SpoilerName("Shuffle Tokens")]
        public string ShuffleTokens { get; set; } = string.Empty;
        [SpoilerName("Shuffle Freestanding Items")]
        public string ShuffleFreestandingItems { get; set; } = string.Empty;
        [SpoilerName("Shuffle Pots")]
        public string ShufflePots { get; set; } = string.Empty;
        [SpoilerName("Shuffle Crates")]
        public string ShuffleCrates { get; set; } = string.Empty;
        [SpoilerName("Shuffle Grass")]
        public string ShuffleGrass { get; set; } = string.Empty;
        [SpoilerName("Shuffle Fish")]
        public string ShuffleFish { get; set; } = string.Empty;
        [SpoilerName("Shuffle Beehives"), ConvertValue(typeof(YesNoToBool))]
        public bool ShuffleBeehives { get; set; } = false;
        [SpoilerName("Shuffle Cows"), ConvertValue(typeof(YesNoToBool))]
        public bool ShuffleCows { get; set; } = false;
        [SpoilerName("Shuffle Trees"), ConvertValue(typeof(YesNoToBool))]
        public bool ShuffleTrees { get; set; } = false;
        [SpoilerName("Shuffle Boss Souls")]
        public string ShuffleBossSouls { get; set; } = string.Empty;
        [SpoilerName("Shuffle Frog Song Rupees"), ConvertValue(typeof(YesNoToBool))]
        public bool ShuffleFrogSongRupees { get; set; } = false;
        [SpoilerName("Shuffle Ocarinas")]
        public string ShuffleOcarinas { get; set; } = string.Empty;
        [SpoilerName("Shuffle Ocarina Buttons"), ConvertValue(typeof(YesNoToBool))]
        public bool ShuffleOcarinaButtons { get; set; } = false;
        [SpoilerName("Shuffle Fairies in Fountains"), ConvertValue(typeof(YesNoToBool))]
        public bool ShuffleFairiesinFountains { get; set; } = false;
        [SpoilerName("Shuffle Gossip Stone Fairies"), ConvertValue(typeof(YesNoToBool))]
        public bool ShuffleGossipStoneFairies { get; set; } = false;
        [SpoilerName("Shuffle Bean Fairies"), ConvertValue(typeof(YesNoToBool))]
        public bool ShuffleBeanFairies { get; set; } = false;
        [SpoilerName("Shuffle Fairy Spots"), ConvertValue(typeof(YesNoToBool))]
        public bool ShuffleFairySpots { get; set; } = false;
        #endregion
        #region ITEMS
        [SpoilerName("Item Pool")]
        public string ItemPool { get; set; } = string.Empty;
        [SpoilerName("Shuffle Child's Wallet")]
        public string ShuffleChildsWallet { get; set; } = string.Empty;
        [SpoilerName("Shuffle Tycoon Wallet")]
        public string ShuffleTycoonWallet { get; set; } = string.Empty;
        [SpoilerName("Shuffle Swim")]
        public string ShuffleSwim { get; set; } = string.Empty;
        [SpoilerName("Shuffle Deku Nut Bag")]
        public string ShuffleDekuNutBag { get; set; } = string.Empty;
        [SpoilerName("Bombchu Bag")]
        public string ShuffleBombchuBag { get; set; } = string.Empty;
        [SpoilerName("Shuffle Weird Egg")]
        public string ShuffleWeirdEgg { get; set; } = string.Empty;
        [SpoilerName("Shuffle Adult Trade Items")] 
        public string ShuffleAdultTradeItems { get; set; } = string.Empty;
        [SpoilerName("Shuffle Gerudo Membership Card")] 
        public string ShuffleGerudoMembershipCard { get; set; } = string.Empty;
        [SpoilerName("Shuffle Fishing Pole")] 
        public string ShuffleFishingPole { get; set; } = string.Empty;
        [SpoilerName("Skeleton Key")] 
        public string SkeletonKey { get; set; } = string.Empty;
        [SpoilerName("Roc's Feather")] 
        public string RocsFeather { get; set; } = string.Empty;
        [SpoilerName("Shuffle Dungeon Rewards")] 
        public string ShuffleDungeonRewards { get; set; } = string.Empty;
        #endregion
        #region SHOPS
        [SpoilerName("Shuffle Shops"), ConvertValue(typeof(YesNoToBool))] 
        public bool ShuffleShops { get; set; } = false;
        [SpoilerName("Shuffle Shops Item Amount")] 
        public string ShuffleShopsItemAmount { get; set; } = string.Empty;
        [SpoilerName("Shuffle Scrubs")] 
        public string ShuffleScrubs { get; set; } = string.Empty;
        [SpoilerName("Shuffle Merchants")] 
        public string ShuffleMerchants { get; set; } = string.Empty;
        #endregion
        #region SKIP&TRAPS
        [SpoilerName("Shuffle 100 GS Reward"), ConvertValue(typeof(YesNoToBool))] 
        public bool Shuffle100GSReward { get; set; } = false;
        [SpoilerName("Skip Child Zelda"), ConvertValue(typeof(YesNoToBool))] 
        public bool SkipChildZelda { get; set; } = false;
        [SpoilerName("Skip Epona Race"), ConvertValue(typeof(YesNoToBool))] 
        public bool SkipEponaRace { get; set; } = false;
        [SpoilerName("Ice Trap Count"), ConvertValue(typeof(StringToInt))] 
        public int IceTrapCount { get; set; } = 0;
        [SpoilerName("Ice Trap Filler Replacement Count"), ConvertValue(typeof(StringToInt))] 
        public int IceTrapFillerReplacementCount { get; set; } = 0;
        #endregion
        
        #region MISC
        [SpoilerName("Full Wallets"), ConvertValue(typeof(YesNoToBool))] 
        public bool FullWallets { get; set; } = false;
        [SpoilerName("Infinite Upgrades")] 
        public string InfiniteUpgrades { get; set; } = string.Empty;
        #endregion
        
        public static string ConvertFromForestToDekuTreeColumn(string spoilerValue) => spoilerValue switch
        { 
            "on" => "Closed",
            "deku only" => "Open",
            "off" => "Open",
            _=> "unknown"
        };

        public SOHOption(Dictionary<string, string> opt)
        {
            GameOptionsDictionnary = opt;
        }
    }
}
