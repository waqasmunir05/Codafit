using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumSpecflowStarter.Bindings
{
    public class Common
    {
        protected IWebDriver driver = null;
        public Common()
        {
            driver = WebDriverSingleton.GetInstance();
         
        }

        protected void EnsurePage(string pageUrl)
        {
            driver.Navigate().GoToUrl(pageUrl);
            driver.Manage().Window.Maximize();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}
