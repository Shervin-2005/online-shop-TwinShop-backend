
using System.ComponentModel.DataAnnotations;


namespace TwinShop.Shared.DTOS.Auth
{
    public class UserDto
    {
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }

        public string ProflileImage { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

    }
}
