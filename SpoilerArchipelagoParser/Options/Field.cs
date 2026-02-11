using NoNiDev.SpoilerArchipelagoParser.Options.Converter;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options
{
    public class Field
    {
        public PropertyInfo? Property;
        public string SpoilerName = string.Empty;
        public Func<bool> IsValid = () => true;
        public IConverter<string, string>? Converter;
    }
    public class ComboField
    {
        public PropertyInfo? Property;
        public string[] SpoilerNames = Array.Empty<string>();
        public Func<bool> IsValid = () => true;
        public IComboConverter<string>? Converter;
    }
}
