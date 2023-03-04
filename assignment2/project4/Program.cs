using System;

namespace project4
{
   class project4
    {
        static bool IsToeplitzMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (matrix[i,j] != matrix[i + 1,j + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void Main(string[]args)
        {
            Console.WriteLine("请输入矩阵的行数");
            int m = Int32.Parse(Console.ReadLine());
            Console.WriteLine("请输入矩阵的列数");
            int n = Int32.Parse(Console.ReadLine());
            int[,] matrix = new int[m,n];

            Console.WriteLine("请给矩阵赋初值");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Int32.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine(IsToeplitzMatrix(matrix));
        }

    }
}