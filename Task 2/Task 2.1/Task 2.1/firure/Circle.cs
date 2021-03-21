using System;

namespace Task_2._1
{
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

}
