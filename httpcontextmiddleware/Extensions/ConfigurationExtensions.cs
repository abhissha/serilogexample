using Microsoft.Extensions.Configuration;
namespace HttpContextMiddleware.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetAllowedHost(this IConfiguration config)
        {
            return config.GetValue<string>("AllowedHosts");
        }

        public static string GetInstrumentationKey(this IConfiguration config)
        {
            return config.GetValue<string>("InstrumentationKey");
        }

        public static string GetSecretKey(this IConfiguration config)
        {
            return config.GetValue<string>("SecretKey");
        }
    }
}
