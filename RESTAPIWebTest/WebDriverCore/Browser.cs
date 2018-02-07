using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using RESTAPIWebTest.Extensions;
using RESTAPIWebTest.WebDriverCore.Enums;

namespace RESTAPIWebTest.WebDriverCore
{
    public static class Browser
    {
        private static IWebDriver _webDriver;

        // Define the interface used to search for elements
        public static ISearchContext SearchContext => Driver;

        public static IJavaScriptExecutor JavaScriptExecutor => Driver as IJavaScriptExecutor;

        public static int WaitTimeout => 5;     // default it to 5 seconds

        private static IWebDriver Driver => _webDriver ?? (_webDriver = Initialize());

        public static void GoToUrl(string p_Url)
        {
            Driver.Navigate().GoToUrl(p_Url);
        }

        public static void Navigate(string p_Url)
        {
            GoToUrl(p_Url);
        }

        public static void NavigateWithLogin(string p_User, string p_HttpUrl)
        {
            var username = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];

            // remove the http:// to insert login credentials
            var systemPath = p_HttpUrl.Remove(0, 7);
            GoToUrl($"http://{username}:{password}@{systemPath}");
        }

        public static void IntroduceWaitForChrome()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static void DeleteCookies()
        {
            try
            {
                Driver.Manage().Cookies.DeleteAllCookies();
            }
            catch
            {
                // Ignored
            }
        }

        public static void SetCookie(string p_Name, string p_Value)
        {
            Driver.Manage().Cookies.AddCookie(new Cookie(p_Name, p_Value));
        }

        public static void SetDomainCookie(string p_Name, string p_Value, string p_Domain, string p_Path = "/")
        {
            Driver.Manage().Cookies.AddCookie(new Cookie(p_Name, p_Value, p_Domain, p_Path, null));
        }

        public static void DeleteDomainCookie(string p_Name)
        {
            Driver.Manage().Cookies.DeleteCookieNamed(p_Name);
        }

        public static void DisableJavascriptOnFirefox()
        {
            Driver.Url = "about:config";
            var act = new Actions(Driver);
            act.SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();
            act.SendKeys(Keys.Return).SendKeys("javascript.enabled").Perform();
            Thread.Sleep(2000);
            act.SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();
        }

        public static void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public static void GoToPreviousPage()
        {
            Driver.Navigate().Back();
        }

        public static string GetBrowserType()
        {
            var capabilities = ((RemoteWebDriver)Driver).Capabilities;
            return capabilities.BrowserName;
        }

        public static void CloseBrowserPopup()
        {
            if (!IsAlertPresent())
                return;

            Driver.SwitchTo().Alert().Accept();
        }

        public static void DismissBrowserPopup()
        {
            if (!IsAlertPresent())
                return;

            Driver.SwitchTo().Alert().Dismiss();
        }

        public static void SwitchToFrame(IWebElement p_Frame)
        {
            Driver.SwitchTo().Frame(p_Frame);
        }

        public static void SwitchToFrame(int p_Index)
        {
            Driver.SwitchTo().Frame(p_Index);
        }

        public static void SwitchToDefaultDocument()
        {
            Driver.SwitchTo().DefaultContent();
        }

        public static bool HasAjaxElementFinishedTask(string p_ClassId, int p_Timeout = 15)
        {
            // set the timeout to zero to fast search if the class is there
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            if (Driver.FindElements(By.ClassName(p_ClassId)).Count == 0)
            {
                return true;
            }

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(p_Timeout);
            bool isValid;

            // Set the explicit wait period
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(p_Timeout));
            try
            {
                // Now pool for the ajax element whilst it is in action.  If it's not found it throws an immediate exception
                isValid = wait.Until(p_Driver => p_Driver.FindElement(By.ClassName(p_ClassId)).Displayed == false);
            }
            catch (Exception)
            {
                // If not found, then assume it's actually not there - so return ok
                isValid = true;
            }

            return isValid;
        }

        public static string GetCurrentUrl()
        {
            return Driver.Url;
        }

        public static ReadOnlyCollection<string> GetWindowHandles()
        {
            return Driver.WindowHandles;
        }

        public static void SwitchToWindowHandle(int p_Window)
        {
            var windowHandles = GetWindowHandles();
            Driver.SwitchTo().Window(windowHandles[p_Window]);
        }

        public static void SwitchToLastWindow()
        {
            var windowHandles = GetWindowHandles();
            Driver.SwitchTo().Window(windowHandles.Last());
        }

        public static void SwitchToWindowAlert()
        {
            Driver.SwitchTo().Alert();
        }

        public static string GetCurrentUrlFromLastTab()
        {
            FocusOnLastTab();
            return GetCurrentUrl();
        }

        public static string GetTitle()
        {
            return Driver.Title;
        }

        public static void FocusOnLastTab()
        {
            Driver.SwitchTo().Window(GetWindowHandles().Last());
        }

        public static IWebElement GetElement(By p_ElementLocalization)
        {
            return SearchContext.FindElement(p_ElementLocalization);
        }

        public static IWebElement GetElementWithWait(By p_ElementLocalization)
        {
            WaitForPageLoadComplete();
            GetWaitDriver().Until(ExpectedConditions.ElementIsVisible(p_ElementLocalization));
            return SearchContext.FindElement(p_ElementLocalization);
        }

        public static void WaitUntilElementIsNotVisible(string p_Localization)
        {
            var wait = GetWaitDriver();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(p_Localization)));
        }

        public static void WaitUntilElementIsNotVisible(By p_ElementSpecification)
        {
            var wait = GetWaitDriver();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(p_ElementSpecification));
        }

        public static void WaitFor(By p_ElementSpecification)
        {
            WaitFor(p_ElementSpecification, WaitTimeout);
        }

        public static void WaitFor(By p_ElementSpecification, int p_Timeout)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(p_Timeout));

            try
            {
                wait.Until(p_Driver =>
                {
                    try
                    {
                        p_Driver.FindElement(p_ElementSpecification);
                        return true;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                ////continue
            }
        }

        public static void WaitForElementToAppear(By p_ElementSpecification, int p_Timeout)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(p_Timeout));
            wait.Until(ExpectedConditions.ElementIsVisible(p_ElementSpecification));
        }

        public static void WaitForElementToAppear(By p_ElementSpecification, int p_Timeout, params Type[] p_ExceptionTypes)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(p_Timeout));
            wait.IgnoreExceptionTypes(p_ExceptionTypes);
            wait.PollingInterval = TimeSpan.FromMilliseconds(1000);
            wait.Until(ExpectedConditions.ElementIsVisible(p_ElementSpecification));
        }

        public static void WaitForElementToAppear(IWebElement p_Element)
        {
            WaitForPageAndScriptsLoadComplete();
            GetWaitDriver().Until(p_Driver => p_Element.Displayed);
        }

        public static void WaitForElementToAppear(By p_ElementSpecification)
        {
            WaitForPageLoadComplete();
            GetWaitDriver().Until(ExpectedConditions.ElementIsVisible(p_ElementSpecification));
        }

        public static void WaitForElementToBeEnabled(IWebElement p_Element)
        {
            GetWaitDriver().Until(p_Driver => p_Element.Enabled);
        }

        public static void WaitForElementToBeEnabled(IWebElement p_Element, bool p_CheckByClass)
        {
            GetWaitDriver().Until(p_Driver => !p_Element.HasClass("is-disabled"));
        }

        public static void WaitForElementToBeEnabled(By p_ElementLocation)
        {
            GetWaitDriver().Until(p_Driver => ExpectedConditions.ElementToBeClickable(p_ElementLocation));
        }

        public static void WaitForElementToBeDisabled(IWebElement p_Element)
        {
            GetWaitDriver().Until(p_Driver => !p_Element.Enabled);
        }

        public static void WaitForElementToBeHidden(IWebElement p_Element)
        {
            GetWaitDriver().Until(p_Driver => p_Element.HasClass("u-hidden"));
        }

        public static void WaitForNoAjaxRequestsPending()
        {
            try
            {
                GetWaitDriver().Until(p_Driver => ((IJavaScriptExecutor)p_Driver)?.ExecuteScript(@"return document.readyState").ToString().Equals("complete", StringComparison.InvariantCultureIgnoreCase));
                GetWaitDriver().Until(p_Driver => (bool)((IJavaScriptExecutor)p_Driver).ExecuteScript(@"return window.jQuery != undefined && jQuery.active === 0"));
            }
            catch (Exception)
            {
                // Ignored
            }
        }

        public static void WaitUntil(Func<IWebDriver, bool> p_Predicate, int p_Timeout)
        {
            var waitDriver = new WebDriverWait(Driver, TimeSpan.FromSeconds(p_Timeout));
            waitDriver.Until(p_Driver => p_Predicate(Driver));
        }

        public static object GetJavaScriptObject(string p_ObjectToSearch)
        {
            try
            {
                return JavaScriptExecutor.ExecuteScript($"return {p_ObjectToSearch}");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void WaitForPageLoadComplete(int p_Timeout = -1)
        {
            if (p_Timeout == -1)
            {
                p_Timeout = WaitTimeout;
            }

            Driver.Manage().Timeouts().PageLoad = new TimeSpan(p_Timeout * 10000000); // 1 tick = one 10 millionth of a second so multiply to resolve back

            IWait<IWebDriver> wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(p_Timeout));
            wait.Until(p_Driver => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void WaitForPageAndScriptsLoadComplete()
        {
            WaitForNoAjaxRequestsPending();
            WaitForPageLoadComplete();
        }

        public static void WaitForErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WaitTimeout));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.form-row__error-message")));
        }

        public static void MaximizeWindow()
        {
            Driver.Manage().Window.Maximize();
        }

        public static void Close()
        {
            Driver.Quit();

            if (_webDriver != null)
            {
                _webDriver.Dispose();
                _webDriver = null;
            }
        }

        public static void CloseLastTab()
        {
            _webDriver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }

        public static void CloseSingleTab()
        {
            Driver.ExecuteJavaScript("window.close();");
        }

        public static string GetNewWindowTitle()
        {
            var currentWindowHandle = Driver.CurrentWindowHandle;

            var newWindowHandle = Driver.WindowHandles.Single(p_Wh => p_Wh != currentWindowHandle);
            Driver.SwitchTo().Window(newWindowHandle);

            var newWindowTitle = Driver.Title;

            // close newly opened window then switch back to the original window
            Driver.Close();
            Driver.SwitchTo().Window(currentWindowHandle);

            return newWindowTitle;
        }

        public static bool IsAlertPresent()
        {
            try
            {
                Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
            catch (NoSuchWindowException)
            {
                return false;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        public static IWebElement MoveToElement(IWebElement p_Element)
        {
            Actions act = new Actions(Driver);
            act.MoveToElement(p_Element);
            act.Perform();
            return p_Element;
        }

        public static void OpenNewBrowsersTab()
        {
            Driver.ExecuteJavaScript("window.open();");
            FocusOnLastTab();
        }

        public static void ScrollToElement(IWebElement p_Element)
        {
            try
            {
                var position = p_Element.Location.Y.ToString();
                var script = $"('#main-container').scrollTop({position})";
                ((IJavaScriptExecutor)Driver).ExecuteScript(script);
            }
            catch
            {
                // Ignored
            }
        }

        public static void ScrollIntoView(IWebElement p_Element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView();", p_Element);
        }

        private static WebDriverWait GetWaitDriver()
        {
            var waitDriver = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            return waitDriver;
        }

        private static IWebDriver GetWebDriver(BrowserType p_Browser)
        {
            var driver = GetDriver(p_Browser);

            // Implicit wait of up to 10 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            return driver;
        }
        private static IWebDriver GetDriver(BrowserType p_Browser)
        {
            switch (p_Browser)
            {
                case BrowserType.Chrome:
                    var options = new ChromeOptions();
                    options.AddArgument("start-maximized");
                    return new ChromeDriver( options);

                case BrowserType.Firefox:
                    var profile = new FirefoxProfile();
                    profile.SetPreference("acceptUntrustedCerts", true);
                    return new FirefoxDriver(profile);

                case BrowserType.InternetExplorer:
                    return new InternetExplorerDriver(
                        new InternetExplorerOptions
                        {
                            IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                            UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss,
                            EnsureCleanSession = true
                        });

                case BrowserType.PhantomJs:
                    return new PhantomJSDriver();

                case BrowserType.Safari:
                    return new SafariDriver();

                default:
                    Assert.Fail($"Browser type {p_Browser} not handled.");
                    break;

            }

            return new FirefoxDriver();
        }

        private static IWebDriver Initialize()
        {
            var browser = (BrowserType)Enum.Parse(typeof(BrowserType), ConfigurationManager.AppSettings["Browser"], true);
            return GetWebDriver(browser);
        }

        public static void Goto(string p_System, string p_Path = "", string p_QueryString = "")
        {
            if (Driver == null)
            {
                return;
            }

            Driver.Url = $"{p_System}{p_Path}{p_QueryString}";
        }
    }
}
