using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Xtree(30);
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
                    Console.ForegroundColor = (ConsoleColor)(i*j%15+1);
                    Console.Write("*");
                }

                Console.WriteLine();

            }
            Console.ResetColor();
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
        static void FontAdjusment()
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

        static int[] ArrProc(int min, int max)
        {
            Random Rand = new Random();
            int[] mas = new int[20];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = Rand.Next(min, max);
            }
            int buf;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        buf = mas[i];
                        mas[i] = mas[j];
                        mas[j] = buf;
                    }
                }
                Console.WriteLine(mas[i]);
            }



            return mas;
        }
        // Task 8

        static int[,,] NoPosit(int[,,] mas)

        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    for (int n = 0; n < mas.GetLength(2); n++)
                    {
                        if (mas[i, j, n] > 0)
                            mas[i, j, n] = 0;
                    }
                }
            }

            return mas;
        }
        //task  9
        static int NONNEGATIVESUM(int[] mas)
        {
            int sum=0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 0)
                {
                    sum += mas[i];
                }

            }
            return sum;
        }

        //task 10
        static int Sum2dArr(int[,] mas)
        {
            int sum = 0;
            for (int i = 1; i < mas.GetLength(0); i++)
            {
                for (int j = 1; j < mas.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += mas[i, j];
                    }
                }
            }
            return sum;
        }
    }
}
