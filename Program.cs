using System;

namespace ArrChars
{
    class Program
    {
        static char[] Simbols = new char[4];
        static int WordCount = 10;
        static int MaxWordLength = 20;

        static void Main(string[] args)
        {
            for (int i = 0; i < Simbols.Length; i++)
                Simbols[i] = (char)(i + 97);

            ArrGenerator arrGenerator = new ArrGenerator(in Simbols, MaxWordLength, WordCount);
            ConsWriteWordArr(arrGenerator);
            HomogeneousWordCounter homogeneousWordCounter = new HomogeneousWordCounter(in Simbols);
            homogeneousWordCounter.Count(arrGenerator.WordsArr);
            if (homogeneousWordCounter.MaxSim.Count > 1)
            {
                Console.WriteLine("\nМаксимальные непрерывные подстроки состоят из " + homogeneousWordCounter.MaxCountSim + ":\n");
                foreach (var item in homogeneousWordCounter.MaxSim)
                {
                    Console.WriteLine("\"" + item.ToString() + "\" ");
                }
            }
            else
            {
                Console.WriteLine("\nМаксимальная непрерывная подстрока состоит из " + homogeneousWordCounter.MaxCountSim + " символов \"" + homogeneousWordCounter.MaxSim[0].ToString() + "\"");

            }
            Console.ReadKey();
        }

        private static void ConsWriteWordArr(ArrGenerator arrGenerator)
        {
            for (int i = 0; i < arrGenerator.WordsArr.Count; i++)
            {
                Console.WriteLine(arrGenerator.WordsArr[i]);
            }
        }
    }
}
