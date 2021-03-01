using automation_amazon.Helpers;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace automation_amazon.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer container;
        private readonly ScenarioContext scenarioContext;

        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }

        //Didn't manage to make Hooks working

  //      [BeforeScenario]
        [Scope(Tag = "browser")]
        public void StartBrowser(ScenarioContext scenarioContext)
        {
 //           IWebDriver driver = DriverHelper.GetDriver();
//           container.RegisterInstanceAs(driver);
        }

  //      [AfterScenario]
        [Scope(Tag = "browser")]
        public void StopBrowser()
        {
            IWebDriver driver = container.Resolve<IWebDriver>();
            driver.Quit();
        }
    }
}
