using automation_amazon.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace automation_amazon.ShoppingCartSteps
{
    [Binding]
    public class ShoppingCartSteps
    {
        private IWebDriver _driver;

        public ShoppingCartSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [When(@"I add the book to the basket")]
        public void WhenIAddTheBookToTheBasket()
        {
            ShoppingCartPage shoppingCart = new ShoppingCartPage(_driver);
            shoppingCart.AddToBasketClick();
        }

        [Then(@"I verify that notification is shown with title: ""(.*)""")]
        public void ThenIVerifyThatNotificationIsShownWithTitle(string expectedNotificationMsg)
        {
            ShoppingCartReviewPage reviewCart = new ShoppingCartReviewPage(_driver);
            var actualNotificationMsg = reviewCart.GetNotificationMessage();
            Assert.AreEqual(expectedNotificationMsg, actualNotificationMsg, "Expected message " +
                expectedNotificationMsg + " does not match the actual " + actualNotificationMsg);
        }
    }
}
