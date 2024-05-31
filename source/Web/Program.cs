var builder = WebApplication.CreateBuilder();

builder.Host.UseSerilog();

builder.Services.AddResponseCompression();
builder.Services.AddJsonStringLocalizer();
builder.Services.AddHashService();
builder.Services.AddJwtService();
builder.Services.AddAuthorization().AddAuthentication().AddJwtBearer();
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
