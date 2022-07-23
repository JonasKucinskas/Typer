using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;


namespace Typer
{
    internal class Config
    {
        public int Time { get; set; }
        public string FileName { get; set; }

        public static Config returnConfigObject()
        {
            string path = Environment.CurrentDirectory + "\\Data\\Config\\config.json";

            return JsonConvert.DeserializeObject<Config>(File.ReadAllText(path));
        }

        /// <summary>
        /// Writes to config file
        /// </summary>
        /// <param name="settings"></param>
        public static void WriteToConfig(Config cfg)
        {
            string path = Environment.CurrentDirectory + "\\Data\\Config\\config.json";

            using (StreamWriter write = new StreamWriter(path, false))
            {
                write.WriteLine(JsonConvert.SerializeObject(cfg)); 
            }
        }
    }
}
