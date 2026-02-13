using NoNiDev.SpoilerArchipelagoParser.Options.Converter;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Attributes
{
    /// <summary>
    /// Attribute for converte value of a property to another type using a converter class that implements IConverter<T, U>
    /// </summary>
    /// <param name="convertType">The type of converter</param>
    [AttributeUsage(AttributeTargets.Property)]
    public class ConvertValueAttribute (Type convertType) : Attribute
    {
        public Type ConverterType { get; set; } = convertType;
    }

    //[AttributeUsage(AttributeTargets.Property)]
    //public class ConvertValueAttributeold<T, U>(Type convertType) : ConvertValueBaseAttribute
    //{
    //    public Type ConverterType { get; set; } = convertType;

    //    public IConverter<T, U>? Converter
    //    {
    //        get
    //        {
    //            if (ConverterType == null)
    //            {
    //                throw new InvalidOperationException("Converter Type cannot be null.");
    //            }
    //            if (!typeof(IConverter<T, U>).IsAssignableFrom(ConverterType))
    //            {
    //                throw new InvalidOperationException($"Converter Type must implement IConverter<{typeof(T).Name}, {typeof(U).Name}>.");
    //            }
    //            return Activator.CreateInstance(ConverterType) as IConverter<T, U>;
    //        }
    //    }
    //}

    //[AttributeUsage(AttributeTargets.Property)]
    //public class ConvertValue2Attribute(Type convertType) : Attribute
    //{
    //    public Type ConverterType { get; set; } = convertType;

    //    public IConverter2? Converter
    //    {
    //        get
    //        {
    //            if (ConverterType == null)
    //            {
    //                throw new InvalidOperationException("Converter Type cannot be null.");
    //            }
    //            if (!typeof(IConverter2).IsAssignableFrom(ConverterType))
    //            {
    //                throw new InvalidOperationException($"Converter Type must implement IConverter2.");
    //            }
    //            return Activator.CreateInstance(ConverterType) as IConverter2;
    //        }
    //    }
    //}

    //public abstract class ConvertValueBaseAttribute : Attribute
    //{
    //    //public IConverter2? Converter;
    //}
}
