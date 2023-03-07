using System;

namespace project3
{
    class project3
    {
        static void Main(string[]args)
        {
            int[] arr = new int[99];
            for(int i = 0; i < arr.Length; i++)//初始化数组
            {
                arr[i] = i+2;
            }

            for(int i = 2; i <=100; i++)
            {
                for(int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] % i == 0 && arr[j]!=i)
                        arr[j] = 0;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]!=0)
                {
                    Console.Write(arr[i]+" ");
                }
            }
        }
    }
}