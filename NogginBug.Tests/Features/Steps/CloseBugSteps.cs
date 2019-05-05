using System;
using TechTalk.SpecFlow;

namespace NogginBug.Tests.Features.Steps
{
    [Binding]
    public class CloseBugSteps
    {
        [When(@"I click the '(.*)' button")]
        public void WhenIClickTheButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a success message is displayed")]
        public void ThenASuccessMessageIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the bug'(.*)'closed'")]
        public void ThenTheBugClosed(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
