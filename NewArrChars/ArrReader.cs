using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewArrChars
{
    public static class ArrReader
    {
        public static string[] Read(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                string line = sr.ReadLine();
                sr.Close();
                string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return words;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            return new string[0];
        }
    }
}
