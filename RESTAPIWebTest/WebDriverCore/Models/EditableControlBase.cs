//using System.Collections.Generic;
//using System.Linq;

//using OpenQA.Selenium;

//namespace RESTAPIWebTest.WebDriverCore.Models
//{
//    /// <summary>
//    /// Class Input Control Base.
//    /// </summary>
//    public abstract class EditableControlBase : Control
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="EditableControlBase" /> class.
//        /// </summary>
//        /// <param name="p_DivRowElement">The div row element.</param>
//        protected EditableControlBase(IWebElement p_DivRowElement) : base(p_DivRowElement.FindElement(By.CssSelector("input,select")))
//        {
//            Value = DomElement.GetAttribute("value");

//            var labels = p_DivRowElement.FindElements(By.CssSelector($"label[for='{Id}']"));
//            if (labels != null && labels.Any())
//            {
//                Label = labels.First().Text;
//            }

//            var errors = p_DivRowElement.FindElements(By.CssSelector(".m-form__error-message"));
//            if (errors != null && errors.Any())
//            {
//                HasErrors = true;
//                ErrorMessages = new List<string>();
//                foreach (var error in errors)
//                {
//                    ErrorMessages.Add(error.Text);
//                }

//                foreach (var error in errors)
//                {
//                    var elements = error.FindElements(By.CssSelector("span"));
//                    if (elements.Count == 0)
//                        continue;
//                    foreach (var element in elements)
//                        ErrorMessages.Add(element.Text);
//                }
//            }

//            var help = p_DivRowElement.FindElements(By.CssSelector(".helpText"));
//            if (help == null || !help.Any())
//                return;
//            HasHelp = true;
//            HelpText = help.First().Text;
//        }

//        /// <summary>
//        /// Gets or sets a value indicating whether this instance has errors.
//        /// </summary>
//        /// <value>
//        /// <c>true</c> if this instance has errors; otherwise, <c>false</c>.
//        /// </value>
//        public bool HasErrors { get; set; }

//        /// <summary>
//        /// Gets or sets the error messages.
//        /// </summary>
//        /// <value>
//        /// The error messages.
//        /// </value>
//        public List<string> ErrorMessages { get; set; }

//        /// <summary>
//        /// Setvalues this instance.
//        /// </summary>
//        /// <param name="p_Value">The value.</param>
//        public virtual void SetValue(string p_Value)
//        {
//            DomElement.SendKeys(p_Value);
//        }

//        /// <summary>
//        /// Clicks this instance.
//        /// </summary>
//        public void Click()
//        {
//            DomElement.Click();
//        }

//        /// <summary>
//        /// Clicks this instance.
//        /// </summary>
//        public void Clear()
//        {
//            DomElement.Clear();
//        }
//    }
//}
