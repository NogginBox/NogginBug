using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace NogginBug.Tests
{
    [Binding]
    public class CreateNewBugSteps
    {
        private readonly RemoteWebDriver _webDriver;

        public CreateNewBugSteps(RemoteWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [When(@"enter details of a new bug")]
        public void WhenEnterDetailsOfANewBug()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"click save")]
        public void WhenClickSave()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a success message is displayed")]
        public void ThenASuccessMessageIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
