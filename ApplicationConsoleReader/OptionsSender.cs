using NoNiDev.SpoilerArchipelagoParser;
using NoNiDev.SpoilerArchipelagoParser.SOHOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.ApplicationConsoleReader
{
    internal class OptionsSender
    {
        public static void SendOptions(ArchipelagoOption options)
        {
            List<SOHPlayerOptions> optionsToSend = new();
            foreach(var item in options.SOHOptions)
            {
                Console.WriteLine($"Player {item.PlayerName}, send this slot ?");
                if (UserReader.GetUserAnswer())
                {
                    optionsToSend.Add(item);
                }
            }


            Console.WriteLine();
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("These datas will be send, please check up before confirmation.");
            Console.WriteLine("*********************************************************************");
            foreach(var item in optionsToSend)
            {
                Console.WriteLine($"Player {item.PlayerName}");
                Console.WriteLine("OPTIONS : ");
                foreach (var line in item.Options)
                {
                    if (!string.IsNullOrEmpty(line.Value))
                    {
                        Console.WriteLine($"{line.Key} - {line.Value}");
                    }
                }
                Console.WriteLine("---------------------------------------------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ready to send datas");
            foreach( var item in optionsToSend)
            {
                Console.WriteLine($"Player {item.PlayerName} will be sent.");
            }
            if (UserReader.GetUserAnswer())
            {
                Console.WriteLine("Data Sent");
                Console.WriteLine($"{optionsToSend.Count} player(s) sent to the google sheet");
                
            }
            else
            {
                Console.WriteLine("Sending cancelled");
                
            }

            Console.WriteLine("This tool is provided by NoNiDev :) ");

        }
    }
}
