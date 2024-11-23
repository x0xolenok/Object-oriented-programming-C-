using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj5
{
    internal class Matrix
    {
        private float[][] table;
        public Matrix()
        {
            table = new float[1][];
            table[0] = new float[1] { 0 };
        }

        public Matrix(int dRows, int dColumns)
        {
            table = new float[dRows][];
            for (int i = 0; i < table.Length; i += 1)
            {
                table[i] = new float[dColumns];
            }
        }

        public Matrix(float[][] sampleTable)
        {
            int rows = sampleTable.Length;
            int columns = sampleTable[0].Length;
            table = new float[rows][];
            for (int i = 0; i < table.Length; i += 1)
            {
                table[i] = new float[columns];
                for (int j = 0; j < table[i].Length; j += 1)
                {
                    table[i][j] = sampleTable[i][j];
                }
            }
        }

        public Matrix(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                throw new ArgumentException("Error: file can't be accessed or doesn't exist.");
            }
            int rowsAmount = System.IO.File.ReadLines(filePath).Count();
            table = new float[rowsAmount][];
            int counter = 0;
            foreach (string line in System.IO.File.ReadLines(filePath))
            {
                if (line.Length != 0)
                {
                    if (!(line[0] == '[' && line[line.Length - 1] == ']'))
                    {
                        throw new FormatException("Error: incorrect data format in the file.");
                    }
                    string numStr = "";
                    table[counter] = new float[line.Split(',').Length];
                    int internalCounter = 0;
                    for (int i = 1; i < line.Length - 1; i += 1)
                    {
                        if (line[i].ToString() + line[i + 1] != ", ")
                        {
                            numStr += line[i];
                        }
                        else
                        {
                            try
                            {
                                float num = float.Parse(numStr, CultureInfo.InvariantCulture.NumberFormat);
                                table[counter][internalCounter] = num;
                                numStr = "";
                                internalCounter += 1;
                            }
                            catch (Exception)
                            {
                                throw new FormatException("Error: incorrect data format in the file.");
                            }
                        }
                    }
                    try
                    {
                        float lastParse = float.Parse(numStr, CultureInfo.InvariantCulture.NumberFormat); ;
                        table[counter][internalCounter] = lastParse;
                    }
                    catch (Exception)
                    {
                        throw new FormatException("Error: incorrect data format in the file.");
                    }
                    counter += 1;
                }
            }
        }

        public bool WriteToFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                throw new ArgumentException("Error: file can't be accessed or doesn't exist.");
            }
            if (table == null)
            {
                return false;
            }
            using (StreamWriter sw = File.AppendText(filePath))
            {
                for (int i = 0; i < table.Length; i += 1)
                {
                    sw.Write("[");
                    for (int j = 0; j < table[i].Length; j += 1)
                    {
                        if (j != table[i].Length - 1)
                        {
                            sw.Write(table[i][j] + ", ");
                        }
                        else
                        {
                            sw.WriteLine(table[i][j] + "]");
                        }
                    }
                }
            }
            return true;
        }

        public float[] GetRow(int rowNum)
        {
            if (table.Length >= rowNum && rowNum >= 0)
            {
                return table[rowNum];
            }
            else
            {
                throw new ArgumentException("Access denied: row not found.");
            }
        }

        public float[] GetColumn(int columnNum)
        {
            if (table[0].Length >= columnNum && columnNum >= 0)
            {
                float[] res = new float[table.Length];
                for (int i = 0; i < table.Length; i += 1)
                {
                    res[i] = table[i][columnNum];
                }
                return res;
            }
            else
            {
                throw new ArgumentException("Access denied: column not found.");
            }
        }

        public int GetRows()
        {
            return table.Length;
        }

        public int GetColumns()
        {
            return table[0].Length;
        }

        public float[][] GetMatrix()
        {
            return table;
        }

        ~Matrix()
        {
            for (int i = 0; i < table.Length; i += 1)
            {
                if (table[i] != null)
                {
                    Array.Clear(table[i], 0, table[i].Length);
                }
            }
        }

        public override string ToString()
        {
            string stringValue = "";
            for (int i = 0; i < table.Length; i += 1)
            {
                stringValue += "[";
                for (int j = 0; j < table[i].Length; j += 1)
                {
                    if (table[i][j] == (int)table[i][j])
                    {
                        stringValue += table[i][j];
                    }
                    else
                    {
                        stringValue += table[i][j].ToString("0.000");
                    }
                    if (j != table[i].Length - 1)
                    {
                        stringValue += ", ";
                    }
                }
                stringValue += "]\n";
            }
            return stringValue;
        }

    }
}
