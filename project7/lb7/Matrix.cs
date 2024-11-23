using System;
using System.Collections.Generic;
using System.Text;

namespace lb7
{
    public class Matrix
    {
        private readonly int[,] _matrix;

        public Matrix(int[,] matrix)
        {
            if (matrix == null)
                throw new NullReferenceException();
            this._matrix = matrix.Clone() as int[,];
        }

        public Matrix(List<int[]> list, int maxRowLength)
        {
            _matrix = new int[list.Count, maxRowLength];
            for (var i = 0; i < list.Count; i++)
                for (int j = 0; j < list[i].Length; j++)
                    _matrix[i, j] = list[i][j];
        }

        public int[,] getArray()
        {
            return _matrix.Clone() as int[,];
        }

        public int getRowsNumber()
        {
            return _matrix.GetLength(1);
        }

        public int getColumnsNumber()
        {
            return _matrix.GetLength(0);
        }


        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2 == null || matrix1 == null)
                throw new NullReferenceException();
            if (matrix2._matrix.GetLength(0) != matrix1._matrix.GetLength(0)
                || matrix2._matrix.GetLength(1) != matrix1._matrix.GetLength(1))
                throw new ArgumentException("The matrices must be of the same size.");

            var resultMatrix = matrix1._matrix.Clone() as int[,];

            for (var i = 0; i < resultMatrix.GetLength(0); i++)
                for (var j = 0; j < resultMatrix.GetLength(1); j++)
                    resultMatrix[i, j] += matrix2._matrix[i, j];

            return new Matrix(resultMatrix);
        }


        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2 == null || matrix1 == null)
                throw new NullReferenceException();
            if (matrix2._matrix.GetLength(0) != matrix1._matrix.GetLength(0)
                || matrix2._matrix.GetLength(1) != matrix1._matrix.GetLength(1))
                throw new ArgumentException("The matrices must be of the same size.");


            var resultMatrix = matrix1._matrix.Clone() as int[,];

            for (var i = 0; i < resultMatrix.GetLength(0); i++)
                for (var j = 0; j < resultMatrix.GetLength(1); j++)
                    resultMatrix[i, j] -= matrix2._matrix[i, j];

            return new Matrix(resultMatrix);
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix2 == null || matrix1 == null)
                throw new NullReferenceException();
            if (matrix2._matrix.GetLength(0) != matrix1._matrix.GetLength(1)
                || matrix2._matrix.GetLength(1) != matrix1._matrix.GetLength(0))
                throw new ArgumentException("The number of rows of matrix 1 must" +
                                            " correspond to number of colums of matrix 2");

            var resultMatrix = new int[matrix2._matrix.GetLength(1), matrix1._matrix.GetLength(0)];
            for (var i = 0; i < resultMatrix.GetLength(0); i++)
                for (var j = 0; j < resultMatrix.GetLength(1); j++)
                    for (var n = 0; n < matrix1._matrix.GetLength(1); n++)
                        resultMatrix[i, j] += (matrix1._matrix[i, n] * matrix2._matrix[n, j]);

            return new Matrix(resultMatrix);
        }



        public override string ToString()
        {
            var result = new StringBuilder();
            for (var j = 0; j < _matrix.GetLength(0); j++)
            {
                for (var i = 0; i < _matrix.GetLength(1); i++)
                    result.Append(_matrix[j, i] + " ");
                if (j + 1 < _matrix.GetLength(0))
                    result.Append("\n");
            }

            return result.ToString();
        }
    }
}
