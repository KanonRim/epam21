using System;
using System.Collections.Generic;

namespace Task_2._1
{
    class Program
    {
        static List<Figure> listFig = new List<Figure>();
        static void Main(string[] args)
        {
            do
            {
                int answer = ConsoleHelper.IntReadParse("\nВыбирете действие\n" +
                    "1.Добавить фигуру\n" +
                    "2.Вывести фигуры\n" +
                    "3.Очистить холст\n" +
                    "4.Выход", 1, 4);
                if (answer == 4) break;
                switch (answer)
                {
                    case 1:
                        AddFigure();
                        break;
                    case 2:
                        PritFig();
                        break;
                    case 3:
                        listFig.Clear();
                        break;
                    default:

                        break;
                }

            } while (true);


        }

        public static void PritFig()
        {
            foreach (var item in listFig)
            {
                Console.WriteLine(item.Name);
            }
        }
        public static void AddFigure()
        {
            Console.WriteLine(@"
        Circle = 1,
        Ring=2,
        Rectangle=3,
        Square=4");

                        int tip = ConsoleHelper.IntReadParse("Введите тип фигуры", 1, 4);

            int x, y, r, r2;
            switch (tip)
            {
                case (int)TypeFigure.Circle:
                    x = ConsoleHelper.IntReadParse("Введите x кориднату центра", 0, int.MaxValue);
                    y = ConsoleHelper.IntReadParse("Введите y кориднату центра", 0, int.MaxValue);
                    r = ConsoleHelper.IntReadParse("Введите radius", 1, int.MaxValue);
                    listFig.Add(new Circle(new Position(x, y), r));
                    break;

                case (int)TypeFigure.Ring:
                    x = ConsoleHelper.IntReadParse("Введите x кориднату центра", 0, int.MaxValue);
                    y = ConsoleHelper.IntReadParse("Введите y кориднату центра", 0, int.MaxValue);
                    r = ConsoleHelper.IntReadParse("Введите radius внутрений", 1, int.MaxValue);
                    r2 = ConsoleHelper.IntReadParse("Введите radius внешний", 1, int.MaxValue);
                    listFig.Add(new Ring(new Position(x, y), r, r2));
                    break;

                case (int)TypeFigure.Rectangle:
                    x = ConsoleHelper.IntReadParse("Введите x кориднату центра", 0, int.MaxValue);
                    y = ConsoleHelper.IntReadParse("Введите y кориднату центра", 0, int.MaxValue);
                    r = ConsoleHelper.IntReadParse("Введите высоту", 1, int.MaxValue);
                    r2 = ConsoleHelper.IntReadParse("Введите длинну", 1, int.MaxValue);
                    listFig.Add(new Rectangle(new Position(x, y), r, r2));
                    break;

                case (int)TypeFigure.Square:
                    x = ConsoleHelper.IntReadParse("Введите x кориднату центра", 0, int.MaxValue);
                    y = ConsoleHelper.IntReadParse("Введите y кориднату центра", 0, int.MaxValue);
                    r = ConsoleHelper.IntReadParse("Введите сторону", 1, int.MaxValue);
                    listFig.Add(new Square(new Position(x, y), r));
                    break;

                default:
                    break;
            }
        }
    }


    // task 2
    public struct Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    enum TypeFigure
    {
        Circle = 1,
        Ring = 2,
        Rectangle = 3,
        Square = 4

    }
    interface IAeraing
    {
        public double S { get; }
    }
    interface IRading
    {
        public double R { get; }
    }

}
