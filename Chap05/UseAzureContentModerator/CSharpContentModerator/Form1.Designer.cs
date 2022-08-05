
namespace CSharpContentModerator
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
            this.btnImageContentModerator = new System.Windows.Forms.Button();
            this.btnTextContentModeratr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImageContentModerator
            // 
            this.btnImageContentModerator.Location = new System.Drawing.Point(232, 18);
            this.btnImageContentModerator.Name = "btnImageContentModerator";
            this.btnImageContentModerator.Size = new System.Drawing.Size(132, 53);
            this.btnImageContentModerator.TabIndex = 0;
            this.btnImageContentModerator.Text = "圖形內容仲裁";
            this.btnImageContentModerator.UseVisualStyleBackColor = true;
            this.btnImageContentModerator.Click += new System.EventHandler(this.btnImageContentModerator_Click);
            // 
            // btnTextContentModeratr
            // 
            this.btnTextContentModeratr.Location = new System.Drawing.Point(232, 93);
            this.btnTextContentModeratr.Name = "btnTextContentModeratr";
            this.btnTextContentModeratr.Size = new System.Drawing.Size(132, 47);
            this.btnTextContentModeratr.TabIndex = 1;
            this.btnTextContentModeratr.Text = "文字內容仲裁";
            this.btnTextContentModeratr.UseVisualStyleBackColor = true;
            this.btnTextContentModeratr.Click += new System.EventHandler(this.btnTextContentModeratr_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 162);
            this.Controls.Add(this.btnTextContentModeratr);
            this.Controls.Add(this.btnImageContentModerator);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImageContentModerator;
        private System.Windows.Forms.Button btnTextContentModeratr;
    }
}

