using System;

namespace project1
{
    abstract class Polygon
    {
        public abstract double GetArea();//计算面积
        public abstract bool IsLegal(); //判断是否合法
    }

    class Triangle : Polygon //三角形
    {
        //三角形的三边
        private double edge1;
        private double edge2;
        private double edge3;

        public Triangle(double a, double b, double c) //构造函数
        {
                edge1 = a; edge2 = b; edge3 = c;
        }
        public override bool IsLegal() 
        {
            double a = edge1;
            double b = edge2;
            double c = edge3;
            return !(a + b <= c || a + c <= b || b + c <= a || a <= 0 || b <= 0 || c <= 0);
        }
        public override double GetArea() //根据三边计算面积
        {
            if(IsLegal())
            {
                double p = (edge1 + edge2 + edge3) / 2;
                return Math.Sqrt(p * (p - edge1) * (p - edge2) * (p - edge3));
            }
            else
            {
                Console.WriteLine("该三角形不合法");
                return -1;
            }

        }

        public double Edge1
        {
            get { return edge1; }
            set {edge1 = value;}
        }
        public double Edge2
        {
            get { return edge2; }
            set {edge2 = value;}
        }
        public double Edge3
        {
            get { return edge3; }
            set{edge3 = value;}
        }
    }

    class Rectangle:Polygon  //长方形
    {
        private double length;
        private double width;

        public Rectangle() { }
        public Rectangle(double length, double width)
        {
                this.length = length;
                this.width = width;
        }

        public override bool IsLegal()
        {
            return !(length <= 0 || width <= 0);
        }

        public override double GetArea()
        {
            if(IsLegal())
            {
                return length * width;
            }
            else
            {
                Console.WriteLine("该长方形不合法");
                return -1;
            }
        }

       public double Length
        {
            get { return length; }
            set { length = value;}
        }

        public double Width
        {
            get { return width; }
            set{width = value;}
        }
    }

    class Square :Rectangle  //正方形
    {
         public Square(double a) :base(a, a) { }
         public double Edge
        {
            get { return Length; }
            set 
            { 
                Length = value;
                Width = value;
            }
        }
    }


    class test
    {
        static void Main(String[]args)
        {
            Console.WriteLine("创建一个三角形，边长为3,4,5");
            Triangle tri = new Triangle(3,4,5);
            Console.WriteLine("面积为:" + tri.GetArea());

            Console.WriteLine("创建一个长方形，长为4，宽为5");
            Rectangle rec = new Rectangle(4, 5);
            Console.WriteLine("面积为:" + rec.GetArea());

            Console.WriteLine("创建一个正方形，边长为5");
            Square sq = new Square(5);
            Console.WriteLine("面积为:"+sq.GetArea());
        }
    }
}