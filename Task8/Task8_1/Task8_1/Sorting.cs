using System;
using System.Collections.Generic;
using System.Text;

namespace Task8_1
{
    class Sorting
    {
        public delegate int SortingTwoObjects(object firstObject, object secondObject);

        private static void Swap(ref object[] objects, int i, int j)
        {
            object temp = objects[i];
            objects[i] = objects[j];
            objects[j] = temp;
        }
        public static void Sort(object[] objects, SortingTwoObjects sortingTwoObjects)
        {
            try
            {
                bool flag = false;
                for (int i = 0; i < objects.Length; ++i)
                {
                    flag = false;
                    for (int j = 0; j < objects.Length - 1; ++j)
                    {
                        if (objects[j].GetType() == objects[j + 1].GetType())
                        {
                            if (sortingTwoObjects(objects[j], objects[j + 1]) > 0)
                            {
                                Swap(ref objects, j, (j + 1));
                                flag = true;
                            }
                        }
                        else
                            throw new FormatException("Different types in array");
                    }
                    if (flag == false)
                        break;
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
