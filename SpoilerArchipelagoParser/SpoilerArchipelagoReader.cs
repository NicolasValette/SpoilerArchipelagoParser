using NoNiDev.SpoilerArchipelagoParser.Attributes;
using NoNiDev.SpoilerArchipelagoParser.Options;
using NoNiDev.SpoilerArchipelagoParser.Options.SOHOptions;
using NoNiDev.SpoilerArchipelagoParser.RandoStats;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NoNiDev.SpoilerArchipelagoParser
{
    public class SpoilerArchipelagoReader
    {
        private HashSet<string> _players = [];
        private HashSet<string> _games = [];
        private List<ArchippelagoSlot> _options = [];

        private Dictionary<string, Type> _gameType = [];

        public SpoilerArchipelagoReader()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(Options.GameOptions)));
            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<GameAttribute>();
                if (attribute != null)
                {
                    _gameType.Add(attribute.GameName, type);
                }
            }
        }
        private Options.GameOptions GetGameOptions(string gameName, string playerName, Dictionary<string, string> gameOptions)
        {
            if (!_gameType.ContainsKey(gameName))
                throw new Exception($"Game {gameName} is not supported.");
            return (Options.GameOptions)Activator.CreateInstance(_gameType[gameName], new Object[] { playerName, gameOptions });
        }
        public ArchipelagoOption ReadSpoiler(StreamReader spoilerFile)
        {
            string? line = "";
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

                if (line!.StartsWith("Players", StringComparison.InvariantCultureIgnoreCase))
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

                if (line!.StartsWith("Player", StringComparison.InvariantCultureIgnoreCase))
                {
                    currentplayer++;
                    string playerName = line.Trim().Split(':', StringSplitOptions.TrimEntries)[1];
                    _players.Add(playerName);
                    try
                    { 
                        if (ReadPlayerOptions(line, spoilerFile) is SOHPlayerOptions player)
                        {
                            listOptions.Add(player);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if (currentplayer >= nbPlayers) break;
                }
                line = spoilerFile.ReadLine();
            }
            return new ArchipelagoOption(_players, _games, listOptions, new RandoStat( _options));
        }


        private Options.GameOptions ReadPlayerOptions(string currentLine, StreamReader spoilerFile)
        {
            string playerName = currentLine.Trim().Split(':', StringSplitOptions.TrimEntries)[1];
            string? line = spoilerFile.ReadLine();
            string[] game = line!.Split(':', StringSplitOptions.TrimEntries);
            line = spoilerFile.ReadLine();
            string count = line!.Split(':', StringSplitOptions.TrimEntries)[1];
            _options.Add(new ArchippelagoSlot(playerName, game[1], int.Parse(count)));
            _games.Add(game[1]);
            if (game[0].Contains("Game", StringComparison.InvariantCultureIgnoreCase))
            {
                Dictionary<string, string> options = ReadSOHOptions(spoilerFile);

                Options.GameOptions option = GetGameOptions(game[1], playerName, options);
                
                var context = new ValidationContext(option);
                var errors = new List<ValidationResult>();
                if (Validator.TryValidateObject(option, context, errors, true))
                {
                    return option;
                }
                else
                {
                    string errorMessages = string.Join("; ", errors.Select(e => e.ErrorMessage));
                    throw new ValidationException($"SOH Options validation failed for player {playerName}: {errorMessages}");
                }
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