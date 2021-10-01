using System;

namespace MagicSquare
{
    class Program
    {
        static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write(String.Format("{0,-3}", matrix[i, j]));
                }
                Console.WriteLine();
            }
        }
        static void FillMatrix(ref int[,] matrix, int size, ref int[,] magicSquare)
        {
            int value = 1;
            for (int z = (size - 1), v = 0; z < (2 * size - 1); ++z, ++v)
            {
                for (int i = z, j = v; i >= v; --i, ++j)
                {
                    matrix[i, j] = value;
                    ++value;
                }
            }

            int temp = 0;
            for (int i = 0; i < (matrix.GetLength(0) - size) / 2; ++i)
            {
                for (int j = 0; j < matrix.GetLength(0); ++j)
                {
                    if (matrix[i, j] != 0)
                    {
                        temp = matrix[i, j];
                        matrix[i, j] = 0;
                        matrix[i + size, j] = temp;
                    }
                }
            }
            temp = 0;
            for (int i = matrix.GetLength(0) - 1; i >= (matrix.GetLength(0) - size/2); --i)
            {
                for (int j = 0; j < matrix.GetLength(0); ++j)
                {
                    if (matrix[i, j] != 0)
                    {
                        temp = matrix[i, j];
                        matrix[i, j] = 0;
                        matrix[i - size, j] = temp;
                    }
                }
            }
            temp = 0;
            for (int i = 0; i < (matrix.GetLength(0) - size) / 2; ++i)
            {
                for (int j = 0; j < matrix.GetLength(0); ++j)
                {
                    if (matrix[j, i] != 0)
                    {
                        temp = matrix[j, i];
                        matrix[j, i] = 0;
                        matrix[j, i + size] = temp;
                    }
                }
            }
            temp = 0;
            for (int i = matrix.GetLength(0) - 1; i >= (matrix.GetLength(0) - size / 2); --i)
            {
                for (int j = 0; j < matrix.GetLength(0); ++j)
                {
                    if (matrix[j, i] != 0)
                    {
                        temp = matrix[j, i];
                        matrix[j, i] = 0;
                        matrix[j, i - size] = temp;
                    }
                }
            }
            int k = 0;
            for (int i = 0, v = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(0); ++j)
                {
                    if (matrix[i,j]!=0)
                    {
                        magicSquare[v, k] = matrix[i, j];
                        ++k;
                    }
                }
                if (k > 0)
                {
                    ++v;
                    k = 0;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of square:");
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[(2 * size - 1), (2 * size - 1)];
            int[,] magicSquare = new int[size, size];
            FillMatrix(ref matrix, size, ref magicSquare);
            Print(magicSquare);
        }
    }
}
