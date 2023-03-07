using System;

namespace project2
{
    class project2
    {
        static void Main(string[]args)
        {
            Console.WriteLine("请输入数组长度");
            int n = Int32.Parse(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine("请给数组赋初值");
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = Int32.Parse(Console.ReadLine());
            }
            int max = arr[0];
            int min = arr[0];
            double sum = 0;
            double average = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if (arr[i] > max)
                    max= arr[i];
                if(arr[i] < min)
                    min= arr[i];
            }
            average = sum / n;

            Console.WriteLine($"该数组的最大值为{max},最小值为{min},平均值为{average},所有元素之和为{sum}");
        }

    }
}