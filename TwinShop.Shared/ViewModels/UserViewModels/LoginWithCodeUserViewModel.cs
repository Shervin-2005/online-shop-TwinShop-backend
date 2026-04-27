using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.CustomAtribute;
using TwinShop.Shared.ViewModels.Base;

namespace TwinShop.Shared.ViewModels.UserViewModels
{
    public class LoginWithCodeUserViewModel : BaseValidatoin
    {
        public int Id { get; set; }
        [PhoneNumberValidationAtribute]
        public string? PhoneNumber { get; set; }

        public string? Code { get; set; }

    }
}
