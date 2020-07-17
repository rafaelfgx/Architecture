using DotNetCore.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Architecture.Web
{
    public class Startup
    {
        public void Configure(IApplicationBuilder application)
        {
            application.UseException();
            application.UseHttps();
            application.UseRouting();
            application.UseStaticFiles();
            application.UseResponseCompression();
            application.UseAuthentication();
            application.UseAuthorization();
            application.UseEndpoints();
            application.UseSpa();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSecurity();
            services.AddResponseCompression();
            services.AddControllersDefault();
            services.AddSpa();
            services.AddContext();
            services.AddServices();
        }
    }
}
