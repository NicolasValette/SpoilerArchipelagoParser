using NoNiDev.SpoilerArchipelagoParser.Options;
using NoNiDev.SpoilerArchipelagoParser.Options.SOHOptions;
using NoNiDev.SpoilerArchipelagoParser.RandoStats;

namespace NoNiDev.SpoilerArchipelagoParser
{
    public class ArchipelagoOption(HashSet<string> playerNames, HashSet<string> games, List<GameOptions> sohOptions, RandoStat randoStats)
    {
        public HashSet<string> Players { get; set; } = playerNames;
        public HashSet<string> Games { get; set; } = games;
        public List<GameOptions> SOHOptions{ get; set; } = sohOptions; 
        public RandoStat RandoStats { get; set; } = randoStats;

        public GameOptions GetSOHOptions(string playerName)
        {
            return SOHOptions.Where(o => o.PlayerName == playerName).First();
        }
    }
}
