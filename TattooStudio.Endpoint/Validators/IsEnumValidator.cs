using System;
using System.ComponentModel.DataAnnotations;
using TattooStudio.Models;

namespace TattooStudio.Endpoint.Validators
{
    public class IsEnumValidatorAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "The 'Sample' type must be enum";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var v = Enum.GetValues<Samples>();

            if (Enum.TryParse<Samples>(value.ToString(),out Samples result))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(FormatErrorMessage(null));
            }
        }

    }
}
