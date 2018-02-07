//using System.Collections.Generic;
//using System.Linq;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using RESTAPIWebTest.Interfaces;
//using RESTAPIWebTest.WebDriverCore.Enums;
//namespace RESTAPIWebTest.WebDriverCore.Models
//{
//    /// <summary>
//    /// Class Dropdown.
//    /// </summary>
//    public class Dropdown : EditableControlBase, ISelectableControl
//    {
//        /// <summary>
//        /// The select element
//        /// </summary>
//        private readonly SelectElement _selectElement;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="Dropdown" /> class.
//        /// </summary>
//        /// <param name="p_DivRowElement">The div row element.</param>
//        public Dropdown(IWebElement p_DivRowElement) : base(p_DivRowElement)
//        {
//            _selectElement = new SelectElement(DomElement);
//            Type = ControlType.Dropdown;

//            Options = _selectElement.Options.Select(p_Option => new Option(p_Option)
//            {
//                Text = p_Option.Text,
//                Value = p_Option.GetAttribute("value"),
//                IsSelected = p_Option.GetAttribute("selected") != null
//            }).ToList();
//        }

//        /// <summary>
//        /// Gets the select element.
//        /// </summary>
//        /// <value>
//        /// The select element.
//        /// </value>
//        public SelectElement SelectElement => _selectElement;

//        /// <summary>
//        /// Gets or sets the options.
//        /// </summary>
//        /// <value>
//        /// The options.
//        /// </value>
//        public List<Option> Options { get; set; }

//        /// <summary>
//        /// Selects the by text.
//        /// </summary>
//        /// <param name="p_TextToSelect">The text to select.</param>
//        public void SelectByText(string p_TextToSelect)
//        {
//            _selectElement.SelectByText(p_TextToSelect);
//        }

//        /// <summary>
//        /// Selects the by text.
//        /// </summary>
//        /// <param name="p_ValueToSelect">The text to select.</param>
//        public void SelectByValue(string p_ValueToSelect)
//        {
//            SetValue(p_ValueToSelect);
//        }

//        /// <summary>
//        /// Setvalues this instance.
//        /// </summary>
//        /// <param name="p_Value">The value.</param>
//        public override void SetValue(string p_Value)
//        {
//            _selectElement.SelectByValue(p_Value);
//        }
//    }
//}
