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
    #region GANON
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
        Token,
        Greg
    }
    public enum ETrials
    {
        All,
        None
    }
    public enum EBossKeyCOndition
    {
        Vanilla,
        Anywhere,
        LACS_Vanilla,
        LACS_Stones,
        LACS_MEdallions,
        LACS_Rewards,
        LACS_Dungeons,
        LACS_Token
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
        On_Plus_Ganon
    }
    /// <summary>
    /// shuffle_merchants options
    /// </summary>
    public enum EMerchantSanity
    {
        Off,
        Only_Beans,
        All_But_Beans,
        All
    }
    #endregion
    #region ITEMS
    /// <summary>
    /// shuffle_adult_trade_items options
    /// </summary>
    public enum  EAdultTrade
    {
        Only_Claim_Check,   //false
        All_Items           //true
    }
    #endregion
    #region SHOPS
    #endregion
    #region SKIPS
    #endregion
    #region MISC
    public enum  EOnOFf
    {
        On,
        Off
    }
    /// <summary>
    /// infinite_upgrade options
    /// </summary>
    public enum EInfiniteUpgrade
    {
        Off,
        Progressive,
        Condensed
    }
    #endregion


}
