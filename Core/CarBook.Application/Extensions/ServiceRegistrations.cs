using CarBook.Application.Behavior;
using CarBook.Application.Features.CQRS.Handlers.AboutHandler;
using CarBook.Application.Features.CQRS.Handlers.BannerHandler.Read;
using CarBook.Application.Features.CQRS.Handlers.BannerHandler.Write;
using CarBook.Application.Features.CQRS.Handlers.BrandHandler;
using CarBook.Application.Features.CQRS.Handlers.CarHandler.Read;
using CarBook.Application.Features.CQRS.Handlers.CarHandler.Write;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandles.Read;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandles.Write;
using CarBook.Application.Features.CQRS.Handlers.ContactHandle.Write;
using ContactBook.Application.Features.CQRS.Handlers.ContactHandle.Read;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

        services.AddScoped<CreateCarCommandHandle>();
        services.AddScoped<GetCarByIdQueryHandle>();
        services.AddScoped<GetCarQueryHandle>();
        services.AddScoped<GetCarWithBrandQueryHandle>();
        services.AddScoped<UpdateCarCommandHandle>();
        services.AddScoped<RemoveCarCommandHandle>();

        services.AddScoped<CreateCategoryCommandHandle>();
        services.AddScoped<GetCategoryByIdCommandHandle>();
        services.AddScoped<GetCategoryCommandHandle>();
        services.AddScoped<UpdateCategoryCommandHandle>();
        services.AddScoped<RemoveCategoryCommandHandle>();

        services.AddScoped<CreateContactCommandHandle>();
        services.AddScoped<GetContactByIdQueryHandle>();
        services.AddScoped<GetContactQueryHandle>();
        services.AddScoped<UpdateContactCommandHandle>();
        services.AddScoped<RemoveContactCommandHandle>();


        services.AddAutoMapper(src => src.AddMaps(Assembly.GetExecutingAssembly()));

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
