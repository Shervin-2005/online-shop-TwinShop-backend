using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.BLL.Services.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;

namespace TwinShop.BLL.Services.Implementations
{
    public class ErrorService : IErrorService
    {
        public readonly IErrorRepository _errorRepository;
        public ErrorService(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }
        public async Task<OperationResult> LogErrorAsync(ErrorLogDTO error)
        {
            var result = await _errorRepository.LogErrorAsync(error);
            return result;
        }

    }

}