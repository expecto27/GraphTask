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
            this.btnDrawGraph = new System.Windows.Forms.Button();
            this.btnDrawMST = new System.Windows.Forms.Button();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.picMST = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMST)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbMatrix
            // 
            this.rtbMatrix.Location = new System.Drawing.Point(12, 12);
            this.rtbMatrix.Name = "rtbMatrix";
            this.rtbMatrix.Size = new System.Drawing.Size(205, 176);
            this.rtbMatrix.TabIndex = 0;
            this.rtbMatrix.Text = "";
            // 
            // btnDrawGraph
            // 
            this.btnDrawGraph.Location = new System.Drawing.Point(79, 267);
            this.btnDrawGraph.Name = "btnDrawGraph";
            this.btnDrawGraph.Size = new System.Drawing.Size(75, 23);
            this.btnDrawGraph.TabIndex = 1;
            this.btnDrawGraph.Text = "button1";
            this.btnDrawGraph.UseVisualStyleBackColor = true;
            this.btnDrawGraph.Click += new System.EventHandler(this.btnDrawGraph_Click);
            // 
            // btnDrawMST
            // 
            this.btnDrawMST.Location = new System.Drawing.Point(86, 343);
            this.btnDrawMST.Name = "btnDrawMST";
            this.btnDrawMST.Size = new System.Drawing.Size(75, 23);
            this.btnDrawMST.TabIndex = 2;
            this.btnDrawMST.Text = "button2";
            this.btnDrawMST.UseVisualStyleBackColor = true;
            // 
            // picGraph
            // 
            this.picGraph.Location = new System.Drawing.Point(824, 119);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(647, 389);
            this.picGraph.TabIndex = 3;
            this.picGraph.TabStop = false;
            // 
            // picMST
            // 
            this.picMST.Location = new System.Drawing.Point(223, 26);
            this.picMST.Name = "picMST";
            this.picMST.Size = new System.Drawing.Size(595, 387);
            this.picMST.TabIndex = 4;
            this.picMST.TabStop = false;
            // 
            // task7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1489, 770);
            this.Controls.Add(this.picMST);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.btnDrawMST);
            this.Controls.Add(this.btnDrawGraph);
            this.Controls.Add(this.rtbMatrix);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "task7";
            this.Text = "task7";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMST)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMatrix;
        private System.Windows.Forms.Button btnDrawGraph;
        private System.Windows.Forms.Button btnDrawMST;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.PictureBox picMST;
    }
}