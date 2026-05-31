using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.Shared.Custom_Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException(string resource,int id)
              : base($"{resource} with id {id} not found.", 404) { }
    }
}
