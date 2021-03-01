using automation_amazon.Helpers;
using OpenQA.Selenium;

namespace AutomationAmazon.PageModel
{
    public class BookDetailsPage 
    {
        private IWebDriver _driver;
        private SeleniumHelpers selenium;
        private static By _productTitle = By.Id("productTitle");
        private static By _type = By.XPath("//*[@id='tmm-grid-1-0-swatch']//*[@class='slot-title']");
        private static By _price = By.XPath("//*[@id='tmm-grid-1-0-swatch']//*[@class='slot-price']");
        private static By _quantityDropdownFirstOption = By.XPath("//*[@id='selectQuantity']//option[1]");


        public BookDetailsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetProductTitle() {
            string actualTitle = "";
            if (selenium.CheckElementIsVisible(_productTitle)) {
                actualTitle = _driver.FindElement(_productTitle).Text;                
            }
            return actualTitle;
        }

        public string GetBookType() {
            string bookType;
            return bookType = _driver.FindElement(_type).Text;
                }

        public string GetPrice() {
            string bookPrice;
            return bookPrice = _driver.FindElement(_price).Text;
        }

        public string GetQuantity()
        {
            var dropDownValue = _driver.FindElement(_quantityDropdownFirstOption).GetAttribute("value");

            return dropDownValue;
        }
    }
}
