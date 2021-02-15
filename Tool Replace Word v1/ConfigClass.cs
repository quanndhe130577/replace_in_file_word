using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Replace_Word_v1
{
    public class ConfigClass
    {
        public string short_part_hosomau { get; set; }
        public string short_part_fileEdit { get; set; }
        public string folder_result { get; set; }
        public string file_name { get; set; }

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

        static public bool UpdateConfig(ConfigClass conf)
        {
            StreamWriter file = File.CreateText(Environment.CurrentDirectory + "\\Config.json");

            JsonSerializer serializer = new JsonSerializer();
            using (JsonWriter writer = new JsonTextWriter(file))
            {
                serializer.Serialize(writer, conf);
                // {"ExpiryDate":new Date(1230375600000),"Price":0}
            }

            return true;
        }
    }
}
