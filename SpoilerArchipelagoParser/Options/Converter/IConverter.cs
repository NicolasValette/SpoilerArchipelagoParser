using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter
{
    public interface IConverter
    {
        public string Convert(string spoilerValue);
    }
}
