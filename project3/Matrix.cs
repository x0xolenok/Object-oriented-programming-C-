using System;

namespace project2;

class Matrix
{
    private float[][] table;
    public Matrix(){
        table = new float[1][];
        table[0] = new float[1] {0};
    }

    public Matrix(int dRows, int dColumns){
        table = new float[dRows][];
        for (int i = 0; i < table.Length; i+=1){
            table[i] = new float[dColumns];
        }
    }

    public Matrix(float[][] sampleTable){
        int rows = sampleTable.Length;
        int columns = sampleTable[0].Length;
        table = new float[rows][];
        for (int i = 0; i < table.Length; i+=1){
            table[i] = new float[columns];
            for (int j = 0; j < table[i].Length; j+=1){
                table[i][j] = sampleTable[i][j];
            }
        }
    }

    public float[] GetRow(int rowNum){
        if (table.Length >= rowNum && rowNum >= 0){
            return table[rowNum];
        }
        else{
            throw new ArgumentException("Access denied: row not found.");
        }
    }

    public float[] GetColumn(int columnNum){
        if (table[0].Length >= columnNum && columnNum >= 0){
            float[] res = new float[table.Length];
            for (int i = 0; i < table.Length; i+=1){
                res[i] = table[i][columnNum];
            }
            return res;
        }
        else{
            throw new ArgumentException("Access denied: column not found.");
        }
    }

    public int GetRows(){
        return table.Length;
    }

    public int GetColumns(){
        return table[0].Length;
    }

    public float[][] GetMatrix(){
        return table;
    }

    ~Matrix(){
        for (int i = 0; i < table.Length; i+=1){
            if (table[i] != null){
                Array.Clear(table[i], 0, table[i].Length);
            }
        }
    }

    public override string ToString(){
        string stringValue = "";
        for (int i = 0; i < table.Length; i+=1){
            stringValue += "[";
            for (int j = 0; j < table[i].Length; j+=1){
                if (table[i][j] == (int)table[i][j]){
                    stringValue += table[i][j];
                }
                else{
                    stringValue += table[i][j].ToString("0.000");
                }
                if (j != table[i].Length - 1){
                    stringValue += ", ";
                }
            }
            stringValue += "]\n";
        }
        return stringValue;
    }

}
