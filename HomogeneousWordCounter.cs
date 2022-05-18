using System;
using System.Collections.Generic;
using System.Text;

namespace ArrChars
{
    class HomogeneousWordCounter
    {
        char[] Simbols = new char[26];

        private List<char> _MaxSim = new List<char>();
        public List<char> MaxSim => _MaxSim;

        private int _MaxCountSim;
        public int MaxCountSim
        {
            get { return _MaxCountSim; }
            private set
            {
                if (value > _MaxCountSim)
                {
                    _MaxCountSim = value;
                }
            }
        }

        Dictionary<char, int> numberOfSpecificCharacters;

        Dictionary<char, int> numberOfSpecificCharactersBefore;
        Dictionary<char, int> numberOfSpecificCharactersCenter;
        Dictionary<char, int> numberOfSpecificCharactersAfter;

        Dictionary<char, int> result;

        public HomogeneousWordCounter(in char[] simbols)
        {
            Simbols = simbols;
            numberOfSpecificCharacters = new Dictionary<char, int>();
            numberOfSpecificCharactersBefore = new Dictionary<char, int>();
            numberOfSpecificCharactersCenter = new Dictionary<char, int>();
            numberOfSpecificCharactersAfter = new Dictionary<char, int>();
            result = new Dictionary<char, int>();
            for (int i = 0; i < simbols.Length; i++)
            {
                numberOfSpecificCharacters.Add(simbols[i], 0);
                numberOfSpecificCharactersBefore.Add(simbols[i], 0);
                numberOfSpecificCharactersCenter.Add(simbols[i], 0);
                numberOfSpecificCharactersAfter.Add(simbols[i], 0);
                result.Add(simbols[i], 0);
            }
        }

        public void Count(in List<string> wordsArr)
        {
            foreach (var word in wordsArr)
            {
                if (word.Length == 1)
                {
                    numberOfSpecificCharacters[word[0]] += 1;
                }
                else
                {
                    CountOrderedSimbols(word);
                }
            }

            int maxCountSim = 0;
            for (int i = 0; i < Simbols.Length; i++)
            {
                numberOfSpecificCharacters[Simbols[i]] = numberOfSpecificCharacters[Simbols[i]] + numberOfSpecificCharactersBefore[Simbols[i]] + numberOfSpecificCharactersAfter[Simbols[i]];
                int maxForSim = numberOfSpecificCharactersCenter[Simbols[i]] > numberOfSpecificCharacters[Simbols[i]] ? numberOfSpecificCharactersCenter[Simbols[i]] : numberOfSpecificCharacters[Simbols[i]];

                result[Simbols[i]] = maxForSim;

                if (maxCountSim < maxForSim)
                {
                    _MaxSim.Clear();
                    _MaxSim.Add(Simbols[i]);
                    maxCountSim = maxForSim;
                }
                else if (maxCountSim == numberOfSpecificCharacters[Simbols[i]])
                {
                    _MaxSim.Add(Simbols[i]);
                }
            }
            MaxCountSim = maxCountSim;
        }

        private void CountOrderedSimbols(string word)
        {
            string w = word[0].ToString();

            bool fromStart = true;
            string maxStart = "";

            string maxCenter = "";

            string maxEnd = "";

            for (int i = 1; i < word.Length; i++)
            {
                if (w[w.Length - 1] == word[i])
                {
                    w += word[i];
                    if (i == word.Length - 1)
                    {
                        maxEnd = w;
                    }
                }
                else if (fromStart)
                {
                    fromStart = false;
                    maxStart = w;
                    if (i == word.Length - 1)
                    {
                        maxEnd = word[i].ToString();
                    }
                    w = word[i].ToString();
                }
                else
                {
                    if (maxCenter.Length < w.Length)
                    {
                        maxCenter = w;
                    }
                    if (i == word.Length - 1)
                    {
                        maxEnd = word[i].ToString();
                    }
                    w = word[i].ToString();
                }
            }

            //все буквы в слове одинаковые//
            if (maxStart.Length == word.Length)
            {
                numberOfSpecificCharacters[word[0]] += word.Length;
            }
            else
            {
                if (maxStart.Length > maxEnd.Length)//для исключения попыток объединить начало и конец одного слова
                {
                    if (numberOfSpecificCharactersBefore[maxStart[0]] < maxStart.Length)
                    {
                        numberOfSpecificCharactersBefore[maxStart[0]] = maxStart.Length;
                    }
                }
                else
                {
                    if (numberOfSpecificCharactersAfter[maxEnd[0]] < maxEnd.Length)
                    {
                        numberOfSpecificCharactersAfter[maxEnd[0]] = maxEnd.Length;
                    }
                }

                if (!string.IsNullOrEmpty(maxCenter))
                {
                    if (numberOfSpecificCharactersCenter[maxCenter[0]] < maxCenter.Length)
                    {
                        numberOfSpecificCharactersCenter[maxCenter[0]] = maxCenter.Length;
                    }
                }
                //максимальная длина последовательности внутри слова
            }
        }
    }
}
