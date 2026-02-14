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
}
