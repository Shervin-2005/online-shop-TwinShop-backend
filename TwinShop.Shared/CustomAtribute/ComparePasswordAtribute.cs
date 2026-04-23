using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.DTOS;

namespace TwinShop.Shared.CustomAtribute
{
    public class ComparePasswordAtribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty("RepeatPassword");
            var otherValue = otherProperty.GetValue(validationContext.ObjectInstance);
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(MessagesAndConsts.EnterPassword);

            if (!value.Equals(otherValue))
                  return new ValidationResult(MessagesAndConsts.PasswordNotMatch);
            return ValidationResult.Success;

        }
    }
}
