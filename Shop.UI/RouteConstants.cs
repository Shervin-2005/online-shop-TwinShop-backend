
namespace Shop.UI
{
    public class RouteConstants
    {
        public const string BaseUrl = "https://localhost:7231/";

        public const string LoginRoute = "api/Auth/Login";
        public const string RegisterRoute = "api/Auth/Register";
        public const string GetbyPhoneNumber = "api/Auth/GetbyPhoneNumber";
        public const string GetbyEmail = "api/Auth/GetbyEmail";

        public const string GetBrandAll = "api/Brands/GetAll";
        public const string GetById = "api/Brands/GetById";
        public const string Delete = "api/Brands/Delete";
        public const string GetBrandsByName = "api/Brands/GetBrandsByName";
        public const string GetBrandsByCategoryName = "api/Brands/GetBrandsByCategoryName";
        public const string Create = "api/Brands/Create";

    }
}
