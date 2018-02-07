//using System;
//using System.Reflection;

//using OpenQA.Selenium;
//using RESTAPIWebTest.Extensions;

//namespace RESTAPIWebTest.WebDriverCore.Models
//{
//    public abstract class FormBase<TViewClass> : PageBase
//    {
//        public virtual void Submit()
//        {
//            Browser.WaitForElementToBeEnabled(Browser.SearchContext.FindElement(By.CssSelector("[type='submit']")));
//            Browser.SearchContext.FindElement(By.CssSelector("[type='submit']")).ClickByJs();
//        }

//        protected virtual void Complete(TViewClass p_Data)
//        {
//            var properties = typeof(TViewClass).GetProperties();

//            foreach (var property in properties)
//            {
//                try
//                {
//                    if (property.PropertyType == typeof(DateTime))
//                    {
//                        var date = (DateTime)property.GetValue(p_Data, null);
//                        CompleteDate(property, date);
//                    }
//                    else
//                    {
//                        var field = Browser.SearchContext.FindElement(By.Name(property.Name));

//                        if (field.TagName != "input")
//                            continue;
//                        var value = property.GetValue(p_Data, null);

//                        if (value == null)
//                            continue;
//                        field.Clear();
//                        field.SendKeys(value.ToString());
//                    }
//                }

//                catch
//                {
//                    // Ignored
//                }
//            }
//        }

//        protected virtual void CompleteDate(PropertyInfo p_PropertyInfo, DateTime p_Date)
//        {
//            var field = Browser.SearchContext.FindElement(By.Name(p_PropertyInfo.Name));
//            if (field.TagName == "input")
//                field.SendKeys(p_Date.ToString("dd/MM/yyyy"));

//            field = Browser.SearchContext.FindElement(By.Name(p_PropertyInfo.Name + ".Day"));
//            if (field.TagName == "select")
//                for (var i = 0; i < p_Date.Day; i++)
//                    field.SendKeys(Keys.ArrowDown);

//            field = Browser.SearchContext.FindElement(By.Name(p_PropertyInfo.Name + ".Month"));
//            if (field.TagName == "select")
//            {
//                var month = p_Date.ToString("MMMM");
//                field.SendKeys(month);
//            }

//            field = Browser.SearchContext.FindElement(By.Name(p_PropertyInfo.Name + ".Year"));
//            if (field.TagName == "select" || field.TagName == "input")
//                field.SendKeys(p_Date.Year.ToString());
//        }
//    }
//}
