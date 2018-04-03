﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;
using Newtonsoft.Json;
using System.Threading;
using System.Windows.Forms;

namespace Grafinity
{
    /// <summary>
    /// Class containing a set of functions for editting, loading and saving configuration.
    /// </summary>
    public static class ConfigManager
    {
        private static string config = File.ReadAllText(Application.ExecutablePath + "\\config.config");

        /// <summary>
        /// String containing parsed config.
        /// </summary>
        public static string Config { get => config; private set => config = value; }

        /// <summary>
        /// Returns active mode.
        /// </summary>
        /// <returns></returns>
        public static string GetMode()
        {
            string json = File.ReadAllText(Application.ExecutablePath + "\\config.config");

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return values["mode"];
        }

        /// <summary>
        /// Returns destination path.
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            string json = File.ReadAllText(Application.ExecutablePath + "\\config.config");

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return values["path"];
        }

        /// <summary>
        /// Set and save mode.
        /// </summary>
        /// <param name="value"></param>
        public static void UpdateMode(string value)
        {
            string json = File.ReadAllText(Application.ExecutablePath + "\\config.config");
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            values["mode"] = value;

            json = JsonConvert.SerializeObject(values);
            File.WriteAllText(Application.ExecutablePath + "\\config.config", json);
        }

        /// <summary>
        /// Set and save destination path.
        /// </summary>
        /// <param name="value"></param>
        public static void UpdatePath(string value)
        {
            string json = File.ReadAllText(Application.ExecutablePath + "\\config.config");
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            values["path"] = value;

            json = JsonConvert.SerializeObject(values);
            File.WriteAllText(Application.ExecutablePath + "\\config.config", json);
        }
    }
}
