using System;
using System.Collections.Generic;
using System.Text;

namespace NewArrChars
{
    class Sequens
    {
        public char Simbol;
        public int Count;
        public string Str;
        public Word FromWord;
        public bool blocked = false;
        public Sequens(Word word, string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                Simbol = str[0];
            }
            else
            {
                Simbol = ' ';
            }
            Count = str.Length;
            Str = str;
            FromWord = word;
        }

        public Sequens(char simbol, int count)
        {
            Str = "";
            if (simbol != ' ')
            {
                for (int i = 0; i < count; i++)
                {
                    Str += simbol;
                }
            }
            Count = count;
            Simbol = simbol;
        }
    }
}
