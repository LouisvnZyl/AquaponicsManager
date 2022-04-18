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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors(ApiConstants.CorsOriginPolicyName);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerWithUI();
        }
    }
}
