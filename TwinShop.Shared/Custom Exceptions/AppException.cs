using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.Shared.Custom_Exceptions
{
    public abstract class AppException : Exception
    {
        public int StatusCode {  get; }

        protected AppException(string message, int statusCode) : base(message)
            => StatusCode = statusCode;
        
        protected AppException(string message, int statusCode, Exception? innerException)
            : base(message, innerException) => StatusCode = statusCode;
    }
}
