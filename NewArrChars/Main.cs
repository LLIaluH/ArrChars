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
            Console.WriteLine("Нажмите Y, чтобы автоматически сгенерировать слова. Чтобы читать из файла, нажмите Enter...");
            List<string> words;
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                ArrGenerator arrGenerator = new ArrGenerator(50, 100000);//для генератора
                words = arrGenerator.WordsList;
            }
            else
            {
                words = ArrReader.Read(@"C:\Users\mikheev_av1\Desktop\qweqwe.txt");//для чтения из файла
            }
            Console.Write("\n");
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

            Console.WriteLine("Нажмите Y, чтобы вывести все слова. Чтобы пропустить - Enter...\n");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.Write("\n");
                Console.Clear();
                foreach (var w in Words)
                {
                    w.Print(maxLength);
                }
            }

            MaxSubsequence maxSubseq = new MaxSubsequence(Words);

            Console.ReadLine();
        }
    }
}
