using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewArrChars
{
    public static class ArrReader
    {
        public static List<string> Read(string path)
        {
            try
            {
                //StreamReader sr = new StreamReader(path);
                //string line = sr.ReadLine();
                //sr.Close();
                //string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var words = File.ReadAllLines(path);
                List<string> res = new List<string>();
                foreach (var word in words)
                {
                    res.Add(word);
                }
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            return new List<string>();
        }
    }
}
