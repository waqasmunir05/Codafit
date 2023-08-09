using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSpecflowStarter
{
    public class WebDriverSingleton
    {
        private static IWebDriver driver;
        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new ChromeDriver(@"C:\WebDriver");
            }
            return driver;
        }
    }
}
