using AutomationAmazon.PageModel;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace automation_amazon.StepDefinitions
{
    [Binding]
    public class HomePageSteps
    {
        private IWebDriver _driver;

        public HomePageSteps(IWebDriver driver)
        {
            _driver = driver;
        }

         private readonly string homeURL = "https://www.amazon.co.uk";

        [When(@"I navigate to Amazon home page")]
        public void WhenINavigateToAmazonHomePage()
        {
            HomePage homePage = new HomePage(_driver);
            _driver.Navigate().GoToUrl(homeURL);
 //           homePage.NavigateToHomePage();
            Assert.IsTrue(new HomePage(_driver).IsAmazonLogoPresent());
            
            homePage.AcceptCookies();
        }
        
        [When(@"I perform search by ""(.*)"" in ""(.*)"" category")]
        public void WhenIPerformSearchBy(string searchText, string category)
        {
            HomePage homePage = new HomePage(_driver);
            homePage.SelectCategory(category);
            homePage.SearchField.Clear();
            homePage.SearchField.SendKeys(searchText);
            homePage.SearchField.SendKeys(Keys.Return);            
        }

        [Then(@"I verify that the first search result is ""(.*)""")]
        public void ThenIVerifyThatTheFirstSearchResultIs(string searchText)
        {
            HomePage homePage = new HomePage(_driver);
            homePage.VerifyFirstSearchResult(searchText);
        }
    }
}
