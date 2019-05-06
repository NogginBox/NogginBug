using NogginBug.Tests.Features.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace NogginBug.Tests.Features.Steps
{
    [Binding]
    public class AssignBugToUserSteps
    {
        private readonly RemoteWebDriver _webDriver;

        public AssignBugToUserSteps(RemoteWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [When(@"I assign '(.*)' from available users")]
        public void WhenIAssignUserFromAvailableUsers(string name)
        {
            // select the drop down list
            var availableUsers = _webDriver.FindElementById("Bug_AssignedUser_Id");
            var selectUser = new SelectElement(availableUsers);

            selectUser.SelectByText(name);
        }
        
        [Then(@"the bug is assigned to '(.*)'")]
        public void ThenTheBugIsAssignedTo(string name)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("alert")));

            _webDriver.AssertElementTextContains(".alert", name);
        }
    }
}
