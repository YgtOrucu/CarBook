using CarBook.Persistence.Context;
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

    }
}
