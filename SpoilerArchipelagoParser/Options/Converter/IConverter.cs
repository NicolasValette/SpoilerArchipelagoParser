using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Options.Converter
{
    /// <summary>
    /// Provide method to convert object type Tinput to type Uoutput
    /// </summary>
    /// <typeparam name="Tinput">The initial type</typeparam>
    /// <typeparam name="Uoutput">The expected type</typeparam>
    public interface IConverter <in Tinput, out Uoutput>
    {
        public Uoutput Convert(Tinput value);
    }
    //public interface IConverter2
    //{
    //    public object Convert(object value);
    //}
}
