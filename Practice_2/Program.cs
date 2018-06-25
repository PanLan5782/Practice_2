using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");

            string q = sr.ReadLine();

            string text = sr.ReadToEnd();

            int j = 0;
            int i = 0;
            int start = -1;

            while (i < text.Length)
            {
                if (char.ToLower(text[i]) == char.ToLower(q[j]) && !IsSpace(text[i]))
                {
                    j++;
                    if (start == -1)
                        start = i;
                }
                else if (IsSpace(text[i])
                    && IsSpace(q[j]))
                {
                    while (i < text.Length && IsSpace(text[i]))
                        i++;
                    while (j < q.Length && IsSpace(q[j]))
                        j++;
                    i--;
                }
                else
                {
                    j = 0;
                    if (start != -1)
                        i--;
                    start = -1;

                }

                if (j == q.Length)
                {
                    text = text.Insert(start, "@");
                    i++;
                    j = 0;
                    start = -1;
                }
                i++;
            }

            sw.Write(text);
            sr.Close();
            sw.Close();
        }

        private static bool IsSpace(char ch)
        {
            return (ch == '\t' || ch == '\n' || ch == '\r' || ch == ' ');
        }
    }
}
