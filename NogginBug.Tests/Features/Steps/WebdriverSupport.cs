using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace NogginBug.Tests.Features.Steps
{
    [Binding]
    public class WebDriverSupport
    {
        private readonly IObjectContainer _objectContainer;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var driver = new ChromeDriver(".");
            _objectContainer.RegisterInstanceAs<RemoteWebDriver>(driver);
        }
    }
}
