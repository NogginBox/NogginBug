using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Xunit;

namespace NogginBug.Tests.Features.Steps
{
    [Binding]
    public class ViewOpenBugsSteps
    {
        const string BaseUrl = "https://localhost:44314/";

        private int _expectedBugsWithOpenStatus;

        [Given(@"there are (.*) bugs with status open")]
        public void GivenThereAreBugsWithStatusOpen(int numOpenBugs)
        {
            _expectedBugsWithOpenStatus = numOpenBugs;
        }
        
        [Then(@"I see a list of the titles of all bugs with open status")]
        public void ThenISeeAListOfTheTitlesOfAllBugsWithOpenStatus()
        {
            using (var driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(BaseUrl);
                var bugs = driver.FindElementsByCssSelector("#bugs li");
                Assert.Equal(_expectedBugsWithOpenStatus, bugs.Count);
            }

        }
    }
}
