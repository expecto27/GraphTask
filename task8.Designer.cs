namespace Graph_tasks
{
    partial class task8
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
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.btnDrawGraph = new System.Windows.Forms.Button();
            this.txtStartNode = new System.Windows.Forms.TextBox();
            this.rtbMatrix = new System.Windows.Forms.RichTextBox();
            this.rtbShortestPaths = new System.Windows.Forms.RichTextBox();
            this.kp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.Location = new System.Drawing.Point(524, 42);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(646, 413);
            this.picGraph.TabIndex = 0;
            this.picGraph.TabStop = false;
            // 
            // btnDrawGraph
            // 
            this.btnDrawGraph.Location = new System.Drawing.Point(116, 108);
            this.btnDrawGraph.Name = "btnDrawGraph";
            this.btnDrawGraph.Size = new System.Drawing.Size(75, 23);
            this.btnDrawGraph.TabIndex = 1;
            this.btnDrawGraph.Text = "button1";
            this.btnDrawGraph.UseVisualStyleBackColor = true;
            this.btnDrawGraph.Click += new System.EventHandler(this.btnDrawGraph_Click);
            // 
            // txtStartNode
            // 
            this.txtStartNode.Location = new System.Drawing.Point(192, 348);
            this.txtStartNode.Name = "txtStartNode";
            this.txtStartNode.Size = new System.Drawing.Size(100, 22);
            this.txtStartNode.TabIndex = 2;
            // 
            // rtbMatrix
            // 
            this.rtbMatrix.Location = new System.Drawing.Point(297, 59);
            this.rtbMatrix.Name = "rtbMatrix";
            this.rtbMatrix.Size = new System.Drawing.Size(147, 145);
            this.rtbMatrix.TabIndex = 3;
            this.rtbMatrix.Text = "";
            // 
            // rtbShortestPaths
            // 
            this.rtbShortestPaths.Location = new System.Drawing.Point(16, 404);
            this.rtbShortestPaths.Name = "rtbShortestPaths";
            this.rtbShortestPaths.Size = new System.Drawing.Size(440, 164);
            this.rtbShortestPaths.TabIndex = 4;
            this.rtbShortestPaths.Text = "";
            // 
            // kp
            // 
            this.kp.Location = new System.Drawing.Point(130, 185);
            this.kp.Name = "kp";
            this.kp.Size = new System.Drawing.Size(75, 23);
            this.kp.TabIndex = 5;
            this.kp.Text = "button1";
            this.kp.UseVisualStyleBackColor = true;
            this.kp.Click += new System.EventHandler(this.kp_Click);
            // 
            // task8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 608);
            this.Controls.Add(this.kp);
            this.Controls.Add(this.rtbShortestPaths);
            this.Controls.Add(this.rtbMatrix);
            this.Controls.Add(this.txtStartNode);
            this.Controls.Add(this.btnDrawGraph);
            this.Controls.Add(this.picGraph);
            this.Name = "task8";
            this.Text = "task8";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.Button btnDrawGraph;
        private System.Windows.Forms.TextBox txtStartNode;
        private System.Windows.Forms.RichTextBox rtbMatrix;
        private System.Windows.Forms.RichTextBox rtbShortestPaths;
        private System.Windows.Forms.Button kp;
    }
}