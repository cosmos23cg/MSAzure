
namespace LUISCCSharpClient
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtUtterance = new System.Windows.Forms.TextBox();
            this.btnLUIS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "語句";
            // 
            // txtUtterance
            // 
            this.txtUtterance.Location = new System.Drawing.Point(153, 45);
            this.txtUtterance.Name = "txtUtterance";
            this.txtUtterance.Size = new System.Drawing.Size(285, 22);
            this.txtUtterance.TabIndex = 1;
            // 
            // btnLUIS
            // 
            this.btnLUIS.Location = new System.Drawing.Point(239, 95);
            this.btnLUIS.Name = "btnLUIS";
            this.btnLUIS.Size = new System.Drawing.Size(86, 30);
            this.btnLUIS.TabIndex = 2;
            this.btnLUIS.Text = "語言理解";
            this.btnLUIS.UseVisualStyleBackColor = true;
            this.btnLUIS.Click += new System.EventHandler(this.btnLUIS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 155);
            this.Controls.Add(this.btnLUIS);
            this.Controls.Add(this.txtUtterance);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUtterance;
        private System.Windows.Forms.Button btnLUIS;
    }
}

