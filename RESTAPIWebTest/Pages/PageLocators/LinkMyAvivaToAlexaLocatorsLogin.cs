using System.Collections.Generic;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RESTAPIWebTest.WebDriverCore;

namespace RESTAPIWebTest.PageObjects
{
    public class LinkMyAvivaToAlexaLocatorsLogin
    {
        // My Aviva logo
        [FindsBy(How = How.ClassName, Using = "")]
        protected IWebElement AvivaLogo { get; set; }

        // Link MyAviva to Alexa step 1 of 3
        [FindsBy(How = How.ClassName, Using = "a-progress-bar__step")]
        protected IWebElement ProgressBarStep { get; set; }

        // Username
        [FindsBy(How = How.Id, Using = "username")]
        protected IWebElement txtUsername { get; set; }

        // Password
        [FindsBy(How = How.Id, Using = "password")]
        protected IWebElement txtPassword { get; set; }

        // Login button
        [FindsBy(How = How.Id, Using = "login")]
        protected IWebElement btnLogin { get; set; }

        // Login button
        [FindsBy(How = How.PartialLinkText, Using = "need to register")]
        protected IWebElement lnkNeedToRegister { get; set; }

        protected IWebElement UsernameForgotten()
        {
            return Browser.SearchContext.FindElements(By.CssSelector("a[href=/'#reset-username/']"))[1];
        }

        protected IWebElement PasswordForgotten()
        {
            return Browser.SearchContext.FindElements(By.CssSelector("a[href=/'#reset-password/']"))[1];
        }

        //Error and warning fields
        [FindsBy(How = How.CssSelector, Using = "fieldset.is-error p")]
        protected IList<IWebElement> ErrorElements;
    }
}
