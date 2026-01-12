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
        public string PlayerName { get; set; }
        [JsonIgnore]
        public Dictionary<string, string> Options { get; init; }
        public string Goal { get; init; }
        public int TriforcePieces { get; init; }
        public string Accessibility { get; init; }
        #region World Doors
        
        public string KokiriForest { get; init; }
        public string DekuTree { get; init; }
        public string DoorOfTime { get; init; }
        public string ZoraFountain { get; init; }
        public string JabuJabuMouth { get; init; }
        public string OverworldsDoors { get; init; }
        public string SleepingWaterfall { get; set; }
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
        public string ChildWallet { get; init; }
        public string BronzeScale { get; init; }
        public string StickBag { get; init; }
        public string NutBag { get; init; }
        public string BombchuBag { get; init; }
        public string WeirdEgg { get; init; }
        public string AdultTrade { get; init; }
        public string FishingPole { get; init; }
        public string SkeletonKey { get; init; }
        public string DungeaonRewards { get; init; }
        #endregion
        #region Shops
        public string ShuffleShops { get; init; }
        public int ShuffleShopsItemCount { get; init; }
        public int ShuffleShopMinPrice { get; init; }
        public int ShuffleShopsMaxPrice { get; init; }
        public int ScrubMinPrice { get; init; }
        public int ScrubMaxPrice { get; init; }
        #endregion
        [JsonPropertyName("100tokens")]
        public bool HundredTokens { get; init; }
        public bool SkipChildZelda { get; init; }
        public bool SkipMaskQuest { get; init; }
        public bool SkipEponaRace { get; init; }
        public int BigPoeCount { get; init; }
        public string IceTrapsCondition { get; init; }
        public int IceTrapsValue { get; init; }
        public bool BlueFireArrows { get; init; }
        public bool SunlightArrows { get; init; }
        public bool FullWallets { get; init; }
        public string InfiniteUpgrades { get; init; }
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

            if (string.Compare(options["Closed Forest"], "on", true) == 0)
            {
                KokiriForest = "Closed";
                DekuTree = "Closed";

            }
            else if (string.Compare(options["Closed Forest"], "deku_only", true) == 0)
            {
                KokiriForest = "Open";
                DekuTree = "Closed";
            }
            else
            {
                KokiriForest = "Open";
                DekuTree = "Open";
            }
            DoorOfTime = options["Door of Time"];
            ZoraFountain = options["Zora's Domain"];
            JabuJabuMouth = options["Jabu-Jabu"];
            OverworldsDoors = options["Lock Overworld Doors"];
            SleepingWaterfall = options["Sleeping Waterfall"];

            StartAge = options["Starting Age"];
            if (string.Compare(options["Rainbow Bridge"], "vanilla", true) == 0)
            {
                RainbowBridgeCondition = "Vanilla";
                RainbowBridgeValue = 0;
            }
            else if (string.Compare(options["Rainbow Bridge"], "always_open", true) == 0)
            {
                RainbowBridgeCondition = "Open";
                RainbowBridgeValue = 0;
            }
            else if (string.Compare(options["Rainbow Bridge"], "stones", true) == 0)
            {
                RainbowBridgeCondition = "Stones";
                RainbowBridgeValue = int.Parse(options["Rainbow Bridge Stones Required"]);
            }
            else if (string.Compare(options["Rainbow Bridge"], "medallions", true) == 0)
            {
                RainbowBridgeCondition = "Medallions";
                RainbowBridgeValue = int.Parse(options["Rainbow Bridge Medallions Required"]);
            }
            else if (string.Compare(options["Rainbow Bridge"], "dungeon_rewards", true) == 0)
            {
                RainbowBridgeCondition = "Rewards";
                RainbowBridgeValue = int.Parse(options["Rainbow Bridge Dungeon Rewards Required"]);
            }
            else if (string.Compare(options["Rainbow Bridge"], "dungeons", true) == 0)
            {
                RainbowBridgeCondition = "Dungeons";
                RainbowBridgeValue = int.Parse(options["Rainbow Bridge Dungeons Required"]);
            }
            else if (string.Compare(options["Rainbow Bridge"], "tokens", true) == 0)
            {
                RainbowBridgeCondition = "Tokens";
                RainbowBridgeValue = int.Parse(options["Rainbow Bridge Skull Tokens Required"]);
            }
            else if (string.Compare(options["Rainbow Bridge"], "greg", true) == 0)
            {
                RainbowBridgeCondition = "Greg";
                RainbowBridgeValue = 0;
            }
            
            if (string.Compare(options["Ganons Castle Boss Key"], "vanilla", true) == 0)
            {
                GanonBossKeyCondition = "Vanilla";
                GanonBossKeyValue = 0;
            }
            else if (string.Compare(options["Ganons Castle Boss Key"], "anywhere", true) == 0)
            {
                GanonBossKeyCondition = "Anywhere";
                GanonBossKeyValue = 0;
            }
            else if (string.Compare(options["Ganons Castle Boss Key"], "lacs_vanilla", true) == 0)
            {
                GanonBossKeyCondition = "LACS Vanilla";
                GanonBossKeyValue = 2;
            }
            else if (string.Compare(options["Ganons Castle Boss Key"], "lacs_stones", true) == 0)
            {
                GanonBossKeyCondition = "LACS Stones";
                GanonBossKeyValue = int.Parse(options["Ganons Castle Boss Key Stones Required"]);
            }
            else if (string.Compare(options["Ganons Castle Boss Key"], "lacs_medallions", true) == 0)
            {
                GanonBossKeyCondition = "LACS Medallions";
                GanonBossKeyValue = int.Parse(options["Ganons Castle Boss Key Medallions Required"]);
            }
            else if (string.Compare(options["Ganons Castle Boss Key"], "lacs_dungeon_rewards", true) == 0)
            {
                GanonBossKeyCondition = "LACS Rewards";
                GanonBossKeyValue = int.Parse(options["Ganons Castle Boss Key Dungeon Rewards Required"]);
            }
            else if (string.Compare(options["Ganons Castle Boss Key"], "lacs_dungeons", true) == 0)
            {
                GanonBossKeyCondition = "LACS Dungeons";
                GanonBossKeyValue = int.Parse(options["Ganons Castle Boss Key Dungeons Required"]);
            }
            else if (string.Compare(options["Ganons Castle Boss Key"], "lacs_skull_tokens", true) == 0)
            {
                GanonBossKeyCondition = "LACS Tokens";
                GanonBossKeyValue = int.Parse(options["Ganons Castle Boss Key Skull Tokens Required"]);
            }
            GanonTrials = options["Skip Ganon's Trials"];

            DungeonKeyRings         = string.Compare(options["Key Rings"], "yes", true) == 0?true:false;
            MapAndCompasses         = options["Maps and Compasses"];
            FortressCarpenters      = options["Fortress Carpenters"];

            Mastersanity            = options["Shuffle Master Sword"];
            Tokensanity             = options["Shuffle Tokens"];
            Freestandingsanity      = options["Shuffle Freestanding Items"];
            Cratesanity             = options["Shuffle Crates"];
            Grasssanity             = options["Shuffle Grass"];
            Scrubsanity             = options["Shuffle Scrubs"];
            Fishsanity              = options["Shuffle Fish"];
            Beehivesanity           = options["Shuffle Beehives"];
            Cowsanity               = options["Shuffle Cows"];
            Treesanity              = options["Shuffle Trees"];
            Bosssanity              = options["Shuffle Boss Souls"];
            Merchantsanity          = options["Shuffle Merchants"];
            Frogsanit               = options["Shuffle Frog Song Rupees"];
            Ocarinasanity           = options["Shuffle Ocarina Buttons"];
            FairysanityFountains    = options["Shuffle Fairies in Fountains"];
            FairysanityStones       = options["Shuffle Gossip Stone Fairies"];
            FairysanityBeans        = options["Shuffle Bean Fairies"];
            FairysanitySongs        = options["Shuffle Fairy Spots"];

            ChildWallet             = options["Shuffle Child's Wallet"];
            BronzeScale             = options["Shuffle Swim"];
            StickBag                = options["Shuffle Deku Stick Bag"];
            NutBag                  = options["Shuffle Deku Nut Bag"];
            BombchuBag              = options["Bombchu Bag"];
            WeirdEgg                = options["Shuffle Weird Egg"];
            AdultTrade              = options["Shuffle Adult Trade Items"];
            FishingPole             = options["Shuffle Fishing Pole"];
            SkeletonKey             = options["Skeleton Key"];
            DungeaonRewards         = options["Shuffle Dungeon Rewards"];

            ShuffleShops            = options["Shuffle Shops"];
            ShuffleShopsItemCount   = int.Parse(options["Shuffle Shops Item Amount"]);
            ShuffleShopMinPrice     = int.Parse(options["Shuffle Shops Minimum Price"]);
            ShuffleShopsMaxPrice    = int.Parse(options["Shuffle Shops Maximum Price"]);
            ScrubMinPrice           = int.Parse(options["Shuffle Scrubs Minimum Price"]);
            ScrubMaxPrice           = int.Parse(options["Shuffle Scrubs Maximum Price"]);

            HundredTokens           = options["Shuffle 100 GS Reward"] == "Yes";
            SkipChildZelda          = options["Skip Child Zelda"] == "Yes";
            SkipMaskQuest           = options["Complete Mask Quest"] == "Yes";
            SkipEponaRace           = options["Skip Epona Race"] == "Yes";
            BigPoeCount             = int.Parse(options["Big Poe Target Count"]);
            IceTrapsCondition       = options["Ice Trap Count"];
            IceTrapsValue           = int.Parse(options["Ice Trap Filler Replacement Count"]);
            BlueFireArrows          = options["Blue Fire Arrows"] == "Yes";
            SunlightArrows          = options["Sunlight Arrows"] == "Yes";
            FullWallets             = options["Full Wallets"] == "Yes";
            InfiniteUpgrades        = options["Infinite Upgrades"];
        }
}
}
