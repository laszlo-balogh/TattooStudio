using System.ComponentModel.DataAnnotations;

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
            if (value.GetType().IsEnum)
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
