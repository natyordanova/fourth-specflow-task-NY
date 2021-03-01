using AutomationAmazon.PageModel;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace automation_amazon.StepDefinitions
{
    [Binding]
    public class BookDetailsSteps
    {
        private IWebDriver _driver;

        public BookDetailsSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [When(@"I navigate to book ""(.*)"" details page and verify the book title")]
        public void WhenINavigateToBookDetailsPage(string expectedBookTitle)
        {
            HomePage homePage = new HomePage(_driver);
            homePage.FirstResultTitle.Click();

            BookDetailsPage bookDetails = new BookDetailsPage(_driver);

            Assert.AreEqual(expectedBookTitle, bookDetails.GetProductTitle());
        }

        [Then(@"I verify the book details:")]
        public void ThenIVerifyTheBookDetails(string expectedType, string expectedPrice, int expectedQuantity)
        {
            BookDetailsPage bookDetails = new BookDetailsPage(_driver);
            string actualBookType = bookDetails.GetBookType();
            Assert.AreEqual(expectedType, actualBookType, "Expected type does not match the actual");

            string actualBookPrice = bookDetails.GetPrice();
            Assert.AreEqual(expectedPrice, actualBookPrice, "Expected price does not match the actual");

            string actualQuantity = bookDetails.GetQuantity();
            Assert.AreEqual(expectedQuantity, actualQuantity, "Expected quantity is " + expectedQuantity + " but actual is " + actualQuantity);
        }
    }
}
