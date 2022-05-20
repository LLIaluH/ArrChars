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
            //var words = ArrReader.Read(@"C:\Users\Андрей\Desktop\new 1.txt");
            var words = ArrReader.Read(@"C:\Users\mikheev_av1\Desktop\qweqwe.txt");
            Words = new List<Word>();
            foreach (var w in words)
            {
                Words.Add(new Word(w));
            }

            foreach (var w in Words)
            {
                w.Print();
            }

            MaxSubsequence maxSubseq = new MaxSubsequence(Words);

            Console.ReadLine();
        }
    }
}
