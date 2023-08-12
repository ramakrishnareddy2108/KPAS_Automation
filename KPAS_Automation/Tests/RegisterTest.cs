using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using KPAS_Automation.Pages.Home.Pages;
using KPAS_Automation.Support;
using KPAS_Automation.TestData;

namespace KPAS_Automation.Tests
{
    [TestFixture]
    public class RegisterTest : TestBase
    {
        [Test]
        public void ValidLoginTest()
        {
            var registrationPage = new RegisterPage(Driver);
            Driver.Navigate().GoToUrl(BaseUrl + Uris.Registration);
            registrationPage.Login(RegistrationTestData.ValidUsername, RegistrationTestData.ValidPassword);

            //Driver.Url.Should().Be(BaseUrl + Uris.DashBoard);
        }
    }
}