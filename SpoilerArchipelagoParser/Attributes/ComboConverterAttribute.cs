using NoNiDev.SpoilerArchipelagoParser.Options.Converter;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ComboConverterAttribute<U> (string[] values, Type convertType) : Attribute
    {
        public string[] Values { get; set; } = values;
        public Type ConverterType { get; set; } = convertType;

        public IComboConverter<U>? Converter
        {
            get
            {
                if (ConverterType == null)
                {
                    throw new InvalidOperationException("Converter Type cannot be null.");
                }
                if (!typeof(IComboConverter<U>).IsAssignableFrom(ConverterType))
                {
                    throw new InvalidOperationException($"Converter Type must implement IConverter<{typeof(string).Name}, {typeof(string).Name}>.");
                }
                return Activator.CreateInstance(ConverterType) as IComboConverter<U>;
            }
        }
    }
}
