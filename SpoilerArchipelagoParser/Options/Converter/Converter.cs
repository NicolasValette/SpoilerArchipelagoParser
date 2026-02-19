using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter
{
    public class GregConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Off" => "Without",
            "Reward" => "Joker Logique",
            "Wildcard" => "Joker",
            _ => "unknown"
        };


    }
    public class LockOverworldConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Yes" => "Closed",
            "No" => "Open",
            _ => "unknown"
        };
    }
    public class SkipTrialsConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Yes" => "None",
            "No" => "All",
            _ => "unknown"
        };
    }
    public class CarpentersConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Normal" => "All prisoners",
            "Fast" => "One prisoner",
            "Free" => "All free",
            _ => "unknown"
        };
    }
    public class LocationConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "All" => $"Everywhere",
            "Dungeon" => "Dungeons",
            _ => spoilerValue
        };
    }
    public class BossSoulsConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "On" => "All Except Ganon",
            "Off" => "None",
            "On Plus Ganons" => "All Bosses",
            _ => "unknown"
        };
    }
    public class GanonBossKeyConditionConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Lacs Vanilla"          => "LACS Vanilla"        ,
            "Lacs Stones"           => "LACS Stones"         ,
            "Lacs Medallions"       => "LACS Medallions"     ,
            "Lacs Dungeon Rewards"  => "LACS Dungeon Rewards",
            "Lacs Dungeons"         => "LACS Dungeons"       ,
            "Lacs Skull Tokens"     => "LACS Tokens",
            _ => spoilerValue
        };
    }
    public class ScrubsCoverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Off" => "None",
            _ => spoilerValue
        };
    }
    public class RainbowBridgeConditionCoverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Always Open" => "Open",
            _ => spoilerValue
        };
    }
    public class ZoraFountainCoverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Closed As Child" => "Closed for Child",
            _ => spoilerValue
        };
    }

}
