using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SpoilerNameAttribute (string name): Attribute
    {
        public string SpoilerName { get; } = name;
    }
}
