using System.ComponentModel.DataAnnotations;

namespace TwinShop.DAL.Entities
{
    public class OTP
    {
        public int Id { get; set; }

        [Required]
        public string Mobile { get; set; } = null!;

        [Required]
        public string Code { get; set; } = null!;

        public DateTime ExpireTime { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
