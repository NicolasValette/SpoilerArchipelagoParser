using NoNiDev.SpoilerArchipelagoParser.Attributes;
using NoNiDev.SpoilerArchipelagoParser.Options.Converter;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.OWOptions
{
    [Game("Outer Wilds")]
    public class OWOption : GameOptions
    {
        #region PLAYER
        public string Goal { get;set; } = string.Empty;
        public string Accessibility { get; set; } = string.Empty;
        [SpoilerName("Progression Balancing"), ConvertValue(typeof(StringToInt))]
        public int ProgressionBalancing { get; set; } = 0;
        #endregion
        #region UNIVERSE
        public string Spawn { get; set; } = string.Empty;
        [SpoilerName("Randomize Coordinates")]
        public string EyeCoordinates { get; set; } = string.Empty;
        [SpoilerName("Randomize Orbits")]
        public string PlanetOrbits { get; set; } = string.Empty;
        [SpoilerName("Randomize Rotations")]
        public string PlanetRotations { get; set; } = string.Empty;
        [SpoilerName("Randomize Warp Platforms")]
        public string WarpPlatforms { get; set; } = string.Empty;
        [SpoilerName("Randomize Dark Bramble Layout")]
        public string Sombronces { get; set; } = string.Empty;
        #endregion
        #region SANITY
        [SpoilerName("Early Key Item")]
        public string EarlyKeyItem { get; set; } = string.Empty;
        [SpoilerName("Logsanity"), ConvertValue(typeof(YesNoToBool))]
        public bool LogSanity { get; set; } = false;
        [SpoilerName("Shuffle Spacesuit"), ConvertValue(typeof(YesNoToBool))]
        public bool ShuffleSpacesuit { get; set; } = false;
        [SpoilerName("Split Translator"), ConvertValue(typeof(YesNoToBool))]
        public bool SplitTranslator { get; set; } = false;
        #endregion
        #region EXTRA
        [SpoilerName("Trap Chance"), ConvertValue(typeof(StringToInt))]
        public int TrapPercentage { get; set; } = 0;
        [SpoilerName("Death Link")]
        public string DeathLink { get; set; } = string.Empty;
        #endregion

        public OWOption(string name, Dictionary<string, string> opt) : base(name, opt)
        {
        }
    }
}
