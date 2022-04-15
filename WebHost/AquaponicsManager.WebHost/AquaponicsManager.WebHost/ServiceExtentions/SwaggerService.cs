using Microsoft.OpenApi.Models;

namespace AquaponicsManager.WebHost.ServiceExtentions
{
    internal static class SwaggerService
    {
        internal static IServiceCollection AddSwaggerWithXml(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Table Manners API",
                    Version = "v1",
                    Description = "The primary API for the Table Manners project."
                });

                var xmlDocumentFilePath = Path.Combine(AppContext.BaseDirectory, "Akeso.WebHost.xml");
                if (File.Exists(xmlDocumentFilePath))
                {
                    config.IncludeXmlComments(xmlDocumentFilePath);
                }

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.<br /><br /> 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      <br /><br />Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }

        internal static IApplicationBuilder UseSwaggerWithUI(this IApplicationBuilder app)
        {
            app.UseSwagger()
               .UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "TableManners API"));

            return app;
        }
    }
}
