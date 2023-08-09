using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumSpecflowStarter.Models;
using TechTalk.SpecFlow;

namespace SeleniumSpecflowStarter.Features
{
    [Binding]
    public class BrokerSearchSteps
    {
        IWebDriver driver = null;
        Broker broker = null;
        public BrokerSearchSteps()
        {
            driver = WebDriverSingleton.GetInstance();
            broker = TestData.ReadExcel(1);
        }


        [Given(@"that I navigate to dubailand website")]
        public void GivenThatINavigateToDubailandWebsite()
        {
            driver.Navigate().GoToUrl("https://www.dubailand.gov.ae/en");
            driver.Manage().Window.Maximize();
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("introjs-skipbutton")));
            //var skip = driver.FindElement(By.ClassName("introjs-skipbutton"));
            //skip.Click();
            driver.Manage().Window.Maximize();
            Assert.IsTrue(driver.Title.ToLower().Contains("dubai land department - home"));
            driver.FindElement(By.Id("closeChatNotif")).Click();

        }

        [Given(@"I press on Services")]
        public void GivenIPressOnServices()
        {
            var services = driver.FindElement(By.XPath("//*[@id]/ul[1]/li[5]/a"));
            services.Click();
        }

        [Given(@"I press on Informatives")]
        public void GivenIPressOnInformatives()
        {
            var informatives = driver.FindElement(By.XPath("//*[@id]/ul[1]/li[5]/ul/li[4]/a"));
            informatives.Click();
        }

        [Given(@"I press on General")]
        public void GivenIPressOnGeneral()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var general = driver.FindElement(By.Id("expandAll"));
            general.Click();

        }

        [Given(@"I press on Licensed real estate brokers")]
        public void GivenIPressOnLicensedRealEstateBrokers()
        {
            Thread.Sleep(2000);
            //var brokersservice = driver.FindElement(By.LinkText("Licensed Real Estate Brokers"));
            driver.FindElement(By.Id("service_directory_search")).SendKeys("Licensed Real Estate Brokers");
          // driver.FindElement(By.XPath("//a[@href='/en/eservices/licensed-real-estate-brokers']")).Click();
            //driver.FindElement(By.LinkText("Property Status Enquiry")).Click();
            //var element = driver.FindElement(By.LinkText("Licensed Real Estate Brokers"));
           // Actions actions = new Actions(driver);
           // actions.MoveToElement(element);
           // element.Click();
            driver.FindElement(By.LinkText("Licensed Real Estate Brokers")).Click();
            //*[@id="collapse-17784"]/div/ul/li[11]/div[1]/a
            //driver.FindElement(By.LinkText("Licensed Real Estate Brokers")).Click();

            // driver.FindElement(By.XPath("/html/body/div[9]/section[2]/div/div[2]/div/div/div[6]/div[4]/div/div[1]/div[2]/div/ul/li[11]/div[1]/a")).Click();
            //brokersservice.Click();
        }

        [Given(@"I press on proceed to Service")]
        public void GivenIPressOnProceedToService()
        {
            var proceedbutton = driver.FindElement(By.LinkText("Access this Service"));
            proceedbutton.Click();
        }

        [Given(@"I have entered Broker Name")]
        public void GivenIHaveEnteredBrokerName()
        {
            var SearchInputBox = driver.FindElement(By.Id("service_directory_search"));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("service_directory_search")));
            SearchInputBox.SendKeys(broker.BrokerName);
            
        }

        [When(@"I press on Search")]
        public void WhenIPressOnSearch()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.Id("service_directory_btn")).Click();
        }

        [Then(@"Broker search results appear")]
        public void ThenBrokerSearchResultsAppear()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".custom-card-title div")));
            var brokernametext = driver.FindElement(By.CssSelector(".custom-card-title div"));
            var text = brokernametext.Text;
            Assert.IsTrue(text.Contains(broker.BrokerName));
        }


    }
}
