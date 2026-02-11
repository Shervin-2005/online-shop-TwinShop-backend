using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UI
{
    public class RouteConstants
    {
        public const string BaseUrl = "https://localhost:7231/";
        public const string LoginRoute = "api/Auth/Login";
        public const string GetBrandById = "api/Brands/GetById?id={0}";
    }
}
