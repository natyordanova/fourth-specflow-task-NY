using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace automation_amazon.StepDefinitions
{
    [Binding]
    public class BaseSeleniumSteps
    {
        public IWebDriver _driver;

        public BaseSeleniumSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I start the Chrome browser")]
        public void GivenIStartTheChromeBrowser()
        {

            string currentUserDir = Environment.GetEnvironmentVariable("USERPROFILE").Replace("\\", "\\\\");
            //_driver = new ChromeDriver("C:\\Users\\natyo\\source\\repos\\fourth-specflow-task-NY\\driver\\"); 
            //_driver = new ChromeDriver("C:\\Users\\natyo\\source\\repos\\fourth-specflow-task-NY\\packages\\Selenium.WebDriver.ChromeDriver.88.0.4324.9600\\driver\\win32");
            string chromeDriverPath = currentUserDir + "\\source\\repos\\fourth-specflow-task-NY\\driver";
            Environment.SetEnvironmentVariable("webdriver.chrome.driver", chromeDriverPath);
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Then(@"I stop the Chrome browser")]
        public void ThenIStopTheChromeBrowser()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}
