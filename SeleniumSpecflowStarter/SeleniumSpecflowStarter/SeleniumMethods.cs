using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using NUnit.Framework;
using System.Configuration;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace SeleniumSpecflowStarter
{
    public enum SearchType
    {
        Id,
        XPath,
        Name,
        LinkText,
        ClassName,
    }

    public enum WaitOption
    {
        Visibile,
        Clickable,
        Exists
    }
    public class SeleniumMethods
    {

        public static IWebElement findElement(IWebDriver driver, By by, WaitOption waitOption = WaitOption.Visibile)
        {
            if (by != null)
            {
                var condition = ExpectedConditions.ElementIsVisible(by);
                switch (waitOption)
                {
                    case WaitOption.Clickable:
                        condition = ExpectedConditions.ElementToBeClickable(by);
                        break;
                    case WaitOption.Exists:
                        condition = ExpectedConditions.ElementExists(by);
                        break;
                }

                var ele = new WebDriverWait(driver, new TimeSpan(0, 0, 20)).Until(condition);
                return ele;
            }

            return null;
        }

        internal static void EnterText(IWebDriver driver, string v, SearchType id)
        {
            throw new NotImplementedException();
        }

        public static void Sleep(IWebDriver driver, int secs)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(secs);
                fluentWait.PollingInterval = TimeSpan.FromSeconds(secs);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.Until(x => x.FindElement(By.Id("sdfdsfdsfdsfdsfdsf")));
            }
            catch (Exception e) { }
        }
        public static void ScrollTo(IWebDriver driver, IWebElement element )
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoViewIfNeeded()", element);
            //Sleep(driver,1);
        }
        public static IWebElement find(IWebDriver driver, string element, SearchType searchType, WaitOption waitOption = WaitOption.Visibile)
        {
            By by = null;
            switch (searchType)
            {
                case SearchType.Id:
                    by = By.Id(element);
                    break;
                case SearchType.ClassName:
                    by = By.ClassName(element);
                    break;
                case SearchType.LinkText:
                    by = By.LinkText(element);
                    break;
                case SearchType.Name:
                    by = By.Name(element);
                    break;
                case SearchType.XPath:
                    by = By.XPath(element);
                    break;
            }
            if (by != null)
            {
                return findElement(driver, by, waitOption);
            }

            return null;
        }
        public static IWebElement EnterText(IWebDriver driver, string element, string value, SearchType elementtype, bool clear = false, WaitOption waitOption = WaitOption.Visibile)
        {
            IWebElement ele = find(driver, element, elementtype, waitOption);

            if (ele != null)
            {
                if (clear) ele.Clear();
                ele.SendKeys(value);
            }
            return ele;
        }
        public static IWebElement UploadFile(IWebDriver driver, string element, string filePath, SearchType elementtype, WaitOption waitOption = WaitOption.Exists)
        {
            IWebElement ele = find(driver, element, elementtype, waitOption);

            if (ele != null)
            {
                ele.SendKeys(filePath);
            }
            return ele;
        }

        public static IWebElement SelectListDropDown(IWebDriver driver, string element, string value, SearchType elementtype, bool clear = false)
        {
            IWebElement ele = find(driver, element, elementtype);

            if (ele != null)
            {
                if (clear) ele.Clear();
                ele.SendKeys(value);
                ele.Click();
                driver.FindElement(By.TagName("body")).Click();
            }
            return ele;
        }
        public static void SetAttribute(IWebDriver driver, string element, string name, string value, SearchType elementtype, bool clear = false)
        {
            IWebElement ele = find(driver, element, elementtype);

            if (ele != null)
            {
                if (clear) ele.Clear();
                IJavaScriptExecutor exe = (IJavaScriptExecutor)driver;
                exe.ExecuteScript("document.getElementById('" + ele.GetAttribute("id") + "').setAttribute('" + name + "', '" + value + "')");
            }
        }
        public static void SetTelerikDate(IWebDriver driver, string elementID, DateTime date)
        {
            IWebElement ele = find(driver, elementID, SearchType.Id, WaitOption.Exists);

            if (ele != null)
            {
                IJavaScriptExecutor exe = (IJavaScriptExecutor)driver;
                string js = "var d = new Date();";
                js += "d.setFullYear(" + date.Year + "," + (date.Month - 1) + "," + date.Day + ");";
                js += "$telerik.findDatePicker('" + ele.GetAttribute("id") + "').set_selectedDate(d);";
                exe.ExecuteScript(js);
            }
        }
        //Click into a button, Checkbox, option etc

        public static void Click(IWebDriver driver, string element, SearchType elementtype)
        {
            IWebElement ele = find(driver, element, elementtype, WaitOption.Clickable);
            if (ele != null)
            {
                ele.Click();
            }

        }
        //Selecting a drop down control    (driver, "ctl00$ContentPlaceHolder1$PropertySearch1$UnitSearchParameters1$ddlStatus","Approved","Name")
        //SelectElement status = new SelectElement(driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$PropertySearch1$UnitSearchParameters1$ddlStatus")));

        public static void SelectDropDown(IWebDriver driver, string element, string value, SearchType elementtype)
        {
            IWebElement ele = find(driver, element, elementtype, WaitOption.Clickable);
            if (ele != null)
            {
                new SelectElement(ele).SelectByText(value);
            };
        }

        internal static void Click(object driver, string v, SearchType id)
        {
            throw new NotImplementedException();
        }
        internal static IWebElement FindByText(IWebDriver driver, string v, string tagName = "div")
        {
            return driver.FindElement(By.XPath("//" + tagName + "[text() = '" + v + "']"));
          
        }
        internal static void ClickByText(IWebDriver driver, string v, string tagName = "div")
        {
           IWebElement ele = FindByText(driver,v,tagName);
            if (ele != null)
            {
                ele.Click();
            }
        }
        internal static IWebElement ParentOf(IWebDriver driver, IWebElement child)
        {
           if(child != null)
            {
                WebElement parent = (WebElement)((IJavaScriptExecutor)driver).ExecuteScript(
                                   "return arguments[0].parentNode;", child);
                return parent;
            }
            return null;

        }

        internal static IWebElement FindChild( IWebElement parent,int childIndex, string tagName = "")
        {
            if (parent != null)
            {
                return parent.FindElement(By.XPath("./" + tagName  +"["+(childIndex +1)+"]"));
               
            }
            return null;

        }
        internal static ReadOnlyCollection<IWebElement> FindChildren(IWebElement parent, string tagName = "")
        {
            if (parent != null)
            {
                return parent.FindElements(By.XPath("./" + tagName + ""));

            }
            return null;

        }
        internal static string GetFiledValue(IWebDriver driver, string key)
        {
            var NameLabel = SeleniumMethods.FindByText(driver, key, "span");
            var container = SeleniumMethods.ParentOf(driver, NameLabel);
            var value = SeleniumMethods.FindChild(container, 1, "span");
            return value.Text;

        }
    }
}
