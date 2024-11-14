using System.ComponentModel.DataAnnotations;
using System.Numerics;


namespace WebApplication2.Models
{
    public class PersonIValidateInterface : IValidatableObject
    {
        public string? PersonName { get; set; }
        public int? Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PersonName == null)
            {
                yield return new ValidationResult("PersonName must be supplied", [nameof(PersonName)]);
            }
            if (Age.HasValue == false)
            {
                yield return new ValidationResult("Age should be supplied", [nameof(Age)]);
            }
        }

        public override string ToString()
        {
            return $"Person object - Person name: {PersonName}, Age: {Age}";
        }
    }
}
