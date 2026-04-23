using System.Security;

namespace Shop.UI.Http
{
    public class RouteConstants
    {
        public const string BaseUrl = "https://localhost:7231/";

        public const string LoginRoute = "api/Auth/LoginWithPassword";
        public const string Register = "api/Auth/Register";
        public const string EditUserInfo = "api/Auth/EditUserInfo?phoneNumber={0}";
        public const string RegisterRoute = "api/Auth/Register";
        public const string ChangePassword = "api/Auth/ChangePassword?phoneNumber={0}";
        public const string GetUserbyPhoneNumber = "api/Auth/GetUserbyPhoneNumber?phoneNumber={0}";
        public const string GetbyEmail = "api/Auth/GetbyEmail";
        public const string GetAllBrands = "api/Brands/GetAll";
        public const string GetById = "api/Brands/GetById";
        public const string DeleteBrand = "api/Brands/Delete?id={0}";
        public const string GetBrandsByName = "api/Brands/GetBrandsByName";
        public const string GetBrandsByCategoryName = "api/Brands/GetBrandsByCategoryName";
        public const string CreateBrand = "api/Brands/Create";
        public const string LogError = "api/Error/LogError";
        public const string GetAllProducts = "api/Products/GetAll";
        public const string CreateCategory = "api/Categories/Create";
        public const string GetAllCategories = "api/Categories/GetAll";
        public const string DeleteCategory = "api/Categories/Delete?id={0}";
        public const string GetCategoryByName = "api/Categories/GetCategoryByName?name={0}";
        public const string UpdateCategory = "api/Categories/Update?id={0}";
        public const string UpdateBrand = "api/Brands/Update?id={0}";
        public const string UpdateProduct = "api/Products/Update?id={0}";
        public const string SearchCategories = "api/Categories/SearchCategories?searchTerm={0}";
        public const string SearchBrands = "api/Brands/SearchBrands?searchTerm={0}";
        public const string SearchProducts = "api/Products/SearchProducts?searchTerm={0}";
        public const string DeleteProduct = "api/Products/Delete?id={0}";
        public const string CreateProduct = "api/Products/Create";
    }
}
