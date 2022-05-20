using System;
using System.Collections.Generic;
using System.Text;

namespace NewArrChars
{
    class Word
    {
        public string WordStr;
        public List<Sequens> subSequenses;

        public Word(string str)
        {
            WordStr = str;
            subSequenses = new List<Sequens>();
            if (string.IsNullOrEmpty(str))            
                return;
            
            if (str.Length == 1)
            {
                subSequenses.Add( new Sequens(this, str));
            }
            else
            {
                string s = str[0].ToString();

                for (int i = 0; i < str.Length - 1; i++)
                {
                    if (s[0] == str[i + 1])//следующий такой же как в собираемой подстроке
                    {
                        if (i + 2 == str.Length)
                        {
                            if (s[0] == str[i + 1])
                            {
                                subSequenses.Add(new Sequens(this, s + str[str.Length - 1].ToString()));
                            }
                            else
                            {
                                subSequenses.Add(new Sequens(this, str[str.Length - 1].ToString()));
                            }
                            break;
                        }
                        s += str[i + 1];
                    }
                    else
                    {
                        subSequenses.Add(new Sequens(this, s));
                        if (i + 2 == str.Length)
                        {
                            if (s[0] == str[i + 1])
                            {
                                subSequenses.Add(new Sequens(this, s + str[str.Length - 1].ToString()));
                            }
                            else
                            {
                                subSequenses.Add(new Sequens(this, str[str.Length - 1].ToString()));
                            }
                            break;
                        }
                        s = str[i + 1].ToString();
                    }
                }
            }
        }

        public void Print()
        {
            Console.Write(WordStr + "\t");
            foreach (var seq in subSequenses)
            {
                Console.Write("(" + seq.Str + ") ");
            }
            Console.Write("\n");
        }
    }
}
