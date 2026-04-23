using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.Shared
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }

        public static OperationResult SuccessedResult(bool success = true,
            string message = "")
        {
            return new OperationResult
            {
                Success = success,
                Message = message,
            };

        }
        public static OperationResult Failed(
            string message = "", Exception? ex = null)
        {
            return new OperationResult
            {
                Success = false,
                Message = message,
                Exception = ex,
            };
        }
       
    }
}
