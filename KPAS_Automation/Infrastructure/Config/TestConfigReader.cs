using KPAS_Automation.Enums;
using KPAS_Automation.Support;

namespace KPAS_Automation.Infrastructure.Config
{
    public class TestConfigReader
    {
        public static string BaseUrl => TestConfigurator.GetSettingString(Constants.BaseUrl);
        public static string GridUrl => TestConfigurator.GetSettingString(Constants.GridUrl);
        public static BrowserType BrowserType => TestConfigurator.GetSettingsEnum<BrowserType>("AppSettings:BrowserType");
        public static float Timeout => TestConfigurator.GetSettingsInt(Constants.Timeout);

        public static BrowserConfig BrowserConfig = TestConfigurator.GetSection(Constants.BrowserConfigSection);
    }
}