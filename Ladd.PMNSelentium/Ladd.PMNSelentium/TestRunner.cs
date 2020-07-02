using log4net;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace Ladd.PMNSelentium
{
    public class TestRunner
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ConfigurationManager _config;

        public TestRunner(ConfigurationManager config)
        {
            _config = config;
        }

        public void Run(IWebDriver driver, string browser)
        {

            log.Info(browser + " Loaded and setting Timeouts for 30 Seconds");
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 30);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);

            log.Info("Navigating to URL: " + _config.BaseURL);
            driver.Navigate().GoToUrl(_config.BaseURL);

            var login = new LoginPage();
            login.TestLogin(_config, driver, browser);
            System.Threading.Thread.Sleep(2000);
            if (_config.DataMartsToAdd.Count() > 0)
            {
                var add = new DataMartsToAdd();
                foreach (var dm in _config.DataMartsToAdd)
                {
                    driver.Navigate().GoToUrl(_config.BaseURL + "\\DataMarts");
                    log.Info("Starting to Create Datamart for " + dm.DMTestName);
                    add.CreateDM(dm, driver, browser);
                    log.Info("Successfully created Datamart " + dm.DMTestName);
                }
            }

            if (_config.DataMartsToEdit.Count() > 0)
            {
                driver.Navigate().GoToUrl(_config.BaseURL + "\\DataMarts");
                var remove = new DataMartsToEdit();
                foreach (var dm in _config.DataMartsToEdit)
                {
                    remove.EditDM(dm, driver, browser);
                    log.Info("Successfully edited datamart " + dm.DMTestName);
                }
            }

            if (_config.DataMartsToRemove.Count() > 0)
            {
                driver.Navigate().GoToUrl(_config.BaseURL + "\\DataMarts");
                var remove = new DataMartsToDelete();
                foreach (var dm in _config.DataMartsToRemove)
                {
                    remove.DeleteDataMart(dm, driver, browser);
                    System.Threading.Thread.Sleep(2000);
                    log.Info("Successfully deleted datamart " + dm);
                }
            }
        }
    }
}