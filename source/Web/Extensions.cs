using Architecture.Application;
using Architecture.Application.Demo;
using Architecture.Database;
using DotNetCore.AspNetCore;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using DotNetCore.Security;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Web;

public static class Extensions
{
    public static void AddContext(this IServiceCollection services)
    {
        var connectionString = services.GetConnectionString(nameof(Context));
        services.AddContext<Context>(options => options.UseSqlServer(connectionString));
    }

    public static void AddSecurity(this IServiceCollection services)
    {
        services.AddHashService();
        services.AddJsonWebTokenService(Guid.NewGuid().ToString(), TimeSpan.FromHours(12));
        services.AddAuthenticationJwtBearer();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddClassesMatchingInterfaces(typeof(IUserService).Assembly);
        services.AddClassesMatchingInterfaces(typeof(IUserRepository).Assembly);
        services.AddClassesMatchingInterfaces(typeof(IDemoService).Assembly);
    }

    public static void AddSpa(this IServiceCollection services)
    {
        services.AddSpaStaticFiles("Frontend/dist");
    }

    public static void UseSpa(this IApplicationBuilder application)
    {
        application.UseSpaAngular("Frontend", "start", "http://localhost:4200");
    }
}
