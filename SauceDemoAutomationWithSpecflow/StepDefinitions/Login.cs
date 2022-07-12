using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SauceDemoAutomationWithSpecflow.StepDefinitions
{
    [Binding]
    public class Login
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        IWebDriver webDriver;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Given(@"User navigates to ""([^""]*)""")]
        public void GivenUserNavigatesToUrl(string url)
        {
            webDriver = new FirefoxDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(url);
        }

        [When(@"User input text ""(.*)"" on ""(.*)""")]
        public void WhenUserInputTextOnUserNameField(string text, string identifier)
        {
            IWebElement webElement = webDriver.FindElement(By.XPath(identifier));
            webElement.SendKeys(text);
        }

        [When(@"User input password text ""(.*)"" on ""(.*)""")]
        public void WhenUserInputPasswordTextOnPasswordField(string text, string identifier)
        {
            IWebElement webElement = webDriver.FindElement(By.XPath(identifier));
            webElement.SendKeys(text);
        }

        [When(@"User clicks on ""(.*)""")]
        public void WhenUserCLicksOnLoginButton(string identifier)
        {
            IWebElement webElement = webDriver.FindElement(By.XPath(identifier));
            webElement.Click();
        }

        [When(@"User is redirected to ""(.*)""")]
        public void ThenUserIsRedirectedToHomePage(string expectedUrl)
        {
            webDriver.Url.Should().Be(expectedUrl);
            webDriver.Close();
        }

    }

}
