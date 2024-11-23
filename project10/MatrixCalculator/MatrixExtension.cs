using System.Data;

namespace MatrixCalculator
{
    public static class MatrixExtensions
    {
        public static DataTable ToDataTable(this Matrix matrix)
        {
            DataTable table = new DataTable();
            for (int i = 0; i < matrix.ColumnsNum; i++)
                table.Columns.Add();
            for (int i = 0; i < matrix.RowsNum; i++)
            {
                var row = table.NewRow();
                for (int j = 0; j < matrix.ColumnsNum; j++)
                    row[j] = matrix[i, j];
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
