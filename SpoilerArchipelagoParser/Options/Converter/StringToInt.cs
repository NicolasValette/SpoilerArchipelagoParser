using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter
{
    public class StringToInt : IConverter<string, int>
    {
        public int Convert(string value)
        {
            if (int.TryParse(value, out int result))
                return result;
            else
                throw new ArgumentException($"Cannot convert '{value}' to int. Expected integer string.");
        }
    }

    public class YesNoToBool : IConverter<string, bool>
    {
        public bool Convert(string value)
        {
            if (value.Equals("yes", StringComparison.OrdinalIgnoreCase))
                return true;
            else if (value.Equals("no", StringComparison.OrdinalIgnoreCase))
                return false;
            else
                throw new ArgumentException($"Cannot convert '{value}' to bool. Expected 'yes' or 'no'.");
        }
    }
    public class YesNoToVanillaShuffled : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Yes" => "Shuffled",
            "No" => "Vanilla",
            _ => "unknown"
        };
    }
    public class YesNoToAddedWithout : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Yes" => "Added",
            "No" => "Without",
            _ => "unknown"
        };
    }
    public class YesNoToStartWithShuffled : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Yes" => "Shuffled",
            "No" => "Start with",
            _ => "unknown"
        };
    }
    public class BombchuBagConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "None" => "Vanilla",
            "Single Bag" => "Single Bag",
            "Progressive Bags" => "Three Bags",
            _ => "unknown"
        };
    }
    public class AdultTradeConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Yes" => "All Items",
            "No" => "Only Claim Check",
            _ => "unknown"
        };
    }
    public class MerchantConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Off" => "Off",
            "Bean Merchant Only" => "Only Beans",
            "All But Beans" => "All But Beans",
            "All" => "All",
            _ => "unknown"
        };
    }
    public class InfiniteUpgradesConverter : IConverter<string, string>
    {
        public string Convert(string spoilerValue) => spoilerValue switch
        {
            "Off" => "Off",
            "Progressive" => "Progressive",
            "Condensed Progressive" => "Condensed",
            _ => "unknown"
        };
    }

}
