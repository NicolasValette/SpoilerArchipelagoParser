using NoNiDev.SpoilerArchipelagoParser.Options.Converter;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConvertValueAttribute (IConverter _convert): Attribute
    {
        public IConverter ConvertValue { get; set; } = _convert;
    }
}
