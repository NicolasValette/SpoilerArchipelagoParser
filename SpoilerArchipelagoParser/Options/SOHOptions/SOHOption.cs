using NoNiDev.SpoilerArchipelagoParser.Attributes;
using NoNiDev.SpoilerArchipelagoParser.Enums;
using NoNiDev.SpoilerArchipelagoParser.Options.Converter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NoNiDev.SpoilerArchipelagoParser.Options.SOHOptions
{
    [Game(gameName:"Ship of Harkinian", version:"1.2.0")]
    public class SOHOption : GameOptions
    {
       
        #region PLAYER
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
        public int TriforcePercent { get; set; } = 0;
        [RestrictEnumValues<EAccessibility>]
        public string Accessibility { get; set; } = string.Empty;
        [SpoilerName("Progression Balancing"), ConvertValue(typeof(StringToInt))]
        public int ProgressionBalancing { get; set; } = 50;
        #endregion
        #region DOORS
        [SpoilerName("Closed Forest"), RestrictEnumValues<EForestOpenClosed>]
        [JsonIgnore]
        public string ClosedForest { get; set; } = string.Empty;
        //[NotParserValue]
        [SpoilerName("Closed Forest"), ConvertValue(typeof(ClosedForestToDekuTree))]
        public string DekuTree { get; set; } = string.Empty;
        [SpoilerName("Closed Forest"), ConvertValue(typeof(ClosedForestToKokiri))]
        public string KokiriForest { get; set; } = string.Empty;
        [SpoilerName("Kakariko Gate"), RestrictEnumValues<EOpenClosed>]
        public string KakarikoGate { get; set; } = string.Empty;
        [SpoilerName("Door of Time"), RestrictEnumValues<EDoorOfTime>]
        public string DoorOfTime { get; set; } = string.Empty;
        [SpoilerName("Sleeping Waterfall"), RestrictEnumValues<EOpenClosed>]
        public string SleepingWaterfall { get; set; } = string.Empty;
        [SpoilerName("Zora's Domain"), RestrictEnumValues<EOpenClosedClosedAsChild>, ConvertValue(typeof(ZoraFountainCoverter))]
        public string ZoraFountain { get; set; } = string.Empty;
        [SpoilerName("Jabu-Jabu"), RestrictEnumValues<EOpenClosed>]
        public string JabuJabuMouth { get; set; } = string.Empty;
        [SpoilerName("Lock Overworld Doors"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(LockOverworldConverter))]
        public string OverworldDoors { get; set; } = string.Empty;
        #endregion
        #region GANON
        [SpoilerName("Starting Age"), RestrictEnumValues<EStartingAge>]
        public string StartAge { get; set; } = string.Empty;
        [SpoilerName("Rainbow Bridge"), RestrictEnumValues<EBridgeCondition>, ConvertValue(typeof(RainbowBridgeConditionCoverter))]
        public string RainbowBridgeCondition { get; set; } = string.Empty;
        [ComboConverter<int>(["Rainbow Bridge",
            "Rainbow Bridge Stones Required", 
            "Rainbow Bridge Medallions Required", 
            "Rainbow Bridge Dungeon Rewards Required", 
            "Rainbow Bridge Dungeons Required", 
            "Rainbow Bridge Skull Tokens Required"],
            typeof(RainbowBridgeComboConverter))]
        public int RainbowBridgeValue { get; set; } = 0;
        [SpoilerName("Rainbow Bridge Greg Modifier"), ConvertValue(typeof(GregConverter))]
        public string RainbowBridgeGregModifier { get; set; } = string.Empty;
        [SpoilerName("Skip Ganon's Trials"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(SkipTrialsConverter))]
        public string GanonTrials { get; set; } = string.Empty;
        [SpoilerName("Ganons Castle Boss Key"), RestrictEnumValues<EBossKeyCondition>, ConvertValue(typeof(GanonBossKeyConditionConverter))]
        public string GanonBossKeyCondition { get; set; } = string.Empty;
        [ComboConverter<int>(["Ganons Castle Boss Key",
            "Ganons Castle Boss Key Stones Required",
            "Ganons Castle Boss Key Medallions Required",
            "Ganons Castle Boss Key Dungeon Rewards Required",
            "Ganons Castle Boss Key Dungeons Required",
            "Ganons Castle Boss Key Skull Tokens Required"],
            typeof(GanonCastleBossKeyComboConverter))]
        public int GanonBossKeyValue { get; set; } = 0;
        [SpoilerName("Ganons Castle Boss Key Greg Wildcard"), ConvertValue(typeof(GregConverter))]
        public string GanonBossKeyGregModifier { get; set; } = string.Empty;
        #endregion
        #region DUNGEONS
        [SpoilerName("Maps and Compasses"), RestrictEnumValues<EMapAndCompass>]
        public string MapsAndCompasses { get; set; } = string.Empty;
        [SpoilerName("Bottom of the Well Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool BottomOfTheWellKeyrings { get; set; } = false;
        [SpoilerName("Forest Temple Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool ForestTempleKeyrings { get; set; } = false;
        [SpoilerName("Fire Temple Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool FireTempleKeyrings { get; set; } = false;
        [SpoilerName("Water Temple Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool WaterTempleKeyrings { get; set; } = false;
        [SpoilerName("Shadow Temple Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool ShadowTempleKeyrings { get; set; } = false;
        [SpoilerName("Spirit Temple Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool SpiritTempleKeyrings { get; set; } = false;
        [SpoilerName("Gerudo Fortress Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool GerudoFortressKeyrings { get; set; } = false;
        [SpoilerName("Gerudo Training Ground Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool GerudoTrainingGroundsKeyrings { get; set; } = false;
        [SpoilerName("Ganon's Castle Keyring"), ConvertValue(typeof(YesNoToBool))]
        public bool GanonsCastleKeyrings { get; set; } = false;
        [SpoilerName("Fortress Carpenters"), RestrictEnumValues<ECarpenters>, ConvertValue(typeof(CarpentersConverter))]
        public string FortressCarpenters { get; set; } = string.Empty;
        #endregion
        #region SANITY
        [SpoilerName("Shuffle Master Sword"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToVanillaShuffled))]
        public string MasterSwordSanity { get; set; } = string.Empty;
        [SpoilerName("Shuffle Kokiri Sword"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToVanillaShuffled))]
        public string KokiriSwordSanity { get; set; } = string.Empty;
        [SpoilerName("Shuffle Tokens"), RestrictEnumValues<ELocationSanity>, ConvertValue(typeof(LocationConverter))]
        public string Tokensanity { get; set; } = string.Empty;
        [SpoilerName("Shuffle Freestanding Items"), RestrictEnumValues<ELocationSanity>, ConvertValue(typeof(LocationConverter))]
        public string Freestandingsanity { get; set; } = string.Empty;
        [SpoilerName("Shuffle Pots"), RestrictEnumValues<ELocationSanity>, ConvertValue(typeof(LocationConverter))]
        public string Potsanity { get; set; } = string.Empty;
        [SpoilerName("Shuffle Crates"), RestrictEnumValues<ELocationSanity>, ConvertValue(typeof(LocationConverter))]
        public string Cratesanity { get; set; } = string.Empty;
        [SpoilerName("Shuffle Grass"), RestrictEnumValues<ELocationSanity>, ConvertValue(typeof(LocationConverter))]
        public string Grasssanity { get; set; } = string.Empty;
        [SpoilerName("Shuffle Fish"), RestrictEnumValues<EFishSanity>, ConvertValue(typeof(LocationConverter))]
        public string Fishsanity { get; set; } = string.Empty;
        [SpoilerName("Shuffle Beehives"), ConvertValue(typeof(YesNoToBool))]
        public bool Beehivesanity { get; set; } = false;
        [SpoilerName("Shuffle Cows"), ConvertValue(typeof(YesNoToBool))]
        public bool Cowsanity { get; set; } = false;
        [SpoilerName("Shuffle Trees"), ConvertValue(typeof(YesNoToBool))]
        public bool Treesanity { get; set; } = false;
        [SpoilerName("Shuffle Boss Souls"), RestrictEnumValues<EBossSanity>, ConvertValue(typeof(BossSoulsConverter))]
        public string BossSoulSanity { get; set; } = string.Empty;
        [SpoilerName("Shuffle Frog Song Rupees"), ConvertValue(typeof(YesNoToBool))]
        public bool Frogsanity { get; set; } = false;
        [SpoilerName("Shuffle Ocarinas"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToVanillaShuffled))]
        public string Ocarinasanity { get; set; } = string.Empty;
        [SpoilerName("Shuffle Ocarina Buttons"), ConvertValue(typeof(YesNoToBool))]
        public bool OcarinaButtonSanity { get; set; } = false;
        [SpoilerName("Shuffle Fairies in Fountains"), ConvertValue(typeof(YesNoToBool))]
        public bool FairysanityFountains { get; set; } = false;
        [SpoilerName("Shuffle Gossip Stone Fairies"), ConvertValue(typeof(YesNoToBool))]
        public bool FairysanityStones { get; set; } = false;
        [SpoilerName("Shuffle Bean Fairies"), ConvertValue(typeof(YesNoToBool))]
        public bool FairysanityBeans { get; set; } = false;
        [SpoilerName("Shuffle Fairy Spots"), ConvertValue(typeof(YesNoToBool))]
        public bool FairysanitySongs { get; set; } = false;
        #endregion
        #region POOL
        [JsonPropertyName("poolBalancing")]
        [SpoilerName("Item Pool"), RestrictEnumValues<EItemPool>]
        public string ItemPool { get; set; } = string.Empty;
        [SpoilerName("Shuffle Child's Wallet"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToStartWithShuffled))]
        public string ChildWallet { get; set; } = string.Empty;
        [SpoilerName("Shuffle Tycoon Wallet"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToAddedWithout))]
        public string TycoonWallet { get; set; } = string.Empty;
        [SpoilerName("Shuffle Swim"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToStartWithShuffled))]
        public string BronzeScale { get; set; } = string.Empty;
        [SpoilerName("Shuffle Deku Stick Bag"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToStartWithShuffled))]
        public string StickBag { get; set; } = string.Empty;
        [SpoilerName("Shuffle Deku Nut Bag"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToStartWithShuffled))]
        public string NutBag { get; set; } = string.Empty;
        [SpoilerName("Bombchu Bag"), RestrictEnumValues<EBombchuBag>, ConvertValue(typeof(BombchuBagConverter))]
        public string BombchuBag { get; set; } = string.Empty;
        [SpoilerName("Shuffle Weird Egg"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToVanillaShuffled))]
        public string WeirdEgg { get; set; } = string.Empty;
        [SpoilerName("Shuffle Adult Trade Items"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(AdultTradeConverter))] 
        public string AdultTrade { get; set; } = string.Empty;
        [SpoilerName("Shuffle Gerudo Membership Card"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToVanillaShuffled))] 
        public string GerudoCard { get; set; } = string.Empty;
        [SpoilerName("Shuffle Fishing Pole"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToStartWithShuffled))] 
        public string FishingPole { get; set; } = string.Empty;
        [SpoilerName("Skeleton Key"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToAddedWithout))] 
        public string SkeletonKey { get; set; } = string.Empty;
        [SpoilerName("Roc's Feather"), RestrictEnumValues<EYesNo>, ConvertValue(typeof(YesNoToAddedWithout))] 
        public string RocsFeather { get; set; } = string.Empty;
        [SpoilerName("Shuffle Dungeon Rewards")] 
        public string DungeonRewards { get; set; } = string.Empty;
        #endregion
        #region SHOPS
        [SpoilerName("Shuffle Shops"), ConvertValue(typeof(YesNoToBool))] 
        public bool ShuffleShops { get; set; } = false;
        [SpoilerName("Shuffle Shops Item Amount"), ConvertValue(typeof(StringToInt))] 
        public int ShuffleShopsItems { get; set; } = 0;
        [SpoilerName("Shuffle Scrubs"), ConvertValue(typeof(ScrubsCoverter))] 
        public string ShuffleScrubs { get; set; } = string.Empty;
        [SpoilerName("Shuffle Merchants"), RestrictEnumValues<EMerchantSanity>, ConvertValue(typeof(MerchantConverter))] 
        public string ShuffleMerchants { get; set; } = string.Empty;
        #endregion
        #region EXTRA
        [SpoilerName("Shuffle 100 GS Reward"), ConvertValue(typeof(YesNoToBool))] 
        public bool Token100 { get; set; } = false;
        [SpoilerName("Skip Child Zelda"), ConvertValue(typeof(YesNoToBool))] 
        public bool SkipChildZelda { get; set; } = false;
        [SpoilerName("Skip Epona Race"), ConvertValue(typeof(YesNoToBool))] 
        public bool SkipEponaRace { get; set; } = false;
        [SpoilerName("Ice Trap Count"), ConvertValue(typeof(StringToInt))] 
        public int IceTrapsCount { get; set; } = 0;
        [SpoilerName("Ice Trap Filler Replacement Count"), ConvertValue(typeof(StringToInt))] 
        public int IceTrapsPercent { get; set; } = 0;
        #endregion
        #region QOL
        [SpoilerName("Full Wallets"), ConvertValue(typeof(YesNoToBool))] 
        public bool FullWallets { get; set; } = false;
        [SpoilerName("Infinite Upgrades"), RestrictEnumValues<EInfiniteUpgrade>, ConvertValue(typeof(InfiniteUpgradesConverter))] 
        public string InfiniteUpgrades { get; set; } = string.Empty;
        #endregion
        public static string ConvertFromForestToDekuTreeColumn(string spoilerValue) => spoilerValue switch
        { 
            "on" => "Closed",
            "deku only" => "Open",
            "off" => "Open",
            _=> "unknown"
        };
        public SOHOption(string name, Dictionary<string, string> opt) : base(name, opt)
        {
        }

    }
}
