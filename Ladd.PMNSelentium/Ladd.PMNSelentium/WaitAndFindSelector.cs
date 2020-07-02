using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ladd.PMNSelentium
{
    public static class WaitAndFindSelector
    {
        public static void FindByAndExecute(Action action, IWebDriver driver)
        {
            if (action.ByType.ToLower() == "id")
            {
                if (action.InputType == "text")
                    FindIdAndSendText(action.ByValue, action.InputValue, driver);
                else if (action.InputType.ToLower() == "checkbox")
                    FindIdAndClickCheckbox(action.ByValue, action.InputValue, driver);
                else if (Utils.IsSelectable(action.InputType))
                    FindIdAndClick(action.ByValue, driver);
            }
            else if (action.ByType.ToLower() == "css")
            {
                if (action.InputType == "text")
                    FindCssAndSendText(action.ByValue, action.InputValue, driver);
                else if (action.InputType.ToLower() == "checkbox")
                    FindCssAndClickCheckbox(action.ByValue, action.InputValue, driver);
                else if (Utils.IsSelectable(action.InputType))
                    FindCssAndClick(action.ByValue, driver);
            }
            else if (action.ByType.ToLower() == "name")
            {
                if (action.InputType == "text")
                    FindNameAndSendText(action.ByValue, action.InputValue, driver);
                else if (action.InputType.ToLower() == "checkbox")
                    FindNameAndClickCheckbox(action.ByValue, action.InputValue, driver);
                else if (Utils.IsSelectable(action.InputType))
                    FindNameAndClick(action.ByValue, driver);
            }
            else if (action.ByType.ToLower() == "xpath")
            {
                if (action.InputType == "text")
                    FindXPathAndSendText(action.ByValue, action.InputValue, driver);
                else if (action.InputType.ToLower() == "checkbox")
                    FindXPathAndClickCheckbox(action.ByValue, action.InputValue, driver);
                else if (Utils.IsSelectable(action.InputType))
                    FindXPathAndClick(action.ByValue, driver);
            }
            else
                throw new Exception("By is not a correct Value");
        }
        public static void FindIdAndSendText(string id, string text, IWebDriver driver)
        {
            bool notLoaded = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.Id(id));
                    notLoaded = false;
                    element.Click();
                    element.Clear();
                    element.SendKeys(text);
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            if (s.Elapsed > TimeSpan.FromSeconds(30))
                throw new Exception("Page did not load or could not find element");
            s.Stop();
            Thread.Sleep(1000);
        }
        public static void FindIdAndClickCheckbox(string id, string value, IWebDriver driver)

        {
            bool notLoaded = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.Id(id));
                    notLoaded = false;
                    if (element.Selected.ToString().ToLower() != value.ToLower())
                        element.Click();
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");
            s.Stop();
            Thread.Sleep(1000);
        }
        public static void FindIdAndClick(string id, IWebDriver driver)

        {
            bool notLoaded = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.Id(id));
                    notLoaded = false;
                    element.Click();
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");
            s.Stop();
            Thread.Sleep(1000);
        }

        public static void FindNameAndSendText(string name, string text, IWebDriver driver)
        {
            bool notLoaded = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.Name(name));
                    notLoaded = false;
                    element.Clear();
                    element.SendKeys(text);
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");
            s.Stop();
            Thread.Sleep(1000);
        }
        public static void FindNameAndClickCheckbox(string name, string value, IWebDriver driver)
        {
            bool notLoaded = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.Name(name));
                    notLoaded = false;
                    if (element.Selected.ToString().ToLower() != value.ToLower())
                        element.Click();
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");
            s.Stop();
            Thread.Sleep(1000);
        }
        public static void FindNameAndClick(string name, IWebDriver driver)
        {
            bool notLoaded = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.Name(name));
                    notLoaded = false;
                    element.Click();
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");
            s.Stop();
            Thread.Sleep(1000);
        }

        public static void FindCssAndSendText(string css, string text, IWebDriver driver)
        {
            bool notLoaded = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.CssSelector(css));
                    notLoaded = false;
                    element.Clear();
                    element.SendKeys(text);
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");
            s.Stop();
            Thread.Sleep(1000);
        }
        public static void FindCssAndClickCheckbox(string css, string value, IWebDriver driver)
        {
            bool notLoaded = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.CssSelector(css));
                    notLoaded = false;
                    if (element.Selected.ToString().ToLower() != value.ToLower())
                        element.Click();
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");
            s.Stop();
            Thread.Sleep(1000);
        }
        public static void FindCssAndClick(string css, IWebDriver driver)
        {
            bool notLoaded = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.CssSelector(css));
                    notLoaded = false;
                    element.Click();
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");
            s.Stop();
            Thread.Sleep(1000);
        }

        public static void FindXPathAndSendText(string xpath, string text, IWebDriver driver)
        {
            bool notLoaded = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.XPath(xpath));
                    notLoaded = false;
                    element.Clear();
                    element.SendKeys(text);
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");
            s.Stop();
            Thread.Sleep(1000);
        }
        public static void FindXPathAndClickCheckbox(string xpath, string value, IWebDriver driver)
        {
            bool notLoaded = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.XPath(xpath));
                    notLoaded = false;
                    if (element.Selected.ToString().ToLower() != value.ToLower())
                        element.Click();

                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");
            s.Stop();
            Thread.Sleep(1000);
        }
        public static void FindXPathAndClick(string xpath, IWebDriver driver)
        {
            bool notLoaded = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.XPath(xpath));
                    notLoaded = false;
                    element.Click();
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");
            s.Stop();
            Thread.Sleep(1000);
        }



        public static void ValidateFindByAndExecute(Action action, IWebDriver driver)
        {
            if (action.ByType.ToLower() == "id")
            {
                if (action.InputType == "text")
                    ValidateFindIdAndSendText(action.ByValue, action.InputValue, driver);
                else if (action.InputType == "dropdownSelection")
                    ValidateFindIdAndDropDown(action.ValidateByType, action.ValidateByValue, driver);
                else if (action.InputType == "checkbox")
                {
                    ////?? find out how to validate a kendo checkbox
                }
                else if (Utils.IsSelectable(action.InputType))
                    FindIdAndClick(action.ByValue, driver);
            }
            else if (action.ByType.ToLower() == "css")
            {
                if (action.InputType == "text")
                    ValidateFindCssAndSendText(action.ByValue, action.InputValue, driver);
                else if (action.InputType == "dropdownSelection")
                    ValidateFindIdAndDropDown(action.ValidateByType, action.ValidateByValue, driver);
                else if (action.InputType == "checkbox")
                {
                    ////?? find out how to validate a kendo checkbox
                }
                else if (Utils.IsSelectable(action.InputType))
                    FindCssAndClick(action.ByValue, driver);
            }
            else if (action.ByType.ToLower() == "name")
            {
                if (action.InputType == "text")
                    ValidateFindNameAndSendText(action.ByValue, action.InputValue, driver);
                else if (action.InputType == "dropdownSelection")
                    ValidateFindIdAndDropDown(action.ValidateByType, action.ValidateByValue, driver);
                //else if (action.InputType == "checkbox")
                else if (Utils.IsSelectable(action.InputType))
                    ValidateFindNameAndDropDown(action.ValidateByType, action.ValidateByValue, driver);
            }
            else if (action.ByType.ToLower() == "xpath")
            {
                if (action.InputType == "text")
                    ValidateFindXPathAndSendText(action.ByValue, action.InputValue, driver);
                else if (action.InputType == "dropdownSelection")
                    ValidateFindXPathAndDropDown(action.ValidateByValue, action.InputValue, driver);
                else if (action.InputType == "checkbox")
                    ValidateFindXPathAndCheckBox(action.ByValue, action.InputValue, driver);
                else if (Utils.IsSelectable(action.InputType))
                    ValidateFindXPathAndDropDown(action.ValidateByType, action.ValidateByValue, driver);
            }
            else
                throw new Exception("By is not a correct Value");
        }

        public static void ValidateFindIdAndSendText(string id, string text, IWebDriver driver)
        {
            bool notLoaded = true;
            bool validated = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.Id(id)).GetAttribute("value");
                    notLoaded = false;
                    if (text != element)
                        validated = false;
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            s.Stop();
            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");
            if (!validated)
                throw new Exception("The Input that was saved was not the same");
            Thread.Sleep(1000);
        }
        public static void ValidateFindIdAndDropDown(string id, string text, IWebDriver driver)
        {
            bool notLoaded = true;
            bool validated = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.Id(id)).Text;
                    notLoaded = false;
                    if (text != element)
                        validated = false;
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            s.Stop();

            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");

            if (!validated)
                throw new Exception("The Input that was saved was not the same");
            Thread.Sleep(1000);
        }

        public static void ValidateFindNameAndSendText(string name, string text, IWebDriver driver)
        {
            bool notLoaded = true;
            bool validated = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.Name(name)).GetAttribute("value");
                    notLoaded = false;
                    if (text != element)
                        validated = false;
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            s.Stop();

            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");

            if (!validated)
                throw new Exception("The Input that was saved was not the same");
            Thread.Sleep(1000);
        }
        public static void ValidateFindNameAndDropDown(string name, string text, IWebDriver driver)
        {
            bool notLoaded = true;
            bool validated = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.Name(name)).Text;
                    notLoaded = false;
                    if (text != element)
                        validated = false;
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            s.Stop();

            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");

            if (!validated)
                throw new Exception("The Input that was saved was not the same");
            Thread.Sleep(1000);
        }

        public static void ValidateFindCssAndSendText(string css, string text, IWebDriver driver)
        {
            bool notLoaded = true;
            bool validated = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.CssSelector(css)).GetAttribute("value");
                    notLoaded = false;
                    if (text != element)
                        validated = false;
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            s.Stop();

            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");

            if (!validated)
                throw new Exception("The Input that was saved was not the same");
            Thread.Sleep(1000);
        }
        public static void ValidateFindCssAndDropDown(string css, string text, IWebDriver driver)
        {
            bool notLoaded = true;
            bool validated = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.CssSelector(css)).Text;
                    notLoaded = false;
                    if (text != element)
                        validated = false;
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            s.Stop();

            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");

            if (!validated)
                throw new Exception("The Input that was saved was not the same");
            Thread.Sleep(1000);
        }

        public static void ValidateFindXPathAndSendText(string xpath, string text, IWebDriver driver)
        {
            bool notLoaded = true;
            bool validated = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.XPath(xpath)).GetAttribute("value");
                    notLoaded = false;
                    if (text != element)
                        validated = false;
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            s.Stop();

            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");

            if (!validated)
                throw new Exception("The Input that was saved was not the same");
            Thread.Sleep(1000);
        }
        public static void ValidateFindXPathAndDropDown(string xpath, string text, IWebDriver driver)
        {
            bool notLoaded = true;
            bool validated = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.XPath(xpath)).Text;
                    notLoaded = false;
                    if (text != element)
                        validated = false;
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            s.Stop();

            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");

            if (!validated)
                throw new Exception("The Input that was saved was not the same");
            Thread.Sleep(1000);
        }
        public static void ValidateFindXPathAndCheckBox(string xpath, string value, IWebDriver driver)
        {
            bool notLoaded = true;
            bool validated = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.XPath(xpath));
                    notLoaded = false;
                    if (element.Selected.ToString().ToLower() != value.ToLower())
                        validated = false;
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            s.Stop();

            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");

            if (!validated)
                throw new Exception("The Input that was saved was not the same");
            Thread.Sleep(1000);
        }

        public static void ValidateFindDataBindAndSendText(string dataBind, string text, IWebDriver driver)
        {
            bool notLoaded = true;
            bool validated = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.CssSelector(string.Format("[data-bind*='{0}']", dataBind))).GetAttribute("value");
                    notLoaded = false;
                    if (text != element)
                        validated = false;
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            s.Stop();

            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");

            if (!validated)
                throw new Exception("The Input that was saved was not the same");
            Thread.Sleep(1000);
        }
        public static void ValidateFindDataBindAndDropDown(string dataBind, string text, IWebDriver driver)
        {
            bool notLoaded = true;
            bool validated = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.CssSelector(string.Format("[data-bind*='{0}']", dataBind))).Text;
                    notLoaded = false;
                    if (text != element)
                        validated = false;
                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            s.Stop();

            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");

            if (!validated)
                throw new Exception("The Input that was saved was not the same");
            Thread.Sleep(1000);
        }
        public static void ValidateFindDataBindAndCheckBox(string dataBind, IWebDriver driver)
        {
            bool notLoaded = true;
            bool validated = true;

            var timeClock = new Stopwatch();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && notLoaded)
            {
                try
                {
                    var element = driver.FindElement(By.CssSelector(string.Format("[data-bind*='{0}']", dataBind)));
                    notLoaded = false;

                }
                catch
                {
                    //purposely silently eating the error
                }
            }
            s.Stop();

            if (s.Elapsed > TimeSpan.FromSeconds(30) && !notLoaded)
                throw new Exception("Page did not load or could not find element");

            if (!validated)
                throw new Exception("The Input that was saved was not the same");
            Thread.Sleep(1000);
        }
    }
}
