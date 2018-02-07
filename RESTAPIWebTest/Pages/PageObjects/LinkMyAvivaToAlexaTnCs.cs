using OpenQA.Selenium.Support.PageObjects;
using RESTAPIWebTest.Pages.PageLocators;
using RESTAPIWebTest.WebDriverCore;

namespace RESTAPIWebTest.Pages.PageObjects
{
    public class LinkMyAvivaToAlexaTnCs : LinkMyAvivaToAlexaLocatorsTnCs
    {
        public LinkMyAvivaToAlexaTnCs()
        {
            PageFactory.InitElements(Browser.SearchContext, this);
        }
        public void AcceptTnCs()
        {
            chkbxAgreeTnCs.Click();
        }

        public void SubmitTnCs()
        {
            btnContinue.Click();
        }
    }
}
