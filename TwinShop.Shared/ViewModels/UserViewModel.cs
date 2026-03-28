using System.ComponentModel.DataAnnotations;
using TwinShop.Shared.CustomAtribute;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ViewModels.Base;

namespace TwinShop.Shared.ViewModels
{
    public class UserViewModel:BaseValidatoin
    {
        [MaxLength(50, ErrorMessage = Messages.firstNameInvalid2)]
        [MinLength(3, ErrorMessage = Messages.firstNameInvalid1)]
        public string? FirstName { get; set; }

        [MaxLength(50, ErrorMessage = Messages.lastNameInvalid2)]
        [MinLength(2, ErrorMessage = Messages.lastNameInvalid1)]

        public string? LastName { get; set; }

        public string ProflileImage { get; set; }
        [PhoneNumberValidationAtribute]
        public string PhoneNumber { get; set; }

        //   [OptionalEmailAtribute]
        public string? Email { get; set; }
        [ComparePasswordAtribute]
        public string? Password { get; set; }
       // public string? VerifyPassword { get; set; }

    }
}
