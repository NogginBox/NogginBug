using NogginBug.Tests.Features.Extensions;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace NogginBug.Tests.Features.Steps
{
    [Binding]
    public class CreateNewUserSteps
    {
        private readonly RemoteWebDriver _webDriver;

        public CreateNewUserSteps(RemoteWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [When(@"enter details of a new user")]
        public void WhenEnterDetailsOfANewUser()
        {
            // Create a unique name so we don't add user with the same name as existing user
            _webDriver.EnterInput("#User_Name", $"Name {Guid.NewGuid()}");
        }
    }
}
