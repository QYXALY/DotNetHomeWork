using System;

namespace calculater
{
    class cal
    {
        static void Main(string[]args)
        {
            double a;
            double b;
            char c;
            Console.WriteLine("请输入第一个数");
            a = Double.Parse(Console.ReadLine());

            Console.WriteLine("请输入第二个数");
            b = Double.Parse(Console.ReadLine());

            Console.WriteLine("请输入运算符号");
            c =Char.Parse(Console.ReadLine());

            switch (c)
            {
                case '+':
                    Console.WriteLine(a + b);
                    break;
                case '-':
                    Console.WriteLine(a - b);
                    break;
                case '*':
                    Console.WriteLine(a * b);
                    break;
                case '/':
                    Console.WriteLine(a / b);
                    break;
                default:
                    Console.WriteLine("输入错误");
                    break;
            }
        }

    }

}