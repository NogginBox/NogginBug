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
            EnterInput("#Bug_Title", "New title");
            EnterInput("#Bug_Description", "New description");
        }
        
        [When(@"click save")]
        public void WhenClickSave()
        {
            var btn = _webDriver.FindElementByCssSelector("button[type=submit]");
            btn.Click();
        }

        private void EnterInput(string cssSelector, string text)
        {
            var el = _webDriver.FindElementByCssSelector(cssSelector);
            el.SendKeys(text);
        }
    }
}
