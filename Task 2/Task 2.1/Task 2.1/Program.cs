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

            int tip = ConsoleHelper.IntReadParse("Введите тип фигуры",1,4);



            int x, y, r,r2;
            switch (tip)
            {               
                case (int)TypeFigure.Circle:
                    x = ConsoleHelper.IntReadParse( "Введите x кориднату центра", 0, int.MaxValue);
                    y = ConsoleHelper.IntReadParse( "Введите y кориднату центра", 0, int.MaxValue);
                    r = ConsoleHelper.IntReadParse( "Введите radius", 1, int.MaxValue);
                    listFig.Add(new Circle(new Position(x, y), r));
                    break;

                case (int)TypeFigure.Ring:
                    x = ConsoleHelper.IntReadParse("Введите x кориднату центра", 0, int.MaxValue);
                    y = ConsoleHelper.IntReadParse("Введите y кориднату центра", 0, int.MaxValue);
                    r = ConsoleHelper.IntReadParse("Введите radius внутрений", 1, int.MaxValue);
                    r2 = ConsoleHelper.IntReadParse("Введите radius внешний", 1, int.MaxValue);
                    listFig.Add(new Ring(new Position(x,y),r,r2));
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
    // task 1
    class MegaString
    {
        private char[] _ch;

        public MegaString(char[] mas)
        {
            Symbol = mas;
        }
        public MegaString(string str)
        {
            Symbol = str.ToCharArray();
        }

        public override string ToString()
        {
            return new String(_ch);
        }

        public char[] Symbol
        {
            get
            {
                return _ch;
            }
            set
            {
                _ch = value;
            }
        }

        private int lenght;

        public int Lenght
        {
            get { return _ch.Length; }
        }


        public static bool operator ==(MegaString str1, MegaString srt2)
        {
            if (str1.Lenght != srt2.Lenght)
            {
                return false;
            }
            else
            {
                return str1._ch == srt2._ch;
            }
        }
        public static bool operator !=(MegaString str1, MegaString srt2)
        {
            if (str1.Lenght == srt2.Lenght)
            {
                return false;
            }
            else
            {
                return str1._ch != srt2._ch;
            }
        }

        public static MegaString operator +(MegaString str1, MegaString str2)
        {
            return new MegaString(str1.ToString() + str2.ToString());
        }


        public int IndexOfMas(char ch)
        {
            for (int i = 0; i < Lenght; i++)
            {
                if (_ch[i] == ch)
                    return i;

            }
            return -1;

        }
        public char[] ToCharArr()
        {
            return _ch;
        }

        //new
        public MegaString ToConsoleCenter(int Width = 125)
        {
            string leftSpace = new string(' ', (Width / 2) - (Lenght / 2));
            return new MegaString(leftSpace + ToString());
        }
    }


    // task 2
    public struct Position
    {
        public int x;
        public int y;
        public Position(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    enum TypeFigure
    {
        Circle = 1,
        Ring=2,
        Rectangle=3,
        Square=4

    }
    interface IAeraing
    {
        public double S { get; }
    }
    interface IRading
    {
        public double R { get; }
    }


    public class Figure 
    {
        private Position _pos;
        
        public Position Position
        {
            get { return _pos; }
            set { _pos = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
        }


        public Figure(Position pos,string name)
        {
            _name = name;
            Position = pos;
        }
    }

    public class Circle : Figure ,IAeraing
    {
        private double _r;
        public double R
        {
            get { return _r; }
            set { _r = value; }
        }
        private double _p;

        public double P
        {
            get { return 2 * Math.PI * _r; }
        }

        private double _s;

        public double S
        {
            get { return Math.PI * _r * _r; }
        }
        public Circle(Position centr, float radius) : base(centr,"Круг")
        {
            R = radius;
            float zero = 0.000000000000001f;
            if (Math.Abs(radius) < zero)
            {
                throw new ArgumentException("Radius = 0");
            }
        }


    }

    public class Ring : Figure , IAeraing
    {
        private Circle _inner;
        private Circle _outer;
        private double _sumR;

        public double SumR
        {
            get { return _inner.R + _outer.R; }
        }
        public double S
        {
            get { return _inner.S - _outer.S; }
        }

        public Ring(Position centr, float innerR, float outerR) : base(centr,"Кольцо")
        {
            if (innerR > outerR)
            {
                throw new ArgumentException("innerR>outerR");
            }
            _inner = new Circle(centr, innerR);
            _outer = new Circle(centr, outerR);

        }


    }

    public class Rectangle : Figure, IAeraing

    {
        private double height;
        private double width;

        private double _p;

        public double P
        {
            get { return height+width; }
        }

        private double _s;

        public double S
        {
            get { return height*width; }
        }

        public Rectangle(Position pos, double height,double width) :base(pos,"Прямоугольник")
        {
            if(height==0||width==0)
                throw new ArgumentException("side==0");
            this.height = height;
            this.width = width;
        }
    }
    public class Square: Rectangle, IAeraing
    {
        public Square(Position pos, double side) : base(pos, side, side) { }
    }

}
