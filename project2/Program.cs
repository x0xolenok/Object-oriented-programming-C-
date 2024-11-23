using System;

namespace project2;
class Program
{
    static void Main(string[] args)
    {
        float[][] sampleTable = new float[1][] {
            new float[3] {3, 4, 2}
            //new float[3] {1, 2, 3},
            //new float[3] {4, 5, 6}
        };
        Matrix m1 = new Matrix(sampleTable);
        sampleTable = new float[3][] {
            new float[4] {13, 9, 7, 15},
            new float[4] {8, 7, 4, 6},
            new float[4] {6, 4, 0, 3}
            //new float[2] {7, 8},
            //new float[2] {9, 10},
            //new float[2] {11, 12}
        };
        Matrix m2 = new Matrix(sampleTable);
        Matrix m3 = new Matrix(MatrixMath.MultiplyMatrices(m1, m2).GetMatrix());
        Console.WriteLine(m3);
    }
}
