using System;
using System.IO;

namespace lb7
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = null;
            try
            {
                Console.WriteLine("Plese type in filename: ");
                filename = Console.ReadLine();
                var matrixesList = MatrixIO.readMatrixFromXmlFile(filename);
                Console.WriteLine("Matrixes in " + filename + ": ");
                foreach (Matrix e in matrixesList)
                    Console.WriteLine(e + "\n");
                Console.WriteLine("Choose an operation: ");
                Console.WriteLine("\t1 - addition");
                Console.WriteLine("\t2 - subsctraction");
                Console.WriteLine("\t3 - multiplication");
                string choose = Console.ReadLine();
                Matrix result = matrixesList[0];
                matrixesList.Remove(result);
                switch (choose)
                {
                    case "1":
                        foreach (Matrix e in matrixesList)
                            result = result + e;
                        break;
                    case "2":
                        foreach (Matrix e in matrixesList)
                            result = result - e;
                        break;
                    case "3":
                        foreach (Matrix e in matrixesList)
                            result = result * e;
                        break;
                    default:
                        Console.WriteLine("\"" + choose + "\" is unknown command");
                        break;
                }
                MatrixIO.writeMatrixToXmlFile(result, "output.xml");
            }
            catch(FileNotFoundException)
            {
                Console.Write("File " + filename + " wasn't found.");
            }
        }

    }
}
