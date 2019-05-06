using NogginBug.Tests.Features.Extensions;
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
            _webDriver.EnterInput("#Bug_Title", "New title");
            _webDriver.EnterInput("#Bug_Description", "New description");
        }
        
        [When(@"click save")]
        public void WhenClickSave()
        {
            var btn = _webDriver.FindElementByCssSelector("button[type=submit]");
            btn.Click();
        }

        
    }
}
