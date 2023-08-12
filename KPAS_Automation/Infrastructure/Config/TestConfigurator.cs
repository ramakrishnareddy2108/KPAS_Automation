using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace KPAS_Automation.Infrastructure.Config
{
    public class TestConfigurator
    {
        public static IConfiguration _configuration;

        // Use value in appsettings if not set in Env Variables
        private static string _testEnvironment = Environment.GetEnvironmentVariable("TestRunParameters_TestEnvironment");

        /// <summary>
        /// Strongly typed from appsettings
        /// </summary>

        public static IConfiguration LoadConfiguration
            => _configuration ??= new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{_testEnvironment}.json", true, true)
#if DEBUG
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.Development.json", true, true)
#endif
            .Build();

        public static string GetSettingString(string name)
        {
            return LoadConfiguration[name]
                ?? throw new Exception($"{name} not set in config.");
        }

        public static int GetSettingsInt(string name) => int.Parse(GetSettingString(name));

        public static float GetSettingsFloat(string name) => float.Parse(GetSettingString(name));

        public static T GetSettingsEnum<T>(string name) where T : struct, Enum => Enum.Parse<T>(GetSettingString(name));

        public static bool GetSettingsBool(string name) => bool.Parse(GetSettingString(name));

        public static BrowserConfig GetSection(string name) => _configuration.GetSection(name).Get<BrowserConfig>();
    }
}