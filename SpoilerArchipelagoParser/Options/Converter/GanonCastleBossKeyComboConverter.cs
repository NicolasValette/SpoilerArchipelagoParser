using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter
{
    public class GanonCastleBossKeyComboConverter : IComboConverter<string>
    {
        public string Convert(Dictionary<string, object> values) => values["Ganons Castle Boss Key"] switch
        {
            "Vanilla" => "0",
            "Anywhere" => "0",
            "LACS Vanilla" => "2",
            "Lacs Stones" => values["Ganons Castle Boss Key Stones Required"] as string ?? string.Empty,
            "Lacs Medallions" => values["Ganons Castle Boss Key Medallions Required"] as string ?? string.Empty,
            "Lacs Dungeon Rewards" => values["Ganons Castle Boss Key Dungeon Rewards Required"] as string ?? string.Empty,
            "Lacs Dungeons" => values["Ganons Castle Boss Key Dungeons Required"] as string ?? string.Empty,
            "Lacs Tokens" => values["Ganons Castle Boss Key Skull Tokens Required"] as string ?? string.Empty,
            _ => throw new KeyNotFoundException($"Cannont find key \"{values["Ganons Castle Boss Key"]}\" in the dictionnary for {this.GetType().Name}")
        };
    }
}
