using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.BLL.Services.Interfaces;

namespace TwinShop.BLL.Services.Implementations
{

    public class VerificationCodeService : IVerificationCodeService
    {
        private static Dictionary<string, string> _verificationCodes = new Dictionary<string, string>();

        public void SendVerificationCode(string phoneNumber)
        {
            // Generate a 4-digit code
            string verificationCode = GenerateVerificationCode();

            // Store the verification code locally in memory
            _verificationCodes[phoneNumber] = verificationCode;
        }

        public bool VerifyCode(string phoneNumber, string providedCode)
        {
            if (_verificationCodes.ContainsKey(phoneNumber) && _verificationCodes[phoneNumber] == providedCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(1000, 10000).ToString(); // Generates a random 4-digit code
        }
    }
}
