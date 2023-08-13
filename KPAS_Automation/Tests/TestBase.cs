using OpenQA.Selenium;
using KPAS_Automation.Infrastructure.Config;
using KPAS_Automation.Utilities;
using KPAS_Automation.Support;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace KPAS_Automation.Tests
{
    public class TestBase
    {
        protected IWebDriver Driver;
        protected ExtentReports _extent;
        protected ExtentTest _test;
        protected OracleUtility DbUtility { get; private set; }
        protected string BaseUrl;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _extent = new ExtentReports();

            // Ensure directories exist
            if (!Directory.Exists(Paths.ReportsPath))
            {
                Directory.CreateDirectory(Paths.ReportsPath);
            }
            if (!Directory.Exists(Paths.ScreenshotsPath))
            {
                Directory.CreateDirectory(Paths.ScreenshotsPath);
            }

            var htmlReporter = new ExtentHtmlReporter(Paths.HtmlReport);
            _extent.AttachReporter(htmlReporter);


            _ = TestConfigurator.LoadConfiguration;
        }

        [SetUp]
        public void SetUp()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            DriverInitializer driverManager = new DriverInitializer();
            Driver = driverManager.InitializeDriver();
            DbUtility = new OracleUtility();
            BaseUrl = TestConfigReader.BaseUrl;
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string screenshotPath = Path.Combine(Paths.ScreenshotsPath, $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                // Capture the screenshot
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

                _test.Fail("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                _test.Fail(TestContext.CurrentContext.Result.Message);
            }


            _extent.Flush();
            Driver.Quit();
            DbUtility.Dispose();
        }
    }
}