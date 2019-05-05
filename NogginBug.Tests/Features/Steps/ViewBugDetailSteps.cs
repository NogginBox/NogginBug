using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace NogginBug.Tests.Features.Steps
{
    [Binding]
    public class ViewBugDetailSteps
    {
        private readonly RemoteWebDriver _webDriver;

        public ViewBugDetailSteps(RemoteWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [When(@"I click the bug title")]
        public void WhenIClickTheBugTitle()
        {
            var bugLink = _webDriver.FindElementByCssSelector("#bugs li a");
            bugLink.Click();
        }
        
        [Then(@"I see a the bug title, description and when it was opended")]
        public void ThenISeeATheBugTitleDescriptionAndWhenItWasOpended()
        {
            AssertElementTextStartsWith("#bug-title", "Bug");
            AssertElementTextStartsWith("#bug-date-opened", Shared.MayThe4th.ToString("dddd"));
            AssertElementTextStartsWith("#bug-description", "Bug description");
        }

        private void AssertElementTextStartsWith(string cssSelector, string text)
        {
            var el = _webDriver.FindElementByCssSelector(cssSelector);
            Assert.StartsWith(text, el.Text);
        }
    }
}
