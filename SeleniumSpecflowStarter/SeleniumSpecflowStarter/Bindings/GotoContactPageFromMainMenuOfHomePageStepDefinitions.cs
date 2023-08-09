using System;
using System.Threading;
using NPOI.SS.Formula.Functions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;


namespace SeleniumSpecflowStarter.Bindings
{
    [Binding]
    public class GotoContactPageFromMainMenuOfHomePageStepDefinitions
    {
        IWebDriver driver = null;

        public GotoContactPageFromMainMenuOfHomePageStepDefinitions()
        {
            driver = WebDriverSingleton.GetInstance();
        }

        [Given(@"User is on Homepage")]
        public void GivenUserIsOnHomepage()
        {
            // Navigate to website HomepPage, Maximize browser window
            driver.Navigate().GoToUrl("https://codafit.com/");
            driver.Manage().Window.Maximize();

            //Validate Title of HomePage
            Assert.IsTrue(driver.Title.Contains("Main Home - Codafit"));
        }

        [When(@"User Clicks on Contact button on the main Menu")]
        public void WhenUserClicksOnContactButtonOnTheMainMenu()
        {
            //Find Contact button from the Menu and Click
            driver.FindElement(By.XPath("//*[@id=\"nav-menu-item-5637\"]/a/span/span[1]/span[2]")).Click();

        }

        [When(@"User Clicks on Contact button on the Banner")]
        public void WhenUserClicksOnContactButtonOnTheBanner()
        {
            // Locate Contact us button on Banner
            var towhom = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div/section/div[6]/div/div/div/div/div/div[1]/div/h2"));
            SeleniumMethods.ScrollTo(driver, towhom);
            Thread.Sleep(2000);
            //SeleniumMethods.ScrollTo(driver, towhom);
            towhom.Click();
            // Set the maximum time to wait for an element to be visible (in seconds)
            int waitTimeout = 10;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeout));

            // Find the element using its locator (e.g., By.Id, By.XPath, etc.)
            By elementLocator = By.XPath("/html/body/div[1]/div/div/div/div[2]/div/section/div[5]/div/div/div/div/div/div/div[1]/div/div/div/div[2]/div/div/div/div/div[4]/a/span[1]");

            try
            {
                // Wait until the element becomes visible
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));

                // Perform actions on the visible element
                element.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Element did not become visible within the specified timeout.");
            }
        }


        [Then(@"User is navigated to Contact Page successfully")]
        public void ThenUserIsNavigatedToContactPageSuccessfully()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(driver.Title.Contains("Let's talk business - Codafit"));
            // Capture the entire page content
            string pageContent = driver.PageSource;

            // Expected content or patterns to validate
            string expectedContent = "We’d like to hear from you!";

            // Perform validation
            if (pageContent.Contains(expectedContent))
            {
                Console.WriteLine("Page content validation successful.");
            }
            else
            {
                Console.WriteLine("Page content validation failed.");
            }

            // Close the browser window and quit WebDriver
            //driver.Quit();
        }
    }
}
