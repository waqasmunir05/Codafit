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
using static System.Net.WebRequestMethods;


namespace SeleniumSpecflowStarter.Bindings
{
    [Binding]
    public sealed class OwnerlLoginWithEmiratesID
    {

        IWebDriver driver = null;
        

        public OwnerlLoginWithEmiratesID()
        {
            driver = WebDriverSingleton.GetInstance();
            //broker = TestData.ReadExcel(1);

        }

        [Given(@"that I am on Dubailand website")]
        public void GivenThatIAmOnDubailandWebsite()
        {
            driver.Navigate().GoToUrl("https://dldwebqa.dubailand.gov.ae/en");
            driver.Manage().Window.Maximize();
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("sr-only")));
            //Thread.Sleep(10000);
            //driver.FindElement(By.XPath("//*[@id=]/div/div/div[3]/button")).Click();
            



        }

        [Given(@"I Press Sign In button")]
        public void GivenIPressSignInButton()
        {


            driver.FindElement(By.ClassName("icon-account")).Click();
            //signin.Click();
        }

        [Given(@"I navigate to Signin Page")]
        public void GivenINavigateToSigninPage()
        {
            var signintab = driver.FindElement(By.Id("login-content-tab"));
            var sitext = signintab.Text;
            Assert.AreEqual(sitext, "Sign in");
            
        }

        [Given(@"I select Owner Login option")]
        public void GivenISelectOwnerLoginOption()
        {
            Thread.Sleep(3000);


            //var owneremail = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[1]/div[2]/div[2]/ul[1]/li[1]/i"));
            driver.FindElements(By.ClassName("dropdown-item"))[1].Click();

            //loginIndividual.Click();
            
     
        }

        [Given(@"I Enter enter valid Owner Emirates ID (.*)")]
        public void GivenIEnterEnterValidOwnerEmiratesID(string p0)
        {
            var eid = driver.FindElement(By.Id("eid"));
            eid.SendKeys(p0);
            
        }

        [Given(@"I Enter valid Date of Birth (.*)")]
        public void GivenIEnterValidDateOfBirth(string dob)
        {
            Actions action = new Actions(driver);
            
            var dobele = driver.FindElement(By.Id("date-picker-inp-dob"));
            dobele.SendKeys(dob);
            dobele.SendKeys(Keys.Tab);
            //action.SendKeys(Keys.Escape);
        }
        


        [Given(@"I Press login button")]
        public void GivenIPressLoginButton()
        {
            Thread.Sleep(2000);
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[9]/div[2]/div[2]/div/div/div[1]/div/div/div/div[1]/div[3]/div/button")));
            driver.FindElement(By.XPath("//*[@id='businessUser']/div[4]/button")).Click();
            //*[@id="businessUser"]/div[4]/button
            //*[@id="login-content"]/div[3]/div/button
            

        }


        [Given(@"I Press Continue button")]
        public void GivenIPressContinueButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='token-verify']/div/div/div[2]/div[2]/button")));
            var continuebutton = driver.FindElement(By.XPath("//*[@id='token-verify']/div/div/div[2]/div[2]/button"));
            continuebutton.Click();

        }

        [When(@"I Enter valid Passcode (.*)")]
        public void WhenIEnterValidPasscode(string passcode)
        {
            var pcode = driver.FindElement(By.Name("password"));
            pcode.SendKeys(passcode);
            
        }

        [When(@"I Press Verify button")]
        public void WhenIPressVerifyButton()
        {
            //driver.FindElement(By.XPath("//*[@id]/div/div[4]/button")).Click();
            driver.FindElement(By.ClassName("otp-btn")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("otp-btn")));

        }

        [Then(@"Owner is logged In")]
        public void ThenOwnerIsLoggedIn()
        {
            Thread.Sleep(10000);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[11]/section/div/div/div[1]/div[1]")));
            var pagetitle = driver.FindElement(By.XPath("/html/body/div[11]/section/div/div/div[1]/div[1]"));
            var pt = pagetitle.Text;
            Assert.AreEqual("Personal Information", pt);



        }

        [Then(@"I verify owner name is (.*)")]
        public void ThenIVerifyOwnerNameIsRashidBinThaniBinKhalafAlthani(string ownername)
        {
            var on = driver.FindElement(By.XPath("/html/body/div[11]/section/div/div/div[1]/div[2]/div[1]/div/h5"));
            var oname = on.Text;
            Assert.AreEqual(ownername, oname);
        }
        [Then(@"I verify email is (.*)")]
        public void ThenIVerifyEmailIsWaqas_MunirEres_Ae(string email)
        {
            var owneremail = driver.FindElement(By.CssSelector(".profile-sidebar-body .icon-email-link"));
            var parent = (WebElement)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].parentNode", owneremail);
            //var owneremail = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[1]/div[2]/div[2]/ul[1]/li[1]/i"));
            var oe = parent.Text;
            Assert.AreEqual(email, oe);

        }

        [Then(@"I verify mobile is (.*)")]
        public void ThenIVerifyMobileIs(string ownermobile)
        {
            var mobile = driver.FindElement(By.CssSelector(".profile-sidebar-body .icon-call-link"));
            var parent = (WebElement)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].parentNode", mobile);
            //var owneremail = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[1]/div[2]/div[2]/ul[1]/li[1]/i"));
            var mob = parent.Text;
            Assert.AreEqual(ownermobile, mob);
        }

        [Then(@"I verify emiratesid is (.*)")]
        public void ThenIVerifyEmiratesidIs(string emiratesid)
        {
            var eid = driver.FindElement(By.CssSelector(".profile-sidebar-body .fax-icon-new"));
            var parent = (WebElement)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].parentNode", eid);
            //var owneremail = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[1]/div[2]/div[2]/ul[1]/li[1]/i"));
            var id = parent.Text;
            id =id.Replace ("-","");
            Assert.AreEqual(emiratesid, id);
            
        }
        // Login with Mobile number
        [Given(@"I select Mobile login option")]
        public void GivenISelectMobileLoginOption()
        {
            SeleniumMethods.ClickByText(driver, "Mobile Number", "label");
            

        }

        [Given(@"I Enter valid owner mobile number (.*)")]
        public void GivenIEnterValidOwnerMobileNumber(string mobile)
        {
            driver.FindElement(By.Id("mobile")).SendKeys(mobile);
        }

        [Given(@"I select Title Deed option")]
        public void GivenISelectTitleDeedOption()
        {
            SeleniumMethods.ClickByText(driver, "Title Deed", "label");
        }

        [Given(@"I enter Certificate number (.*)")]
        public void GivenIEnterCertificateNumber(string certificatenumber)
        {
            driver.FindElement(By.Id("certNumber")).SendKeys(certificatenumber);
        }

        [Given(@"I select certificate issue date (.*)")]
        public void GivenISelectCertificateIssueDate(string date)
        {

            Actions action = new Actions(driver);

            var dobele = driver.FindElement(By.Id("cert_date_x"));
            dobele.SendKeys(date);
            dobele.SendKeys(Keys.Enter);
            //cdate.Click();




        }

        [Given(@"I enter owner number (.*)")]
        public void GivenIEnterOwnerNumber(string ownernumber)
        {
            driver.FindElement(By.Id("pDetail")).SendKeys(ownernumber);
        }


        // Login with invalid emirates ID

        [Then(@"error message displayed with user not found")]
        public void ThenErrorMessageDisplayedWithUserNotFound()
        {
            Thread.Sleep(2000);
            //var feedback = driver.FindElement(By.ClassName("invalid-feedback"));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='messagePopUpx']/div/div/div[2]/p")));
            var feedback = driver.FindElement(By.XPath("//*[@id='messagePopUpx']/div/div/div[2]/p"));
            string invalidmessage = feedback.Text;
            Assert.AreEqual("If you are tenant you need to proceed for registration, If you are owner you need to update your contact details through our Trustee services centers.", invalidmessage);


        }

        // Property owner logout
        [Then(@"I Click on Logout button")]
        public void ThenIClickOnLogoutButton()
        {
            // var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            // wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[9]/div[3]/section[2]/div/div/div[1]/div[2]/div[2]/ul[2]/li[4]/a/i")));
            //driver.FindElement(By.XPath("/html/body/div[9]/div[3]/section[2]/div/div/div[1]/div[2]/div[2]/ul[2]/li[4]/a/i")).Click();
            /* Thread.Sleep(5000);
             var logout = driver.FindElement(By.ClassName("icon-logout-new"));
             var parent = (WebElement)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].parentNode", logout);
             //var owneremail = driver.FindElement(By.XPath("/html/body/div[9]/div[2]/section[2]/div/div/div[1]/div[2]/div[2]/ul[1]/li[1]/i"));
             var element = driver.FindElement(By.CssSelector(".profile-sidebar-body .icon-logout-new"));
             // Actions actions = new Actions(driver);
             SeleniumMethods.ScrollTo(driver, logout);

             var title = driver.FindElement(By.ClassName("card-body"));
             SeleniumMethods.ScrollTo(driver, title);
             SeleniumMethods.ScrollTo(driver, logout);*/

            driver.FindElement(By.ClassName("icon-account")).Click();
            driver.FindElements(By.ClassName("dropdown-item"))[3].Click();

            // actions.Perform();
            //driver.FindElement(By.ClassName("html")).SendKeys(Keys.Control, Keys.Subtract);
           // logout.Click();
        }

        [When(@"I click confirm logout button")]
        public void WhenIClickConfirmLogoutButton()
        {
            Thread.Sleep(3000);
            var logoutButton = driver.FindElement(By.CssSelector("#logout-confirm .btn-block:first-child"));
            logoutButton.Click();
        }


        [Then(@"user is logged out")]
        public void ThenUserIsLoggedOut()
        {
            var logout = driver.FindElement(By.ClassName("sso-left-panel"));
            var logouttext = logout.Text;
            
            Assert.AreEqual(logouttext, "You have logged out successfully.");

        }




    }
}
