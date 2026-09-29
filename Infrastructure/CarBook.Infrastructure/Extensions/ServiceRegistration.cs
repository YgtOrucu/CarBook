using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.JwtInterfaces;
using CarBook.Domain.Entities;
using CarBook.Infrastructure.Options;
using CarBook.Infrastructure.Repositories;
using CarBook.Infrastructure.Repositories.JwtRepository;
using CarBook.Persistence.Options;
using CarBook.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace CarBook.Infrastructure.Extensions;

public static class ServiceRegistration
{
    public static void AppInfrastructureSetting(this IServiceCollection services, IConfiguration builder)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
        {
            var jwttokenpotions = builder.GetSection(nameof(JwtTokenOption)).Get<JwtTokenOption>();

            opt.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = jwttokenpotions.Issuer,
                ValidAudience = jwttokenpotions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwttokenpotions.Key)),
                ClockSkew = TimeSpan.Zero,
            };


            opt.Events = new JwtBearerEvents
            {
                OnTokenValidated = async context =>
                {
                    var userRepository = context.HttpContext.RequestServices.GetRequiredService<UserManager<AppUser>>();
                    var userId = context.Principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    var tokenSecurityStamp = context.Principal?.FindFirst("security_stamp")?.Value;

                    if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(tokenSecurityStamp))
                    {
                        context.Fail("Gerekli yetkilendirme bilgileri bulunamadı.");
                        return;
                    }
                    var user = await userRepository.FindByIdAsync(userId);
                    if (user == null || user.SecurityStamp != tokenSecurityStamp)
                    {
                        context.Fail("Bu token ile oturum sonlandırılmıştır.");
                    }
                }
            };
        });

        services.Configure<JwtTokenOption>(builder.GetSection(nameof(JwtTokenOption)));
        services.Configure<MailSettingsOption>(builder.GetSection(nameof(MailSettingsOption)));

        services.AddScoped<IJwtService, JwtRepository>();
        services.AddScoped<ISendMailRepository, SendMailRepository>();
        services.AddScoped<IOpenAIRepository, OpenAIRepository>();

        services.AddHttpClient("OpenAIAddress", opt =>
        {
            var address = builder.GetSection("OpenAIApiKey").Value;
            if (address == null)
                throw new Exception("The ApıAddress could not be found");

            opt.BaseAddress = new Uri(address);
        });
    }
}
