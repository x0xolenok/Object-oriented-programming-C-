using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixApp
{
    public partial class Form1 : Form
    {
        int m, n, m1, n1;
        int isClear = 1;
        int isClear2 = 1;
        Matrix matr = new Matrix();
        Matrix matr2 = new Matrix();
        Matrix result = new Matrix();
        Matrix result2 = new Matrix();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m = Convert.ToInt32(textBox1.Text);
            n = Convert.ToInt32(textBox2.Text);
            if (isClear == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Columns.Add("c" + Convert.ToString(i), " ");
                }
                for (int i = 0; i < m; i++)
                {
                    dataGridView1.Rows.Add();
                }
                isClear = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            m1 = Convert.ToInt32(textBox3.Text);
            n1 = Convert.ToInt32(textBox4.Text);
            if (isClear2 == 1)
            {
                for (int i = 0; i < n1; i++)
                {
                    dataGridView2.Columns.Add("c" + Convert.ToString(i), " ");
                }
                for (int i = 0; i < m1; i++)
                {
                    dataGridView2.Rows.Add();
                }
                isClear2 = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            isClear2 = 1;
            m1 = 0;
            n1 = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            matr2 = new Matrix(m1, n1);
            for (int i = 0; i < m1; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    matr2[i, j] = Convert.ToDouble(dataGridView2[j, i].Value);
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            result = new Matrix(n, m);
            result = matr + matr2;
            for (int i = 0; i < result.N; i++)
            {
                dataGridView3.Columns.Add("c" + Convert.ToString(i), " ");
            }
            for (int i = 0; i < result.M; i++)
            {
                dataGridView3.Rows.Add();
            }
            for (int k = 0; k < result.M; k++)
            {
                for (int l = 0; l < result.N; l++)
                {
                    dataGridView3[l, k].Value = result[k, l];
                }
            }
        }

        private void subtract1()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            result = new Matrix(n, m);
            result = matr - matr2;
            for (int i = 0; i < result.N; i++)
            {
                dataGridView2.Columns.Add("c" + Convert.ToString(i), " ");
            }
            for (int i = 0; i < result.M; i++)
            {
                dataGridView2.Rows.Add();
            }
            for (int k = 0; k < result.M; k++)
            {
                for (int l = 0; l < result.N; l++)
                {
                    dataGridView2[l, k].Value = result[k, l];
                }
            }
        }

        private async void button2_Click_2(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            result2 = new Matrix(m, n);
            for (int i = 0; i < result2.N; i++)
            {
                dataGridView3.Columns.Add("c" + Convert.ToString(i), " ");
            }
            for (int i = 0; i < result2.M; i++)
            {
                dataGridView3.Rows.Add();
            }

            await Task.Run(() => add1());
            await Task.Run(() => subtract1());

            for (int k = 0; k < result2.M; k++)
            {
                for (int l = 0; l < result2.N; l++)
                {
                    dataGridView3[l, k].Value = result2[k, l];
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            isClear = 1;
            m = 0;
            n = 0;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            matr = new Matrix(m, n);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matr[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                }
            }
        }
    }
}
