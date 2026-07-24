using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Interceptors;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.CarRepositories;
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

        services.AddDbContext<CarBookContext>();
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();

    }
}
