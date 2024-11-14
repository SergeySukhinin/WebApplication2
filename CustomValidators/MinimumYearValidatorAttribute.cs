using System.ComponentModel.DataAnnotations;

namespace WebApplication2.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessage { get; set; } = "Year should not be newer than {0}";
        public MinimumYearValidatorAttribute() { }
        public MinimumYearValidatorAttribute(int minimumYear) {
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime? date = (DateTime)value;
                if (date.Value.Year >= MinimumYear)
                {
                    //return new ValidationResult(ErrorMessage);    //without supplying minimum year
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));   //if error message is not supplied than Default Error Message would be placed
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
