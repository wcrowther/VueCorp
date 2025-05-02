using coreApi;
using coreApi.Data;
using coreApi.Helpers;
using coreApi.Models;
using coreLogic.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Serilog;
using System;
using System.Text;
using WildHare.Extensions;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

// ========================================================================================================

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;

builder.Services.Configure<JsonOptions>(options => { options.SerializerOptions.PropertyNamingPolicy = null; });
builder.Services.AddSingleton(builder.Configuration.GetSection("App").Get<AppSettings>());
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
		policy => policy.WithOrigins(builder.Configuration["App:AllowedOrigins"].Split(";", true))
						.AllowCredentials()
						.AllowAnyHeader()
						.AllowAnyMethod());
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<CoreApiDataContext>(options => 
	options.UseSqlite(builder.Configuration.GetConnectionString("CoreApiData"))
); 

Log.Logger = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration)
	.CreateLogger();

builder.Host.UseSerilog();

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
	};
	c.IncludeErrorDetails   = environment.IsDevelopment();
});

builder.Services.AddAuthorizationBuilder()
	.AddPolicy("User",		 policy => policy.RequireRole("User"))
	.AddPolicy("Admin",		 policy => policy.RequireRole("Admin"))
	.AddPolicy("SuperAdmin", policy => policy.RequireRole("SuperAdmin"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMySwaggerGen();

builder.Services.AddMyServices();  // Dependency Injection of My Services

// ========================================================================================================

var app = builder.Build();

app.UseStaticFiles();

app.UseMySwagger();

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();

app.UseAuthorization();

app.RegisterMyEndpoints();

app.MapFallbackToFile("/index.html");

if (environment.IsDevelopment())
{
	app.UseMiddleware<DebugMiddleware>();
}

// ========================================================================================================

app.Run();


