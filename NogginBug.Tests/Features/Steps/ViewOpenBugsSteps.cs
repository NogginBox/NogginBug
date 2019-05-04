using Flurl;
using Flurl.Http;
using NogginBug.Data.Model;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace NogginBug.Tests.Features.Steps
{



    [Binding]
    public class ViewOpenBugsSteps
    {
        const string SiteUrl = "https://localhost:44314/";
        private readonly RemoteWebDriver _webDriver;

        private int _expectedBugsWithOpenStatus;

        public ViewOpenBugsSteps(RemoteWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        [Given(@"there are (.*) bugs with status open")]
        public async Task GivenThereAreBugsWithStatusOpen(int numOpenBugs)
        {
            _expectedBugsWithOpenStatus = numOpenBugs;

            await SiteUrl
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

        [When(@"I visit the home page")]
        public void WhenIVisitTheHomePage()
        {
            _webDriver.Navigate().GoToUrl(SiteUrl);
        }


        [Then(@"I see a list of the titles of all bugs with open status")]
        public void ThenISeeAListOfTheTitlesOfAllBugsWithOpenStatus()
        {
            
            var bugs = _webDriver.FindElementsByCssSelector("#bugs li");
            Assert.Equal(_expectedBugsWithOpenStatus, bugs.Count);
        }
    }
}
