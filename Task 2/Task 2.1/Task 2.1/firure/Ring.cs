using System;

namespace Task_2._1
{
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

}
