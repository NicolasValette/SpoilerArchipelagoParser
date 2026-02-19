using NoNiDev.SpoilerArchipelagoParser.Options;
using NoNiDev.SpoilerArchipelagoParser.Options.SOHOptions;
using NoNiDev.SpoilerArchipelagoParser.RandoStats;
using System.Numerics;

namespace NoNiDev.SpoilerArchipelagoParser
{
    public class ArchipelagoOption
    {
        public HashSet<string> Players { get; set; } 
        public HashSet<string> Games { get; set; }
        public List<GameOptions> SOHOptionsList{ get; set; }
        public RandoStat RandoStats { get; set; }

        public ArchipelagoOption(HashSet<string> playerNames, HashSet<string> games, List<GameOptions> sohOptions, RandoStat randoStats)
        {
            Players = playerNames;
            Games = games;
            SOHOptionsList = sohOptions;
            RandoStats = randoStats;
            foreach (GameOptions opt in SOHOptionsList)
            {
                opt.Process();
            }
        }

        public GameOptions GetSOHOptions(string playerName)
        {
            return SOHOptionsList.Where(o => o.PlayerName == playerName).First();
        }
    }
}
