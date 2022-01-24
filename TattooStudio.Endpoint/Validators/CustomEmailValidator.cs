using System.ComponentModel.DataAnnotations;
using TattooStudio.Endpoint.DTOs;
using TattooStudio.Models;

namespace TattooStudio.Endpoint.Validators
{
    public class CustomEmailValidatorAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Invalid e-mail format. Correct: email@email.com";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string customer = value.ToString();

            //CustomerDto customer = value as CustomerDto;

            if (value == null)
            {
                return new ValidationResult(FormatErrorMessage(null));
            }
            else if (customer.Contains('@'))
            {
                string[] array = customer.Split('@');
                if (array.Length > 2)
                {
                    return new ValidationResult(FormatErrorMessage(null));
                }
                else if (!array[1].Contains('.'))
                {
                    return new ValidationResult(FormatErrorMessage(null));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult(FormatErrorMessage(null));
            }
        }

    }
}
