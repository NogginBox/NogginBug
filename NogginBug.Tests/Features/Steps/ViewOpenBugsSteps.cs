using Coypu;
using Coypu.Drivers.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace NogginBug.Tests.Features.Steps
{
    [Binding]
    public class ViewOpenBugsSteps
    {
        private int _expectedBugsWithOpenStatus;

        [Given(@"there are (.*) bugs with status open")]
        public void GivenThereAreBugsWithStatusOpen(int numOpenBugs)
        {
            _expectedBugsWithOpenStatus = numOpenBugs;
        }
        
        [Then(@"I see a list of the titles of all bugs with open status")]
        public void ThenISeeAListOfTheTitlesOfAllBugsWithOpenStatus()
        {
            var config = new SessionConfiguration
            {
                AppHost = "localhost",
                Port = 44314,
                SSL = true,
                //Driver = typeof(SeleniumWebDriver),
                //Browser = Coypu.Drivers.Browser.Chrome
                
            };

            var driver = new SeleniumWebDriver(Coypu.Drivers.Browser.Chrome);
            driver.

            using (var browser = new BrowserSession(config, driver))
            {
                //var ff = browser.Native as FirefoxDriver;

                browser.Visit("/");
            }
            }
    }
}
