using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NQ.Core.Validation
{
    /// <summary>
    /// Used to validate whether model property contains property name of provided type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ClassPropertyAttribute : ValidationAttribute
    {
        Type _type;

        public ClassPropertyAttribute(Type type)
        {
            _type = type;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != default)
            {
                var castedValue = value as string;
                var propNamesToCheck = _type.GetProperties().Select(x => x.Name);

                if (propNamesToCheck.Any(x => x.Equals(castedValue, StringComparison.OrdinalIgnoreCase)))
                    return ValidationResult.Success;
                else
                    return new ValidationResult($"'{validationContext.MemberName}' parameter should be one of '{string.Join(", ", propNamesToCheck)}'.");
            }

            return ValidationResult.Success;
        }
    }
}
