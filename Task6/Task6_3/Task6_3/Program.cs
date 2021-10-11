using System;

namespace Task6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] initMatrix = { { 12.71, 8.71, 3.42 }, { 14.51, 5.73, 20.12 }, { 17.83, 8.68, 9.34 }, { 2.34, 16.72, 20.79 } };
            Matrix matrix = new Matrix(initMatrix);
            foreach(var item in matrix)
            {
                Console.Write(item + " ");
            }
        }
    }
}
