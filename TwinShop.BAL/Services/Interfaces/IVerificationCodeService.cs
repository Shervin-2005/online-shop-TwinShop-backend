using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.BLL.Services.Interfaces
{
    public interface IVerificationCodeService
    {
        void SendVerificationCode(string phoneNumber);
        bool VerifyCode(string phoneNumber,string providedCode);
    }
}
