using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Twin_Shop__Web_API.Data;
using TwinShop.DAL.Entities;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class ErrorRepository:IErrorRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogServiceRepository _logServiceRepository;

        public ErrorRepository(AppDbContext dbContext, ILogServiceRepository logServiceRepository)
        {
            _dbContext= dbContext;
            _logServiceRepository = logServiceRepository;
        }
        public async Task<OperationResult> LogErrorAsync(ErrorLogDTO error)
        {
            ErrorLog errorLog = new ErrorLog
            {
                CreatedAt = error.CreatedAt,
                Message = error.Message,
                Source = error.Source,
                StackTrace = error.StackTrace,
                Layer = error.Layer,
                Curl = error.Curl,
                Route = error.Route
            };
            try
            {
                 
                _dbContext.ErrorLogs.Add(errorLog);
                await _dbContext.SaveChangesAsync();

                return OperationResult.Failed(errorLog.Id.ToString());
            }
            catch (Exception ex2)
            {
                var result = await _logServiceRepository.SaveFailedLogAsync(ex2);
                return OperationResult.Failed(result.Message!);
            }
        }
    }
}
