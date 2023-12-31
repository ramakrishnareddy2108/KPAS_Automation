﻿using OpenQA.Selenium;
using KPAS_Automation.Infrastructure.Config;
using KPAS_Automation.Utilities;

namespace KPAS_Automation.Tests
{
    public class TestBase
    {
        protected IWebDriver Driver;
        protected string BaseUrl;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _ = TestConfigurator.LoadConfiguration;
        }

        [SetUp]
        public void SetUp()
        {
            DriverInitializer driverManager = new DriverInitializer();
            Driver = driverManager.InitializeDriver();
            BaseUrl = TestConfigReader.BaseUrl;
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}