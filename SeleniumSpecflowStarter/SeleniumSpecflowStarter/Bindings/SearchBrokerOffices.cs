using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumSpecflowStarter.Models;
using TechTalk.SpecFlow;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace SeleniumSpecflowStarter.Bindings
{
    [Binding]
    public sealed class SearchBrokerOffices : Common
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        Office office = null;

        public SearchBrokerOffices()
        {
            office = TestData.ReadExcelOffice(1);

        }
        [Given(@"I am on office list")]
        public void GivenIAmOnOfficeList()
        {
            EnsurePage("https://dubailand.gov.ae/en/eservices/licensed-real-estate-brokers/licensed-real-estate-brokers-list/#/");

        }

        [Given(@"I enter valid office name")]
        public void GivenIEnterValidOfficeName()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("service_directory_search")));
            var SearchInputBox = driver.FindElement(By.Id("service_directory_search"));
            SearchInputBox.SendKeys(office.OfficeName);
        }


        [When(@"I Click on search button")]
        public void WhenIClickOnSearchButton()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.Id("service_directory_btn")).Click();
        }

        [When(@"I Click on Office Card")]
        public void WhenIClickOnOfficeCard()
        {
            Thread.Sleep(5000);
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("custom-card-title")));
            driver.FindElement(By.ClassName("custom-card-title")).Click();
        }

        [Then(@"Office Details are loaded")]
        public void ThenOfficeDetailsAreLoaded()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("brokerofficename")));
            var officeNameLoaded = driver.FindElement(By.Id("brokerofficename"));
            Assert.IsNotNull(officeNameLoaded);
        }

        [Then(@"I verify Office Name")]
        public void ThenIVerifyOfficeName()
        {
            var officeNameActual = driver.FindElement(By.Id("brokerofficename")).Text;
            var officeNameActualTrimmed = officeNameActual.Replace(" (l.l.c)", "");
            Assert.AreEqual(office.OfficeName, officeNameActualTrimmed);
        }

        [Then(@"I verify Office Number")]
        public void ThenIVerifyOfficeNumber()
        {
            var officeNumberActual = driver.FindElement(By.Id("officeNumber")).Text;
            Assert.AreEqual(office.officeNumber, officeNumberActual);
        }

        [Then(@"I verify office Activity")]
        public void ThenIVerifyOfficeActivity()
        {
            Thread.Sleep(5000);
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
            var parentElement = driver.FindElement(By.Id("dvActivities"));
            //wait.Until(ExpectedConditions.ElementExists(By.ClassName("card-text")));
            var allChildElements = parentElement.FindElements(By.ClassName("card-text"));
            var activicties = allChildElements.Select(c => c.Text).ToList();

            Assert.IsTrue(activicties.Any(c => c == office.officeActivity));
        }


        [When(@"I click on Brokers tab")]
        public void WhenIClickOnBrokersTab()
        {
            driver.FindElement(By.Id("x2-tab")).Click();
        }

        [Then(@"Brokers list is loaded")]
        public void ThenBrokersListIsLoaded()
        {
            var brokerCount = driver.FindElement(By.Id("brokerscount")).Text;
            Assert.IsNotEmpty(brokerCount);
        }

        [Then(@"I verify Brokers count")]
        public void ThenIVerifyBrokersCount()
        {
            var brokerCountActual = driver.FindElement(By.Id("brokerscount")).Text.Replace("(", "");
            brokerCountActual = brokerCountActual.Replace(")", "");

            Assert.AreEqual(office.officeBrokerCount, brokerCountActual);
        }

        [When(@"I Click on Ranking tab")]
        public void WhenIClickOnRankingTab()
        {
            driver.FindElement(By.Id("x3-tab")).Click();
        }

        [Then(@"I verify office rank points")]
        public void ThenIVerifyOfficeRankPoints()
        {
            var officeRankActual = driver.FindElement(By.Id("totalPoints")).Text;
            Assert.AreEqual(office.officeRank, officeRankActual);
        }

        [When(@"I click on office Awards tab")]
        public void WhenIClickOnOfficeAwardsTab()
        {
            driver.FindElement(By.Id("x4-tab")).Click();

        }

        [Then(@"I verify awards")]
        public void ThenIVerifyAwards()
        {
            var officeAwardActual = driver.FindElement(By.Id("awardsList_office")).Text.Replace("\r\n2019","");

        }








    }
}
