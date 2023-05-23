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
            
        }

        private char IntToChar(int n)
        {
            return n == 1 ? '1' : '0';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
