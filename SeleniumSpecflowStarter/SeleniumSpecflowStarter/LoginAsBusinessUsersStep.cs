using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NPOI.XWPF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace SeleniumSpecflowStarter
{
    [Binding]
    public class LoginAsBusinessUsersStep
    {
        IWebDriver driver = null;

        public LoginAsBusinessUsersStep()
        {
            driver = WebDriverSingleton.GetInstance();
            //broker = TestData.ReadExcel(1);

        }

        [Given(@"I select Business user as Login option")]
        public void GivenISelectBusinessUserAsLoginOption()
        {
            driver.FindElements(By.ClassName("dropdown-item"))[0].Click();
        }
        [Given(@"I select Username and Password as Login option")]
        public void GivenISelectUsernameAndPasswordAsLoginOption()
        {
            driver.FindElement(By.Id("login-opt-sso-pass")).Click();
        }

        [Then(@"I enter Username as (.*)")]
        public void ThenIEnterUsernameAsRasheedt(string userName)
        {
            var usernameField = driver.FindElement(By.Id("ssoUsername"));
            usernameField.SendKeys(userName);
        }

        [Then(@"I enter Password as (.*)")]
        public void ThenIEnterPasswordAs(string password)
        {
            var passwordField = driver.FindElement(By.Id("ssoPassword"));
            passwordField.SendKeys(password);
        }

        [When(@"I Click Login button")]
        public void WhenIClickLoginButton()
        {
            driver.FindElement(By.XPath("//*[@id='emiratesID']/div[2]/button")).Click();
        }

        [Then(@"I am successfully logged in to Dubailand Dashboard")]
        public void ThenIAmSuccessfullyLoggedInToDubailandDashboard()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("page-title")));
            var dashboardSuccess = driver.FindElement(By.ClassName("page-title"));
            string dashboardTitle = dashboardSuccess.Text;
            Assert.IsTrue(dashboardTitle != null && dashboardTitle.Contains("Welcome to Dubai Land Department Application Dashboard"));
            //Assert.Contains("Welcome to Dubai Land Department Application Dashboard", dashboardTitle);
        }

        [When(@"I click on Go to Account button")]
        public void WhenIClickOnGoToAccountButton()
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[11]/section/div/div[2]/div[3]/div[2]/div/div[1]/div[2]/button")));
            driver.FindElement(By.XPath("/html/body/div[11]/section/div/div[2]/div[3]/div[2]/div/div[1]/div[2]/button")).Click();
        }

        [Then(@"user is redirect to Trakheesi application successfully")]
        public void ThenUserIsRedirectToTrakheesiApplicationSuccessfully()
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
            wait.Until(wd => wd.WindowHandles.Count == 2);
            this.driver.SwitchTo().Window(this.driver.WindowHandles[1]);

            try
            {
                var closeButton = driver.FindElement(By.ClassName("close"));

                if (closeButton != null)
                {
                    closeButton.Click();
                }
            }
            catch { }

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("MainContent_TabContainer1_TabLicenses_Licenses")));

            var licenseTab = driver.FindElement(By.Id("MainContent_TabContainer1_TabLicenses_Licenses"));
            string licenseTabLabel = licenseTab.Text;
            Assert.IsTrue(licenseTabLabel != null && licenseTabLabel.Contains("Licenses"));
            driver.Quit();
        }

        [Then(@"Trakheesi Company user is redirect to Trakheesi application successfully")]
        public void ThenTrakheesiCompanyUserIsRedirectToTrakheesiApplicationSuccessfully()
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
            wait.Until(wd => wd.WindowHandles.Count == 2);
            this.driver.SwitchTo().Window(this.driver.WindowHandles[1]);

            try { 
            var closeButton = driver.FindElement(By.ClassName("close"));

            if (closeButton != null)
            {
                closeButton.Click();
            }
            }
            catch { }
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("MainContent_TabContainer1_TabLicenses_TabLicensesLabel")));

            var licenseTab = driver.FindElement(By.Id("MainContent_TabContainer1_TabLicenses_TabLicensesLabel"));
            string licenseTabLabel = licenseTab.Text;
            Assert.IsTrue(licenseTabLabel != null && licenseTabLabel.Contains("License"));
            driver.Quit();
        }

        [Then(@"RVS employee user is redirect to RVS application successfully")]
        public void ThenRVSEmployeeUserIsRedirectToRVSApplicationSuccessfully()
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
            wait.Until(wd => wd.WindowHandles.Count == 2);
            this.driver.SwitchTo().Window(this.driver.WindowHandles[1]);

            var violationsDashboard = driver.FindElement(By.Id("rvs-tab"));
            string violationsDashboardlable = violationsDashboard.Text;
            Assert.IsTrue(violationsDashboardlable != null && violationsDashboardlable.Contains("Violation Dashboard"));
            driver.Quit();
        }

        [Then(@"Management Company user is redirect to Ejari application successfully")]
        public void ThenManagementCompanyUserIsRedirectToEjariApplicationSuccessfully()
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
            wait.Until(wd => wd.WindowHandles.Count == 2);
            this.driver.SwitchTo().Window(this.driver.WindowHandles[1]);

            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("btn-close")));
                var closeButton = driver.FindElement(By.ClassName("btn-close"));

                if (closeButton != null)
                {
                    closeButton.Click();
                }
            }
            catch { }
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("welcome-message")));

            var welcomeMessage = driver.FindElement(By.ClassName("welcome-message"));
            string welcomeMessageLabel = welcomeMessage.Text;
            Assert.IsTrue(welcomeMessageLabel != null && welcomeMessageLabel.Contains("Welcome\r\nTake a look at your activities, tasks, notifications and more."));
            driver.Quit();
        }





    }
}
