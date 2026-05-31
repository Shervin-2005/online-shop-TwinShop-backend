using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.Shared.Custom_Exceptions
{
    public class DatabaseException : AppException
    {
        public DatabaseException(string message ,Exception innerException)
        :base(message, 500, innerException) { } 
    }
}
