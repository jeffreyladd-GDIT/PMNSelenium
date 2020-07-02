using System.Collections.Generic;

namespace Ladd.PMNSelentium
{
    public class ConfigurationManager
    {
        public string ConfigName { get; set; }
        public string PathToLogs { get; set; }
        public string EmailToMailReport { get; set; }
        public bool ChromeDriver { get; set; }
        public bool IEDriver { get; set; }
        public bool FirefoxDriver { get; set; }
        public string BaseURL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<DataMart> DataMartsToAdd { get; set; }
        public IEnumerable<DataMart> DataMartsToEdit { get; set; }
        public IEnumerable<string> DataMartsToRemove { get; set; }
    }

    public class DataMart
    {
        public string DMTestName { get; set; }
        public IEnumerable<Action> Actions { get; set; }
    }

    public class Action
    {
        public string Name { get; set; }
        public string ByType { get; set; }
        public string ByValue { get; set; }
        public string InputType { get; set; }
        public string InputValue { get; set; }
        public bool Validate { get; set; }
        public string ValidateByType { get; set; }
        public string ValidateByValue { get; set; }
    }
}
