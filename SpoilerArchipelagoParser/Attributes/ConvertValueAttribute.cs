using NoNiDev.SpoilerArchipelagoParser.Options.Converter;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConvertValueAttribute <T, U>(Type convertType) : Attribute
    {
        public Type ConverterType { get; set; } = convertType;

        public IConverter<T, U>? Converter 
        {
            get
            {
                if (ConverterType == null)
                {
                    throw new InvalidOperationException("Converter Type cannot be null.");
                }
                if (!typeof(IConverter<T, U>).IsAssignableFrom(ConverterType))
                {
                    throw new InvalidOperationException($"Converter Type must implement IConverter<{typeof(T).Name}, {typeof(U).Name}>.");
                }
                return Activator.CreateInstance(ConverterType) as IConverter<T, U>;
            }
        }
    }
}
