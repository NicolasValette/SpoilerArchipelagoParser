using NoNiDev.SpoilerArchipelagoParser.SOHOptions;

namespace NoNiDev.SpoilerArchipelagoParser
{
    public class ArchipelagoOption(HashSet<string> playerNames, HashSet<string> games, List<SOHPlayerOptions> sohOptions)
    {
        public HashSet<string> Players { get; set; } = playerNames;
        public HashSet<string> Games { get; set; } = games;
        public List<SOHPlayerOptions> SOHOptions{ get; set; } = sohOptions; 
    }
}
