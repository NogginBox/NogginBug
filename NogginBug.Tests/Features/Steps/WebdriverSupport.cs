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
        private RemoteWebDriver _driver;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            _driver = new ChromeDriver(".");
            _objectContainer.RegisterInstanceAs<RemoteWebDriver>(_driver);
        }

        [AfterScenario]
        public void DesposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
