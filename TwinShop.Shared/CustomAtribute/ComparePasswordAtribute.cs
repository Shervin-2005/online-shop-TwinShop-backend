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
           // var otherProperty = validationContext.ObjectType.GetProperty("VerifyPassword");
          //  var otherValue = otherProperty.GetValue(validationContext.ObjectInstance);
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(Messages.EnterPassword);

           // if (!value.Equals(otherValue))
            //    return new ValidationResult(Messages.PasswordNotMatch);
            return ValidationResult.Success;

        }
    }
}
