using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_tasks
{
    public partial class Matrix : Form
    {
        public Matrix(int[,] M)
        {
            InitializeComponent();
            
            for(int i = 0; i < M.GetLength(0); i++)
            {
                for(int j = 0; j < M.GetLength(0); j++)
                {
                    label1.Text += IntToChar(M[i, j]);
                }
                label1.Text += '\n';
            }


            if (M.GetLength(0) > 6)
            {
                this.ClientSize = new System.Drawing.Size(950, 473);
                this.button2.Location = new System.Drawing.Point(350, 400);
            }

        }

        private char IntToChar(int n)
        {
            return n == 1 ? '1' : '0';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point last;
        private void task1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - last.X;
                this.Top += e.Y - last.Y;
            }
        }

        private void task1_MouseDown(object sender, MouseEventArgs e)
        {
            last = new Point(e.X, e.Y);
        }



    }
}
