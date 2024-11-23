using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using static System.Xml.Linq.XElement;
using System.Xml.Linq;
using System.Xml;

namespace lb7
{
    public class MatrixIO
    {
        private static Matrix readMatrixFromString(string input)
        {
            var rowsArr = input.Split("\n");
            var maxRowLength = 0;
            string[] inputArr;
            var list = new List<int[]>();
            try
            {
                for (int i = 0; i < rowsArr.Length; i++)
                {
                    if (rowsArr[i] != "")
                    {
                        inputArr = rowsArr[i].Split(" ");
                        if (maxRowLength != 0)
                        {
                            if (inputArr.Length <= maxRowLength)
                            {
                                list.Add(Array.ConvertAll(inputArr, int.Parse));
                            }
                            else
                            {
                                Console.WriteLine("Max row length for your matrix is " + maxRowLength);
                            }
                        }
                        else
                        {
                            maxRowLength = inputArr.Length;
                            list.Add(Array.ConvertAll(inputArr, int.Parse));
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Not valid input. Plese type in only integers.");
                Console.WriteLine("Please try again:");
            }
            return new Matrix(list, maxRowLength);
        }

        public static Matrix readMatrixFromConsole()
        {
            var list = new List<int[]>();
            string input = " ";
            var maxRowLength = 0;
            var stringBuilder = new StringBuilder();
            while (!(input.Equals("")))
            {
                input = Console.ReadLine();
                if (input != "")
                {
                    if (maxRowLength != 0)
                    {
                        if (input.Length <= maxRowLength)
                        {
                            stringBuilder.Append(input + "\n");
                        }
                        else
                        {
                            Console.WriteLine("Max row length for your matrix is " + maxRowLength);
                        }
                    }
                    else
                    {
                        maxRowLength = input.Length;
                        stringBuilder.Append(input + "\n");
                    }
                }
            }

            return readMatrixFromString(stringBuilder.ToString());
        }



        public static List<Matrix> readMatrixFromFile(string filename)
        {
            String inputFile = File.ReadAllText(filename);
            var allMatrixesString = inputFile.Split("\n\n");
            var matrixesList = new List<Matrix>();
            for (int j = 0; j < allMatrixesString.Length; j++)
            {
                matrixesList.Add(readMatrixFromString(allMatrixesString[j]));
            }

            return matrixesList;


        }
        public static void writeMatrixToFile(Matrix matrix, string filename)
        {
            if (File.ReadAllText(filename) == "")
            {
                File.WriteAllText(filename, matrix.ToString());
            }
            else
            {
                File.AppendAllText("output.txt", "\n\n" + matrix);
            }

        }

        public static List<Matrix> readMatrixFromXmlFile(string filename)
        {
            System.Xml.Linq.XElement xml =
                      System.Xml.Linq.XElement.Load(filename);
            var matrixesList = new List<Matrix>();

            foreach (var matrixXml in xml.Elements()) {
                List<int[]> matrixList = new List<int[]>();
                foreach (var row in matrixXml.Elements()){
                    int[] rowArr = new int[row.Elements("el").Count()];
                    int i = 0;
                    foreach (var el in row.Elements())
                    {
                        rowArr[i] = Convert.ToInt32(el.Value);
                        i++;
                    }
                    matrixList.Add(rowArr);
                }
                var matrix = new Matrix(matrixList, matrixList[0].Length);
                matrixesList.Add(matrix);
            }


            return matrixesList;


        }
        public static void writeMatrixToXmlFile(Matrix matrix, string filename)
        {
            XDocument document =
                new XDocument(new XDeclaration("1.0", "UTF-8", null));
            var root = new XElement("root");
            var matrixEl = new XElement("matrix");
            root.Add(matrixEl);
            document.Add(root);

            int[,] matrixArr = matrix.getArray();

            for (int i = 0; i < matrixArr.GetLength(0); i++){
                var rowEl = new XElement("row");
                for (int j = 0; j < matrixArr.GetLength(1); j++)
                {
                    var elEl = new XElement("el");
                    elEl.Add(matrixArr[i, j]);
                    rowEl.Add(elEl);
                }

                matrixEl.Add(rowEl);
            }



            var sw = new StringWriter();
            XmlWriter xWrite = XmlWriter.Create(sw);
            document.Save(xWrite);
            xWrite.Close();

            document.Save(filename);


        }
    }

}
