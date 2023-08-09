using System;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace SeleniumSpecflowStarter.Bindings
{
    [Binding]
    public class YoutubeSearchFeatureSteps 
    {
        private string searchkeyword;
        //IWebDriver driver;
        //private ChromeDriver driver;
        IWebDriver driver = null;
        public YoutubeSearchFeatureSteps() => driver =new ChromeDriver(@"C:\WebDriver");
        [Given(@"I have navigated to youtube website")]
        public void GivenIHaveNavigatedToYoutubeWebsite()
        {
            driver.Navigate().GoToUrl("https://www.youtube.com/");
            driver.Manage().Window.Maximize();
            Assert.IsTrue(driver.Title.ToLower().Contains("youtube"));
        }
        
        [Given(@"I have entered Pakistan as search keyword")]
        public void GivenIHaveEnteredPakistanAsSearchKeyword()
        {
            //Thread.Sleep(5000);
            //this.searchkeyword = searchString.ToLower();
            var SearchInputBox = driver.FindElement(By.Name("search_query"));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("search_query")));     
            SearchInputBox.SendKeys("Pakistan");
        }
        
        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            var searchButton = driver.FindElement(By.Id("search-icon-legacy"));
            searchButton.Click();
        }
        
        [Then(@"I should be navigated to search results page")]
        public void ThenIShouldBeNavigatedToSearchResultsPage()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(driver.Url.ToLower().Contains("pakistan"));
            Assert.IsTrue(driver.Title.ToLower().Contains("pakistan"));


        }
    }
}
