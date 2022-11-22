using Architecture.Application;
using Architecture.Database;
using DotNetCore.AspNetCore;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using DotNetCore.Logging;
using DotNetCore.Security;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Host.UseSerilog();

builder.Services.AddResponseCompression();
builder.Services.AddSwaggerGen();
builder.Services.AddSpaStaticFiles("Frontend");
builder.Services.AddAuthenticationJwtBearer(new JwtSettings(Guid.NewGuid().ToString(), TimeSpan.FromHours(12)));
builder.Services.AddContext<Context>(options => options.UseSqlServer(builder.Services.GetConnectionString(nameof(Context))));
builder.Services.AddClassesMatchingInterfaces(typeof(IUserService).Assembly, typeof(IUserRepository).Assembly);
builder.Services.AddControllers().AddJsonOptions().AddAuthorizationPolicy();

var application = builder.Build();

application.UseException();
application.UseHttps();
application.UseResponseCompression();
application.UseSwagger();
application.UseSwaggerUI();
application.UseRouting();
application.UseAuthentication();
application.UseAuthorization();
application.UseEndpoints(endpoints => endpoints.MapControllers());
application.UseSpaAngular("Frontend", "start", "http://localhost:4200");

application.Run();
