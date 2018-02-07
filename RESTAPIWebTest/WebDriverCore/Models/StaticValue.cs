//using System.Linq;
//using OpenQA.Selenium;
//using RESTAPIWebTest.WebDriverCore.Enums;

//namespace RESTAPIWebTest.WebDriverCore.Models
//{
//    /// <summary>
//    /// Class StaticValue.
//    /// </summary>
//    public class StaticValue : Control
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="StaticValue" /> class.
//        /// </summary>
//        /// <param name="divRowElement">The div row element.</param>
//        public StaticValue(IWebElement p_DivRowElement) : base(p_DivRowElement.FindElement(By.CssSelector("p.staticValue")))
//        {
//            this.Type = ControlType.StaticValue;
//            this.Value = DomElement.Text.Replace("\r\n", ", ");
//            var labels = p_DivRowElement.FindElements(By.CssSelector("label"));
//            if (labels != null && labels.Any())
//            {
//                Label = labels.First().Text;
//            }

//            var help = p_DivRowElement.FindElements(By.CssSelector(".helpText"));
//            if (help == null || !help.Any())
//                return;
//            HasHelp = true;
//            HelpText = help.First().Text;
//        }
//    }
//}
