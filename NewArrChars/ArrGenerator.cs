using System;
using System.Collections.Generic;
using System.Text;

namespace NewArrChars
{
    class ArrGenerator
    {
        private Random r;
        private char[] Simbols;
        public int MaxWordLength;
        public List<string> WordsList { get; }
        public int WordsSumLength
        {
            get { return wordsSumLength; }
            private set { wordsSumLength = value; }
        }

        private int wordsSumLength = 0;

        public ArrGenerator()
        {
            r = new Random();
            WordsList = new List<string>();
        }

        public ArrGenerator(int maxWordLength, int wordCount)
        {
            r = new Random();
            WordsList = new List<string>();
            Simbols = new char[26];
            this.MaxWordLength = maxWordLength;
            for (int i = 0; i < 26; i++)
            {
                Simbols[i] = (char)(i + 97);
            }
            GetNewList(Simbols, maxWordLength, wordCount);
        }

        public List<string> GetNewList(in char[] simbols, int maxWordLength, int wordCount)
        {
            this.MaxWordLength = maxWordLength;
            WordsList.Clear();
            for (int i = 0; i < wordCount; i++)
            {
                var word = GetWord(simbols, maxWordLength);
                WordsSumLength += word.Length;
                WordsList.Add(word);
            }
            return WordsList;
        }

        private string GetWord(char[] simbols, int maxWordLength)
        {
            string word = "";
            for (int i = 0; i < r.Next(1, maxWordLength); i++)
            {
                word += simbols[r.Next(0, simbols.Length)];
            }
            return word;
        }

        public string[] GetArr()
        {
            return WordsList.ToArray();
        }
    }
}
