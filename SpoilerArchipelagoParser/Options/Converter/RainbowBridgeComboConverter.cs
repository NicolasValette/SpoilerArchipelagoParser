using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter
{
    public class RainbowBridgeComboConverter : IComboConverter<int>
    {
        public int Convert(Dictionary<string, object> values) => values["Rainbow Bridge"] switch
        {
            "Vanilla"           => 2,
            "Always Open"       => 0,
            "Stones"            => int.Parse((string)values["Rainbow Bridge Stones Required"]),
            "Medallions"        => int.Parse((string)values["Rainbow Bridge Medallions Required"]),
            "Dungeon Rewards"   => int.Parse((string)values["Rainbow Bridge Dungeon Rewards Required"]),
            "Dungeons"          => int.Parse((string)values["Rainbow Bridge Dungeons Required"]),
            "Tokens"            => int.Parse((string)values["Rainbow Bridge Skull Tokens Required"]),
            "Greg"              => 1,//int.Parse((string)values["Rainbow Bridge Greg Modifier"]),
            _ => throw new KeyNotFoundException($"Cannont find key \"{values["Rainbow Bridge"]}\" in the dictionnary for {this.GetType().Name}")
        };
    }
}
