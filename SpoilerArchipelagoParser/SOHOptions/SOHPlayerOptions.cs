using NoNiDev.SpoilerArchipelagoParser.Attributes;
using NoNiDev.SpoilerArchipelagoParser.Enums;
using System.Text.Json.Serialization;

namespace NoNiDev.SpoilerArchipelagoParser.SOHOptions
{
    public class SOHPlayerOptions
    {
        [JsonPropertyName("joueur")]
        public string PlayerName { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public Dictionary<string, string> Options { get; init; }
        public string Goal { get; init; }
        public int TriforcePieces { get; init; }
        public int TriforcePercent { get; init; }
        public string Accessibility { get; init; }
        public string ItemPool { get; init; }
        #region Doors

        public string KokiriForest { get; init; }
        public string DekuTree { get; init; }
        public string KakarikoGate { get; set; }
        public string DoorOfTime { get; init; }
        public string ZoraFountain { get; init; }
        public string JabuJabuMouth { get; init; }
        public string OverworldDoors { get; init; }
        [RestrictValues(typeof(EOpenClosed))]
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

        public string MapsAndCompassesNew { get; init; }
        public string FortressCarpenters { get; init; }
        public string SmallKey { get; init; }
        public string GerudoFortressSmallKeys { get; init; }
        public string BossKey { get; init; }

        #endregion
        #region KeyRings
        public string KeyRings { get; init; }
        public bool GerudoFortressKeyrings { get; init; }
        public bool ForestTempleKeyrings { get; init; }
        public bool FireTempleKeyrings { get; init; }
        public bool WaterTempleKeyrings { get; init; }
        public bool ShadowTempleKeyrings { get; init; }
        public bool SpiritTempleKeyrings { get; init; }
        public bool GanonsCastleKeyrings { get; init; }
        public bool BottomOfTheWellKeyrings { get; init; }
        public bool GerudoTrainingGroundsKeyrings { get; init; }

        #endregion
        #region Sanity
        public string KokiriSwordsanity { get; init; }
        public string Mastersanity { get; init; }
        public string Tokensanity { get; init; }
        public string Freestandingsanity { get; init; }
        public string Potsanity { get; set; }
        public string Cratesanity { get; init; }
        public string Grasssanity { get; init; }
        public string Scrubsanity { get; init; }
        public string Fishsanity { get; init; }
        public string Beehivesanity { get; init; }
        public string Cowsanity { get; init; }
        public string Treesanity { get; init; }
        public string Bosssanity { get; init; }
        public string Merchantsanity { get; init; }
        public string Frogsanity { get; init; }
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
        public string DungeonRewards { get; init; }
        public string RocFeather { get; init; }
        #endregion
        #region Shops
        public bool ShuffleShops { get; init; }
        public int ShuffleShopsItemCount { get; init; }
        public int ShuffleShopsMinPrice { get; init; }
        public int ShuffleShopsMaxPrice { get; init; }
        public int ScrubMinPrice { get; init; }
        public int ScrubMaxPrice { get; init; }
        #endregion
        [JsonPropertyName("token100")]
        public bool HundredTokens { get; init; }
        public bool SkipChildZelda { get; init; }
        public bool SkipMaskQuest { get; init; }
        public bool SkipEponaRace { get; init; }
        public int BigPoeCount { get; init; }
        public int IceTrapsCount { get; init; }
        public int IceTrapsFillerPercentage { get; init; }
        public bool BlueFireArrows { get; init; }
        public bool SunlightArrows { get; init; }
        public bool FullWallets { get; init; }
        public string InfiniteUpgrades { get; init; }
        #region LEGACY
        public bool DungeonKeyRings { get; init; }
        public string MapsAndCompasses { get; init; }
        #endregion
        public SOHPlayerOptions(string playerName, Dictionary<string, string> options)
        {
            PlayerName = playerName; Options = options;
            Date = DateTime.Now;
            if (string.Compare(options["Triforce Hunt"], "Yes", true) == 0)
            {
                Goal = "Triforce Hunt";
            }
            else
            {
                Goal = "Ganon";
            }
            TriforcePieces = int.Parse(options["Triforce Hunt Pieces Total"]);
            TriforcePercent = int.Parse(options["Triforce Hunt Pieces Required Percentage"]);
            Accessibility = options["Accessibility"];
            ItemPool = options["Item Pool"];
            #region Doors

            switch (options["Closed Forest"].ToLower())
            {
                case "on":
                    KokiriForest = "Closed";
                    DekuTree = "Closed";
                    break;
                case "deku_only":
                    KokiriForest = "Open";
                    DekuTree = "Closed";
                    break;
                default:
                    KokiriForest = "Open";
                    DekuTree = "Open";
                    break;
            }
            KakarikoGate = options["Kakariko Gate"];
            DoorOfTime = options["Door of Time"];
            ZoraFountain = options["Zora's Domain"].ToLower() switch
            {
                "closed as child" => "Closed for Child",
                _ => options["Zora's Domain"],
            };
            JabuJabuMouth = options["Jabu-Jabu"];
            OverworldDoors = options["Lock Overworld Doors"].ToLower() == "no" ? "Open" : "Closed";
            SleepingWaterfall = options["Sleeping Waterfall"];

            #endregion
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
            else if (string.Compare(options["Rainbow Bridge"], "dungeon rewards", true) == 0)
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
            else if (string.Compare(options["Ganons Castle Boss Key"], "lacs vanilla", true) == 0)
            {
                GanonBossKeyCondition = "LACS Vanilla";
                GanonBossKeyValue = 2;
            }
            else if (string.Compare(options["Ganons Castle Boss Key"], "lacs stones", true) == 0)
            {
                GanonBossKeyCondition = "LACS Stones";
                GanonBossKeyValue = int.Parse(options["Ganons Castle Boss Key Stones Required"]);
            }
            else if (string.Compare(options["Ganons Castle Boss Key"], "lacs medallions", true) == 0)
            {
                GanonBossKeyCondition = "LACS Medallions";
                GanonBossKeyValue = int.Parse(options["Ganons Castle Boss Key Medallions Required"]);
            }
            else if (string.Compare(options["Ganons Castle Boss Key"], "lacs dungeon rewards", true) == 0)
            {
                GanonBossKeyCondition = "LACS Rewards";
                GanonBossKeyValue = int.Parse(options["Ganons Castle Boss Key Dungeon Rewards Required"]);
            }
            else if (string.Compare(options["Ganons Castle Boss Key"], "lacs dungeons", true) == 0)
            {
                GanonBossKeyCondition = "LACS Dungeons";
                GanonBossKeyValue = int.Parse(options["Ganons Castle Boss Key Dungeons Required"]);
            }
            else if (string.Compare(options["Ganons Castle Boss Key"], "lacs tokens", true) == 0)
            {
                GanonBossKeyCondition = "LACS Tokens";
                GanonBossKeyValue = int.Parse(options["Ganons Castle Boss Key Skull Tokens Required"]);
            }
            GanonTrials = options["Skip Ganon's Trials"].ToLower() == "yes" ? "All" : "None";

            SmallKey = options["Small Key Shuffle"];
            GerudoFortressSmallKeys = options["Gerudo Fortress Key Shuffle"];
            BossKey = options["Boss Key Shuffle"];

            #region Dungeons

            MapsAndCompasses = options["Maps and Compasses"];

            KeyRings = options["Key Rings"];
            ForestTempleKeyrings = string.Compare(options["Forest Temple Keyring"], "yes", true) == 0 ? true : false;
            GerudoFortressKeyrings = string.Compare(options["Gerudo Fortress Keyring"], "yes", true) == 0 ? true : false;
            FireTempleKeyrings = string.Compare(options["Fire Temple Keyring"], "yes", true) == 0 ? true : false;
            WaterTempleKeyrings = string.Compare(options["Water Temple Keyring"], "yes", true) == 0 ? true : false;
            ShadowTempleKeyrings = string.Compare(options["Shadow Temple Keyring"], "yes", true) == 0 ? true : false;
            SpiritTempleKeyrings = string.Compare(options["Spirit Temple Keyring"], "yes", true) == 0 ? true : false;
            GanonsCastleKeyrings = string.Compare(options["Ganon's Castle Keyring"], "yes", true) == 0 ? true : false;
            BottomOfTheWellKeyrings = string.Compare(options["Bottom of the Well Keyring"], "yes", true) == 0 ? true : false;
            GerudoTrainingGroundsKeyrings = string.Compare(options["Gerudo Training Ground Keyring"], "yes", true) == 0 ? true : false;
            #endregion
            switch (options["Fortress Carpenters"].ToLower())
            {
                case "normal":
                    break;
            }

            FortressCarpenters = options["Fortress Carpenters"].ToLower() switch
            {
                "normal" => "All prisoners",
                "fast" => "One prisoner",
                "free" => "All free",
                _ => "Unknown",

            };

            KokiriSwordsanity = options["Shuffle Kokiri Sword"].ToLower() == "yes" ? "On" : "Off";
            Mastersanity = options["Shuffle Master Sword"].ToLower() == "yes" ? "On" : "Off";
            Tokensanity = options["Shuffle Tokens"].ToLower() switch
            {
                "dungeon" => "Dungeons",
                "all" => "Everywhere",
                _ => options["Shuffle Tokens"]
            };
            Potsanity = options["Shuffle Pots"].ToLower() switch
            {
                "dungeon" => "Dungeons",
                _ => options["Shuffle Pots"]
            };
            Freestandingsanity = options["Shuffle Freestanding Items"].ToLower() switch
            {
                "dungeon" => "Dungeons",
                "all" => "Everywhere",
                _ => options["Shuffle Freestanding Items"]
            };
            Cratesanity = options["Shuffle Crates"].ToLower() switch
            {
                "dungeon" => "Dungeons",
                _ => options["Shuffle Crates"]
            };
            Grasssanity = options["Shuffle Grass"].ToLower() switch
            {
                "dungeon" => "Dungeons",
                _ => options["Shuffle Grass"]
            };
            Scrubsanity = options["Shuffle Scrubs"].ToLower() == "yes" ? "On" : "Off";
            Fishsanity = options["Shuffle Fish"];
            Beehivesanity = options["Shuffle Beehives"].ToLower() == "yes" ? "On" : "Off";
            Cowsanity = options["Shuffle Cows"].ToLower() == "yes" ? "On" : "Off";
            Treesanity = options["Shuffle Trees"].ToLower() == "yes" ? "On" : "Off";
            Bosssanity = options["Shuffle Boss Souls"];

            Merchantsanity = options["Shuffle Merchants"];
            Frogsanity = options["Shuffle Frog Song Rupees"].ToLower() == "yes" ? "On" : "Off";
            Ocarinasanity = options["Shuffle Ocarina Buttons"].ToLower() == "yes" ? "On" : "Off";
            FairysanityFountains = options["Shuffle Fairies in Fountains"].ToLower() == "yes" ? "On" : "Off";
            FairysanityStones = options["Shuffle Gossip Stone Fairies"].ToLower() == "yes" ? "On" : "Off";
            FairysanityBeans = options["Shuffle Bean Fairies"].ToLower() == "yes" ? "On" : "Off";
            FairysanitySongs = options["Shuffle Fairy Spots"].ToLower() == "yes" ? "On" : "Off";

            ChildWallet = options["Shuffle Child's Wallet"].ToLower() == "yes" ? "On" : "Off";
            BronzeScale = options["Shuffle Swim"].ToLower() == "yes" ? "On" : "Off";
            StickBag = options["Shuffle Deku Stick Bag"].ToLower() == "yes" ? "On" : "Off";
            NutBag = options["Shuffle Deku Nut Bag"].ToLower() == "yes" ? "On" : "Off";
            BombchuBag = options["Bombchu Bag"];
            WeirdEgg = options["Shuffle Weird Egg"].ToLower() == "yes" ? "On" : "Off";
            AdultTrade = options["Shuffle Adult Trade Items"].ToLower() == "All Items" ? "On" : "Only Claim Check";
            FishingPole = options["Shuffle Fishing Pole"].ToLower() == "yes" ? "On" : "Off";
            SkeletonKey = options["Skeleton Key"].ToLower() == "yes" ? "On" : "Off";
            DungeonRewards = options["Shuffle Dungeon Rewards"].ToLower() == "yes" ? "On" : "Off";

            ShuffleShops = options["Shuffle Shops"] == "Yes";
            ShuffleShopsItemCount = int.Parse(options["Shuffle Shops Item Amount"]);
            ShuffleShopsMinPrice = int.Parse(options["Shuffle Shops Minimum Price"]);
            ShuffleShopsMaxPrice = int.Parse(options["Shuffle Shops Maximum Price"]);
            ScrubMinPrice = int.Parse(options["Shuffle Scrubs Minimum Price"]);
            ScrubMaxPrice = int.Parse(options["Shuffle Scrubs Maximum Price"]);

            HundredTokens = options["Shuffle 100 GS Reward"] == "Yes";
            SkipChildZelda = options["Skip Child Zelda"] == "Yes";
            SkipMaskQuest = options["Complete Mask Quest"] == "Yes";
            SkipEponaRace = options["Skip Epona Race"] == "Yes";
            BigPoeCount = int.Parse(options["Big Poe Target Count"]);
            IceTrapsCount = int.Parse(options["Ice Trap Count"]);
            IceTrapsFillerPercentage = int.Parse(options["Ice Trap Filler Replacement Count"]);
            BlueFireArrows = options["Blue Fire Arrows"] == "Yes";
            SunlightArrows = options["Sunlight Arrows"] == "Yes";
            FullWallets = options["Full Wallets"] == "Yes";
            InfiniteUpgrades = options["Infinite Upgrades"];
            RocFeather = options["Roc's Feather"].ToLower() == "yes" ? "On" : "Off";

            #region LEGACY
            DungeonKeyRings = false;
            #endregion
        }
    }
}
