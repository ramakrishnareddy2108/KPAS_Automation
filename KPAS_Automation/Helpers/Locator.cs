using OpenQA.Selenium;

namespace KPAS_Automation.Helpers
{
    public class Locator
    {
        public string Value { get; private set; }
        public By SelectorType { get; private set; }

        private Locator(By selectorType, string value)
        {
            SelectorType = selectorType;
            Value = value;
        }

        public static Locator ById(string id) => new Locator(By.Id(id), id);

        public static Locator ByXPath(string xpath) => new Locator(By.XPath(xpath), xpath);

        // ... You can expand for other selectors like By.ClassName, By.CssSelector, etc.
    }
}