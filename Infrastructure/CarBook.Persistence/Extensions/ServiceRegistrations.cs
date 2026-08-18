using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Persistence.Options;
using CarBook.Persistence.Context;
using CarBook.Persistence.Interceptors;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
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
        services.Configure<MailSettingsOption>(configuration.GetSection(nameof(MailSettingsOption)));
        services.AddDbContext<CarBookContext>((serviceProvider, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString(name: "DefaultConnection"));

            var interceptor = serviceProvider.GetRequiredService<DbContextInterceptor>();
            options.AddInterceptors(interceptor);
        });

        services.AddDbContext<CarBookContext>();
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IOpenAIRepository, OpenAIRepository>();
        services.AddScoped<ISendMailRepository, SendMailRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<ICarPricingRepository, CarPricingRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();

        services.AddHttpClient("OpenAIAddress", opt =>
        {
            var address = configuration.GetSection("OpenAIApiKey").Value;
            if (address == null)
                throw new Exception("The ApıAddress could not be found");

            opt.BaseAddress = new Uri(address);
        });

    }
}
