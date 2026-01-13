using NoNiDev.SpoilerArchipelagoParser;
using NoNiDev.SpoilerArchipelagoParser.SOHOptions;
using System.Text;
using System.Text.Json;

namespace NoNiDev.ApplicationConsoleReader
{
    internal class OptionsSender
    {
        public static async Task SendOptions(ArchipelagoOption options, string apiUrl)
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
                if (item.PlayerName.Contains("NONO", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Is this NONO ?");
                    if (UserReader.GetUserAnswer())
                    {
                        item.PlayerName = "Nono";
                    }
                }
                else if (item.PlayerName.Contains("NIKO", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Is this NIKO ?");
                    if (UserReader.GetUserAnswer())
                    {
                        item.PlayerName = "Niko";
                    }
                }
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
                Console.WriteLine("SENDING DATA");
                foreach (var item in optionsToSend)
                {
                    Console.WriteLine($"Send {item.PlayerName}");
                    Task t = SentToApiAsync(item, apiUrl);
                    while (!t.IsCompleted)
                    {
                        Console.Write(".");
                        Thread.Sleep(500);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Data Sent");
                Console.WriteLine($"{optionsToSend.Count} player(s) sent to the google sheet");
                
            }
            else
            {
                Console.WriteLine("Sending cancelled");
                
            }

            

        }
        private static async Task SentToApiAsync(SOHPlayerOptions optionToSend, string api)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            
            string jsonString = JsonSerializer.Serialize<SOHPlayerOptions>(optionToSend, options);
            using var client = new HttpClient();
            using var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(api, content);
            var responseText = await response.Content.ReadAsStringAsync();
            Console.WriteLine();
           Console.WriteLine(responseText);
            
        }
    }
}
