using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladd.PMNSelentium
{
    public static class Utils
    {
        public static By GetBy(string by, string value)
        {
            if (by.ToLower() == "id")
                return By.Id(value);
            else if (by.ToLower() == "css")
                return By.CssSelector(value);
            else if (by.ToLower() == "name")
                return By.Name(value);
            else if (by.ToLower() == "xpath")
                return By.XPath(value);
            else
                throw new Exception("By is not a correct Value");
        }

        public static void WaitForElement(By by, IWebDriver driver)
        {
            bool notLoaded = true;

            while (notLoaded)
            {
                try
                {
                    driver.FindElement(by);
                    notLoaded = false;
                }
                catch (Exception)
                {
                    //purposely silently eating the error
                }
            }
        }

        public static bool IsSelectable(string type)
        {
            return type == "dropdown" || type == "dropdownSelection" || type == "button" || type == "tab" || type == "checkbox";
        }
    }
}
