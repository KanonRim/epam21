﻿using System;
using System.Text;

namespace task1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            
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

        static int LOWERCASE(string str)
        {
            int lower = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i]==' ' && char.IsLower(str[i+1]))
                {
                    lower++;
                }
            }
            return lower;
        }
        static string VALIDATOR(string str)
        {
            StringBuilder newStr =new StringBuilder( str);
            newStr[0] = char.ToUpper(newStr[0]);
            for (int i = 0; i < newStr.Length-2; i++)
            {
                
                if ((newStr[i] =='.' || newStr[i] == '?' || newStr[i] == '!') && newStr[i+1] == ' ')
                {
                        newStr[i + 2] = char.ToUpper(newStr[i + 2]);
                }
            }
            return newStr.ToString();

        }
    }
}
