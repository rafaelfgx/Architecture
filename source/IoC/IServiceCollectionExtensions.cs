using DotNetCore.IoC;
using DotNetCoreArchitecture.Application;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DotNetCoreArchitecture.IoC
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogger(configuration);
            services.AddHash();
            services.AddCriptography(Guid.NewGuid().ToString());
            services.AddJsonWebToken(Guid.NewGuid().ToString(), TimeSpan.FromHours(12));

            services.AddClassesMatchingInterfacesFrom
            (
                typeof(IAuthenticationApplication).Assembly,
                typeof(IAuthenticationDomain).Assembly,
                typeof(IDatabaseUnitOfWork).Assembly
            );

            services.AddDbContextEnsureCreatedMigrate<DatabaseContext>(options => options
                .UseSqlServer(configuration.GetConnectionString(nameof(DatabaseContext)))
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
            );
        }
    }
}
