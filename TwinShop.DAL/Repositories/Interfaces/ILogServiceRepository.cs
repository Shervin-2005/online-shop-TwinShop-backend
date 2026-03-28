using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface ILogServiceRepository
    {
        public Task<OperationResult> SaveFailedLogAsync(Exception? ex);
    }
}
