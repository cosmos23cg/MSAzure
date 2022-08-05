
namespace CSharpVisionAPI
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
            this.btnRemote = new System.Windows.Forms.Button();
            this.btnLocal = new System.Windows.Forms.Button();
            this.btnReadAPI = new System.Windows.Forms.Button();
            this.btnOCRAPI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRemote
            // 
            this.btnRemote.Location = new System.Drawing.Point(154, 17);
            this.btnRemote.Name = "btnRemote";
            this.btnRemote.Size = new System.Drawing.Size(277, 33);
            this.btnRemote.TabIndex = 0;
            this.btnRemote.Text = "分析指定網址的圖片";
            this.btnRemote.UseVisualStyleBackColor = true;
            this.btnRemote.Click += new System.EventHandler(this.btnRemote_Click);
            // 
            // btnLocal
            // 
            this.btnLocal.Location = new System.Drawing.Point(154, 64);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(277, 33);
            this.btnLocal.TabIndex = 1;
            this.btnLocal.Text = "分析存放在本機電腦的圖片";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // btnReadAPI
            // 
            this.btnReadAPI.Location = new System.Drawing.Point(154, 111);
            this.btnReadAPI.Name = "btnReadAPI";
            this.btnReadAPI.Size = new System.Drawing.Size(277, 33);
            this.btnReadAPI.TabIndex = 2;
            this.btnReadAPI.Text = "使用Read API讀取圖片中的手寫文字";
            this.btnReadAPI.UseVisualStyleBackColor = true;
            this.btnReadAPI.Click += new System.EventHandler(this.btnReadAPI_Click);
            // 
            // btnOCRAPI
            // 
            this.btnOCRAPI.Location = new System.Drawing.Point(154, 158);
            this.btnOCRAPI.Name = "btnOCRAPI";
            this.btnOCRAPI.Size = new System.Drawing.Size(277, 33);
            this.btnOCRAPI.TabIndex = 3;
            this.btnOCRAPI.Text = "使用OCR API讀取圖片中的印刷文字";
            this.btnOCRAPI.UseVisualStyleBackColor = true;
            this.btnOCRAPI.Click += new System.EventHandler(this.btnOCRAPI_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 222);
            this.Controls.Add(this.btnOCRAPI);
            this.Controls.Add(this.btnReadAPI);
            this.Controls.Add(this.btnLocal);
            this.Controls.Add(this.btnRemote);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRemote;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnReadAPI;
        private System.Windows.Forms.Button btnOCRAPI;
    }
}

