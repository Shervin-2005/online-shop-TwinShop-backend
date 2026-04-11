using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.DTOS;

namespace TwinShop.Shared.CustomAtribute
{
    public class PhoneNumberValidationAtribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(MessagesAndConsts.Mandatory);
            if (value.ToString()!.Length < 11)
                return new ValidationResult(MessagesAndConsts.NumberInvalid1);
            if (value.ToString()!.Length > 11)
                return new ValidationResult(MessagesAndConsts.numberInvalid2);
            if (!value.ToString()!.StartsWith("09"))
                return new ValidationResult(MessagesAndConsts.numberInvalid2);
            return ValidationResult.Success!;
        }
    }
}
