using coreApi;
using coreApi.Data;
using coreApi.Helpers;
using coreApi.Models;
using coreLogic.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using WildHare.Extensions;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

// ========================================================================================================

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;

builder.Services.Configure<JsonOptions>(options => { options.SerializerOptions.PropertyNamingPolicy = null; });
builder.Services.AddSingleton(builder.Configuration.GetSection("App").Get<AppSettings>());

builder.Services.AddSignalR().AddJsonProtocol(options =>
{
	options.PayloadSerializerOptions.PropertyNamingPolicy = null; // use PascalCase
}); 

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
		policy => policy.WithOrigins(builder.Configuration["App:AllowedOrigins"].Split(";", true))
						.AllowCredentials()
						.AllowAnyHeader()
						.AllowAnyMethod());
});

builder.Services.AddHttpContextAccessor();

Log.Logger = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration)
	.CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDbContext<CoreApiDataContext>(options =>
	options.UseSqlite(builder.Configuration.GetConnectionString("CoreApiData"))
);

builder.Services.AddAuthentication(cfg =>
{
    cfg.DefaultAuthenticateScheme   = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme      = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(c =>
{
    c.TokenValidationParameters = new TokenValidationParameters()
    {
		ValidateLifetime	= true,						// Ensures the token is not expired
		ClockSkew			= TimeSpan.Zero,			// Optional: Remove default 5-minute tolerance for expiration
		ValidIssuer         = builder.Configuration["App:AuthIssuer"],
		ValidAudience       = builder.Configuration["App:AuthAudience"],
        IssuerSigningKey    = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["App:AuthSigningKey"])),
		RoleClaimType		= "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
	};
	c.IncludeErrorDetails   = environment.IsDevelopment();
});

builder.Services.AddAuthorizationBuilder()
	.AddPolicy("User",		 policy => policy.RequireRole("User", "Admin", "SuperAdmin"))
	.AddPolicy("Admin",		 policy => policy.RequireRole("Admin", "SuperAdmin"))
	.AddPolicy("SuperAdmin", policy => policy.RequireRole("SuperAdmin"));

builder.Services.AddEndpointsApiExplorer();  // OpenApi

builder.Services.AddMyCustomSwaggerGen();

builder.Services.AddMyServices();  // Dependency Injection of My Services

// ========================================================================================================

var app = builder.Build();

app.UseStaticFiles();

app.UseMyCustomSwagger();

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();

app.UseAuthorization();

app.RegisterMyEndpoints();

app.RegisterRealtimeHubs();

app.MapFallbackToFile("/index.html");

if (environment.IsDevelopment())
{
	app.UseMiddleware<DebugMiddleware>();
}

// ========================================================================================================

app.Run();


