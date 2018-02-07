//using System.Collections.Generic;
//using System.Linq;
//using OpenQA.Selenium;
//using RESTAPIWebTest.Interfaces;

//namespace RESTAPIWebTest.WebDriverCore.Models
//{
//    /// <summary>
//    /// Class Input
//    /// </summary>
//    public class CheckboxRadio : InputControl, ISelectableControl
//    {
//        /// <inheritdoc />
//        /// <summary>
//        /// Initializes a new instance of the <see cref="T:RESTAPIWebTest.WebDriverCore.Models.CheckboxRadio" /> class.
//        /// </summary>
//        /// <param name="p_DivRowElement">The div row element.</param>
//        public CheckboxRadio(IWebElement p_DivRowElement) : base(p_DivRowElement)
//        {
//            Options = new List<Option>();
//            var options = p_DivRowElement.FindElements(By.Name(Name));
//            if (options == null || !options.Any()) return;
//            foreach (var option in options)
//            {
//                Options.Add(new Option(option)
//                {
//                    Text = option.Text,
//                    Value = option.GetAttribute("value"),
//                    IsSelected = option.Selected
//                });
//            }
//        }

//        /// <inheritdoc />
//        /// <summary>
//        /// Gets or sets the options.
//        /// </summary>
//        /// <value>
//        /// The options.
//        /// </value>
//        public List<Option> Options { get; set; }

//        /// <inheritdoc />
//        /// <summary>
//        /// Selects the by text.
//        /// </summary>
//        /// <param name="p_TextToSelect">The text to select.</param>
//        public void SelectByText(string p_TextToSelect)
//        {
//            var optionToSelect = Options.FirstOrDefault(p_Option => p_Option.Text == p_TextToSelect);
//            SelectOption(optionToSelect);
//        }

//        /// <inheritdoc />
//        /// <summary>
//        /// Selects the by value.
//        /// </summary>
//        /// <param name="p_ValueToSelect">The value to select.</param>
//        public void SelectByValue(string p_ValueToSelect)
//        {
//            SetValue(p_ValueToSelect);
//        }

//        /// <inheritdoc />
//        /// <summary>
//        /// Setvalues this instance.
//        /// </summary>
//        /// <param name="p_Value">The value to select</param>
//        public override void SetValue(string p_Value)
//        {
//            var optionToSelect = Options.FirstOrDefault(p_Option => p_Option.Value == p_Value);
//            SelectOption(optionToSelect);
//        }

//        /// <summary>
//        /// Selects the option.
//        /// </summary>
//        /// <param name="p_OptionToSelect">The option to select.</param>
//        private static void SelectOption(Option p_OptionToSelect)
//        {
//            if (p_OptionToSelect != null && !p_OptionToSelect.IsSelected)
//            {
//                p_OptionToSelect.DomElement.Click();
//            }
//        }
//    }
//}
