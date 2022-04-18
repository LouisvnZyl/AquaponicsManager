namespace AquaponicsManager.WebHost.Helpers
{
    public class AppsettingsMapper
    {
        public static T GetMappedValues<T>(string sectionName, IConfiguration configuration) where T : new()
        {
            var setting = new T();
            configuration.Bind(sectionName, setting);
            return setting;
        }
    }
}
