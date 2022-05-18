using System;
using System.Collections.Generic;
using System.Text;

namespace ArrChars
{
    class ArrGenerator
    {
        private Random r;
        public int MaxWordLength;
        public List<string> WordsArr { get; }
        public int WordsSumLength {
            get { return wordsSumLength; }
            private set { wordsSumLength = value; }
        }

        private int wordsSumLength = 0;

        public ArrGenerator()
        {
            r = new Random();
            WordsArr = new List<string>();
        }

        public ArrGenerator(in char[] simbols, int maxWordLength, int wordCount)
        {
            r = new Random();
            WordsArr = new List<string>();
            this.MaxWordLength = maxWordLength;
            GetNewArr(simbols, maxWordLength, wordCount);
        }

        public List<string> GetNewArr(in char[] simbols, int maxWordLength, int wordCount)
        {
            this.MaxWordLength = maxWordLength;
            WordsArr.Clear();
            for (int i = 0; i < wordCount; i++)
            {
                var word = GetWord(simbols, maxWordLength);
                WordsSumLength += word.Length;
                WordsArr.Add(word);
            }
            return WordsArr;
        }

        private string GetWord(char[] simbols, int maxWordLength)
        {
            string word ="";
            for (int i = 0; i < r.Next(1, maxWordLength); i++)
            {
                word += simbols[r.Next(0, simbols.Length)];
            }
            return word;
        }
    }
}
