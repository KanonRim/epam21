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
            String[] line = Console.ReadLine().Split(' ');
            if (line.Length < 2)
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
        //task 2
        static void TriAngl(int n)
        {
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        //task 3
        static void AnotTriAngl(int n)
        {
            n += 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j < i * 2; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
        // tack 4 

        static void AnotTriAngl(int n, int max)
        {
            n += 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < max - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j < i * 2; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        static void Xtree(int n)
        {
            n += 1;
            for (int i = 1; i < n; i++)
            {
                AnotTriAngl(i, n);
            }

        }

        //task 5
        static void SumOfNubers()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                if (i % 2 == 0 || i % 5 == 0)
                    sum += i;
            }
            Console.WriteLine(sum);
        }


        // task 6 
        [Flags]
        enum form
        {
            None = 0,
            bold = 1,
            italic = 2,
            underline = 4,
        }
        void FontAdjusment ()
        {
            form textform = form.None;
            while (true)
            {
                Console.WriteLine("Ведите: ");
                Console.WriteLine(" 1: bold;\n 2: italic;\n 3: underline;");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        textform ^= form.bold;
                        break;
                    case 2:
                        textform ^= form.italic;
                        break;
                    case 3:
                        textform ^= form.underline;
                        break;
                }
                Console.Write("Параметры надписи: ");
                if (textform == 0)
                    Console.Write("None");
                else
                {
                    if ((textform & form.bold) == form.bold)
                    {
                        Console.Write("bold ");
                    }
                    if ((textform & form.italic) == form.italic)
                    {
                        Console.Write("italic ");
                    }
                    if ((textform & form.underline) == form.underline)
                    {
                        Console.Write("underline ");
                    }
                }
                Console.WriteLine();
            }
        }
        // Task 7

    }
}
