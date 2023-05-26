namespace Graph_tasks
{
    partial class task7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbMatrix = new System.Windows.Forms.RichTextBox();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picMST = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.Label();
            this.btnDrawGraph = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMST)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbMatrix
            // 
            this.rtbMatrix.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbMatrix.Location = new System.Drawing.Point(367, 16);
            this.rtbMatrix.Margin = new System.Windows.Forms.Padding(2);
            this.rtbMatrix.Name = "rtbMatrix";
            this.rtbMatrix.Size = new System.Drawing.Size(180, 108);
            this.rtbMatrix.TabIndex = 0;
            this.rtbMatrix.Text = "";
            // 
            // picGraph
            // 
            this.picGraph.Location = new System.Drawing.Point(21, 199);
            this.picGraph.Margin = new System.Windows.Forms.Padding(2);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(429, 361);
            this.picGraph.TabIndex = 3;
            this.picGraph.TabStop = false;
            this.picGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.task1_MouseDown);
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.task1_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.panel1.Controls.Add(this.picMST);
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.btnDrawGraph);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.picGraph);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 363);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.task1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.task1_MouseMove);
            // 
            // picMST
            // 
            this.picMST.Location = new System.Drawing.Point(570, 199);
            this.picMST.Margin = new System.Windows.Forms.Padding(2);
            this.picMST.Name = "picMST";
            this.picMST.Size = new System.Drawing.Size(429, 361);
            this.picMST.TabIndex = 30;
            this.picMST.TabStop = false;
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.Red;
            this.close.Location = new System.Drawing.Point(539, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(27, 25);
            this.close.TabIndex = 27;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // btnDrawGraph
            // 
            this.btnDrawGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDrawGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawGraph.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDrawGraph.ForeColor = System.Drawing.Color.White;
            this.btnDrawGraph.Location = new System.Drawing.Point(147, 200);
            this.btnDrawGraph.Name = "btnDrawGraph";
            this.btnDrawGraph.Size = new System.Drawing.Size(400, 157);
            this.btnDrawGraph.TabIndex = 2;
            this.btnDrawGraph.Text = "Получить минимальное остовное дерево";
            this.btnDrawGraph.UseVisualStyleBackColor = true;
            this.btnDrawGraph.Click += new System.EventHandler(this.btnDrawGraph_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(569, 162);
            this.panel3.TabIndex = 14;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.task1_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.task1_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Orange;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.rtbMatrix);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 140);
            this.panel2.TabIndex = 0;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.task1_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.task1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите матрицу смежности";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Graph_tasks.Properties.Resources.notepadd;
            this.pictureBox2.Location = new System.Drawing.Point(31, 65);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 59);
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // task7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 363);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "task7";
            this.Text = "task7";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMST)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMatrix;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Button btnDrawGraph;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picMST;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}