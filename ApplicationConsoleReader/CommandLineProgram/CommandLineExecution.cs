using NoNiDev.CallAPI.AllRandomGame;
using NoNiDev.CallAPI.RandoStat;
using NoNiDev.SpoilerArchipelagoParser;
using NoNiDev.SpoilerArchipelagoParser.Attributes;
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

            //RandoStatExecute(options);
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
            SaveConfigFile();
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
            if (_archOption != null)
            {
                foreach (var game in _archOption.Games)
                {
                    if (task.Result.Contains(game))
                    {
                        Console.WriteLine($"Game {game} already exists in RandoStat.");
                    }
                    else
                    {
                        //Task<string> addGameTask = APIToRandoStat.AddGame(game);
                        //while (!addGameTask.IsCompleted)
                        //{
                        //    Console.Write(".");
                        //    Thread.Sleep(500);
                        //}
                        //Console.WriteLine($"Added game {game} to RandoStat: {addGameTask.Result}");
                        Console.WriteLine($"Add Game {game}");
                    }
                }
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
