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

