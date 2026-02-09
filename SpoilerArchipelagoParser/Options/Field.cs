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
        public Func<string, string, string> Convert = (s, s2) => s;
    }
}
