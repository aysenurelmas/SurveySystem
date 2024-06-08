using Core.CrossCuttingConcerns.Serilog.Logger;
using Core.DataAccess.Security.JWT;
using Core.Security.JWT;
using Core.Security.OtpAuthenticator.OtpNet;
using Core.Security.OtpAuthenticator;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Core.CrossCuttingConcerns.Serilog;


namespace Core;

public static class CoreServiceRegistration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddMemoryCache();

        services.AddScoped<ITokenHelper, JwtHelper>();

        services.AddScoped<Stopwatch>();

        services.AddTransient<LoggerServiceBase, FileLogger>();
        services.AddTransient<MsSqlLogger>();

        services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
      //  services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
}

