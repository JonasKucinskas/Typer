using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer
{
    internal class wordFiles
    {

        public static List<string> ReturnFileNames(string path)
        {
            List<string> fileNames = Directory.EnumerateFiles(path)
                                          .Select(p => System.IO.Path.GetFileNameWithoutExtension(p))
                                          .ToList();

            return fileNames;
        }

        
    }
}
