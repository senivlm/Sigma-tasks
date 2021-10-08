using System;

namespace Task5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = new int[3, 4, 5] { { { 0, 1, 1, 0, 0 }, { 0, 0, 0, 0, 0 }, { 1, 1, 0, 0, 0 }, { 0, 0, 0, 0, 1 } },
                                                { { 0, 0, 0, 0, 0 }, { 1, 0, 0, 1, 0 }, { 0, 0, 1, 0, 1 }, { 0, 0, 1, 0, 0 } },
                                                    { { 1, 1, 1, 0, 1 }, { 0, 1, 0, 0, 1 }, { 0, 0, 0, 0, 0 }, { 0, 1, 0, 0, 1 } }};
            ThreeDimensionalArray threeDimensionalArray = new ThreeDimensionalArray(array);
            Console.WriteLine(threeDimensionalArray.GetAllProjections());
        }
    }
}
