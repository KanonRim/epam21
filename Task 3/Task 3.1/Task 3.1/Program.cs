using System;
using System.Collections;
using System.Collections.Generic;
using Task_2._1;

namespace Task_3._1
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = ConsoleHelper.IntReadParse("Введите N", 1, int.MaxValue);
            string[] person = GeneratorNumberChar(n);
            Console.WriteLine("Сгенерирован круг людей. Начинаем вычеркивать каждого второго.");
            int round = 0;
            for (int i = 1; person.Length >= 2;)
            {
                person = Remove(person, i);
                i += 1;
                if (i >= person.Length)
                    i -= person.Length;
                round++;
                Console.WriteLine($"Раунд {round}. Вычеркнут человек. Людей осталось: {person.Length}");
                Console.WriteLine(string.Join( ' ',person));
            }
            Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");

        }

        static string[] GeneratorNumberChar(int max)
        {
            string[] c = new string[max];
            for (int i = 0; i < max; i++)
            {
                c[i]= Convert.ToString(i+1);
            }
            return c;

        }
        static string[] Remove(string[] oldChar, int remove)
        {
            if (remove > oldChar.Length)
                throw new IndexOutOfRangeException("remove > oldChar.Length");
            string[] newChar = new string[oldChar.Length - 1];
            for (int i = 0; i < newChar.Length; i++)
            {
                if (i < remove)
                {
                    newChar[i] = oldChar[i];
                }
                else
                {
                    newChar[i] = oldChar[i + 1];
                }
            }
            return newChar;
        }

    }


}