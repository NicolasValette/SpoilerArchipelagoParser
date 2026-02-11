using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter
{
    public class RainbowBridgeComboConverter : IComboConverter<string>
    {
        public string Convert(Dictionary<string, object> values) => values["Rainbow Bridge"] switch
        {
            "Vanilla" => "2",
            "Always_Open" => "0",
            "Stones" => values["Rainbow Bridge Stones Required"] as string ?? string.Empty,
            "Medallions" => values["Rainbow Bridge Medallions Required"] as string ?? string.Empty,
            "Dungeon Rewards" => values["Rainbow Bridge Dungeon Rewards Required"] as string ?? string.Empty,
            "Dungeons" => values["Rainbow Bridge Dungeons Required"] as string ?? string.Empty,
            "Tokens" => values["Rainbow Bridge Skull Tokens Required"] as string ?? string.Empty,
            "Greg" => values["Rainbow Bridge Greg Modifier"] as string ?? string.Empty,
            _ => throw new KeyNotFoundException($"Cannont find key \"{values["Rainbow Bridge"]}\" in the dictionnary for {this.GetType().Name}")
        };
    }
}
