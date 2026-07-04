using CarBook.Application.Features.CQRS.Handlers.AboutHandler;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Application.Extensions;
public static class ServiceRegistrations
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<CreateAboutCommantHandle>();
        services.AddScoped<GetAboutByIdQueryHandle>();
        services.AddScoped<GetAboutQueryHandle>();
        services.AddScoped<UpdateAboutCommantHandle>();
        services.AddScoped<RemoveAboutCommantHandle>();
    }
}
