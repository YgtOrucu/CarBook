using CarBook.WebAPI.Endpoints.AboutEndpoints;
using CarBook.WebAPI.Endpoints.BannerEndpoints;
using CarBook.WebAPI.Endpoints.BrandEndpoints;
using CarBook.WebAPI.Endpoints.CarEndpoints;
using CarBook.WebAPI.Endpoints.CategoryEndpoints;
using CarBook.WebAPI.Endpoints.ContactEndpoints;

namespace CarBook.WebAPI.Endpoints.RegisterEndpoints
{
    public static class RegisterEndpoint
    {
        public static void AppRegisterEndpoint(this IEndpointRouteBuilder app)
        {
            app.AppAboutEndpoint();
            app.AppBannerEndpoint();
            app.AppBrandEndpoint();
            app.AppCarEndpoint();
            app.AppCategoryEndpoint();
            app.AppContactEndpoint();
        }
    }
}
