using System;
using System.Collections.Generic;
using System.Text;

namespace CalculateShape
{
    //Abstract Shap class is our base class to inherit from
    abstract class Shape
    {
        //abstract function that needs to be implemented
        public abstract double Area();
    }

    class Square : Shape
    {
        private double width;
        public Square(double w)
        {
            this.width = w;
        }


        public override double Area()
        {
            double area = this.width * this.width;
            return Math.Round(area, 2);
        }
    }

    class Rectangle : Shape
    {
        private double width;
        private double height;
        public Rectangle(double d, double h)
        {
            this.width = d;
            this.height = h;
        }

        public override double Area()
        {
            double area = this.width * this.height;
            return Math.Round(area, 2);
        }
    }

    class Circle : Shape
    {
        private double diameter;
        public Circle(double d)
        {
            this.diameter = d;
        }
        public override double Area()
        {
            double area = Math.PI * (this.diameter/ 2) * (this.diameter / 2);
            return Math.Round(area, 2);
        }
    }

    class Triangle: Shape
    {
        private double width;
        private double height;
        public Triangle(double w, double h)
        {
            this.width = w;
            this.height = h;
        }

        public override double Area()
        {
            double area = (this.width * this.height) / 2;
            return Math.Round(area, 2);
        }
    }

}
