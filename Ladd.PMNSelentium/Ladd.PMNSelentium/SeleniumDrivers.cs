using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace Ladd.PMNSelentium
{
    public class SeleniumDrivers
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ConfigurationManager _config;

        public SeleniumDrivers(ConfigurationManager config)
        {
            this._config = config;
        }


        public void LoadDrivers()
        {
            if (_config.ChromeDriver)
            {
                log.Info("Loading Chrome Driver and starting Chrome Instance");
                using (IWebDriver driver = new ChromeDriver())
                {
                    try
                    {
                        var runner = new TestRunner(_config);
                        runner.Run(driver, "Chrome");
                    }
                    catch (Exception ex)
                    {
                        log.Error("The following Error Occured" + ex.Message);
                    }
                    finally
                    {
                        driver.Close();
                    }
                }
            }
            if (_config.FirefoxDriver)
            {
                log.Info("Loading FireFox Driver and starting FireFox Instance");
                using (IWebDriver driver = new FirefoxDriver())
                {
                    try
                    {
                        var runner = new TestRunner(_config);
                        runner.Run(driver, "FireFox");
                    }
                    catch (Exception ex)
                    {
                        log.Error("The following Error Occured" + ex.Message);
                    }
                    finally
                    {
                        driver.Close();
                    }
                }
            }
            if (_config.IEDriver)
            {
                log.Info("Loading Internet Explorer Driver and starting Internet Explorer Instance");
                using (IWebDriver driver = new InternetExplorerDriver())
                {
                    try
                    {
                        var runner = new TestRunner(_config);
                        runner.Run(driver, "Internet Explorer");
                    }
                    catch (Exception ex)
                    {
                        log.Error("The following Error Occured" + ex.Message);
                    }
                    finally
                    {
                        driver.Close();
                    }
                }
            }
        }
    }
}