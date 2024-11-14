using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication2.CustomValidators;

namespace WebApplication2.Models
{
    public class Person
        //[ValidateNever] - can be used to temporary exclude this field from a validitation
        // if ErrorMessage is not provided then a default error message would be placed. The same works when using custom validator classes. You may predefine default error messages (by defining inside validator classes)
    {
        [Required(ErrorMessage = "{0} can't be null or empty.")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphabets, space and dot (.)")]
        public string? PersonName { get; set; }
        [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "{0} shoud contain only 10 digits")]
        public string? Phone { get; set; }
        [Required(ErrorMessage ="{0} can't be blank")]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword { get; set; }
        [Range(0, 999.99, ErrorMessage = "{0} should be between ${1} and ${2}")]
        public double? Price { get; set; }
        //[MinimumYearValidator(2005, ErrorMessage = "Date of birth should not be newer than Jan 01, {0}")]   //2005 - is supplied minimum year. Without mentioning it explicitly, by default it would be taken 2000 as mentioned in MinimumYearValidatorAttributes class
        [MinimumYearValidator(2005)]    //error message is not supplied, default error message will be placed. If minimum year is not provided then the default minimum year will be provided that is defined in MinimumYearValidatorAttributes class
        public DateTime? DateOfBirth { get; set; }


        public DateTime? FromDate { get; set; }

        [DateRangeValidatorAttribute("FromDate", ErrorMessage = "'FromDate' should be older or equal to 'ToDate'")]
        public DateTime? ToDate { get; set; }


        public override string ToString()
        {
            return $"Person object - Person name: {PersonName}, Email: {Email}, Phone: {Phone}," +
                $"Password: {Password}, ConfirmPassword: {ConfirmPassword}, Price: {Price}";
        }
    }
}
