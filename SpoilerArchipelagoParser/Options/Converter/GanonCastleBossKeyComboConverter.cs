using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter
{
    public class GanonCastleBossKeyComboConverter : IComboConverter<int>
    {
        public int Convert(Dictionary<string, object> values) => values["Ganons Castle Boss Key"] switch
        {
            "Vanilla"               => 0,
            "Anywhere"              => 0,
            "Lacs Vanilla"          => 2,
            "Lacs Stones"           => int.Parse((string)values["Ganons Castle Boss Key Stones Required"]),
            "Lacs Medallions"       => int.Parse((string)values["Ganons Castle Boss Key Medallions Required"]),
            "Lacs Dungeon Rewards"  => int.Parse((string)values["Ganons Castle Boss Key Dungeon Rewards Required"]),
            "Lacs Dungeons"         => int.Parse((string)values["Ganons Castle Boss Key Dungeons Required"]),
            "Lacs Tokens"           => int.Parse((string)values["Ganons Castle Boss Key Skull Tokens Required"]),
            _ => throw new KeyNotFoundException($"Cannont find key \"{values["Ganons Castle Boss Key"]}\" in the dictionnary for {this.GetType().Name}")
        };
    }
}
