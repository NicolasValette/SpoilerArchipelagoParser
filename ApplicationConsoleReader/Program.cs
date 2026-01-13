// See https://aka.ms/new-console-template for more information
using NoNiDev.ApplicationConsoleReader;
using NoNiDev.SpoilerArchipelagoParser;

#if RELEASE
Console.WriteLine("rel");
#else
Console.WriteLine("Deb");
#endif
StreamReader sr = new StreamReader("E:\\Dev\\git\\Source\\Repos\\SpoilerArchipelagoParser\\ApplicationConsoleReader\\Ressource\\SpoilerExemple.txt");
SpoilerArchipelagoParser spoilerReader = new();
var archipOptions = spoilerReader.ReadSpoiler(sr);
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

StreamReader init = new StreamReader("E:\\Dev\\git\\Source\\Repos\\SpoilerArchipelagoParser\\ApplicationConsoleReader\\Ressource\\Init.txt");
string api = init.ReadLine().Trim();
OptionsSender.SendOptions(archipOptions, api);


