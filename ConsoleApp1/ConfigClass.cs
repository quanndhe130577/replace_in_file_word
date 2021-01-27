using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ConfigClass
    {
        public string folder_scan { get; set; }
        public string filepath_default_header_footer { get; set; }

        static public ConfigClass GetConfig()
        {
            ConfigClass conf;
            StreamReader reader = new StreamReader(Environment.CurrentDirectory + "\\Config.json");
            String str = reader.ReadToEnd();
            reader.Close();
            if (str == "" || str == null)
            {
                Console.WriteLine("Check Config.json for folder");
                return null;
            }
            else
            {
                conf = JsonConvert.DeserializeObject<ConfigClass>(str);
            }

            return conf;
        }
    }
}
