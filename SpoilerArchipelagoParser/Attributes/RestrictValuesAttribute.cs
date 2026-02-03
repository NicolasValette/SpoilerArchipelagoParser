using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Attributes
{
    public class RestrictValuesAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public RestrictValuesAttribute(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type must be an enum.");
            }
            _enumType = enumType;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            List<string> names;
            if (value is string str)
            {
                names = Enum.GetNames(_enumType).Select(x=> x.Replace("_", " ", StringComparison.OrdinalIgnoreCase)).ToList();
                if (names.Any(n => n.Equals(str, StringComparison.OrdinalIgnoreCase)))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult($"The value '{value}' is not valid for enum type '{_enumType.Name}'.");
        }
    }
}
