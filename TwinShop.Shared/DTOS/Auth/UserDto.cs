using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.Shared.DTOS.Auth
{
    public class UserDto
    {
        [StringLength(50)]
        public string? FirstName { get; set; }
        

        [StringLength(50)]
        public string? LastName { get; set; }


        [Phone]
        [StringLength(15)]
        [Required]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

    }
}
