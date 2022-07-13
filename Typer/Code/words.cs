using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Typer
{
    internal class words
    {
        public static string ReturnRandomWord()
        {
            Random rnd = new Random();
            int r = rnd.Next(1518);//Memory efficient.

            string word = File.ReadLines("words.txt").ElementAtOrDefault(r - 1);

            return word;
        }
    }
}
