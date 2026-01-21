using NoNiDev.SpoilerArchipelagoParser.SOHOptions;

namespace NoNiDev.SpoilerArchipelagoParser
{
    public class SpoilerArchipelagoReader
    {
        private HashSet<string> _players = new();
        private HashSet<string> _games = new();

        public ArchipelagoOption ReadSpoiler(StreamReader spoilerFile)
        {
            string line = "";
            int nbPlayers = 0;
            line = spoilerFile.ReadLine();
            List<SOHPlayerOptions> listOptions = new List<SOHPlayerOptions>();
            if (line == null)
                throw new Exception("Unexpected error during file reading.");
            if (!line.Trim().Contains("Archipelago", StringComparison.InvariantCultureIgnoreCase))
                throw new Exception("Wrong file, please provide an archipelago spoilers.");

            line = spoilerFile.ReadLine();
            while (!spoilerFile.EndOfStream)
            {

                if (line.StartsWith("Players", StringComparison.InvariantCultureIgnoreCase))
                {
                    nbPlayers = int.Parse(line.Split(':', StringSplitOptions.TrimEntries)[1]);
                   break;
                }
                line = spoilerFile.ReadLine();
            }
            line = spoilerFile.ReadLine();
            int currentplayer = 0;
            while (!spoilerFile.EndOfStream)
            {

                if (line.StartsWith("Player", StringComparison.InvariantCultureIgnoreCase))
                {
                    currentplayer++;
                    string playerName = line.Trim().Split(':', StringSplitOptions.TrimEntries)[1];
                    _players.Add(playerName);
                    SOHPlayerOptions player = ReadPlayerOptions(line, spoilerFile);
                    if (player != null)
                    {
                        listOptions.Add(player);
                    }
                    if (currentplayer >= nbPlayers) break;
                }
                line = spoilerFile.ReadLine();
            }
            return new ArchipelagoOption(_players, _games, listOptions);
        }

        private SOHPlayerOptions ReadPlayerOptions(string currentLine, StreamReader spoilerFile)
        {
            string playerName = currentLine.Trim().Split(':', StringSplitOptions.TrimEntries)[1];
            string line = spoilerFile.ReadLine();
            string[] game = line.Split(':', StringSplitOptions.TrimEntries);
            _games.Add(game[1]);
            if (game[0].Contains("Game", StringComparison.InvariantCultureIgnoreCase) && game[1].Contains("Ship of Harkinian", StringComparison.InvariantCultureIgnoreCase))
            {
                Dictionary<string, string> options = ReadSOHOptions(spoilerFile);
                SOHPlayerOptions sohOptions = new SOHPlayerOptions(playerName, options);
                return sohOptions;
            }
            
            return null;
        }
        private Dictionary<string, string> ReadSOHOptions(StreamReader spoilerFile)
        {
            Dictionary<string, string> options = new();
            string currentLine = spoilerFile.ReadLine();
            while (!string.IsNullOrEmpty(currentLine))
            {
                string[] splittedLine = currentLine.Split(":",StringSplitOptions.TrimEntries);
                if (!options.ContainsKey(splittedLine[0]))
                {
                    options.Add(splittedLine[0], splittedLine[1]);
                }
                currentLine = spoilerFile.ReadLine();
            }
            return options;
        }

    }
}