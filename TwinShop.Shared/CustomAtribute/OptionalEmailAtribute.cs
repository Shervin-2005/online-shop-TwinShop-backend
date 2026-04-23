using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.DTOS;

namespace TwinShop.Shared.CustomAtribute
{
    public class OptionalEmailAtribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string email || string.IsNullOrWhiteSpace(email))
                return ValidationResult.Success;

            try
            {
                var a = new MailAddress(email.Trim());
                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult(MessagesAndConsts.EmailInvalid);
            }
        }
    }
}
