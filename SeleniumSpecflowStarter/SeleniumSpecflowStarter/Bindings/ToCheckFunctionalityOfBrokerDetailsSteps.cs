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
    public class ToCheckFunctionalityOfBrokerDetailsSteps : Common
    {
        Broker broker = null;

        public ToCheckFunctionalityOfBrokerDetailsSteps()
        {
            broker = TestData.ReadExcel(1);

        }
        [Given(@"I am on brokers list")]
        public void GivenIAmOnBrokersList()
        {
            EnsurePage("https://dubailand.gov.ae/en/eservices/licensed-real-estate-brokers/licensed-real-estate-brokers-list/#/");

        }

        [Given(@"I entered broker name")]
        public void GivenIEnteredBrokerName()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("service_directory_search")));
            var SearchInputBox = driver.FindElement(By.Id("service_directory_search"));
            SearchInputBox.SendKeys(broker.BrokerName);
            
            //driver.FindElement(By.Id("service_directory_btn")).Click();

        }

        [Given(@"I press search button")]
        public void GivenIPressSearchButton()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.Id("service_directory_btn")).Click();
            //searchbutton.Click();
        }

        [When(@"I select broker")]
        public void WhenISelectBroker()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".custom-card-title div")));
            //var selectbroker = driver.FindElement(By.CssSelector(".custom-card-title div"));
            Thread.Sleep(5000);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("custom-card-title")));
            var selectbroker = driver.FindElement(By.ClassName("custom-card-title"));

            selectbroker.Click();
        }

        [Then(@"broker details page should open")]
        public void ThenBrokerDetailsPageShouldOpen()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // Verify Broker name is correct
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("brokername")));
            var brokernametext = driver.FindElement(By.Id("brokername"));
            var text = brokernametext.Text;
            Assert.IsTrue(text.Contains(broker.BrokerName));

        }

        [Then(@"I verify broker number is correct")]
        public void ThenIVerifyBrokerNumberIsCorrect()
        {
            //Verify Broker Number is correct
            var brokernumber = driver.FindElement(By.Id("brokerNumber"));
            var bn = brokernumber.Text;
            Assert.AreEqual(broker.BrokerNumber, bn);
        }

        [Then(@"I Verify broker card issue date is correct")]
        public void ThenIVerifyBrokerCardIssueDateIsCorrect()
        {
            // Verify Broker Card issue date is correct
            var issuedate = driver.FindElement(By.CssSelector("#license-issue span"));
            var idate = issuedate.Text;
            Assert.AreEqual(broker.IssueDate.ToString("dd-MM-yyyy"), idate);
            var officetab = driver.FindElement(By.Id("RealEstatePartner-tab"));
            officetab.Click();
        }

        [Then(@"I Click on Office Tab")]
        public void ThenIClickOnOfficeTab()
        {
            // Verify Office number is correct
            var officenumber = driver.FindElement(By.Id("officeNumber"));
            var on = officenumber.Text;
            Assert.AreEqual(broker.OfficeNumber, on);
        }

        [Then(@"I Verify Office Number is correct")]
        public void ThenIVerifyOfficeNumberIsCorrect()
        {
            //Verify Office issue date is correct
            var officelicenseissue = driver.FindElement(By.Id("officelicenseissue"));
            var officeissue = officelicenseissue.Text;
            Assert.AreEqual(broker.OfficeIssueDate.ToString("dd-MM-yyyy"), officeissue);
        }

        [Then(@"I verify broker office activity is correct")]
        public void ThenIVerifyBrokerOfficeActivityIsCorrect()
        {
            Thread.Sleep(5000);
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
            var parentElement = driver.FindElement(By.Id("dvActivities"));
            //wait.Until(ExpectedConditions.ElementExists(By.ClassName("card-text")));
            var allChildElements = parentElement.FindElements(By.ClassName("card-text"));
            var activicties = allChildElements.Select(c => c.Text).ToList();

            Assert.IsTrue(activicties.Any(c => c == broker.OfficeActivity));
        }

        //Verify Office Activity
        //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("activity-name-0")));
        //var officeactivity = driver.FindElement(By.Id("activity-name-0"));
        //var oa = officeactivity.Text;
        //Assert.AreEqual(broker.OfficeActivity, oa);

        [Then(@"I click broker transactions tab")]
        public void ThenIClickBrokerTransactionsTab()
        {
            var saletransactionstab = driver.FindElement(By.Id("InternationalPartnerorOrganization-tab"));
            saletransactionstab.Click();
        }


        [Then(@"broker transactions counted correctly")]
        public void ThenBrokerTransactionsCountedCorrectly()
        {


            var transTable = driver.FindElement(By.CssSelector("#tblTransactions tbody"));
            //TagName strategy is used to get all <tr> elements 
            var tableRows = transTable.FindElements(By.TagName("tr")).ToList();

            //All table rows
            //foreach (var item in tableRows)
            //{
            //    var s = item.FindElement(By.TagName("td")).Text;
            //}

            var cells = tableRows[1].FindElements(By.TagName("td"));
            var year = cells[0].Text;
            var res = cells[1].Text;
            var comm = cells[2].Text;
            var total = Convert.ToInt32(cells[1].Text) + Convert.ToInt32(cells[2].Text);

            Assert.AreEqual(broker.TransactionYear, year);
            Assert.AreEqual(broker.TransactionResidential, res);
            Assert.AreEqual(broker.TransactionCommercial, comm);
            Assert.AreEqual(broker.TransactionTotal, total.ToString());
        }

        [Then(@"I Click on Projects")]
        public void ThenIClickOnProjects()
        {

            var projectstab = driver.FindElement(By.Id("Projects-tab"));
            projectstab.Click();

        }

        [Then(@"I verify Projects count")]
        public void ThenIVerifyProjectsCount()
        {
            Thread.Sleep(5000);
         
            var projectsList = new List<Project>();
            var projsTable = driver.FindElement(By.CssSelector("#tblProjects tbody"));
            //TagName strategy is used to get all <tr> elements 
            var tableRows = projsTable.FindElements(By.TagName("tr")).ToList();
            //tableRows.Sort();

            foreach (var row in tableRows)
            {
                var projcells = row.FindElements(By.TagName("td"));
                projectsList.Add(new Project()
                {
                    Name = projcells[0].Text,
                    TransactionCount = Convert.ToInt32(string.IsNullOrEmpty(projcells[1].Text) ? "0" : projcells[1].Text)
                });
            }

            Assert.IsTrue(projectsList.Any(c => c.Name == broker.ProjectName && c.TransactionCount.ToString() == broker.ProjTransactions));
            Assert.AreEqual(projectsList.Count.ToString(), broker.ProjectsTotal);
        }

        [Then(@"I Click on Ranking tab")]
        public void ThenIClickOnRankingTab()
        {
            var RankTab = driver.FindElement(By.Id("brokersRanking-tab"));
            RankTab.Click();
            
        }

        [Then(@"I verify Broker Rank points")]
        public void ThenIVerifyBrokerRankPoints()
        {
            var drpyear = driver.FindElement(By.Id("yearList"));
            var Oselect = new SelectElement(driver.FindElement(By.Id("yearList")));
            Oselect.SelectByValue(broker.RankYear);
            var rankpoints = driver.FindElement(By.Id("totalPoints"));
            var rp = rankpoints.Text.ToString();
            Assert.AreEqual(broker.RankPoints, rp);
        }

        [When(@"I click on Awards tab")]
        public void WhenIClickOnAwardsTab()
        {
            driver.FindElement(By.Id("brokersAwards-tab")).Click();
        }

        [Then(@"I verify Broker Award")]
        public void ThenIVerifyBrokerAward()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#brokersAwards div")));
           // char[] MyChar = {'2','0' };
            var awardActual = driver.FindElement(By.CssSelector("#brokersAwards div")).Text.Replace("\r\n2020","");
            
            Assert.IsTrue((broker.Awards).Contains(awardActual));
        }

        [Given(@"I Enter valid broker number")]
        public void GivenIEnterValidBrokerNumber()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("service_directory_search")));
            var SearchInputBox = driver.FindElement(By.Id("service_directory_search"));
            SearchInputBox.SendKeys(broker.BrokerNumber);
        }

        [Given(@"I enter valid Broker Mobile Number")]
        public void GivenIEnterValidBrokerMobileNumber()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("service_directory_search")));
            var SearchInputBox = driver.FindElement(By.Id("service_directory_search"));
            SearchInputBox.SendKeys(broker.BrokerMobile);
        }

        [Given(@"I enter valid Area Name")]
        public void GivenIEnterValidAreaName()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("service_directory_search")));
            var SearchInputBox = driver.FindElement(By.Id("service_directory_search"));
            SearchInputBox.SendKeys(broker.BrokerArea);
        }


        [Then(@"I close Browser")]
        public void ThenICloseBrowser()
        {
            driver.Close();
        }



    }


}
