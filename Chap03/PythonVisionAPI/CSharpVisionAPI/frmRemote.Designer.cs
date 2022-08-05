
namespace CSharpVisionAPI
{
    partial class frmRemote
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAnalyzed = new System.Windows.Forms.Button();
            this.lbDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(738, 580);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnAnalyzed
            // 
            this.btnAnalyzed.Location = new System.Drawing.Point(777, 63);
            this.btnAnalyzed.Name = "btnAnalyzed";
            this.btnAnalyzed.Size = new System.Drawing.Size(75, 30);
            this.btnAnalyzed.TabIndex = 1;
            this.btnAnalyzed.Text = "分析";
            this.btnAnalyzed.UseVisualStyleBackColor = true;
            this.btnAnalyzed.Click += new System.EventHandler(this.btnAnalyzed_Click);
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDescription.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbDescription.Location = new System.Drawing.Point(12, 28);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(2, 22);
            this.lbDescription.TabIndex = 2;
            // 
            // frmRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 641);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.btnAnalyzed);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRemote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRemote";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAnalyzed;
        private System.Windows.Forms.Label lbDescription;
    }
}