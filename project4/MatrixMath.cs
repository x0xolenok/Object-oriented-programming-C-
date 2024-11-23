using System;

namespace project4;

static class MatrixMath
{
    static public Matrix AddMatrices(Matrix m1, Matrix m2){
        if ((m1.GetRows() == m2.GetRows()) && (m1.GetColumns() == m2.GetColumns())){
            float[][] sampleTable = new float[m1.GetRows()][];
            for (int i = 0; i < sampleTable.Length; i+=1){
                sampleTable[i] = new float[m1.GetColumns()];
                for (int j = 0; j < sampleTable[i].Length; j+=1){
                    sampleTable[i][j] = m1.GetMatrix()[i][j] + m2.GetMatrix()[i][j];
                }
            }
            Matrix res = new Matrix(sampleTable);
            return res;
        }
        else{
            throw new ArgumentException("Matrices addition is impossible: dimensions are not the same.");
        }
    }

    static public Matrix SubtractMatrices(Matrix m1, Matrix m2){
        if ((m1.GetRows() == m2.GetRows()) && (m1.GetColumns() == m2.GetColumns())){
            float[][] sampleTable = new float[m1.GetRows()][];
            for (int i = 0; i < sampleTable.Length; i+=1){
                sampleTable[i] = new float[m1.GetColumns()];
                for (int j = 0; j < sampleTable[i].Length; j+=1){
                    sampleTable[i][j] = m1.GetMatrix()[i][j] - m2.GetMatrix()[i][j];
                }
            }
            Matrix res = new Matrix(sampleTable);
            return res;
        }
        else{
            throw new ArgumentException("Matrices subtraction is impossible: dimensions are not the same.");
        }
    }

    static public Matrix MultiplyMatrices(Matrix m1, Matrix m2){
        if (m1.GetColumns() == m2.GetRows()){
            float[][] sampleTable = new float[m1.GetRows()][];
            for (int i = 0; i < sampleTable.Length; i+=1){
                sampleTable[i] = new float[m2.GetColumns()];
                float[] currentRow = m1.GetRow(i);
                for (int j = 0; j < sampleTable[i].Length; j+=1){
                    float[] currentColumn = m2.GetColumn(j);
                    sampleTable[i][j] = 0;
                    for (int k = 0; k < currentRow.Length; k+=1){
                        sampleTable[i][j] += currentRow[k] * currentColumn[k];
                    }
                }
            }
            Matrix res = new Matrix(sampleTable);
            return res;
        }
        else{
            throw new ArgumentException("Matrices multiplication is impossible: dimensions are not compatible.");
        }
    }
}
