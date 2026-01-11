using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.SOHOptions
{
    public class SOHPlayerOptions(string playerName, Dictionary<string, string> options)
    {
        public string PlayerName { get; set; } = playerName;
        public Dictionary<string, string> Options { get; set; } = options;
    }
}
