using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ComboValueAttribute : Attribute
    {
        public string spoilerValue1 { get; set; } = string.Empty;
        public string spoilerValue2 { get; set; } = string.Empty;
        public Func<string, string, string> GetConvertedValue { get; set; } = (v1, v2) => $"{v1} {v2}";
    }
}
