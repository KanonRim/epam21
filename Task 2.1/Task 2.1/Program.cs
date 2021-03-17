using System;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {

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
    }

    public class Figure
    {
        private Position _pos;

        public Position Position
        {
            get { return _pos; }
            set { _pos = value; }
        }
        public Figure(Position pos)
        {
            Position = this.Position;
        }
    }

    public class Circle : Figure
    {
        private float _r;
        public float R
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
            get { return Math.PI * S * S; }
        }
        public Circle(Position centr, float radius) : base(centr)
        {
            R = radius;
            float zero = 0.000000000000001f;
            if (Math.Abs(radius) < zero)
            {
                throw new ArgumentException("Radius = 0");
            }
        }


    }

    public class Ring : Figure
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

        Ring(Position centr, float innerR, float outerR) : base(centr)
        {
            if (innerR > outerR)
            {
                throw new ArgumentException("innerR>outerR");
            }
            _inner = new Circle(centr, innerR);
            _outer = new Circle(centr, outerR);

        }


    }

    public class Rectangle :Figure

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

        public Rectangle(Position pos, double height,double width) :base(pos)
        {
            if(height==0||width==0)
                throw new ArgumentException("side==0");
            this.height = height;
            this.width = width;
        }
    }
    public class Square:Rectangle
    {
        public Square(Position pos, double side) : base(pos, side, side) { }
    }

}
