using System;
using System.Collections.Generic;
using System.Text;

namespace NewArrChars
{
    class Word
    {
        public string WordStr;
        public List<Sequence> subSequenses;

        public Word(string str)
        {
            WordStr = str;
            subSequenses = new List<Sequence>();
            if (string.IsNullOrEmpty(str))            
                return;
            
            if (str.Length == 1)
            {
                subSequenses.Add( new Sequence(this, str));
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
                                subSequenses.Add(new Sequence(this, s + str[str.Length - 1].ToString()));
                            }
                            else
                            {
                                subSequenses.Add(new Sequence(this, str[str.Length - 1].ToString()));
                            }
                            break;
                        }
                        s += str[i + 1];
                    }
                    else
                    {
                        if (subSequenses.Count == 0)
                        {
                            subSequenses.Add(new Sequence(this, s));
                        }
                        else if (subSequenses.Count > 0 && subSequenses[subSequenses.Count - 1].Count <= s.Length)
                        {
                            if (subSequenses.Count > 1)
                            {
                                subSequenses.RemoveAt(subSequenses.Count - 1);
                            }
                            if (s.Length > 1)
                            {
                                subSequenses.Add(new Sequence(this, s));
                            }
                        }
                        //subSequenses.Add(new Sequence(this, s));

                        if (i + 2 == str.Length)
                        {
                            if (s[0] == str[i + 1])
                            {
                                subSequenses.Add(new Sequence(this, s + str[str.Length - 1].ToString()));
                            }
                            else
                            {
                                subSequenses.Add(new Sequence(this, str[str.Length - 1].ToString()));
                            }
                            break;
                        }
                        s = str[i + 1].ToString();
                    }
                }
            }
        }

        public void Print(int maxLength = 50)
        {
            Console.Write("{0, "+ maxLength + "}\t", WordStr);
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var seq in subSequenses)
            {
                string s = "";
                for (int i = 0; i < seq.Count; i++)
                {
                    s += seq.Simbol;
                }
                Console.Write("({0}) ", s);
            }
            Console.ResetColor();
            Console.Write("\n");
        }
    }
}
