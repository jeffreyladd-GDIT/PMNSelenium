using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladd.PMNSelentium
{
    public class DataMartsToAdd
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void CreateDM(DataMart dataMart, IWebDriver driver, string browser)
        {
            log.Info("Waiting for New DataMart Button to be loaded and Clicked");
            System.Threading.Thread.Sleep(1000);

            WaitAndFindSelector.FindIdAndClick("btnNewDataMart", driver);

            //First we loop over to Create the DataMart
            System.Threading.Thread.Sleep(1000);
            foreach (var action in dataMart.Actions)
            {
                try
                {
                    log.Info("Executing the action: " + action.InputType + " on property " + action.ByType + " " + action.ByValue);

                    WaitAndFindSelector.FindByAndExecute(action, driver);

                    log.Info("Executing the action: " + action.InputType + " on property " + action.ByType + " " + action.ByValue + " successfull");
                }
                catch (Exception ex)
                {
                    log.Error("error in DataMart Creation for " + dataMart.DMTestName + " in action " + action.Name);
                }
            }

            log.Info("Refreshing page to validate entries");

            driver.Navigate().Refresh();

            System.Threading.Thread.Sleep(2000);

            foreach (var action in dataMart.Actions.Where(x => x.Validate))
            {
                try
                {

                    log.Info("Validating the action: " + action.InputType + " on property " + action.ByType + " " + action.ByValue);

                    WaitAndFindSelector.ValidateFindByAndExecute(action, driver);

                    log.Info("Executing the action: " + action.InputType + " on property " + action.ByType + " " + action.ByValue + " successfull");

                }
                catch (Exception ex)
                {
                    log.Error("error in DataMart validation for " + dataMart.DMTestName + " in action " + action.Name);
                }
            }
        }
    }
}
