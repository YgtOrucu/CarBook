using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Persistence.Context;
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
        services.AddDbContext<CarBookContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString(name: "DefaultConnection")));

        services.AddDbContext<CarBookContext>();
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
        services.AddScoped<ICarRepository, CarRepository>();

    }
}
