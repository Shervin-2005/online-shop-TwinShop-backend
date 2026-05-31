using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.Shared.Custom_Exceptions
{
    public class ValidationException : AppException
    {
        public IEnumerable<string> Errors { get; }
        public ValidationException(IEnumerable<string> errors)
            :base("Validation failed", 400)
            => Errors = errors;
    }
}
