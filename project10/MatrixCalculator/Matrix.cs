﻿using System;

namespace MatrixCalculator
{
    public class Matrix
    {
        private readonly double[,] _array2D;

        public int RowsNum => _array2D.GetLength(0);
        public int ColumnsNum => _array2D.GetLength(1);

        public double this[int i, int j]
        {
            get { return _array2D[i, j]; }
            set { _array2D[i, j] = value; }
        }

        public Matrix(int n, int m)
        {
            _array2D = new double[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    _array2D[i, j] = 0;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.RowsNum == b.RowsNum && a.ColumnsNum == b.ColumnsNum)
            {
                Matrix result = new Matrix(a.RowsNum, a.ColumnsNum);
                for (int i = 0; i < a.RowsNum; i++)
                    for (int j = 0; j < a.ColumnsNum; j++)
                        result[i, j] = a[i, j] + b[i, j];
                return result;
            }
            else
            {
                throw new Exception("Размеры матриц не совпадают.");
            }
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.RowsNum == b.RowsNum && a.ColumnsNum == b.ColumnsNum)
            {
                Matrix result = new Matrix(a.RowsNum, a.ColumnsNum);
                for (int i = 0; i < a.RowsNum; i++)
                    for (int j = 0; j < a.ColumnsNum; j++)
                        result[i, j] = a[i, j] - b[i, j];
                return result;
            }
            else
            {
                throw new Exception("Размеры матриц не совпадают.");
            }
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.ColumnsNum == b.RowsNum)
            {
                Matrix result = new Matrix(a.RowsNum, b.ColumnsNum);
                for (int i = 0; i < a.RowsNum; i++)
                    for (int j = 0; j < b.ColumnsNum; j++)
                        for (int k = 0; k < a.ColumnsNum; k++)
                            result[i, j] += a[i, k] * b[k, j];
                return result;
            }
            else
            {
                throw new Exception("Количество столбцов первой матрицы не равно количеству строк второй.");
            }
        }

        public Matrix Transpose()
        {
            Matrix result = new Matrix(ColumnsNum, RowsNum);
            for (int i = 0; i < result.RowsNum; i++)
                for (int j = 0; j < result.ColumnsNum; j++)
                    result[i, j] = this[j, i];
            return result;
        }
    }
}
