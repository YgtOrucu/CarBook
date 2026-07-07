using CarBook.Application.Features.CQRS.Handlers.AboutHandler;
using CarBook.Application.Features.CQRS.Handlers.BannerHandler.Read;
using CarBook.Application.Features.CQRS.Handlers.BannerHandler.Write;
using CarBook.Application.Features.CQRS.Handlers.BrandHandler;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Application.Extensions;

public static class ServiceRegistrations
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<CreateAboutCommandHandle>();
        services.AddScoped<GetAboutByIdQueryHandle>();
        services.AddScoped<GetAboutQueryHandle>();
        services.AddScoped<UpdateAboutCommandHandle>();
        services.AddScoped<RemoveAboutCommandHandle>();


        services.AddScoped<CreateBannerCommandHandle>();
        services.AddScoped<GetBannerByIdQueryHandle>();
        services.AddScoped<GetBannerQueryHandle>();
        services.AddScoped<UpdateBannerCommandHandle>();
        services.AddScoped<RemoveBannerCommandHandle>();

        services.AddScoped<CreateBrandCommandHandle>();
        services.AddScoped<GetBrandByIdQueryHandle>();
        services.AddScoped<GetBrandQueryHandle>();
        services.AddScoped<UpdateBrandCommandHandle>();
        services.AddScoped<RemoveBrandCommandHandle>();
    }
}
