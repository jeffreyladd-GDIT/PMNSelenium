using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladd.PMNSelentium
{
    public class LoginPage
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void TestLogin(ConfigurationManager config, IWebDriver driver, string browser)
        {
            log.Info("Waiting for page to load and element userName to be visible");

            WaitAndFindSelector.FindNameAndSendText("username", config.UserName, driver);

            WaitAndFindSelector.FindIdAndSendText("txtPassword", config.Password, driver);

            WaitAndFindSelector.FindCssAndClick("button.btn.btn-primary", driver);


            log.Info("login Successful");
        }
    }
}
