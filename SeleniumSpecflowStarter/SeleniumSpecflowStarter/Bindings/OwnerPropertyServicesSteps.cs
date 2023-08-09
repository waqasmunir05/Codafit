using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace SeleniumSpecflowStarter.Features
{
    [Binding]
    public class OwnerPropertyServicesSteps
    {
        IWebDriver driver = null;

        public OwnerPropertyServicesSteps()
        {
            driver = WebDriverSingleton.GetInstance();
            //broker = TestData.ReadExcel(1);

        }


        [Then(@"I Click on To Whom It May Concern service")]
        public void ThenIClickOnToWhomItMayConcernService()
        {
            // var towhom = driver.FindElement(By.CssSelector(".profile-sidebar-body .icon-to-whom-concern-new"));
            // var parent = (WebElement)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].parentNode", towhom);
            //SeleniumMethods.Sleep(driver, 5);
            Thread.Sleep(2000);
            driver.FindElement(By.Id("closeChatNotif")).Click();
            var towhom = driver.FindElement(By.ClassName("icon-to-whom-concern-new"));
            SeleniumMethods.ScrollTo(driver, towhom);
            Thread.Sleep(2000);
            //SeleniumMethods.ScrollTo(driver, towhom);
            towhom.Click();

        }

        [Then(@"I navigate to To Whom It May Concern service page")]
        public void ThenINavigateToToWhomItMayConcernServicePage()
        {
            var towhomText = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[1]/div/div[1]"));
            var towhomText_expected = towhomText.Text;
            Assert.AreEqual("To whom it may concern", towhomText_expected);
        }

        [Then(@"I Click on Continue button")]
        public void ThenIClickOnContinueButton()
        {
            var continueButton = driver.FindElement(By.Id("btnContinue"));
            continueButton.Submit();
        }

        [Then(@"I verify fee details total is (.*)")]
        public void ThenIVerifyFeeDetailsTotalIs(string expectedFee)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[2]/div[1]/div[4]/span[2]")));
            var actualFee = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[2]/div[1]/div[4]/span[2]"));
            var actualFeeText = actualFee.Text;
            Assert.AreEqual(actualFeeText, expectedFee);

        }

        [Then(@"I Click Pay button")]
        public void ThenIClickPayButton()
        {
            driver.FindElement(By.ClassName("custom-control-label")).Click();
            driver.FindElement(By.ClassName("btn_style1")).Submit();
        }

        
        [When(@"I choose Noqodi payment method")]
        public void WhenIChooseNoqodiPaymentMethod()
        {
            
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
            wait.Until(wd => wd.WindowHandles.Count == 2);
            this.driver.SwitchTo().Window(this.driver.WindowHandles[1]);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btns_btnPay_0")));
             driver.FindElement(By.Id("btns_btnPay_0")).Click();

            //this.driver.SwitchTo().Window(this.driver.WindowHandles[0]);
        }

        [Then(@"I navigate to Noqodi payment details page")]
        public void ThenINavigateToNoqodiPaymentDetailsPage()
        {
            Thread.Sleep(5000);
            var noqodiPage = driver.FindElement(By.ClassName("hosted-preferred-method-text"));
            var noqodiText = noqodiPage.Text;
            Assert.AreEqual(noqodiText, "Choose preferred payment method");

        }

    


        [Then(@"I enter Noqodi username that is (.*)")]
        public void ThenIEnterNoqodiUsernameThatIsDw(string username)
        {
            driver.FindElement(By.CssSelector("input[formControlName=userId]")).SendKeys(username); 
        }



        [Then(@"I enter Password that is (.*)")]
        public void ThenIEnterPasswordThatIsPSs(string password)
        {
            driver.FindElement(By.CssSelector("input[formControlName=rawPasscode]")).SendKeys(password);
        }

        [When(@"I click on Login button")]
        public void WhenIClickOnLoginButton()
        {
            driver.FindElement(By.XPath("//button[contains(text(), 'Login')]")).Click();
        }

        [Then(@"user is logged in")]
        public void ThenUserIsLoggedIn()
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//Span[contains(text(), 'Agree & Pay')]")));
            var loggedIn = driver.FindElement(By.XPath("//Span[contains(text(), 'Agree & Pay')]")).Text;
            Assert.AreEqual("Agree & Pay", loggedIn);
        }

        [Then(@"I click on Pay button")]
        public void ThenIClickOnPayButton()
        {
            driver.FindElement(By.XPath("//Span[contains(text(), 'Agree & Pay')]")).Click();
        }

        [Then(@"I verify transaction is completed")]
        public void ThenIVerifyTransactionIsCompleted()
        {
            this.driver.SwitchTo().Window(this.driver.WindowHandles[0]);
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("svg-check-icon")));
            var completed = driver.FindElement(By.CssSelector("div[id='success'] h5")).Text;
            Assert.AreEqual("Your request has been submitted successfully.", completed);
        }

        [Then(@"I verify property count is (.*)")]
        public void ThenIVerifyPropertyCountIs(string propertyCount)
        {

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("property-number")));
            var count = driver.FindElement(By.ClassName("property-number"));
            var countValue = count.Text;
            Assert.AreEqual(propertyCount, countValue);
        }

        [When(@"I click on View All button")]
        public void WhenIClickOnViewAllButton()
        {
            driver.FindElement(By.ClassName("view-all-property")).Click();
        }

        [Then(@"list of owned properties appear")]
        public void ThenListOfOwnedPropertiesAppear()
        {
           var ownedPropertiestitle = driver.FindElement(By.ClassName("page-sub-title-extra")).Text;
            Assert.AreEqual("Owned Properties", ownedPropertiestitle);

        }

        [When(@"I Click on property details button")]
        public void WhenIClickOnPropertyDetailsButton()
        {
            driver.FindElement(By.Id("details")).Click();
        }

        [Then(@"property details appear")]
        public void ThenPropertyDetailsAppear()
        {
          var pageTitle =  driver.FindElement(By.ClassName("page-sub-title-extra")).Text;
            Assert.IsTrue(pageTitle.Contains("Property Details - Land Number"));

        }

        [Then(@"I verify Land number is (.*)")]
        public void ThenIVerifyLandNumberIs(string landNumeberExpected)
        {
            var landNumber = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[2]/div[1]/div[1]/span[2]/span")).Text;
            Assert.AreEqual(landNumber, landNumeberExpected);

        }

        [Then(@"I verify Area is (.*)")]
        public void ThenIVerifyAreaIsWadiAlSafa(string areaNameExpected)
        {
            var areaNameActual = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[2]/div[1]/div[3]/span[2]/span")).Text;
            Assert.AreEqual(areaNameExpected, areaNameActual);
        }

        [Then(@"I verify Size is (.*)")]
        public void ThenIVerifySizeIs(string sizeExpected)
        {
            var sizeActual = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[2]/div[1]/div[5]/span[2]/span")).Text;
            Assert.AreEqual(sizeExpected, sizeActual);

        }

        [Then(@"I verify Land Type is Residential")]
        public void ThenIVerifyLandTypeIsResidential()
        {
            var landType = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[2]/div[1]/div[7]/span[2]/span")).Text;
            Assert.AreEqual("Residential", landType);
        }

        [Then(@"I verify ownership is (.*)")]
        public void ThenIVerifyOwnershipIs(string ownershipExpected)
        {
            var ownershipActual = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[2]/div[1]/div[9]/span[2]/span")).Text;
            Assert.AreEqual(ownershipExpected, ownershipActual);
        }

        [Then(@"I verify property granted is No")]
        public void ThenIVerifyPropertyGrantedIsNo()
        {
            var grantedActual = driver.FindElement(By.ClassName("no-label")).Text;
            Assert.AreEqual("No", grantedActual);
        }

        [Then(@"I verify property status is Leased_To_Own")]
        public void ThenIVerifyPropertyStatusIsLeased_To_Own()
        {
            var propertyStatusActual = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[2]/div[1]/div[2]/span[2]/span")).Text;
            Assert.AreEqual("Leased_To_Own", propertyStatusActual);
        }

        [Then(@"I verify Property is Free Hold")]
        public void ThenIVerifyPropertyIsFreeHold()
        {
            var freeholdActual = driver.FindElement(By.ClassName("yes-label")).Text;
            Assert.AreEqual("Yes", freeholdActual);
        }






    }
}
