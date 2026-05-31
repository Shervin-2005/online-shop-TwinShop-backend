using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.Shared.Custom_Exceptions
{
    public class FileValidationException : AppException
    {
        public FileValidationException(string message)
            : base (message, 400) { }
    }
}
