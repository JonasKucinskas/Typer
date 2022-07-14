using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Typer
{
    internal class words
    {
        private static int CountLinesTXt(string fileName)
        {
            int lines = 0;
            using (TextReader reader = File.OpenText(fileName))
            {
                while (reader.ReadLine() != null)
                {
                    lines++;
                }
            }

            return lines;
        }
        
        public static string ReturnRandomWord(string fileName)
        {

            //Get number of lines in a file
            int lines = CountLinesTXt(fileName);

            Random rnd = new Random();
            int r = rnd.Next(lines);//Memory efficient yes.

            return File.ReadLines(fileName).ElementAtOrDefault(r - 1);//return word.
        }
    }
}
