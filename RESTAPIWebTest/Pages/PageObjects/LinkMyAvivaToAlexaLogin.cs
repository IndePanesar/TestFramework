using System.Collections.Generic;
using System.Linq;

using OpenQA.Selenium.Support.PageObjects;
using RESTAPIWebTest.PageObjects;
using RESTAPIWebTest.WebDriverCore;

namespace RESTAPIWebTest.Pages.PageObjects
{
    public class LinkMyAvivaToAlexaLogin : LinkMyAvivaToAlexaLocatorsLogin

    {
        private const string PageTitle = "Login | Aviva";

        public LinkMyAvivaToAlexaLogin()
        {
            PageFactory.InitElements(Browser.SearchContext, this);
        }

        public void EnterUsername(string p_Username)
        {
            txtUsername.Click();
            txtUsername.Clear();
            txtUsername.SendKeys(p_Username);
        }

        public void EnterPassword(string p_Password)
        {
            txtPassword.Click();
            txtPassword.Clear();
            txtPassword.SendKeys(p_Password);
        }

        public void ClickLogin()
        {
            btnLogin.Click();
        }

        public string GetPageTitle()
        {
            return PageTitle;
        }

        public string[] GetErrorMessages()
        {
            var il = new List<string>();

            foreach (var ee in ErrorElements)
            {
                il.Add(ee.Text);
            }
            return ErrorElements.Select(p_EE => p_EE.Text).ToArray();
        }

    
    }
}
