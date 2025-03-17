﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace coreApi.Helpers
{
	public static class RegisterSwagger 
    {

		public static void AddMySwaggerGen(this IServiceCollection services)
		{
			services.AddSwaggerGen(AddMySwaggerGenOptions());
		}	

		public static void UseMySwagger(this WebApplication app, bool allEnvironments = true)
		{
			if (allEnvironments || app.Environment.IsDevelopment())
			{
				app.UseSwagger(MyUseSwaggerOptions());
				app.UseSwaggerUI(MyUseSwaggerUIOptions());
			}
		}

		// ==================================================================================

		private static Action<SwaggerGenOptions> AddMySwaggerGenOptions()
		{
			return options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "VueCorp API",
					Version = "v1"
				});

				options.AddSecurityDefinition("Bearer",
					new OpenApiSecurityScheme()
					{
						In              = ParameterLocation.Header,
						Type            = SecuritySchemeType.ApiKey,
						Scheme          = JwtBearerDefaults.AuthenticationScheme,
						Name            = "Authorization",
						BearerFormat    = "JWT",
						Description     = "Add 'Bearer ' + JWT token from 'login' call below."
					}
				);
				options.AddSecurityRequirement(new OpenApiSecurityRequirement {
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						Array.Empty<string>()
					}
				});
			};
		}

		private static Action<SwaggerOptions> MyUseSwaggerOptions()
		{
			return options =>
			{
				options.RouteTemplate = "docs/{documentName}/docs.json";
				options.SerializeAsV2 = true;  // Required for DotNet 9 to work 
			};
		}

		private static Action<SwaggerUIOptions> MyUseSwaggerUIOptions()
		{
			return options =>
			{
				options.EnableTryItOutByDefault();

				options.SwaggerEndpoint("/docs/v1/docs.json", "VueCorp V1");
				options.RoutePrefix = "docs";
				options.EnableTryItOutByDefault();
				options.InjectStylesheet("/swagger-ui/custom.css");
				options.InjectJavascript("/swagger-ui/custom.js");
			};
		}


	}
}
