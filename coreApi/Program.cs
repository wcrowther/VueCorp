using coreApi.Helpers;
using coreApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Text;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

// ========================================================================================================

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;

builder.Services.Configure<JsonOptions>(options => { options.SerializerOptions.PropertyNamingPolicy = null; });
builder.Services.AddSingleton(builder.Configuration.GetSection("App").Get<AppSettings>());
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
		policy => policy.WithOrigins(builder.Configuration["App:AllowOrigins"]) 
						.AllowCredentials()
						.AllowAnyHeader()
						.AllowAnyMethod());
});


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
	.AddPolicy("User", policy => policy.RequireRole("User"))
	.AddPolicy("Admin", policy => policy.RequireRole("Admin"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(RegisterSwagger.AddMySwaggerGenOptions());

builder.Services.AddMyServices();

// ========================================================================================================

var app = builder.Build();

app.UseStaticFiles();

//if (app.Environment.IsDevelopment()){
	app.UseSwagger(options =>
	{
		options.RouteTemplate = "docs/{documentName}/docs.json";
		options.SerializeAsV2 = true;  // Required for DotNet 9 to work 
	});
    app.UseSwaggerUI(options =>
    {
		options.EnableTryItOutByDefault();
		
		options.SwaggerEndpoint("/docs/v1/docs.json", "VueCorp V1");
		options.RoutePrefix = "docs";
		options.EnableTryItOutByDefault();
		options.InjectStylesheet("/swagger-ui/custom.css");
		options.InjectJavascript("/swagger-ui/custom.js");
    });
//}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.RegisterEndpoints();

app.MapFallbackToFile("/index.html");

app.Run();






// builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("App"));


// ========================================================================================================
// Needed by Jason Watmore example
//
// app.UseMiddleware<JwtMiddleware>();
// ========================================================================================================
// FROM Shawn Wildermuth example (Not needed for DotNet 7...)
//
// builder.Services.AddAuthorization(auth =>
// {
//     var authPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
//     authPolicyBuilder       = authPolicyBuilder.RequireAuthenticatedUser();
//     auth.DefaultPolicy       = authPolicyBuilder.Build();
// });
// 
// builder.Services.AddAuthentication(cfg =>
// {
//     cfg.DefaultAuthenticateScheme   = JwtBearerDefaults.AuthenticationScheme;
//     cfg.DefaultChallengeScheme      = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(c =>
// {
//     c.TokenValidationParameters = new TokenValidationParameters()
//     {
//         ValidIssuer         = TokenSecurity.ISSUER,
//         ValidAudience       = TokenSecurity.AUDIENCE,
//         IssuerSigningKey    = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSecurity.SIGNING_KEY)),
//     };
// });
// ========================================================================================================