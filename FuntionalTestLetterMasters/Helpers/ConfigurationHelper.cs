using Microsoft.Extensions.Configuration;

namespace FuntionalTestLetterMasters.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
#if DEBUG
                .AddJsonFile("appsettings.Development.json",
                optional: true,
                reloadOnChange: true)
#else
                .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true)
#endif
                ;

            return builder.Build();
        }
    }
}
