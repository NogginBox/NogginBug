using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using Xunit;

namespace NogginBug.Tests.Features.Steps
{
    [Binding]
    public class ViewOpenBugsSteps
    {
        private readonly RemoteWebDriver _webDriver;

        public ViewOpenBugsSteps(RemoteWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [Then(@"I see a list of the titles of (.*) bugs with open status")]
        public void ThenISeeAListOfTheTitlesOfAllBugsWithOpenStatus(int numOpenBugs)
        {
            var bugs = _webDriver.FindElementsByCssSelector("#bugs li");
            Assert.Equal(numOpenBugs, bugs.Count);
        }
    }
}
