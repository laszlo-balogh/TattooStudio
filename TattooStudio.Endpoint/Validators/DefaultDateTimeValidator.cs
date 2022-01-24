using System;
using System.ComponentModel.DataAnnotations;

namespace TattooStudio.Endpoint.Validators
{
    public class DefaultDateTimeValidatorAttribute : ValidationAttribute
    {

        public override string FormatErrorMessage(string name)
        {
            return "The Born Date field cannot be empty or default";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;

            if (dt == default)
            {
                return new ValidationResult(FormatErrorMessage(null));
            }
            else
            {
                return ValidationResult.Success;
            }

        }

    }
}
