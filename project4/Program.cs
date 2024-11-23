using System;

namespace project4;
class Program
{
    static void Main(string[] args)
    {
        Matrix m1 = new Matrix("matrix.txt");
        Console.WriteLine(m1);
        m1.WriteToFile("output.txt");
    }
}
