using System;
using System.Collections.Generic;
using System.Text;

namespace NewArrChars
{
    class Main
    {
        List<Word> Words;
        public void Start()
        {
            var words = ArrReader.Read(@"C:\Users\mikheev_av1\Desktop\qweqwe.txt");//для чтения из файла

            //ArrGenerator arrGenerator = new ArrGenerator(100, 100);//для генератора
            //var words = arrGenerator.WordsList;

            int maxLength = 0;
            Words = new List<Word>();
            foreach (var w in words)
            {
                if (maxLength < w.Length)
                {
                    maxLength = w.Length;
                }
                Words.Add(new Word(w));
            }

            foreach (var w in Words)
            {
                w.Print(maxLength);
            }

            MaxSubsequence maxSubseq = new MaxSubsequence(Words);

            Console.ReadLine();
        }
    }
}
