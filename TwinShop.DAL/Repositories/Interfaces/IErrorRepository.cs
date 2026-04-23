using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IErrorRepository
    {
        Task<OperationResult> LogErrorAsync(ErrorLogDTO error);
    }
}
