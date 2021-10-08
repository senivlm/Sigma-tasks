using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_2
{
    class ThreeDimensionalArray
    {
        private int m;
        public int M
        {
            get { return m; }
            set 
            {
                try
                {
                    if (!int.TryParse(Convert.ToString(value), out int result))
                        throw new FormatException("Incorrect format of dimension (m)");
                    if (value <= 0)
                        throw new ArgumentException("Incorrect value of dimension (m)");
                    m = value;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private int n;
        public int N
        {
            get { return n; }
            set
            {
                try
                {
                    if (!int.TryParse(Convert.ToString(value), out int result))
                        throw new FormatException("Incorrect format of dimension (n)");
                    if (value <= 0)
                        throw new ArgumentException("Incorrect value of dimension (n)");
                    n = value;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private int p;
        public int P
        {
            get { return p; }
            set
            {
                try
                {
                    if (!int.TryParse(Convert.ToString(value), out int result))
                        throw new FormatException("Incorrect format of dimension (p)");
                    if (value <= 0)
                        throw new ArgumentException("Incorrect value of dimension (p)");
                    p = value;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private int[,,] array;
        public int[,,] Array
        {
            get { return array; }
            set { array = value; }
        }

        private int [,] xyProjection;
        public int [,] XYProjection
        {
            get { return xyProjection; }
            set { xyProjection = value; }
        }

        private int[,] xzProjection;
        public int[,] XZProjection
        {
            get { return xzProjection; }
            set { xzProjection = value; }
        }

        private int[,] yzProjection;
        public int[,] YZProjection
        {
            get { return yzProjection; }
            set { yzProjection = value; }
        }

        public ThreeDimensionalArray()
        {
            m = 0;
            n = 0;
            p = 0;
            array = null;
        }

        public ThreeDimensionalArray(int m, int n, int p)
        {
            try
            {
                this.M = m;
                this.N = n;
                this.P = p;
                if (this.M > 0 && this.N > 0 && this.P > 0)
                {
                    array = new int[m, n, p];
                    Random random = new Random();
                    for (int i=0;i<M;++i)
                    {
                        for (int j=0;j<N;++j)
                        {
                            for (int u=0;u<P;++u)
                            {
                                if (random.Next(-100, 100) > 0)
                                    array[i, j, u] = 1;
                                else
                                    array[i, j, u] = 0;
                            }
                        }
                    }
                }
                else
                    throw new ArgumentException("Array can not be created");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public ThreeDimensionalArray(int[,,] array)
        {
            try
            {
                this.M = array.GetLength(0);
                this.N = array.GetLength(1);
                this.P = array.GetLength(2);
                if (this.M > 0 && this.N > 0 && this.P > 0)
                {
                    this.array = new int[M, N, P];
                    for (int i = 0; i < M; ++i)
                    {
                        for (int j = 0; j < N; ++j)
                        {
                            for (int u = 0; u < P; ++u)
                            {
                                if (array[i, j, u] < 0 || array[i, j, u] > 1)
                                {
                                    this.array = null;
                                    throw new ArgumentException($"Input array has incorrect values in array: {i + 1}, row: {j + 1}, column: {u + 1}");
                                }
                                else
                                    this.array[i, j, u] = array[i, j, u];
                            }
                        }
                    }
                }
                else
                    throw new ArgumentException("Array can not be created");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int[,] GetXYProjection()
        {
            XYProjection = new int[M, P];
            try
            {
                if (M <= 1 || N <= 1 || P <= 1)
                    throw new Exception("Object is not three dimensional");
                for (int i = 0; i < M; ++i)
                {
                    for (int j = 0; j < P; ++j)
                    {
                        for (int u = 0; u < N; ++u)
                        {
                            if (array[i, u, j] == 1)
                            {
                                XYProjection[i, j] = 1;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return XYProjection;
        }

        public int[,] GetXZProjection()
        {
            XZProjection = new int[N, M];
            try
            {
                if (M <= 1 || N <= 1 || P <= 1)
                    throw new Exception("Object is not three dimensional");
                for (int i = 0; i < N; ++i)
                {
                    for (int j = 0; j < M; ++j)
                    {
                        for (int u = 0; u < P; ++u)
                        {
                            if (array[j, i, u] == 1)
                            {
                                XZProjection[i, j] = 1;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return XZProjection;
        }

        public int[,] GetYZProjection()
        {
            YZProjection = new int[N, P];
            try
            {
                if (M <= 1 || N <= 1 || P <= 1)
                    throw new Exception("Object is not three dimensional");
                for (int i = 0; i < N; ++i)
                {
                    for (int j = 0; j < P; ++j)
                    {
                        for (int u = 0; u < M; ++u)
                        {
                            if (array[u, i, j] == 1)
                            {
                                YZProjection[i, j] = 1;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return YZProjection;
        }

        public string GetAllProjections()
        {
            string result = "";
            try
            {
                if (array == null)
                    throw new Exception("Array is not created");
                xyProjection = GetXYProjection();
                xzProjection = GetXZProjection();
                yzProjection = GetYZProjection();
                result = "XY Projection:\n";
                for (int i = 0; i < xyProjection.GetLength(0); ++i)
                {
                    for (int j = 0; j < xyProjection.GetLength(1); ++j)
                    {
                        result += xyProjection[i, j] + " ";
                    }
                    result += '\n';
                }
                result += "XZ Projection:\n";
                for (int i = 0; i < xzProjection.GetLength(0); ++i)
                {
                    for (int j = 0; j < xzProjection.GetLength(1); ++j)
                    {
                        result += xzProjection[i, j] + " ";
                    }
                    result += '\n';
                }
                result += "YZ Projection:\n";
                for (int i = 0; i < yzProjection.GetLength(0); ++i)
                {
                    for (int j = 0; j < yzProjection.GetLength(1); ++j)
                    {
                        result += yzProjection[i, j] + " ";
                    }
                    result += '\n';
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
