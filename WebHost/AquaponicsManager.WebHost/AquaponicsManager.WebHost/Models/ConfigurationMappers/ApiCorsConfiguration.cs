namespace AquaponicsManager.WebHost.Models.ConfigurationMappers
{
    public class ApiCorsConfiguration
    {
        public string AllowedOrigins { get; set; } = string.Empty;
        public string AllowedMethods { get; set; } = string.Empty;
        public string AllowedHeaders { get; set; } = string.Empty;
    }
}
