using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.DTOS;

namespace TwinShop.Shared.CustomAtribute
{
    public class SecondryPriceValidationAtribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(Messages.ProductSecondryPrice);
            int secondryPrice;
            if (!int.TryParse(value.ToString(), out secondryPrice))
                return new ValidationResult(Messages.ValidProductPrice);
            if (secondryPrice == 0)
                return new ValidationResult(Messages.ProductSecondryPrice);
            return ValidationResult.Success;
        }
    }
}
