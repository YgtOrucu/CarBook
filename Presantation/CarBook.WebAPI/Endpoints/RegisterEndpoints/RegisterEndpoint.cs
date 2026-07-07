using CarBook.WebAPI.Endpoints.AboutEndpoints;
using CarBook.WebAPI.Endpoints.BannerEndpoints;
using CarBook.WebAPI.Endpoints.BrandEndpoints;

namespace CarBook.WebAPI.Endpoints.RegisterEndpoints
{
    public static class RegisterEndpoint
    {
        public static void AppRegisterEndpoint(this IEndpointRouteBuilder app)
        {
            app.AppCategoryEndpoint();
            app.AppBannerEndpoint();
            app.AppBrandEndpoint();
        }
    }
}
