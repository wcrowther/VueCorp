using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace coreApi.Helpers
{
    public static class SwaggerHelpers 
    {
		// Adds Authorization field to Swagger documents
		// If we use Type = 'SecuritySchemeType.ApiKey' then we have to prefix 'Bearer '
		// 'SecuritySchemeType.Http' works better 

		public static Action<SwaggerGenOptions> AddSwaggerGenOptions()
        {
            return c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
				{ 
					Title = "VueCorp API", 
					Version = "v1"
				});

                c.AddSecurityDefinition("Bearer", 
					new OpenApiSecurityScheme()
					{
						In              = ParameterLocation.Header,
						Type            = SecuritySchemeType.Http, 
						Name            = "Authorization",
						Scheme          = "Bearer",
						BearerFormat    = "JWT",
						Description     = "JWT Authorization header using the Bearer scheme."
					}
				);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
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
    }
}
