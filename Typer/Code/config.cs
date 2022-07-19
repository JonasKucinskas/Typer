using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;


namespace Typer
{
    internal class config
    {
        public int Time { get; set; }
        public string FileName { get; set; }

        public static config returnConfigObject()
        {
            string path = Environment.CurrentDirectory + "\\Data\\Config\\config.json";

            return JsonConvert.DeserializeObject<config>(File.ReadAllText(path));
        }

        /// <summary>
        /// Writes to config file
        /// </summary>
        /// <param name="settings"></param>
        public static void WriteToConfig(string config)
        {
            string path = Environment.CurrentDirectory + "\\Data\\Config\\config.json";


            using (StreamWriter write = new StreamWriter(path, false))
            {
                write.WriteLine(config); 
            }
        }
    }
}
