using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;

namespace TwinShop.BLL.Services.Interfaces
{
    public interface IErrorService
    {
        Task<OperationResult> LogErrorAsync(ErrorLogDTO error);
    }
}
