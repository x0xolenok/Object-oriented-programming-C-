using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Matrix
    {
        private double[,] data;

        private int m;
        public int M { get { return this.m; } }

        private int n;
        public int N { get { return this.n; } }

        public void setSize(int ms, int ns)
        {
            this.n = ns;
            this.m = ms;
        }
        public void ProcessFunctionOverData(Action<int, int> func)
        {
            for (var i = 0; i < this.m; i++)
            {
                for (var j = 0; j < this.n; j++)
                {
                    func(i, j);
                }
            }
        }

        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.data = new double[m, n];
            this.ProcessFunctionOverData((i, j) => this.data[i, j] = 0);
        }
        public Matrix()
        {
            this.m = 0;
            this.n = 0;
            this.data = new double[m, n];
        }
        public double this[int x, int y]
        {
            get
            {
                return this.data[x, y];
            }
            set
            {
                this.data[x, y] = value;
            }
        }

        public static Matrix operator *(Matrix matrix, double value)
        {
            var result = new Matrix(matrix.M, matrix.N);
            result.ProcessFunctionOverData((i, j) => result[i, j] = matrix[i, j] * value);
            return result;
        }
        public static Matrix operator *(Matrix matrix, Matrix matrix2)
        {
            if (matrix.N != matrix2.M)
            {
                Console.WriteLine("\n\nmatrixes can not be multiplied!!!\n\n");
                var result = new Matrix(0, 0);
                return result;
                // throw new ArgumentException("matrixes can not be multiplied");
            }
            else
            {
                var result = new Matrix(matrix.M, matrix2.N);
                result.ProcessFunctionOverData((i, j) =>
                {
                    for (var k = 0; k < matrix.N; k++)
                    {
                        result[i, j] += matrix[i, k] * matrix2[k, j];
                    }
                });
                return result;
            }
        }
        public static Matrix operator +(Matrix matrix, Matrix matrix2)
        {
            if ((matrix.N != matrix2.N) || (matrix.M != matrix2.M))
            {
                Console.WriteLine("\n\nmatrixes can not be added!!!\n\n");
                var result = new Matrix(0, 0);
                return result;
                //throw new ArgumentException("matrixes can not be added");
            }
            else
            {
                var result = new Matrix(matrix.M, matrix.N);

                for (var v = 0; v < matrix.N; v++)
                {
                    for (var k = 0; k < matrix.M; k++)
                    {
                        result[k, v] = matrix[k, v] + matrix2[k, v];
                    }
                }
                return result;
            }
        }
        public static Matrix operator -(Matrix matrix, Matrix matrix2)
        {
            if ((matrix.N != matrix2.N) || (matrix.M != matrix2.M))
            {
                Console.WriteLine("\n\nmatrixes can not be subtracted!!!\n\n");
                var result = new Matrix(0, 0);
                return result;
                //throw new ArgumentException("matrixes can not be subtracted");
            }
            else
            {
                var result = new Matrix(matrix.M, matrix.N);

                for (var v = 0; v < matrix.N; v++)
                {
                    for (var k = 0; k < matrix.M; k++)
                    {
                        result[k, v] = matrix[k, v] - matrix2[k, v];
                    }
                }

                return result;
            }
        }
        public Matrix transpose()
        {
            Matrix result = new Matrix(N, M);
            for (var v = 0; v < M; v++)
            {
                for (var k = 0; k < N; k++)
                {
                    result.data[k, v] = this.data[v, k];
                }
            }
            return result;
        }

    }

