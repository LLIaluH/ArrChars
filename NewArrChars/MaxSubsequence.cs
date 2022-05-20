using System;
using System.Collections.Generic;
using System.Text;

namespace NewArrChars
{
    class MaxSubsequence
    {
        readonly List<Word> Words;
        List<Sequens> maxCentrals; //самые длинные центральные последовательности
        Dictionary<char, List<Sequens>> ListSeqDict = new Dictionary<char, List<Sequens>>(); //хранит сумму длин последовательностей для каждого символа
        Dictionary<char, Sequens> MaxStartSeqDict = new Dictionary<char, Sequens>(); //хранит максимальную последовательность начала для каждого символа
        Dictionary<char, Sequens> MaxEndSeqDict = new Dictionary<char, Sequens>(); //хранит максимальную последовательность конца для каждого символа

        List<List<Sequens>> finalMax = new List<List<Sequens>>();

        int MaxCountSimbolsInSeq = 0;
        int MaxCountSimbolsInSeqCentral = 0;

        public MaxSubsequence(in List<Word> words)
        {
            for (int i = 0; i < 26; i++)//заполнение значениями поумолчанию
            {
                ListSeqDict.Add((char)(i + 97), new List<Sequens>());
                MaxStartSeqDict.Add((char)(i + 97), null);
                MaxEndSeqDict.Add((char)(i + 97), null);
            }
            Words = words;
            maxCentrals = new List<Sequens>();
            maxCentrals.Add(new Sequens(new Word(""),""));
            Calculate();
            Print();
        }

        public void Calculate()
        {
            for (int i = 0; i < Words.Count; i++)
            {
                var currentWord = Words[i];

                if (currentWord.subSequenses.Count == 1)
                {
                    ListSeqDict[currentWord.subSequenses[0].Simbol].Add(currentWord.subSequenses[0]);//добавляем последовательность символов в словарь под своей буквой
                }
                else
                {
                    char firstSimbol = currentWord.subSequenses[0].Simbol;
                    char lastSimbol = currentWord.subSequenses[currentWord.subSequenses.Count - 1].Simbol;
                    if (MaxStartSeqDict[firstSimbol] == null || MaxStartSeqDict[firstSimbol].Count < currentWord.subSequenses[0].Count)//начало
                    {
                        MaxStartSeqDict[firstSimbol] = currentWord.subSequenses[0];
                    }
                    if (MaxEndSeqDict[lastSimbol] == null
                        || MaxEndSeqDict[lastSimbol].Count < currentWord.subSequenses[currentWord.subSequenses.Count - 1].Count)//конец
                    {
                        MaxEndSeqDict[lastSimbol] = currentWord.subSequenses[currentWord.subSequenses.Count - 1];
                    }
                }

                for (int j = 0; j < currentWord.subSequenses.Count; j++)
                {
                    #region SearchCentral
                    if (j != 0 && j != currentWord.subSequenses.Count - 1)//это одна из центральных последовательностей
                    {
                        var emptyMaxCentrals = maxCentrals.Count == 0;
                        if (emptyMaxCentrals || currentWord.subSequenses[j].Count > maxCentrals[0].Count)
                        {
                            if (!emptyMaxCentrals)//чистка листа отнимает время, чистить пустой лист сомнительная затея, нужно будет протестить на скорость
                                maxCentrals.Clear();
                            maxCentrals.Add(currentWord.subSequenses[j]);
                            MaxCountSimbolsInSeqCentral = maxCentrals[0].Count;
                        }
                        else if (currentWord.subSequenses[j].Count == maxCentrals[0].Count)
                        {
                            maxCentrals.Add(currentWord.subSequenses[j]);
                        }
                    }
                    #endregion
                }
            }

            //итоговый подсчёт
            int lastMaxCount = 0;//максимальная найденная длина последовательности
            finalMax = new List<List<Sequens>>();
            for (int i = 0; i < 26; i++)
            {
                List<Sequens> tempSeq = new List<Sequens>();
                var currSim = (char)(i + 97);
                int currCount = 0;//максимальная найденная длина последовательности
                if (MaxEndSeqDict[currSim] != null)
                {
                    currCount += MaxEndSeqDict[currSim].Count;
                    tempSeq.Add(MaxEndSeqDict[currSim]);//добавляем в результующую последовательность самую максимальную конечную в начало
                }

                foreach (var currSeq in ListSeqDict[currSim])
                {
                    currCount += currSeq.Count;
                    tempSeq.Add(currSeq);
                }

                if (MaxStartSeqDict[currSim] != null)
                {
                    currCount += MaxStartSeqDict[currSim].Count;
                    tempSeq.Add(MaxStartSeqDict[currSim]);//добавляем в результующую последовательность самую максимальную начальную в конец
                }

                if (lastMaxCount < currCount)
                {
                    MaxCountSimbolsInSeq = currCount;
                    lastMaxCount = currCount;
                    finalMax.Clear();
                    finalMax.Add(tempSeq);
                }
                else if (lastMaxCount == currCount)
                {
                    finalMax.Add(tempSeq);
                }
            }
        }

        public void Print()
        {
            var sumCountSeq = finalMax.Count + maxCentrals.Count;
            if (sumCountSeq == 0)
            {
                return;
            }
            else
            {
                if (sumCountSeq != 1 && MaxCountSimbolsInSeqCentral != MaxCountSimbolsInSeq)
                {
                    Console.WriteLine("\nСамая длинная последовательность состоит из слова:");
                }
                else
                {
                    Console.WriteLine("\nСамые длинные последовательности состоят из слов:");
                }
            }

            if (MaxCountSimbolsInSeqCentral <= MaxCountSimbolsInSeq)
            {
                foreach (var fm in finalMax)
                {                    
                    foreach (var seq in fm)
                    {
                        //Console.WriteLine("\t\'" + seq.FromWord.WordStr + "\'\t (" + seq.Str + ")");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("\n\t{0,20}\t", seq.FromWord.WordStr);
                        Console.ResetColor();
                        Console.Write("({0})", seq.Str);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\tПоследовательность состоит из символов: \'{0}\' ({1})\n", fm[0].Simbol, MaxCountSimbolsInSeq);
                    Console.ResetColor();
                }
            }

            if (MaxCountSimbolsInSeq <= MaxCountSimbolsInSeqCentral)
            {
                foreach (var centralSeq in maxCentrals)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\n\t{0}\t", centralSeq.FromWord.WordStr);
                    Console.ResetColor();
                    Console.Write("(" + centralSeq.Str + ")\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\tПоследовательность состоит из символов: \'{0}\' ({1})\n", centralSeq.Simbol, MaxCountSimbolsInSeqCentral);
                    Console.ResetColor();
                }
            }            
        }
    }
}
