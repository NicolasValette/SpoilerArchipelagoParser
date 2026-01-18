// See https://aka.ms/new-console-template for more information
using NoNiDev.ApplicationConsoleReader;
using NoNiDev.SpoilerArchipelagoParser;
using System.Text;

string spoilerFilePath="";
string initFilePath="";
#if RELEASE
if (args.Length < 1)
{
    Console.WriteLine("Missing spoiler file, please provide one");
    Console.WriteLine("Usage : ApplicationConsoleReader.exe spoilerfile_Spoiler.txt");
    Console.WriteLine("Exiting !!");
    Console.WriteLine("Press any keys to quit.");
    Console.ReadLine();
    return;
}
spoilerFilePath = args[0];
var files = Directory.GetFiles(Environment.CurrentDirectory);
Console.WriteLine(Environment.CurrentDirectory);
initFilePath = Path.Combine(Environment.CurrentDirectory, "Init.txt");
if (!files.Contains(initFilePath))
{
    Console.WriteLine("init.txt file not found, creating one.");
    Console.WriteLine("Please provide API URL : ");
    string readLine = Console.ReadLine();
    StreamWriter sw = new StreamWriter(initFilePath, false, Encoding.ASCII);
    sw.WriteLine(readLine);
    sw.Close();
    Console.WriteLine($"{initFilePath} file created");
}
#else
spoilerFilePath = "E:\\Dev\\git\\Source\\Repos\\SpoilerArchipelagoParser\\ApplicationConsoleReader\\Ressource\\SpoilerExemple.txt";
initFilePath = "E:\\Dev\\git\\Source\\Repos\\SpoilerArchipelagoParser\\ApplicationConsoleReader\\Ressource\\Init.txt";
#endif
Console.WriteLine($"Analyzing spoiler : {spoilerFilePath}");
StreamReader sr = new StreamReader(spoilerFilePath);
SpoilerArchipelagoParser spoilerReader = new();
var archipOptions = spoilerReader.ReadSpoiler(sr);
sr.Close();
Console.WriteLine("-------------- SPOILER ANALYZING --------------");
Console.WriteLine($"This archipelago contains {archipOptions.Players.Count} players for {archipOptions.Games.Count} games.");
Console.WriteLine("#--------------------------#");
Console.WriteLine("These players play in this archipelago : ");
Console.WriteLine(string.Join(" - ", archipOptions.Players));
Console.WriteLine("******************");
Console.WriteLine("These games are in this archipelago : ");
Console.WriteLine(string.Join(" - ", archipOptions.Games));
Console.WriteLine("#--------------------------#");
Console.WriteLine();
Console.WriteLine("#--------------------------#");
Console.WriteLine("These players play Ship of Harkinian");
foreach(var item in archipOptions.SOHOptions)
{
    Console.WriteLine(item.PlayerName);
}
Console.WriteLine("#--------------------------#");
Console.WriteLine();
Console.WriteLine("-------------- END OF SPOILER ANALYZING --------------");
Console.WriteLine();

StreamReader init = new StreamReader(initFilePath);
string api = init.ReadLine().Trim();
init.Close();
OptionsSender.SendOptions(archipOptions, api);

#if RELEASE
Console.WriteLine("Press any keys to quit.");
Console.ReadLine();
#endif