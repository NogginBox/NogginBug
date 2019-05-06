using NogginBug.Tests.Features.Extensions;
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
            _webDriver.AssertElementTextStartsWith("#bug-title", "Bug");
            _webDriver.AssertElementTextStartsWith("#bug-date-opened", Shared.MayThe4th.ToString("dddd"));
            _webDriver.AssertElementTextStartsWith("#bug-description", "Bug description");
        }
    }
}
