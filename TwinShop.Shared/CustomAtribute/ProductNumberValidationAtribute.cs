
using System.ComponentModel.DataAnnotations;
using TwinShop.Shared.DTOS;

namespace TwinShop.Shared.CustomAtribute
{
    public class ProductNumberValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(Messages.ProductNumber);
            int number;
            if (!int.TryParse(value.ToString(), out number))
                return new ValidationResult(Messages.ProductNumber);
            if (number < 0)
                return new ValidationResult(Messages.ProductNumber);
            return ValidationResult.Success!;


        }
    }
}
