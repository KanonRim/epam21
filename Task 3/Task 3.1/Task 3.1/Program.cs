using System;
using Task_2._1;

namespace Task_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = ConsoleHelper.IntReadParse("Введите N", 1, int.MaxValue);
            MyClosedCollection<char> person = new MyClosedCollection<char>();
            for (int i = 0; i < n; i++)
            {
                person.Add(Convert.ToChar((i + 1).ToString()));
            }

            var ie = person.GetEnumerator();
            while (person.Length>=2)
            {
                ie.MoveNext();
                ie.MoveNext();
                person.Remove( ie.Current);
                Console.WriteLine(new string (person.Mas));

            }
            
            Console.WriteLine();
        }
    }
}
