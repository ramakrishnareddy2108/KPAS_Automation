using KPAS_Automation.Helpers;

namespace KPAS_Automation.Pages.Home.Locators
{
    public static class RegisterPageLocators
    {
        public static readonly Locator Username = Locator.ById("loginemail");
        public static readonly Locator Password = Locator.ById("loginpassword");
        public static readonly Locator LoginButton = Locator.ByXPath(@"//*[@id='loginbtnid']/span[1]");
    }
}