using System;

namespace Task_2._1
{
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

}
