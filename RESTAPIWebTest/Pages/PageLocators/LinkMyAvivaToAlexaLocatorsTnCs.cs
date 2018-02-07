using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RESTAPIWebTest.Pages.PageLocators
{
    public class LinkMyAvivaToAlexaLocatorsTnCs
    {
        // My Aviva logo
        [FindsBy(How = How.ClassName, Using = "")]
        protected IWebElement AvivaLogo { get; set; }

        // Link MyAviva to Alexa step 1 of 3
        [FindsBy(How = How.ClassName, Using = "a-progress-bar__step")]
        protected IWebElement ProgressBarStep { get; set; }

        // Terms and conditions link
        [FindsBy(How = How.LinkText, Using = "terms and conditions")]
        protected IWebElement lnkTnCsLink { get; set; }

        // Checkbox - Agree to the TnCs
        [FindsBy(How = How.Id, Using = "terms-checkboxes")]
        protected IWebElement chkbxAgreeTnCs { get; set; }

        // Continue button
        [FindsBy(How = How.Id, Using = "submit-terms")]
        protected IWebElement btnContinue { get; set; }

        //Error and warning fields

    }
}
