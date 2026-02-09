using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter
{
    public class ClosedForestToKokiri : IConverter
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "on" => "Closed",
            "deku only" => "Open",
            "off" => "Open",
            _ => "unknown"
        };
    }
}