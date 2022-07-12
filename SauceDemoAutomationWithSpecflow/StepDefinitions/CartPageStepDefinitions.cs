using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SauceDemoAutomationWithSpecflow.StepDefinitions
{
    [Binding]
    public class CartPageStepDefinitions
    {
        private string commonXpath = "(//button[contains(text(),'Add to cart')])";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private string url = "https://www.saucedemo.com/";
        private string userName = "standard_user";
        private string passWord = "secret_sauce";

        IWebDriver webDriver;

        [Given(@"User is already logged in")]
        public void GivenUserIsLoggedIn()
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

        [Given(@"User add the products in the cart")]
        public void GivenUserAddTheProductsInTheCart()
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
        }

        [When(@"I go to the cart page")]
        public void WhenIGoToTheCartPage()
        {
            IWebElement webElement = webDriver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a"));
            webElement.Click();
        }

        [Then(@"I click the checkout button")]
        public void ThenIClickTheCheckoutButton()
        {
            IWebElement webElement = webDriver.FindElement(By.XPath("//*[@id='checkout']"));
            webElement.Click();
            webDriver.Close();
        }

    }
}
