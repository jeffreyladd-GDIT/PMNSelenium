using log4net;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladd.PMNSelentium
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            IList<ConfigurationManager> configs = new List<ConfigurationManager>();
            log.Info("Starting Load of Configuration File");
            foreach (var arg in args)
            {
                if (arg.ToLower().StartsWith("/configs:"))
                {
                    var fixArg = arg.Remove(0, 9);
                    var files = fixArg.Split(',');
                    foreach (var file in files)
                    {
                        configs.Add(JsonConvert.DeserializeObject<ConfigurationManager>(File.ReadAllText(file)));
                    }
                }
            }

            foreach (var config in configs)
            {
                var tests = new SeleniumDrivers(config);
                tests.LoadDrivers();
            }
        }
    }
}
