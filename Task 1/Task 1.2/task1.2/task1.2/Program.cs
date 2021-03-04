using System;
using System.Text;

namespace task1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( DOUBLER("написать программу, которая", "описание"));
        }

        static float Averages(string str)
        {
            float divider = 1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    divider++;
                }
            }
            return (str.Length - (divider - 1)) / divider;
        }

        static string DOUBLER(string str,string doubl)
        {
            StringBuilder newStr = new StringBuilder();
            newStr.Append(str);
            
            for (int i = 0; i < newStr.Length; i++)
            {
                if(doubl.IndexOf (newStr[i]) != -1)
                {
                    newStr.Insert(i + 1, newStr[i]);
                    i++;
                }
            }
            return newStr.ToString();
        }

    }
}
