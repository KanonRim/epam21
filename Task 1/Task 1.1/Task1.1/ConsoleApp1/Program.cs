using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        //task 1
        static void AeraRec()
        {
            float a;
            float b;
            Console.WriteLine("Get arguments");
            String[] line =Console.ReadLine().Split(' ');
            if (line.Length<2)
            {
                Console.WriteLine("need more arguments");
                return; 
            }
            if (float.TryParse(line[0], out a) && float.TryParse(line[1], out b))
            {
                if (a >= 0 && b >= 0)
                {
                    Console.WriteLine("P=" + a * b);                
                }
                else
                {
                    Console.WriteLine("arg <= 0");
                    return;
                }
            }

        }
    }
}
