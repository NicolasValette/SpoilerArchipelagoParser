using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter
{
    public interface IConverter <T, U>
    {
        public U Convert(T value);
    }
}
