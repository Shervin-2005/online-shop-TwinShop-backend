using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.DAL.Entities
{
    public class Otp
    {
        public string? Mobile { get; set; }
        public string? Code { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
