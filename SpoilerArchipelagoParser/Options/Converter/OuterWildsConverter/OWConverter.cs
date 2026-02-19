using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter.OuterWildsConverter
{

    public class GoalOWConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Song Of Five" => "Song of Five",
            "Song Of the Nomai" => "Song of the Nomai",
            "Song Of the Stranger" => "Song of the Stranger",
            "Song Of Six" => "Song of Six",
            "Song Of Seven" => "Song of Seven",
            "Echoes Of the Eye" => "Echoes of the Eye",
            _ => "unknown"
        };
    }
    public class SpawnConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Vanilla" => "Vanilla",
            "Hourglass Twins" => "Sablières",
            "Timber Hearth" => "Âtrebois",
            "Brittle Hollow" => "Cravité",
            "Giants Deep" => "Léviathe",
            "Stranger" => "L'Etranger",
            "Random non Vanilla" => "Random non-vanilla",
            "Deep Bramble" => "Sombronces",
            _ => "unknown"
        };
    }
    public class YesNoToRandomVanilla : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Yes" => "Randomized",
            "No" => "Vanilla",
            _ => "unknown"
        };
    }
    public class DarkBrambleLayoutConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "True" => "Randomized",
            "False" => "Vanilla",
            "Hub Start" => "Randomized But Entrance",
            _ => "unknown"
        };
    }
}
