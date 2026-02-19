using NoNiDev.SpoilerArchipelagoParser.Attributes;
using NoNiDev.SpoilerArchipelagoParser.Options.Converter;
using NoNiDev.SpoilerArchipelagoParser.Options.Converter.OuterWildsConverter;

namespace NoNiDev.SpoilerArchipelagoParser.Options.OWOptions
{
    [Game("Outer Wilds")]
    public class OWOption : GameOptions
    {
        #region PLAYER
        [ConvertValue(typeof(GoalOWConverter))]
        public string Goal { get;set; } = string.Empty;
        public string Accessibility { get; set; } = string.Empty;
        [SpoilerName("Progression Balancing"), ConvertValue(typeof(StringToInt))]
        public int ProgressionBalancing { get; set; } = 0;
        #endregion
        #region UNIVERSE
        [ConvertValue(typeof(SpawnConverter))]
        public string Spawn { get; set; } = string.Empty;
        [SpoilerName("Randomize Coordinates"), ConvertValue(typeof(YesNoToRandomVanilla))]
        public string EyeCoordinates { get; set; } = string.Empty;
        [SpoilerName("Randomize Orbits"), ConvertValue(typeof(YesNoToRandomVanilla))]
        public string PlanetOrbits { get; set; } = string.Empty;
        [SpoilerName("Randomize Rotations"), ConvertValue(typeof(YesNoToRandomVanilla))]
        public string PlanetRotations { get; set; } = string.Empty;
        [SpoilerName("Randomize Warp Platforms"), ConvertValue(typeof(YesNoToRandomVanilla))]
        public string WarpPlatforms { get; set; } = string.Empty;
        [SpoilerName("Randomize Dark Bramble Layout"), ConvertValue(typeof(DarkBrambleLayoutConverter))]
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
