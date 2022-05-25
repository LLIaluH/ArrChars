using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewArrChars
{
    class Main
    {
        List<Word> Words;
        public void Start()
        {
            var sw = new System.Diagnostics.Stopwatch();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Нажмите Y, чтобы автоматически сгенерировать слова. Чтобы читать из файла, нажмите Enter...");
                List<string> words;
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    sw.Reset();
                    sw.Start();
                    ArrGenerator arrGenerator = new ArrGenerator(20, 100);//для генератора
                    words = arrGenerator.WordsList;
                    sw.Stop();
                    Console.WriteLine($"Время затраченное на генерацию: {sw.ElapsedMilliseconds} ms");
                }
                else
                {
                    string path = Directory.GetCurrentDirectory();
                    sw.Reset();
                    sw.Start();
                    words = ArrReader.Read(path + @"\Data.txt");//для чтения из файла 
                    sw.Stop();
                    Console.WriteLine($"Время затраченное на чтение из файла: {sw.ElapsedMilliseconds} ms");
                }
                Console.Write("\n");
                int maxLength = 0;
                sw.Reset();
                sw.Start();
                Words = new List<Word>();
                foreach (var w in words)
                {
                    if (maxLength < w.Length)
                    {
                        maxLength = w.Length;
                    }
                    Words.Add(new Word(w));
                }
                sw.Stop();
                Console.WriteLine($"Время затраченное на поиск последовательностей: {sw.ElapsedMilliseconds} ms");
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
                sw.Reset();
                sw.Start();
                MaxSubsequence maxSubseq = new MaxSubsequence(Words);
                sw.Stop();
                Console.WriteLine($"Время затраченное на поиск самой длинной последовательности: {sw.ElapsedMilliseconds} ms");
                Console.ReadKey();
            }
            

            Console.ReadLine();
        }
    }
}
