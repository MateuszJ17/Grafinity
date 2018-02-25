using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;
using Newtonsoft.Json;

namespace Grafinity
{
    public static class ConfigManager
    {
        static string config = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\config.config");

        public static void UpdateConfig()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("key1", "value1");
            values.Add("key2", "value2");
            string json = JsonConvert.SerializeObject(values);
            File.WriteAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\config.config", json);
        }

        public static void ConfigContent()
        {
            Console.WriteLine(config);
        }
    }
}
