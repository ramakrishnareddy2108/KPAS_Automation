using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using KPAS_Automation.Infrastructure.Config;
using KPAS_Automation.Enums;

namespace KPAS_Automation.Utilities
{
    public class DriverInitializer
    {
        public IWebDriver Driver { get; private set; }

        public IWebDriver InitializeDriver()
        {
            var browserConfig = TestConfigReader.BrowserConfig;
            var gridUrl = TestConfigReader.GridUrl;

            if (gridUrl == null)
            {
                TestContext.WriteLine("gridUrl command line parameter is not provided. Launching driver using local browser.");
            }

            DriverOptions options;

            switch (browserConfig.BrowserType)
            {
                case BrowserType.Chrome:
                    options = new ChromeOptions();
                    break;

                case BrowserType.Firefox:
                    options = new FirefoxOptions();
                    break;

                case BrowserType.Edge:
                    options = new EdgeOptions();
                    break;

                default:
                    return null;
            }

            ConfigureDriverOptions(options, browserConfig);

            if (string.IsNullOrWhiteSpace(gridUrl))
            {
                Driver = GetLocalDriver(browserConfig.BrowserType, options);
            }
            else
            {
                Driver = new RemoteWebDriver(new Uri(gridUrl), options);
            }

            return Driver;
        }

        private void ConfigureDriverOptions(DriverOptions options, BrowserConfig browserConfig)
        {
            if (browserConfig.Headless)
            {
                if (options is ChromeOptions chromeOptions)
                {
                    chromeOptions.AddArgument("--headless");
                }
                else if (options is FirefoxOptions firefoxOptions)
                {
                    firefoxOptions.AddArgument("--headless");
                }
                else if (options is EdgeOptions edgeOptions)
                {
                    edgeOptions.AddArgument("--headless");
                }
            }
        }

        private IWebDriver GetLocalDriver(BrowserType browserName, DriverOptions options)
        {
            switch (browserName)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver(options as ChromeOptions);

                case BrowserType.Firefox:
                    return new FirefoxDriver(options as FirefoxOptions);

                case BrowserType.Edge:
                    return new EdgeDriver(options as EdgeOptions);

                default:
                    return null;
            }
        }
    }
}