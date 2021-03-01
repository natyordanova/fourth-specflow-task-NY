using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace automation_amazon.Helpers
{
    public class SeleniumHelpers
    {
        private IWebDriver _driver;
        public SeleniumHelpers(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool CheckElementIsVisible(By selector)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            return wait.Until(driver =>
            {
                try
                {
                    IWebElement tempElement = _driver.FindElement(selector);
                    return tempElement.Displayed;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
