using Flurl;
using Flurl.Http;
using NogginBug.Data.Model;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace NogginBug.Tests.Features.Steps
{
    [Binding]
    public class ViewOpenBugsSteps
    {
        const string ApiUrl = "https://localhost:44314/";

        private int _expectedBugsWithOpenStatus;

        [Given(@"there are (.*) bugs with status open")]
        public async Task GivenThereAreBugsWithStatusOpen(int numOpenBugs)
        {
            _expectedBugsWithOpenStatus = numOpenBugs;

            await ApiUrl
                .AppendPathSegment("api/v1/bugs")
                .PutJsonAsync(new object[] {
                    new {
                        id = Guid.NewGuid(),
                        title = "Bug 1",
                        description = "Bug description 1",
                        status = BugStatus.Open,
                        openedDate = DateTime.Now.AddHours(-6)
                    },
                    new {
                        id = Guid.NewGuid(),
                        title = "Bug 2",
                        description = "Bug description 2",
                        status = BugStatus.Open,
                        openedDate = DateTime.Now.AddHours(-5)
                    }
                });
        }
        
        [Then(@"I see a list of the titles of all bugs with open status")]
        public void ThenISeeAListOfTheTitlesOfAllBugsWithOpenStatus()
        {
            using (var driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(ApiUrl);
                var bugs = driver.FindElementsByCssSelector("#bugs li");
                Assert.Equal(_expectedBugsWithOpenStatus, bugs.Count);
            }
        }
    }
}
