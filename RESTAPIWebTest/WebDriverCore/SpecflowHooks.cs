using System;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using RESTAPIWebTest.WebDriverCore;
using TechTalk.SpecFlow;

namespace RESTAPIWebTest.SupportUtilities
{


    [Binding]
    public class SpecflowHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {

        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
        }

        [BeforeStep]
        public static void BeforeStep()
        {

        }

        [AfterStep]
        public static void AfterStep()
        {
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            ScenarioContext.Current.Clear();
            Browser.DeleteCookies();
            Browser.Close();
        }

        [AfterTestRun]
        public static void AfterRunScenario()
        {
        }

        public static void TakeScreenshot(string p_FileName)
        {
            try
            {
                var screenshotPath = ConfigurationManager.AppSettings["ScreenshotPath"];
                if (string.IsNullOrEmpty(screenshotPath))
                {
                    return;
                }

                var screenshot = ((ITakesScreenshot)Browser.SearchContext).GetScreenshot();
                screenshot.SaveAsFile($@"{screenshotPath}{p_FileName}.jpg", ScreenshotImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}