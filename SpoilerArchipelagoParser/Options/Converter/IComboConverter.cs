using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter
{
    public interface IComboConverter<U> : IConverter<Dictionary<string, object>, U>
    {
    }
}
