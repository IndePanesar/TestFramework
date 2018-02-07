using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RESTAPIWebTest.WebDriverCore;

namespace RESTAPIWebTest.Extensions
{
    public static class WebElementExtension
    {

        public static void ClickByJs(this IWebElement p_Element)
        {
            Browser.JavaScriptExecutor.ExecuteScript("arguments[0].click();", p_Element);
        }

        public static void ClearByBackspace(this IWebElement p_Element)
        {
            p_Element.SendKeys(Keys.End);
            while (p_Element.GetAttribute("value").Length > 0)
                p_Element.SendKeys(Keys.Backspace);
        }

        public static bool IsEnabledAfterWait(this IWebElement p_Element)
        {
            Browser.WaitForElementToBeEnabled(p_Element);
            return p_Element.Enabled;
        }

        public static bool IsDisabledAfterWait(this IWebElement p_Element)
        {
            Browser.WaitForElementToBeDisabled(p_Element);
            return !p_Element.Enabled;
        }

        public static bool IsDisplayed(this IWebElement p_Element)
        {
            try
            {
                return p_Element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void SelectDropDownListItemByText(this IWebElement p_Element, string p_Text)
        {
            var selectElement = new SelectElement(p_Element);
            selectElement.SelectByText(p_Text);
        }

        public static void ChangeFocusByClickingTheInputAndSendingTheTabKey(this IWebElement p_Element)
        {
            p_Element.Click();
            p_Element.SendKeys(Keys.Tab);
        }

        public static bool HasClass(this IWebElement p_Element, string p_ClassName)
        {
            return p_Element.GetAttribute("class").Contains(p_ClassName);
        }

        public static void ClickWithWait(this IWebElement p_Element, bool p_IsJsOff = false, bool p_IsExceedTest = false)
        {
            if (!p_IsExceedTest)
            {
                Browser.ScrollToElement(p_Element);
            }

            try
            {
                p_Element.Click();
            }
            catch (Exception)
            {
                // ignore
            }
        }

        public static void ClickWithWaitForAjax(this IWebElement p_Element, bool p_ShouldScrollIntoView = false)
        {
            if (p_ShouldScrollIntoView)
            {
                Browser.ScrollToElement(p_Element);
            }

            p_Element.Click();
            Browser.WaitForNoAjaxRequestsPending();
        }


        public static void SendKeysWithWait(this IWebElement p_Element, string p_Text, bool p_IsJsOff = false, bool p_IsExceedTest = false)
        {
            if (p_IsJsOff || p_IsExceedTest)
            {
                p_Element.SendKeys(p_Text);
                return;
            }

            Browser.WaitForElementToAppear(p_Element);
            Browser.ScrollToElement(p_Element);
            p_Element.Clear();
            p_Element.SendKeys(p_Text);
        }

        public static void SendKeysWithClear(this IWebElement p_Element, string p_Text)
        {
            p_Element.Clear();
            p_Element.SendKeys(p_Text);
        }

        public static void SendKeysWithWait(this IWebElement p_Element, string p_Text, int p_Miliseconds)
        {
            Browser.WaitForPageAndScriptsLoadComplete();
            foreach (var character in p_Text)
            {
                p_Element.SendKeys(character.ToString());
                Thread.Sleep(p_Miliseconds);
            }
        }

    }
}
