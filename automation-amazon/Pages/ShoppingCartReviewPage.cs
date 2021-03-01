using OpenQA.Selenium;

namespace automation_amazon.Pages
{
    public class ShoppingCartReviewPage
    {
        private IWebDriver _driver;
        private static By _notificationMessage = By.XPath("//*[@id='huc-v2-order-row-items-msg']//h1");

        public ShoppingCartReviewPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetNotificationMessage() 
        {
            string actualNotificationMsg = _driver.FindElement(_notificationMessage).Text;

            return actualNotificationMsg;
        }
    }
}
