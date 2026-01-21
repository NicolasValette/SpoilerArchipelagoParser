using NoNiDev.SpoilerArchipelagoParser.SOHOptions;

namespace NoNiDev.SpoilerArchipelagoParser
{
    public class ArchipelagoOption(HashSet<string> playerNames, HashSet<string> games, List<SOHPlayerOptions> sohOptions, List<(string,string, string)> playerOptions)
    {
        public HashSet<string> Players { get; set; } = playerNames;
        public HashSet<string> Games { get; set; } = games;
        public List<(string, string, string)> PlayersOptions { get; set; } = playerOptions;
        public List<SOHPlayerOptions> SOHOptions{ get; set; } = sohOptions; 

        public SOHPlayerOptions GetSOHOptions(string playerName)
        {
            return SOHOptions.Where(o => o.PlayerName == playerName).First();
        }
    }
}
