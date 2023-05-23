using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_tasks
{
    public partial class task2 : Form
    {
        public task2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox2.Text);
            if (n < 0 || n > 20)
            {
                MessageBox.Show("Неверное значение", "Введите количество вершин от 1 до 20", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(950, 473);
                this.close.Location = new System.Drawing.Point(925, 4);
                int[,] Matrix = GetAdjacencyMatrix(n);
                Matrix M = new Matrix(Matrix);
                M.ShowDialog();
            }
        }
        private int[,] GetAdjacencyMatrix(int n)
        {
            int[,] AdjacencyMatrix = new int[n,n];
            Random rnd = new Random();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    AdjacencyMatrix[i, j] = rnd.Next(0, 1);
                }
            }
            return AdjacencyMatrix;

        }
        private void pictureBox1_Paint(object sender, EventArgs e)
        {

        }
        private void close_Click(object sender, EventArgs e)
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

