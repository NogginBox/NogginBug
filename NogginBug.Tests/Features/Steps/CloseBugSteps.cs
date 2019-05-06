using NogginBug.Tests.Features.Extensions;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace NogginBug.Tests.Features.Steps
{
    [Binding]
    public class CloseBugSteps
    {
        private readonly RemoteWebDriver _webDriver;

        public CloseBugSteps(RemoteWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [Then(@"the bug's status is '(.*)'")]
        public void ThenTheBugClosed(string bugStatus)
        {
            _webDriver.AssertElementTextContains("#bug-status", bugStatus);
        }
    }
}