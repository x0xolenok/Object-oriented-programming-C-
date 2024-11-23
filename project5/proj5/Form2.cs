using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proj5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("You have not entered the matrix yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    float[][] sampleTable = new float[dataGridView1.Rows.Count][];
                    for (int i = 0; i < dataGridView1.Rows.Count; i += 1)
                    {
                        sampleTable[i] = new float[dataGridView1.Columns.Count];
                        for (int j = 0; j < dataGridView1.Columns.Count; j += 1)
                        {
                            sampleTable[i][j] = Convert.ToSingle(dataGridView1.Rows[i].Cells[j].Value);
                        }
                    }
                    Matrix m1 = new Matrix(sampleTable);
                    MessageBox.Show("The matrix entered: \n" + m1, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Incorrect value in the matrix was detected.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int rows = Convert.ToInt32(textBox1.Text);
                int columns = Convert.ToInt32(textBox2.Text);
                float[][] sampleTable = new float[rows][];
                for (int i = 0; i < sampleTable.Length; i += 1)
                {
                    sampleTable[i] = new float[columns];
                    for (int j = 0; j < sampleTable[i].Length; j += 1)
                    {
                        sampleTable[i][j] = 0;
                    }
                }
                DataTable table = new DataTable();
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
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToResizeRows = false;
                dataGridView1.AllowUserToResizeColumns = false;
                dataGridView1.DataSource = table;
                MessageBox.Show("You can now fill out the matrix.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Dimensions are incorrect.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
