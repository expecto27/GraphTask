namespace Graph_tasks
{
    partial class task9
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
            this.button1 = new System.Windows.Forms.Button();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.rtbMatrix = new System.Windows.Forms.RichTextBox();
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // picGraph
            // 
            this.picGraph.Location = new System.Drawing.Point(323, 50);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(465, 333);
            this.picGraph.TabIndex = 2;
            this.picGraph.TabStop = false;
            // 
            // rtbMatrix
            // 
            this.rtbMatrix.Location = new System.Drawing.Point(133, 191);
            this.rtbMatrix.Name = "rtbMatrix";
            this.rtbMatrix.Size = new System.Drawing.Size(171, 157);
            this.rtbMatrix.TabIndex = 3;
            this.rtbMatrix.Text = "";
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.Location = new System.Drawing.Point(12, 21);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.Size = new System.Drawing.Size(273, 156);
            this.richTextBoxResult.TabIndex = 4;
            this.richTextBoxResult.Text = "";
            // 
            // task9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBoxResult);
            this.Controls.Add(this.rtbMatrix);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.button1);
            this.Name = "task9";
            this.Text = "task9";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.RichTextBox rtbMatrix;
        private System.Windows.Forms.RichTextBox richTextBoxResult;
    }
}