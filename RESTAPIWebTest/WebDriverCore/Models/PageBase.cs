//using System.Threading;
//using OpenQA.Selenium;
//using static System.TimeSpan;

//namespace RESTAPIWebTest.WebDriverCore.Models
//{
//    public abstract class PageBase
//    {
//        //        public List<Control> Controls { get; set; }

//        public abstract string System { get; }

//        public abstract string Path { get; }

//        public string QueryString { get; set; }

//        public abstract By LoadCompleteElement { get; }

//        public void Open()
//        {
//            Browser.MaximizeWindow();
//            Browser.Goto(System, Path, QueryString);
//            WaitForLoad();
//        }

//        public void Open(int p_TimeToWait)
//        {
//            Browser.Goto(System, Path, QueryString);
//            WaitForLoad(p_TimeToWait);
//        }

//        public virtual void WaitForLoad()
//        {
//            Browser.WaitFor(LoadCompleteElement);
//        }

//        public void WaitForLoad(By p_ElementSpecification)
//        {
//            try
//            {
//                Browser.WaitFor(p_ElementSpecification);
//            }
//            catch
//            {
//                // ignored
//            }
//        }

//        public void WaitForLoad(int p_SecsToWait)
//        {
//            try
//            {
//                Browser.WaitFor(LoadCompleteElement, p_SecsToWait);
//            }
//            catch
//            {
//                // ignored
//            }
//        }

//        public virtual void Wait(int p_Secs = 5)
//        {
//            var waitTime = FromSeconds(p_Secs);
//            Thread.Sleep(waitTime);
//        }

//        //public virtual void Parse(string p_ContainerCssClass = "main", string p_RowCssClass = "row")
//        //{
//        //    // Clear out the page controls list
//        //    Controls.Clear();
//        //    var content = Browser.SearchContext.FindElement(By.ClassName(p_ContainerCssClass));
//        //    var divRows = content?.FindElements(By.ClassName(p_RowCssClass));
//        //    if (divRows == null)
//        //        return;
//        //    foreach (var row in divRows)
//        //    {
//        //        try
//        //        {
//        //            var selectList = row.FindElements(By.TagName("select"));
//        //            if (selectList != null && selectList.Count > 0)
//        //            {
//        //                var control = new Dropdown(row);
//        //                Controls.Add(control);
//        //            }
//        //            else
//        //            {
//        //                var staticValue = row.FindElements(By.CssSelector("p.staticValue"));
//        //                if (staticValue != null && staticValue.Any())
//        //                {
//        //                    Controls.Add(new StaticValue(row));
//        //                }
//        //                else
//        //                {
//        //                    var checkboxOrRadio = row.FindElements(By.CssSelector("input[type='radio'],input[type='checkbox']"));
//        //                    if (checkboxOrRadio != null && checkboxOrRadio.Any())
//        //                    {
//        //                        Controls.Add(new CheckboxRadio(row));
//        //                    }
//        //                    else
//        //                    {
//        //                        Controls.Add(new InputControl(row));
//        //                    }
//        //                }
//        //            }
//        //        }

//        //        catch (Exception)
//        //        {
//        //            // ignored
//        //        }
//        //    }
//        //}
//    }
//}
