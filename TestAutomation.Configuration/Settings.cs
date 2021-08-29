using Microsoft.Extensions.Configuration;
using System.IO;

namespace TestAutomation.Configuration
{
    public class Settings
    {
        private static IConfiguration _config;
        public static IConfiguration Config
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");

                    _config = builder.Build();
                }

                return _config;
            }
        }

        public static string Browser => Config["Browser"];
        public static string ReportPath => Config["ReportPath"];
        public static bool Headless => bool.Parse(Config["Headless"]);
    }
}