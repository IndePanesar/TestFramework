//using OpenQA.Selenium;
//using RESTAPIWebTest.WebDriverCore.Enums;

//namespace RESTAPIWebTest.WebDriverCore.Models
//{
//    /// <summary>
//    /// Class Control.
//    /// </summary>
//    public class Control : PageElement
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="Control"/> class.
//        /// </summary>
//        /// <param name="p_DomElement">The DOM element.</param>
//        public Control(IWebElement p_DomElement) : base(p_DomElement)
//        {
//        }

//        /// <summary>
//        /// Gets the name.
//        /// </summary>
//        /// <value>
//        /// The name.
//        /// </value>
//        public string Name => DomElement.GetAttribute("name");

//        /// <summary>
//        /// Gets the id.
//        /// </summary>
//        /// <value>
//        /// The id.
//        /// </value>
//        public string Id => DomElement.GetAttribute("id");

//        /// <summary>
//        /// Gets or sets the label.
//        /// </summary>
//        /// <value>
//        /// The label.
//        /// </value>
//        public string Label { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether this instance has help.
//        /// </summary>
//        /// <value>
//        ///   <c>true</c> if this instance has help; otherwise, <c>false</c>.
//        /// </value>
//        public bool HasHelp { get; set; }

//        /// <summary>
//        /// Gets or sets the help text.
//        /// </summary>
//        /// <value>
//        /// The help text.
//        /// </value>
//        public string HelpText { get; set; }

//        /// <summary>
//        /// Gets or sets the value.
//        /// </summary>
//        /// <value>
//        /// The value.
//        /// </value>
//        public string Value { get; set; }

//        /// <summary>
//        /// Gets a value indicating whether this instance is visible.
//        /// </summary>
//        /// <value>
//        /// <c>true</c> if this instance is visible; otherwise, <c>false</c>.
//        /// </value>
//        public bool IsVisible => DomElement.Displayed;

//        /// <summary>
//        /// Gets a value indicating whether this instance is enabled.
//        /// </summary>
//        /// <value>
//        /// <c>true</c> if this instance is enabled; otherwise, <c>false</c>.
//        /// </value>
//        public bool IsEnable => DomElement.Enabled;

//        /// <summary>
//        /// Gets or sets the type.
//        /// </summary>
//        /// <value>
//        /// The type.
//        /// </value>
//        public ControlType Type { get; set; }
//    }
//}
