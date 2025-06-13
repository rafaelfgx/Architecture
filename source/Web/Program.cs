var builder = WebApplication.CreateBuilder();

builder.Host.UseSerilog();

builder.Services.AddResponseCompression();
builder.Services.AddJsonStringLocalizer();
builder.Services.AddHashService();
builder.Services.AddAuthentication().AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SigningKey"])),
    ValidateIssuer = false,
    ValidateAudience = false
});
builder.Services.AddAuthorization();
builder.Services.AddContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(Context))));
builder.Services.AddClassesMatchingInterfaces(nameof(Architecture));
builder.Services.AddMediator(nameof(Architecture));
builder.Services.AddSwaggerDefault();
builder.Services.AddControllers().AddJsonOptions().AddAuthorizationPolicy();

var application = builder.Build();

application.UseException();
application.UseHsts().UseHttpsRedirection();
application.UseLocalization("en", "pt");
application.UseResponseCompression();
application.UseStaticFiles();
application.UseSwagger().UseSwaggerUI();
application.UseRouting();
application.MapControllers();
application.MapFallbackToFile("index.html");

application.Run();
