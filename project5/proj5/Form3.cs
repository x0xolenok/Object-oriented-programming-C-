using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proj5
{
    public partial class Form3 : Form
    {
        private Form1 f1 = new Form1();
        private Form2 f2 = new Form2();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                f2.Show();
                if (f1.Visible)
                {
                    f1.Hide();
                }
            }
            catch (Exception)
            {
                f1 = new Form1();
                f2 = new Form2();
                f2.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                f1.Show();
                if (f2.Visible)
                {
                    f2.Hide();
                }
            }
            catch (Exception)
            {
                f1 = new Form1();
                f2 = new Form2();
                f1.Show();
            }
        }
    }
}
