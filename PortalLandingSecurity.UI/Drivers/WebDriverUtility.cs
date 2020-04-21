
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecurityLandingPortal.Drivers
{
    public static class WebDriverUtility
    {
        #region privateVariables
        static readonly double waitTimefromApp = Double.Parse(ConfigurationManager.AppSettings["waitElement"].ToString());
        static readonly double timeSpanfromApp = Double.Parse(ConfigurationManager.AppSettings["timeSpan"].ToString());
        private static readonly object wait;
        static TimeSpan timeSpan = TimeSpan.FromMilliseconds(timeSpanfromApp);
        static TimeSpan wait_Time = TimeSpan.FromMilliseconds(waitTimefromApp);
        //static IWebDriver driver = null;
        static string parentHandler;
        #endregion

        
        #region publicMethods
        #region Navigate URL
        ///<summary>
        ///Clear cookies, maximize the window and navigate the URL specified
        ///</summary>
        public static void NavigateUrl(IWebDriver webDriver, string URL)
        {
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(URL);
            WaitForPageToLoad(webDriver);
            Thread.Sleep(5000);
            ClickAcceptCookieBtn(webDriver);
            //wait
        }
        

        public static void ClickAcceptCookieBtn(IWebDriver webDriver)
        {
            Boolean IcookieBtnPresent = webDriver.FindElements(By.ClassName("evidon-banner-acceptbutton")).Count > 0;
            if (IcookieBtnPresent)
            {
                  webDriver.FindElement(By.ClassName("evidon-banner-acceptbutton")).Click();
            }
        }
        public static string getUrlOfCurrentPage(IWebDriver webDriver)
        {
            return webDriver.Url;
        }

        #endregion
        #region navigation back 
        public static void NavigationBack(IWebDriver driver)
        {
            driver.Navigate().Back();
        }
        #endregion

        #region Wait functionality

        ///<summary>
        ///Wait until the Element is Displayed in DOM. Won't check if Element is displayed on UI
        ///</summary>
        ///<param name="webDriver"></param>
        ///<param name="by"></param>
        ///<param name="="waitTime"></param>
        ///<returns><returns>
        public static bool WaitForElementPresentinDOM(this IWebDriver webDriver, By by, TimeSpan? waitTime = null)
        {
            try
            {
                if (waitTime == null)
                    waitTime = wait_Time; // If no wait time set from the page class, than use the default
                WebDriverWait wait = new WebDriverWait(webDriver, waitTime.Value);
                wait.Until(ExpectedConditions.ElementExists(by));
                return true;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }
        public static void WaitForPageToLoad(IWebDriver webDriver, int timeOut = 60)
        {
            try
            {
                //if (waitTime == null)
                //    waitTime = wait_Time; // If no wait time set from the page class, than use the default
                //int timeOut = int.Parse(waitTime);
                IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
                String command = "return document.readyState";
                bool isPageLoaded = false;

                string loadedStatus = js.ExecuteScript(command).ToString();

                for (int i = 1; i <= timeOut; i++)
                {
                    //Check the readyState again
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    loadedStatus = js.ExecuteScript(command).ToString();
                   
                    if (js.ExecuteScript(command).ToString().Equals("complete"))
                    {
                        Console.WriteLine("WaitForPageLoad: " + js.ExecuteScript(command).ToString() + ". Seconds Taken : " + i + ".");
                        isPageLoaded = true;
                        break;
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }

                if (!isPageLoaded)
                {
                    Console.WriteLine(string.Format("WaitForPageLoad Timed Out after waiting for seconds: {0}. Page Not Loaded (or) Page Slow.", timeOut));
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region Refresh Page
        public static void RefreshCurrentPage(this IWebDriver webDriver, int noOfTime = 1)
        {
            webDriver.Navigate().Refresh();
        }
        #endregion

        public static void ClickElemntByJS(IWebElement element, IWebDriver webDriver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("var evt = document.createEvent('MouseEvents');" + "evt.initMouseEvent('click',true, true, window, " +
                "0, 0, 0, 0, 0, false, false, false, false, 0,null);" + "arguments[0].dispatchEvent(evt);", element);

        }

       
        
        #region Browser Screenshot
        public static void GetBrowserScreenshot(IWebDriver driver, TestContext context)
        {
            //string filePath = context.TestRunDirectory + @"\Screenshots";
            //if (!Directory.Exists(filePath))
            //    Directory.CreateDirectory(filePath);
            //context.WriteLine("TEST SCRIPT FAILURE DUE TO EXCEPTION--SCREENSHOT");
            //var screenshotFileName = filePath + "\\" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".jpeg";
            //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotFileName, ScreenshotImageFormat.Jpeg);
            //context.AddResultFile(screenshotFileName);
            ////writeline the name of the file
            //context.WriteLine("ScreenShot is saved at " + screenshotFileName);
            //context.WriteLine("-----------------------------------------------");
        }
        #endregion
        public static void Click(this IWebElement webElement, IWebDriver webDriver, TimeSpan? WaitTime = null)
        {
            bool executeOnException = true;
            try
            {
                // bool eleFound = webElement.FindElement
            }
            catch (Exception e)
            {

            }
        }

        ///<summary>
        /// Getting elements with the locator
        ///</summary>
        public static IWebElement GetElement(this IWebDriver webDriver, By by, TimeSpan? waitTime = null)
        {
            if (waitTime == null)
            {
                waitTime = wait_Time; // If no wait time set from the page class, than use the default 
            }
            var wait = new WebDriverWait(webDriver, waitTime.Value);
            try
            {
                webDriver.WaitForElementPresentinDOM(by, waitTime);
                return wait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (Exception e)
            {
                return null;
            }


        }

        ///<summary>
        /// Getting list of elements with the locator
        ///</summary>
        //public static List<IWebElement> GetElements(this IWebDriver webDriver, By by, TimeSpan? waitTime = null)
        //{
        //    try
        //    {
        //        if (waitTime == null)
        //        {
        //            waitTime = wait_Time;// If no wait time set from the page class, than use the default 
        //        }
        //        if (ConfigurationManager.AppSettings["WebDriver"].ToLower() == "edge")
        //        {
        //            ((IJavaScriptExecutor)webDriver).ExecuteScript("window.scrollTo(0, 0);");
        //        }
        //        webDriver.WaitForElementPresentinDOM(by, waitTime);
        //        List<IWebElement> elements = webDriver.FindElements(by, waitTime.Value).Where(a => a.Displayed).ToList();
        //        Console.WriteLine("List of elements found: " + elements.Count);
        //        return elements;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}
        //public static void WaitForPageLoad()
        //{
        //    driver.WaitForPageLoad(TimeSpan.FromSeconds(200));
        //}

        //public static bool isDocumentReady(IWebDriver webDriver, int seconds = 280)
        //{
        //    try
        //    {
        //        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
        //        wait.Until(webDriver => webDriver.ExecuteJavaScript<string>("return document.readyState").Equals("complete"));
        //        //if (!chatenable)
        //        //{
        //        //    DisableChat();
        //        //}
        //        //DisableCookieConsent();
        //        return true;
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
                
        //        return false;
        //    }
        //}
        /////<summary>
        /////Wait until the Element is Displayed in DOM. Won't check if Element is displayed on UI
        /////</summary>
        /////<param name="webDriver"></param>
        /////<param name="by"></param>
        /////<param name="="waitTime"></param>
        /////<returns><returns>
        //public static bool WaitForElementPresentinDOM(this IWebDriver webDriver, By by, TimeSpan? waitTime = null)
        //{
        //    try
        //    {
        //        if(waitTime == null)
        //               waitTime = wait_Time; // If no wait time set from the page class, than use the default
        //        WebDriverWait wait = new WebDriverWait(webDriver, waitTime.Value);
        //        wait.Until(ExpectedConditions.ElementExists(by));
        //        return true;
        //    }
        //    catch(StaleElementReferenceException)
        //    {
        //        return false;
        //    }
        //}

        public static void ScrollAndClickByElement(this IWebDriver driver, IWebElement element)
        {
            int elementPosition = element.Location.Y;
            ((IJavaScriptExecutor)driver).ExecuteScript(string.Format("window.scroll(0, {0} - 200)", elementPosition));
            Actions builder = new Actions(driver);
            builder.MoveToElement(element, element.Location.X, element.Location.Y).Click().Build().Perform();
        }

        public static bool IsElementVisible(this IWebDriver driver, IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        /// <summary>
        /// Wait until the Element is displayed on the UI
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="waitTime"></param>
        /// <returns></returns>

        public static bool WaitForElementDisplay(this IWebDriver driver, IWebElement element, TimeSpan? waitTime = null)
        {
            try
            {
                if (waitTime == null)
                    waitTime = wait_Time; // If no Wait time set from the page class, then use the default.
                WebDriverWait wait = new WebDriverWait(driver, waitTime.Value);
                return wait.Until(d => element.Displayed);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool WaitForElementDisplayInPage(IWebDriver driver, By by, int timeout)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Wait until the Element is displayed on the UI
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="waitTime"></param>
        /// <returns></returns>

        public static bool WaitForElementDisplay(this IWebDriver driver, By by, TimeSpan? waitTime = null)
        {
            try
            {
                if (waitTime == null)
                    waitTime = wait_Time; // If no Wait time set from the page class, then use the default.
                WebDriverWait wait = new WebDriverWait(driver, waitTime.Value);
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool isClickable(this IWebDriver driver, IWebElement el)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementToBeClickable(el));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
       
        private static void Verify_ElementIsNotClickable(this IWebDriver driver, IWebElement item)
        {
            try
            {
                Actions action = new Actions(driver);
                action.MoveToElement(item).Click().Build().Perform();
                // Actions action = new Actions(driver).MoveToElement(item).Click().Build().Perform();
            }
            catch (Exception ex)
            {

            }
            //Assert.IsFalse(isClickable(item), "No Result Found element was clickable");
        }
        public static bool ValidateRestrictEmails(IWebElement e)
        {
            bool b = false;
            List<string> emailids = new List<string>();
            emailids.Add("a@a.com");
            emailids.Add("a@g.com");
            emailids.Add("abc@dell.com");
            emailids.Add("dell.com@aguel.com");
            emailids.Add("no@email.com");
            emailids.Add("noemail@dell.com");
            emailids.Add("NOMAIL@MAIL.COM");
            emailids.Add("non@non.com");
            emailids.Add("test@dell.com");
            emailids.Add("Test@email.com");
            emailids.Add("test@test.com");
            emailids.Add("test@test.comt");
            emailids.Add("test@test.in");
            emailids.Add("TEST@test1.com");
            emailids.Add("Test@Tester.com");
            emailids.Add("test4@test4.com");
            emailids.Add("TestUAT@uat.com");

            for (int i = 0; i < emailids.Count(); i++)
            {
                if (e.Text.Equals(emailids[i]))
                //if (e.Equals(emailids[i]))
                {
                    b = true;
                    break;
                }

                else
                {
                    b = false;
                }
            }

            return b;
        }

        public static bool HandlePopup(IWebDriver webDriver)
        {
            try
            {
                    if (!string.IsNullOrEmpty(Convert.ToString(webDriver.FindElement(By.XPath("//*[@id='IPEinvL']/div[2]/div[2]/div[2]/div/span[1]")))))//Id("ipeWrapper")))))
                {
                    Console.WriteLine(string.Format("{0}: {1}", DateTime.UtcNow, "Info: Clearing IPerception Survey window"));
                    IJavaScriptExecutor js = webDriver as IJavaScriptExecutor;
                    js.ExecuteScript("javascript:clWin()");
                    Thread.Sleep(30000);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }


        public static void OnElementClick(IWebElement elelment, IWebDriver driver)
        {
            try
            {
                elelment.Click();
            }
            catch
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", elelment);
            }
        }

     

        ///// <summary>
        ///// Execute JavaScript
        ///// </summary>
        ///// <param name="action">Action object</param>
        ///// <param name="javascript">Javascript string</param>
        //public void ExecuteJavaScript(string javascript)
        //{
        //    Console.WriteLine(string.Format("{0}: {1}", DateTime.UtcNow, "Info: Executing JavaScript"));
        //    IJavaScriptExecutor js = webDriver as IJavaScriptExecutor;
        //    js.ExecuteScript(javascript);
        //    WaitForPageToLoad();
        //}
    }
}
#endregion