using CarBook.WebAPI.Endpoints.AboutEndpoints;
using CarBook.WebAPI.Endpoints.BannerEndpoints;
using CarBook.WebAPI.Endpoints.BrandEndpoints;
using CarBook.WebAPI.Endpoints.CarEndpoints;
using CarBook.WebAPI.Endpoints.CategoryEndpoints;
using CarBook.WebAPI.Endpoints.ContactEndpoints;
using CarBook.WebAPI.Endpoints.FeatureEndpoints;
using CarBook.WebAPI.Endpoints.FooterAddressEndpoints;
using CarBook.WebAPI.Endpoints.LocationEndpoints;
using CarBook.WebAPI.Endpoints.PricingEndpoints;

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
            app.AppFeatureEndpoint();
            app.AppFooterAddressEndpoint();
            app.AppLocationEndpoint();
            app.AppPricingEndpoint();
        }
    }
}
