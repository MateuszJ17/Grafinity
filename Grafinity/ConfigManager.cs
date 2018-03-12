using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;
using Newtonsoft.Json;
using System.Threading;

namespace Grafinity
{
    public static class ConfigManager
    {
        static string config = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\config.config");

        public static string GetMode()
        {
            string json = File.ReadAllText((Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\config.config"));
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return values["mode"];
        }

        public static string GetPath()
        {
            string json = File.ReadAllText((Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\config.config"));
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return values["path"];
        }

        public static void UpdateMode(string value)
        {
            string json = File.ReadAllText((Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\config.config"));
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            values["mode"] = value;
            string json2 = JsonConvert.SerializeObject(values);
            File.WriteAllText((Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\config.config"), json2);
        }

        public static void UpdatePath(string value)
        {
            string json = File.ReadAllText((Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\config.config"));
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            values["path"] = value;
            string json2 = JsonConvert.SerializeObject(values);
            File.WriteAllText((Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\config.config"), json2);
        }
    }
}
