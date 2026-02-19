using NoNiDev.SpoilerArchipelagoParser.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RestrictEnumValuesAttribute<T> : RestrictValuesBaseAttribute where T : Enum
    {
        public override bool IsValid(string value)
        {
            
            List<string> names;
            if (value is string str)
            {
                names = Enum.GetNames(typeof(T)).Select(x=> x.Replace("_", " ", StringComparison.OrdinalIgnoreCase)).ToList();
                if (names.Any(n => n.Equals(str, StringComparison.OrdinalIgnoreCase)))
                {
                    return true;
                }
            }

            return false;
        }
    }
    public class RestrictIntValuesAttribute : RestrictValuesBaseAttribute
    {
        public override bool IsValid(string value)
        {
            return int.TryParse(value, out _);
        }
    }
    public class RestrictBoolValuesAttribute : RestrictEnumValuesAttribute<EYesNo>
    {
    }


    public abstract class RestrictValuesBaseAttribute : Attribute
    {
        public abstract bool IsValid(string value);
    }
}
