//using System;

//using OpenQA.Selenium;
//using RESTAPIWebTest.WebDriverCore.Enums;

//namespace RESTAPIWebTest.WebDriverCore.Models
//{
//    /// <summary>
//    /// Class Input
//    /// </summary>
//    public class InputControl : EditableControlBase
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="InputControl" /> class.
//        /// </summary>
//        /// <param name="divRowElement">The div row element.</param>
//        public InputControl(IWebElement p_DivRowElement) : base(p_DivRowElement)
//        {
//            ControlType controlType;
//            if (Enum.TryParse(DomElement.GetAttribute("type"), true, out controlType))
//            {
//                Type = controlType;
//            }
//        }
//    }
//}
