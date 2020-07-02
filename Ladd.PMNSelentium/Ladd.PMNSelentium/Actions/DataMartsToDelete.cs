using log4net;
using OpenQA.Selenium;
using System;

namespace Ladd.PMNSelentium
{
    public class DataMartsToDelete
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void DeleteDataMart(string datamart, IWebDriver driver, string browser)
        {
            try
            {
                log.Info("Waiting for DataMart Grid to load");
                System.Threading.Thread.Sleep(1000);

                WaitAndFindSelector.FindXPathAndClick("//a[.='" + datamart + "']", driver);

                System.Threading.Thread.Sleep(2000);

                WaitAndFindSelector.FindIdAndClick("btnDelete", driver);

                System.Threading.Thread.Sleep(2000);

                WaitAndFindSelector.FindIdAndClick("confirmYes", driver);

                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                log.Error("error in DataMart Deletion for " + datamart);
            }
        }
    }
}
