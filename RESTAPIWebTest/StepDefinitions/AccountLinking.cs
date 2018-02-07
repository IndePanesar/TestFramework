using System.Configuration;
using System.Linq;
using NUnit.Framework;
using RESTAPIWebTest.Pages.PageObjects;
using RESTAPIWebTest.WebDriverCore;
using TechTalk.SpecFlow;

namespace RESTAPIWebTest.StepDefinitions
{
    [Binding]
    class AccountLinking
    {
        private LinkMyAvivaToAlexaTnCs _alexaTnCs;
        private LinkMyAvivaToAlexaLogin _alexaLogin;

        [Given(@"I have am on the account linking page")]
        public void GivenIHaveAmOnTheAccountLinkingPage()
        {
            Browser.GoToUrl(ConfigurationManager.AppSettings["AlexaURL"]);
        }

        [Given(@"I have agreed to the skills TnCs")]
        public void GivenIHaveAgreedToTheSkillsTnCs()
        {
            _alexaTnCs = _alexaTnCs ?? new LinkMyAvivaToAlexaTnCs();
            _alexaTnCs.AcceptTnCs();
        }

        [StepDefinition(@"I click continue button to submit the TnCs")]
        public void ClickContinueButtonToSubmitTheTnCs()
        {
            _alexaTnCs = _alexaTnCs ?? new LinkMyAvivaToAlexaTnCs();
            _alexaTnCs.SubmitTnCs();
        }

        [Then(@"I land on the Login Page of Link MyAviva to Alexa")]
        public void ThenILandOnTheLoginPageOfLinkMyAvivaToAlexa()
        {
            _alexaLogin = _alexaLogin ?? new LinkMyAvivaToAlexaLogin();
            var expectedTitle = _alexaLogin.GetPageTitle();
            var actualTitle = Browser.GetTitle().Trim();
            Assert.IsTrue(expectedTitle.Equals(actualTitle.Trim()), $"Expected page title as {expectedTitle} but was {actualTitle}");
        }

        [StepDefinition(@"I input '(.*)' field as '(.*)'")]
        public void InputFieldAs(string p_Field, string p_Value )
        {
            _alexaLogin = _alexaLogin ?? new LinkMyAvivaToAlexaLogin();
            switch (p_Field.Trim().ToLower())
            {
                case "username":
                    _alexaLogin.EnterUsername(p_Value);
                    break;

                case "password":
                    _alexaLogin.EnterPassword(p_Value);
                    break;

                default:
                    Assert.Fail($"Alexa login input field {p_Field} is not handled.");
                    break;
            }
        }

        [When(@"I submit the login form")]
        public void WhenISubmitTheLoginForm()
        {
            _alexaLogin = _alexaLogin ?? new LinkMyAvivaToAlexaLogin();
            _alexaLogin.ClickLogin();
        }

        [Then(@"I see the error message '(.*)'")]
        public void ThenISeeTheErrorMessage(string p_Error)
        {
            var msg = (_alexaLogin ?? new LinkMyAvivaToAlexaLogin()).GetErrorMessages();
            if ( msg == null || msg.Length < 1)
                Assert.Fail($"Alexa login page is not showing any errors, expected {p_Error}");
            Assert.IsTrue(msg.Any(p_Er=>p_Er.Trim().Equals(p_Error)), $"Expected error message {p_Error} on Alexa Login page.");
        }
    }
}
