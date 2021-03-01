using automation_amazon.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationAmazon.PageModel
{
    public class HomePage
    {
        private IWebDriver _driver;
        private const string AMAZON_URL = "https://www.amazon.co.uk";
        private static By _amazonLogo = By.Id("nav-logo-sprites");
        private static string _itemTitle;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        [FindsBy(How = How.Id, Using = "#searchDropdownBox")]
        public IWebElement SearchDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "#twotabsearchtextbox")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[@class='a-size-mini a-spacing-none a-color-base s-line-clamp-2']//a//span")]
        public IWebElement FirstResultTitle { get; set; }

        [FindsBy(How = How.Id, Using = "#sp-cc-accept")]
        public IWebElement CookiesButton { get; set; }

        public HomePage NavigateToHomePage()
        {                  
            _driver.Navigate().GoToUrl(AMAZON_URL);
            return this;
        }

        public Boolean IsAmazonLogoPresent()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            bool isPresent = _driver.FindElement(_amazonLogo).Displayed;
            return isPresent;
        }

        public void SelectCategory(String category)
        {
            SelectElement dropdown = new SelectElement(SearchDropdown);
            dropdown.SelectByText(category);
            Assert.AreEqual(category, dropdown.SelectedOption.Text);
        }

        public void AcceptCookies()
        {
            try
            {
                if (CookiesButton.Displayed)
                {
                    CookiesButton.Click();
                }
            }
            catch (NoSuchElementException e)
            {
            }
        }

        public void VerifyFirstSearchResult(string searchText)
        {

            _itemTitle = FirstResultTitle.Text;
            bool TitleCorrect = _itemTitle.Contains(searchText + " - Parts One and Two");

            Assert.IsTrue(TitleCorrect, "First search result does not match the searched item ");
        }
    }
}
