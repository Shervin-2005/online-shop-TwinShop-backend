using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.CustomAtribute;
using TwinShop.Shared.ViewModels.Base;

namespace TwinShop.Shared.ViewModels.UserViewModels
{
    public class RegisterUserViewModel:BaseValidatoin
    {
        [PhoneNumberValidationAtribute]
        public string? PhoneNumber { get; set; }
        [ComparePasswordAtribute]
        public string? Password { get; set; }
        public string? RepeatPassword { get; set; }
    }
}
