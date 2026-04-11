using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.DTOS;

namespace TwinShop.Shared.CustomAtribute
{
    public class InitialPriceValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(MessagesAndConsts.ProductInitialPrice);
            int initialPrice;
            if (!int.TryParse(value.ToString(), out initialPrice))
                return new ValidationResult(MessagesAndConsts.ValidProductPrice);
            if (initialPrice == 0)
                return new ValidationResult(MessagesAndConsts.ProductInitialPrice);
            return ValidationResult.Success;
        }
    }
}
