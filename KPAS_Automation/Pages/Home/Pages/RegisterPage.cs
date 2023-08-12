using OpenQA.Selenium;
using KPAS_Automation.Pages.Home.Locators;

namespace KPAS_Automation.Pages.Home.Pages
{
    public class RegisterPage
    {
        private IWebDriver Driver;

        public RegisterPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement TxtUsername => Driver.FindElement(RegisterPageLocators.Username.SelectorType);
        private IWebElement TxtPassword => Driver.FindElement(RegisterPageLocators.Password.SelectorType);
        private IWebElement BtnLogin => Driver.FindElement(RegisterPageLocators.LoginButton.SelectorType);

        public void Login(string username, string password)
        {
            TxtUsername.SendKeys(username);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
        }
    }
}