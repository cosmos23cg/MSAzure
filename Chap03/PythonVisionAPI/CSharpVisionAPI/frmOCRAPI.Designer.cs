
namespace CSharpVisionAPI
{
    partial class frmOCRAPI
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.lbDetectedText = new System.Windows.Forms.Label();
            this.btnAnalyzed = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(797, 52);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 33);
            this.btnSelect.TabIndex = 14;
            this.btnSelect.Text = "選取";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lbDetectedText
            // 
            this.lbDetectedText.AutoSize = true;
            this.lbDetectedText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDetectedText.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbDetectedText.Location = new System.Drawing.Point(15, 15);
            this.lbDetectedText.Name = "lbDetectedText";
            this.lbDetectedText.Size = new System.Drawing.Size(2, 22);
            this.lbDetectedText.TabIndex = 13;
            // 
            // btnAnalyzed
            // 
            this.btnAnalyzed.Location = new System.Drawing.Point(797, 91);
            this.btnAnalyzed.Name = "btnAnalyzed";
            this.btnAnalyzed.Size = new System.Drawing.Size(75, 30);
            this.btnAnalyzed.TabIndex = 12;
            this.btnAnalyzed.Text = "分析";
            this.btnAnalyzed.UseVisualStyleBackColor = true;
            this.btnAnalyzed.Click += new System.EventHandler(this.btnAnalyzed_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(757, 595);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "圖形檔案(*.jpg;*.png)|*.jpg;*.png";
            // 
            // frmOCRAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 665);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lbDetectedText);
            this.Controls.Add(this.btnAnalyzed);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmOCRAPI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmOCRAPI";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lbDetectedText;
        private System.Windows.Forms.Button btnAnalyzed;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}