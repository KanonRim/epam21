using System;
using Task_2._1;

namespace Task_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = ConsoleHelper.IntReadParse("Введите N", 1, int.MaxValue);
            int round = 1;
            MyClosedCollection<String> person = new MyClosedCollection<String>();
            for (int i = 0; i < n; i++)
            {
                person.Add(((i + 1).ToString()));
            }

            Console.WriteLine((String.Join(' ',person.Mas)));

            int following = round * 2;
            while (person.Length>=2)
            {

                var ie = person.GetEnumerator();
                for (int i = 0; i < following; i++)
                {
                    ie.MoveNext();
                }
                person.Remove(ie.Current);
                following = round*2+round;
                round++;



                Console.WriteLine((String.Join(' ', person.Mas)));
            }
            Console.WriteLine();
        }


    }
}
