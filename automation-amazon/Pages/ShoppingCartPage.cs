using automation_amazon.Helpers;
using OpenQA.Selenium;

namespace automation_amazon.Pages
{
    public class ShoppingCartPage
    {
        private IWebDriver _driver;
        public static By _addToBasketBtn = By.CssSelector("#add-to-cart-button");

        public ShoppingCartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddToBasketClick() {
            _driver.FindElement(_addToBasketBtn).Click();
        }
    }
}
