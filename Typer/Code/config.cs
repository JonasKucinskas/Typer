using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Typer
{
    internal class config
    {
        public int Time { get; set; }
        public static void WriteToConfig(config settings)
        {
            using (StreamWriter write = new StreamWriter(@"C:\Users\Gaming\Desktop\program\c#\Typer\Typer\Config\config.cfg", false))
            {
                write.WriteLine(settings.Time);
            }
        }

        public static int ReadConfig()
        {
            int time;

            using (StreamReader read = new StreamReader(@"C:\Users\Gaming\Desktop\program\c#\Typer\Typer\Config\config.cfg"))
            {
                time = Int32.Parse(read.ReadLine());
            }

            return time;
        }
    }
}
