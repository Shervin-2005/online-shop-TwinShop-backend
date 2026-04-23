using System.ComponentModel.DataAnnotations;
using TwinShop.Shared.CustomAtribute;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ViewModels.Base;

namespace TwinShop.Shared.ViewModels.UserViewModels
{
    public class UserViewModel:BaseValidatoin
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = MessagesAndConsts.firstNameInvalid2)]
        [MinLength(3, ErrorMessage = MessagesAndConsts.firstNameInvalid1)]
        public string? FirstName { get; set; }

        [MaxLength(50, ErrorMessage = MessagesAndConsts.lastNameInvalid2)]
        [MinLength(2, ErrorMessage = MessagesAndConsts.lastNameInvalid1)]

        public string? LastName { get; set; }

        public string? ProfileImage { get; set; }

        [PhoneNumberValidationAtribute]
        public string? PhoneNumber { get; set; }

        //   [OptionalEmailAtribute]
        public string? Email { get; set; }
        [ComparePasswordAtribute]
        public string? Password { get; set; }
        public string? RepeatPassword { get; set; }

    }
}
