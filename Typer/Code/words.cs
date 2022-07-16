using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Typer
{
    internal class words
    {
        private static int CountLinesTXT(string fileName)
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
            int lines = CountLinesTXT(fileName);

            Random random = new Random();
            int r = random.Next(lines + 1);//Memory efficient yes.

            return File.ReadLines(fileName).ElementAtOrDefault(r - 1);//return word.
        }
    }
}
