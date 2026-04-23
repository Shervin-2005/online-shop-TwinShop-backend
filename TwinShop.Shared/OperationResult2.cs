using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.Shared
{
    public class OperationResult<t> : OperationResult
    {
        public t Data { get; set; }
        public static OperationResult<t> SuccessedResult(
             t data, string message = "")
        {
            return new OperationResult<t>
            {
                Success = true,
                Message = message,
                Data = data,
            };
        }
        public static OperationResult<t> Failed(
           string message = "", Exception? ex = null)
        {
            return new OperationResult<t>
            {
                Success = false,
                Message = message,
                Exception = ex,
            };
        }
       
    }
}
