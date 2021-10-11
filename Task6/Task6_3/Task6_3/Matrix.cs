using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task6_3
{
    class Matrix : IEnumerable
    {
        private double[,] _matrix;

        public double [,] _Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }

        public Matrix()
        {
            _matrix = null;
        }

        public Matrix(double value)
        {
            try
            {
                if (!double.TryParse(Convert.ToString(value), out double result))
                    throw new ArgumentException("Incorrect format of number");
                _matrix = new double[1, 1];
                _matrix[0, 0] = value;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Matrix(int n, int m)
        {
            try 
            {
                if (!int.TryParse(Convert.ToString(n), out int result1) || !int.TryParse(Convert.ToString(m), out int result2))
                    throw new ArgumentException("Incorrect format of dimension number of matrix");
                if (n <= 0 || m <= 0)
                    throw new ArgumentException("Incorrect dimension of matrix");
                _matrix = new double[n, m];
                Random random = new Random();
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j)
                    {
                        _matrix[i, j] = random.NextDouble();
                    }
                }
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Matrix(double [,] matrix)
        {
            _matrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    _matrix[i, j] = matrix[i, j];
                }
            }
        }

        class MatrixEnumerator : IEnumerator
        {
            double[,] matrix;
            int positionRow = -1;
            int positionColumn = -1;

            public MatrixEnumerator(double[,] matrix)
            {
                this.matrix = matrix;
                positionRow = matrix.GetLength(0) - 1;
                positionColumn = matrix.GetLength(1);
            }
            public object Current
            {
                get 
                {
                    if (positionRow == -1 || positionRow >= matrix.GetLength(0) || positionColumn == -1 || positionColumn >= matrix.GetLength(1))
                        throw new ArgumentException("Incorrect index of acces to matrix");
                    return matrix[positionRow, positionColumn];
                }
            }

            public bool MoveNext()
            {
                if (positionColumn > 0)
                {
                    --positionColumn;
                    return true;
                }
                else if ((positionColumn == 0) && (positionRow > 0))
                {
                    positionColumn = matrix.GetLength(1) - 1;
                    --positionRow;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                positionRow = -1;
                positionColumn = -1;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new MatrixEnumerator(_matrix);
        }
    }
}
