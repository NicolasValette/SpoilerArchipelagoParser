using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Enums
{
    #region SOHAR Setup
    public enum EGoal
    {
        Triforce_Hunt,
        Ganon
    }
    public enum EAccessibility
    {
        Full,
        Minimal
    }
    #endregion
    #region DOORS
    public enum EForestOpenClosed
    {
        On,
        Off,
        Deku_Only
    }
    public enum EOpenClosed
    {
        Open,
        Closed
    }
    public enum EOpenClosedClosedAsChild
    {
        Open,
        Closed,
        Closed_As_Child
    }
    public enum EDoorOfTime
    {
        Open,
        Closed,
        Song_Only
    }
    #endregion
    #region CONDITIONS
    public enum EStartingAge
    {
        Child,
        Adult
    }
    public enum EBridgeCondition
    {
        Vanilla,
        Always_Open,
        Stones,
        Medallions,
        Dungeon_Rewards,
        Dungeons,
        Tokens,
        Greg
    }
    public enum EBossKeyCondition
    {
        Vanilla,
        Anywhere,
        LACS_Vanilla,
        LACS_Stones,
        LACS_MEdallions,
        LACS_Rewards,
        LACS_Dungeons,
        LACS_Tokens
    }
    #endregion
    #region DUNGEONS
    /// <summary>
    /// map_and_compass options
    /// </summary>
    public enum EMapAndCompass
    {
        Start_With,
        Vanilla,
        Own_Dungeon,
        Any_Dungeon,
        Overworld,
        Anywhere
    }
    /// <summary>
    /// fortress_carpenters options
    /// </summary>
    public enum ECarpenters
    {
        Normal,
        Fast,
        Free
    }
    #endregion
    #region SANITY
    public enum ELocationSanity
    {
        Off,
        Dungeon,
        Overworld,
        All
    }
    /// <summary>
    /// shuffle_fish options
    /// </summary>
    public enum EFishSanity
    {
        Off,
        Pond,
        Overworld,
        All
    }
    /// <summary>
    /// shuffle_boss_souls options
    /// </summary>
    public enum EBossSanity
    {
        On,
        Off,
        On_Plus_Ganons
    }
   
    #endregion
    #region ITEMS
    public enum  EItemPool
    {
        Balanced,
        Plentiful,
        Scarce,
        Minimal
    }
    public enum EBombchuBag
    {
        None,
        Single_Bag,
        Progressive_Bags
    }
    #endregion
    #region SHOPS
    /// <summary>
    /// shuffle_merchants options
    /// </summary>
    public enum EMerchantSanity
    {
        Off,
        Bean_Merchant_Only,
        All_But_Beans,
        All
    }
    #endregion
    #region SKIPS
    #endregion
    #region MISC
    public enum  EOnOff
    {
        On,
        Off
    }
    public enum EYesNo
    {
        Yes,
        No
    }
    /// <summary>
    /// infinite_upgrade options
    /// </summary>
    public enum EInfiniteUpgrade
    {
        Off,
        Progressive,
        Condensed_Progressive
    }
    #endregion


}
