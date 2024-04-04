using System.ComponentModel.DataAnnotations;

namespace CatalogAPI.Validations
{
    public class FirstLetterUpperValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if((value == null) || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var FirstLetter = value.ToString()[0].ToString();
            if(FirstLetter != FirstLetter.ToUpper())
            {
                return new ValidationResult("First letter must be to upper");
            }

            return ValidationResult.Success;
        }

        
    }
}
