using Architecture.Web;
using DotNetCore.AspNetCore;
using DotNetCore.Logging;

var builder = WebApplication.CreateBuilder();

builder.Host.UseSerilog();

builder.Services.AddSecurity();
builder.Services.AddResponseCompression();
builder.Services.AddControllers().AddJsonOptions().AddAuthorizationPolicy();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSpa();
builder.Services.AddContext();
builder.Services.AddServices();

var application = builder.Build();

application.UseException();
application.UseHttps();
application.UseRouting();
application.UseResponseCompression();
application.UseAuthentication();
application.UseAuthorization();
application.UseEndpointsMapControllers();
application.UseSwagger();
application.UseSwaggerUI();
application.UseSpa();

application.Run();
