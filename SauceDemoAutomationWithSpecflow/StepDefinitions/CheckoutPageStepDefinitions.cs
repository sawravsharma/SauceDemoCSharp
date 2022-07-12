using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SauceDemoAutomationWithSpecflow.StepDefinitions
{
    [Binding]
    public class CheckoutPageStepDefinitions
    {
        private string commonXpath = "(//button[contains(text(),'Add to cart')])";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private string url = "https://www.saucedemo.com/";
        private string userName = "standard_user";
        private string passWord = "secret_sauce";
        private string expectedUrl = "https://www.saucedemo.com/checkout-step-one.html";
        private string firstName = "Saurav";
        private string lastName = "Sharma";
        private string postCode = "1234";
        IWebDriver webDriver;

        [Given(@"User is already logged in the website")]
        public void GivenUserIsAlreadyLoggedInTheWebsite()
        {
            webDriver = new FirefoxDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(url);
            IWebElement webElement = webDriver.FindElement(By.XPath("//input[@id='user-name']"));
            webElement.SendKeys(userName);
            IWebElement webElement1 = webDriver.FindElement(By.XPath("//input[@id='password']"));
            webElement1.SendKeys(passWord);
            IWebElement webElement2 = webDriver.FindElement(By.XPath("//input[@id='login-button']"));
            webElement2.Click();
        }

        [Given(@"User has added the products in the cart")]
        public void GivenUserHasAddedTheProductsInTheCart()
        {
            try
            {
                for (int i = 1; i <= commonXpath.Count(); i++)
                {
                    IWebElement webElement = webDriver.FindElement(By.XPath(commonXpath + "[" + i + "]"));
                    IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
                    // string title = (string)js.ExecuteScript("return document.title");
                    js.ExecuteScript("arguments[0].click();", webElement);
                    //  webElement.Click();
                    Thread.Sleep(1000);
                }
            }
            catch
            {
                Console.WriteLine("Product not available");
            }
            IWebElement webElement1 = webDriver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a"));
            webElement1.Click();
        }

        [Given(@"User has clicked on Checkout button")]
        public void GivenUserHasClickedOnCheckoutButton()
        {
            IWebElement webElement = webDriver.FindElement(By.XPath("//*[@id='checkout']"));
            webElement.Click();
        }

        [Given(@"User is already on Checkout Page")]
        public void GivenUserIsAlreadyOnCheckoutPage()
        {
            webDriver.Url.Should().Be(expectedUrl);
            //webDriver.Close();
        }

        [When(@"User add his information")]
        public void WhenUserAddHisInformation()
        {
            IWebElement webElement = webDriver.FindElement(By.XPath("//*[@id='first-name']"));
            webElement.SendKeys(firstName);
            Thread.Sleep(5000);
            IWebElement webElement1 = webDriver.FindElement(By.XPath("//*[@id='last-name']"));
            webElement1.SendKeys(lastName);

            IWebElement webElement2 = webDriver.FindElement(By.XPath("//*[@id='postal-code']"));
            webElement2.SendKeys(postCode);
            Thread.Sleep(5000);
        }

        //[When(@"User adds firstname as text ""([^""]*)"" in ""([^""]*)"", lastname as text ""([^""]*)"" in ""([^""]*)"" and post code as text ""([^""]*)"" in ""([^""]*)""")]
        //public void WhenUserAddsFirstnameAsTextInLastnameAsTextInAndPostCodeAsTextIn(string firstname, string lastname, string postcode, string identifier, string identifier1, string identifier2)
        //{
        //    IWebElement webElement = webDriver.FindElement(By.XPath(identifier));
        //    webElement.SendKeys(firstname);
        //    IWebElement webElement1 = webDriver.FindElement(By.XPath(identifier1));
        //    webElement1.SendKeys(lastname);
        //    IWebElement webElement2 = webDriver.FindElement(By.XPath(identifier2));
        //    webElement2.SendKeys(postcode);
        //}

        [Then(@"User clicks on continue button")]
        public void ThenUserClicksOnContinueButton()
        {
            IWebElement webElement = webDriver.FindElement(By.XPath("//*[@id='continue']"));
            webElement.Click();
        }

    }
}
