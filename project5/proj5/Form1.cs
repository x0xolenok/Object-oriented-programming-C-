using System.Data;

namespace proj5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            float[][] sampleTable = new float[3][]
            {
                new float[2] {1, 3},
                new float[2] {2, 3},
                new float[2] {1, 1}
            };
            Matrix m1 = new Matrix(sampleTable);
            for (int i = 0; i < m1.GetColumns(); i += 1)
            {
                table.Columns.Add(i + " col", typeof(float));
                //dataGridView1.Columns[i].ReadOnly = true;
            }
            for (int i = 0; i < m1.GetRows(); i += 1)
            {
                float[] currentRow = m1.GetRow(i);
                DataRow newRow = table.NewRow();
                for (int j = 0; j < currentRow.Length; j += 1)
                {
                    newRow[j + " col"] = currentRow[j];
                }
                table.Rows.Add(newRow);
            }
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.DataSource = table;
        }
    }
}
