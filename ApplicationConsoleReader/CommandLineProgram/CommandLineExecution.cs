using Microsoft.VisualBasic.FileIO;
using NoNiDev.CallAPI.AllRandomGame;
using NoNiDev.CallAPI.RandoStat;
using NoNiDev.SpoilerArchipelagoParser;
using NoNiDev.SpoilerArchipelagoParser.Attributes;
using NoNiDev.SpoilerArchipelagoParser.RandoStats;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace NoNiDev.ApplicationConsoleReader.CommandLineProgram
{
    public static class CommandLineExecution
    {
        private static ConfigOption? _confOption;
        private static ArchipelagoOption? _archOption;

        public static void Execute(ProgramOptions options, string spoilerFilePath)
        {
            Console.WriteLine($"Config File: {options.ConfigFile}");
            Console.WriteLine($"Add Archipel: {options.AddArchipel}");
            Console.WriteLine("Games:");
            
            ReadConfigFile(options.ConfigFile);

            StreamReader sr = new StreamReader(spoilerFilePath);
            SpoilerArchipelagoReader spoilerReader = new();
            _archOption = spoilerReader.ReadSpoiler(sr);

            if (options.AddArchipel)
                RandoStatExecute(options);
            AddRandomGameStatExecute(options);

            Console.WriteLine("Execution completed.");
        }

        public static void SaveConfigFile()
        {
            
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var configContent = JsonSerializer.Serialize<ConfigOption>(_confOption, jsonOptions);
            StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Config.json"), false, Encoding.ASCII);
            sw.WriteLine(configContent);
            sw.Close();
        }
        public static void ReadConfigFile(string configFilePath)
        {
            string initFilePath = Path.Combine(Environment.CurrentDirectory, "Config.json");
            if (configFilePath != string.Empty && File.Exists(configFilePath))
            {
                initFilePath = configFilePath;
            }
            string configContent = File.ReadAllText(initFilePath);
            _confOption = JsonSerializer.Deserialize<ConfigOption>(configContent);
            //SaveConfigFile();
        }
        public static void RandoStatExecute(ProgramOptions options)
        {
            APIToRandoStat.InitURL(_confOption?.ApiRandomStat ?? string.Empty);
            Task < string[]> task = APIToRandoStat.GetGameNames();
            while (!task.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.WriteLine();
            if (_archOption != null)
            {
                
                List<ArchippelagoSlot> slots = new List<ArchippelagoSlot>();
                foreach (var gameSlot in _archOption.RandoStats.Slots)
                {
                    ArchippelagoSlot slot = new ArchippelagoSlot(gameSlot.Name, gameSlot.Game, gameSlot.LocationCount);
                    if (task.Result.Contains(gameSlot.Game))
                    {
                        Console.WriteLine($"Game {gameSlot.Game} already exists in RandoStat.");
                    }
                    else if (gameSlot.Game.Contains("Manual", StringComparison.OrdinalIgnoreCase))
                    {
                        slot.Game = "Manual";
                        Console.WriteLine($"Game {gameSlot.Game} is a manual game, changing its name to Manual.");
                    }
                    else
                    {
                        Task<string> addGameTask = APIToRandoStat.AddGame(gameSlot.Game);
                        while (!addGameTask.IsCompleted)
                        {
                            Console.Write(".");
                            Thread.Sleep(500);
                        }
                        Console.WriteLine($"\nAdded game {gameSlot.Game} to RandoStat: {addGameTask.Result}");
                        Console.WriteLine($"Add Game {gameSlot.Game}");
                    }
                    slots.Add(slot);
                }
                RandoStatData data = new RandoStatData();
                Task<string> addArchTask = APIToRandoStat.AddArchipel(options.ArchipelagoName, options.Url, slots);
                while (!addArchTask.IsCompleted)
                {
                    Console.Write(".");
                    Thread.Sleep(500);
                }
                Console.WriteLine($"\nAdded Archipelago to RandoStat sheet : {addArchTask.Result}");
        
            }

        }

        public static void AddRandomGameStatExecute(ProgramOptions options)
        {
            if (_archOption != null)
            {
                APIToRandomGames.InitURL(_confOption?.ApiAllRandom ?? string.Empty);
                foreach (var gameOption in _archOption.SOHOptionsList)
                {
                    if (options.Games.Contains(gameOption.Game))
                    {

                        if (gameOption.PlayerName.Contains("Nono"))
                        {
                            gameOption.PlayerName = "Nono";
                        }
                        else if (gameOption.PlayerName.Contains("Niko"))
                        {
                            gameOption.PlayerName = "Niko";
                        }
                        else
                        {
                            continue;
                        }
                        Console.WriteLine($"Add stat for game {gameOption.Game}, player : {gameOption.PlayerName}");
                        Task<string> task = APIToRandomGames.AddRandomGames(gameOption);
                        while (!task.IsCompleted)
                        {
                            Console.Write(".");
                            Thread.Sleep(500);
                        }
                        Console.WriteLine($"\n{gameOption.Game} added.");
                    }
                }
            }
        }
    }
}
