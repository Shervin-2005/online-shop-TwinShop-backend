using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.DTOS;

namespace TwinShop.Shared.ErrorHandling
{
    public static class CreateErrorMessage
    {
        public static string ErrorMessage(this string message)
        {
            return string.Format($"{Messages.error}{Environment.NewLine}{Messages.codeError}{message}");

        }
    }
}
