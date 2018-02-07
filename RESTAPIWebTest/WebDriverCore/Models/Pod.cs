//namespace RESTAPIWebTest.WebDriverCore.Models
//{
//    using System.Collections.Generic;
//    using OpenQA.Selenium;

//    /// <summary>
//    /// Class Pod.
//    /// </summary>
//    public class Pod
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="Pod"/> class.
//        /// </summary>
//        public Pod()
//        {
//            this.Fields = new List<Field>();
//        }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="Pod"/> class.
//        /// </summary>
//        /// <param name="source">The source.</param>
//        public Pod(IWebElement source)
//            : this()
//        {
//            this.ParseFields(source);
//        }

//        /// <summary>
//        /// Gets the fields.
//        /// </summary>
//        /// <value>The fields.</value>
//        public IList<Field> Fields { get; private set; }

//        /// <summary>
//        /// Parses the fields.
//        /// </summary>
//        /// <param name="source">The source.</param>
//        public void ParseFields(IWebElement source)
//        {
//            var count = source.FindElements(By.CssSelector("dt")).Count;

//            for (var i = 1; i <= count; i++)
//            {
//                this.Fields.Add(new Field
//                {
//                    Label = source.FindElement(By.CssSelector(string.Format("dt:nth-of-type({0})", i))).Text,
//                    Value = source.FindElement(By.CssSelector(string.Format("dd:nth-of-type({0})", i))).Text
//                });
//            }
//        }
//    }
//}
