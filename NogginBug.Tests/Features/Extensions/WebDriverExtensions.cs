using OpenQA.Selenium.Remote;
using Xunit;

namespace NogginBug.Tests.Features.Extensions
{
    internal static class WebDriverExtensions
    {

        public static void AssertElementTextContains(this RemoteWebDriver webDriver, string cssSelector, string text)
        {
            var el = webDriver.FindElementByCssSelector(cssSelector);
            Assert.Contains(text, el.Text);
        }

        public static void AssertElementTextStartsWith(this RemoteWebDriver webDriver, string cssSelector, string text)
        {
            var el = webDriver.FindElementByCssSelector(cssSelector);
            Assert.StartsWith(text, el.Text);
        }
    }
}
