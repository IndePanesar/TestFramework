//using System;
//using System.Diagnostics.CodeAnalysis;

//namespace RESTAPIWebTest.WebDriverCore.Models
//{
//    /// <summary>
//    /// Model to hold Login data
//    /// </summary>
//    [Serializable]
//    public class LoginBase
//    {
//        /// <summary>
//        /// Gets or sets the User name.
//        /// </summary>
//        /// <value>
//        /// The User name.
//        /// </value>
//        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "TAM will not accept value Username (uppercase U) when it is posted")]
//        // ReSharper disable once InconsistentNaming
//        public string username { get; set; }

//        /// <summary>
//        /// Gets or sets the password.
//        /// </summary>
//        /// <value>
//        /// The Password.
//        /// </value>
//        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "TAM will not accept value Password (uppercase P) when it is posted")]
//        // ReSharper disable once InconsistentNaming
//        public string password { get; set; }

//        /// <summary>
//        /// Gets or sets a value indicating whether [remember username].
//        /// </summary>
//        /// <value>
//        ///   <c>true</c> if [remember username]; otherwise, <c>false</c>.
//        /// </value>
//        public bool RememberUsername { get; set; }
//    }
//}