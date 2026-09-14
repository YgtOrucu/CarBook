using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBook.Persistence.IdentityErrors;
using CarBook.Persistence.Interceptors;
using CarBook.Persistence.Options;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
using CarBook.Persistence.Repositories.CarRepositories;
using CarBook.Persistence.Seeders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Persistence.Extensions;

public static class ServiceRegistrations
{
    public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContextInterceptor>();
        services.AddDbContext<CarBookContext>((serviceProvider, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString(name: "DefaultConnection"));

            var interceptor = serviceProvider.GetRequiredService<DbContextInterceptor>();
            options.AddInterceptors(interceptor);
        });
        services.AddScoped<ICarRepository, CarRepository>();

        services.AddIdentity<AppUser, AppRole>(opt =>
        {
            opt.User.RequireUniqueEmail = true;
            opt.Password.RequireNonAlphanumeric = false;
        })
        .AddEntityFrameworkStores<CarBookContext>()
        .AddDefaultTokenProviders()
        .AddErrorDescriber<TurkishIdentityError>();

        services.Configure<AutoCreateAdmin>(configuration.GetSection(nameof(AutoCreateAdmin)));


        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<ICarPricingRepository, CarPricingRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
        services.AddScoped<ICarDetailRepository, CarDetailRepository>();
    }

    public static async Task UseDbSeederAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var service = scope.ServiceProvider;
        await RoleSeeder.SeedRolesAndAdminUserAsync(service);
    }
}
