using CarBook.WebAPI.Endpoints.AboutEndpoints;
using CarBook.WebAPI.Endpoints.AuthEndpoints;
using CarBook.WebAPI.Endpoints.AuthorEndpoints;
using CarBook.WebAPI.Endpoints.BannerEndpoints;
using CarBook.WebAPI.Endpoints.BlogDetailEndpoints;
using CarBook.WebAPI.Endpoints.BlogEndpoints;
using CarBook.WebAPI.Endpoints.BlogTagEndpoints;
using CarBook.WebAPI.Endpoints.BrandEndpoints;
using CarBook.WebAPI.Endpoints.CarCarPricingEndpoints;
using CarBook.WebAPI.Endpoints.CarEndpoints;
using CarBook.WebAPI.Endpoints.CategoryEndpoints;
using CarBook.WebAPI.Endpoints.CommentEndpoints;
using CarBook.WebAPI.Endpoints.ContactEndpoints;
using CarBook.WebAPI.Endpoints.FeatureEndpoints;
using CarBook.WebAPI.Endpoints.FooterAddressEndpoints;
using CarBook.WebAPI.Endpoints.LocationEndpoints;
using CarBook.WebAPI.Endpoints.PricingEndpoints;
using CarBook.WebAPI.Endpoints.ServicesEndpoints;
using CarBook.WebAPI.Endpoints.SocialMediaEndpoints;
using CarBook.WebAPI.Endpoints.TagEndpoints;
using CarBook.WebAPI.Endpoints.TestimonialEndpoints;

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
            app.AppServicesEndpoint();
            app.AppSocialMediaEndpoint();
            app.AppTestimonialEndpoint();
            app.AppAuthorEndpoint();
            app.AppBlogEndpoint();
            app.AppBlogDetailEndpoint();
            app.AppTagEndpoint();
            app.AppBlogTagEndpoint();
            app.AppCommentEndpoint();
            app.AppCarPricingEndpoint();
            app.AppAuthsEndpoint();
        }
    }
}
