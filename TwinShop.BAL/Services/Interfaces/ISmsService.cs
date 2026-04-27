using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared;
using TwinShop.Shared.ViewModels;
using TwinShop.Shared.ViewModels.UserViewModels;

namespace TwinShop.BLL.Services.Interfaces
{
    public interface ISmsService
    {
        Task<OperationResult> SendOtp(string mobile);
        Task<OperationResult> VerifyOtp(LoginWithCodeUserViewModel loginWithCodeUserViewModel);
    }
}
