using AquaponicsManager.WebHost.Constants;
using AquaponicsManager.WebHost.Helpers;
using AquaponicsManager.WebHost.Models.ConfigurationMappers;
using AquaponicsManager.WebHost.ServiceExtentions;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace AquaponicsManager.WebHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppsettingService(Configuration);
            //services.AddDataAccessServices(Configuration);
            //services.AddApplicationServices(Configuration);

            var apiConfigurationSettings = AppsettingsMapper.GetMappedValues<ApiCorsConfiguration>(AppSettingsConfigurationSections.ApiCorsConfigurationSectionName, Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy(name: ApiConstants.CorsOriginPolicyName,
                    new CorsPolicyBuilder()
                    .WithHeaders(apiConfigurationSettings.AllowedHeaders)
                    .WithMethods(apiConfigurationSettings.AllowedMethods)
                    .AllowAnyOrigin().
                    Build());
            });

            services.AddControllers();
            services.AddSwaggerWithXml();
            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_CONNECTIONSTRING"]);
        }
    }
}
