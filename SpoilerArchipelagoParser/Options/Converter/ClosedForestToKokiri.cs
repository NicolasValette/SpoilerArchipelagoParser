using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter
{
    public class ClosedForestToKokiri : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "On" => "Closed",
            "Deku only" => "Open",
            "Off" => "Open",
            _ => "unknown"
        };
       
    }
}