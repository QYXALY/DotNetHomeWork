using System;

namespace project2
{
    public interface IShape
    {
        double GetArea();
    }

    class Triangle:IShape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public double GetArea() 
        {
            return 0.5*Base*Height;
        }
    }

    class Rectangle:IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public double GetArea()
        {
            return Length * Width;
        }
    }
    class Square : IShape  //正方形
    {
        public double Edge { get; set; }

        public double GetArea()
        {
            return Edge*Edge;
        }
    }

    public class ShapeFactory
    {
        public static IShape GetShape(string name)
        {
            switch(name.ToLower()) //忽略大小写
            {
                case "triangle":
                    Triangle tri= new Triangle();
                    tri.Height=new Random().NextDouble()*10;
                    tri.Base= new Random().NextDouble() * 10;
                    return tri;
                case "rectangle":
                    Rectangle rect= new Rectangle();
                    rect.Width=new Random().NextDouble()*10;
                    rect.Length = new Random().NextDouble() * 10;
                    return rect;
                case "square":
                    Square squ= new Square();
                    squ.Edge= new Random().NextDouble() * 10;
                    return squ;
                default:
                    return null;
            }
        }


        class Test
        {
            public static void Main(string[]args)
            {
                double sum = 0;

                string[] type = { "triangle", "rectangle", "square" };
                for(int i=0;i<10;i++)
                {
                    int a=new Random().Next(0, 3);
                    sum+= ShapeFactory.GetShape(type[a]).GetArea();
                }

                Console.WriteLine("面积之和为："+sum);
            }
        }
    }
}