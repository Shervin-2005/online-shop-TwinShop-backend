using Microsoft.AspNetCore.Mvc;
using TwinShop.BLL.Services.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;

namespace Twin_Shop__Web_API.Controllers
{
    public class ErrorController : BaseController
    {
        public readonly IErrorService _errorService;
        public ErrorController(IErrorService errorService)
        {
            _errorService = errorService;
        }
        [HttpPost]
        public async Task<OperationResult> LogErrorAsync([FromBody] ErrorLogDTO error)
        {
            var result = await _errorService.LogErrorAsync(error);
            return result;
        }
    }
}
