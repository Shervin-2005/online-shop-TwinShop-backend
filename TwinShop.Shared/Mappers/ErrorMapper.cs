using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.DTOS;

namespace TwinShop.Shared.Mappers
{
    public static class ErrorMapper
    {
        public static ErrorLogDTO ExceptionToErrorDTO(this Exception ex, string layer)
        {
            return new ErrorLogDTO
            {
                Layer = layer,
                Message = ex.InnerException?.Message ?? ex.Message,
                Source = ex.Source,
                StackTrace = ex.StackTrace
            };
        }
    }
}
