using System;
using System.Globalization;

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
        };
        Matrix m2 = new Matrix(sampleTable);
        Matrix m3 = new Matrix(MatrixMath.MultiplyMatrices(m1, m2).GetMatrix());
        Console.WriteLine(m1);
        Console.WriteLine(m2);
        Console.WriteLine(m3);
        Console.WriteLine("Enter the dimensions of the matrix:\nrows:");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("columns:");
        int y = Convert.ToInt32(Console.ReadLine());
        sampleTable = new float[x][];
        for (int i = 0; i < sampleTable.Length; i+=1){
            sampleTable[i] = new float[y];
            Console.WriteLine("Enter the #" + i + " row:");
            for (int j = 0; j < sampleTable[i].Length; j+=1){
                Console.WriteLine("cell [" + i + "][" + j + "]:");
                sampleTable[i][j] = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);
            }
        }
        Matrix m4 = new Matrix(sampleTable);
        Console.WriteLine("the resulting matrix:\n" + m4);
    }
}
