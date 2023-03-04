using System;

namespace project1
{
    class project1
    {
        static bool isPrime(int a) //判断素数
        {
            bool flag = true;
            for (int i = 2; i < a; i++)
            {
                if (a % i == 0)
                    flag = false;
            }

            return flag;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数");
            int a = Int32.Parse(Console.ReadLine());
            for (int i = 2; i <= a; i++)
            {
                if (a % i == 0 && isPrime(i))
                    Console.Write(i + " ");
            }
        }
    }
}