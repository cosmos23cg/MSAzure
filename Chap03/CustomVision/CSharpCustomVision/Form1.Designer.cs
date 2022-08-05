
namespace CSharpCustomVision
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
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnCustomVisionClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(160, 26);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(204, 34);
            this.btnTrain.TabIndex = 0;
            this.btnTrain.Text = "建立訓練專案";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(160, 79);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(204, 34);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "執行測試";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnCustomVisionClient
            // 
            this.btnCustomVisionClient.Location = new System.Drawing.Point(160, 131);
            this.btnCustomVisionClient.Name = "btnCustomVisionClient";
            this.btnCustomVisionClient.Size = new System.Drawing.Size(204, 34);
            this.btnCustomVisionClient.TabIndex = 4;
            this.btnCustomVisionClient.Text = "叫用預測資源";
            this.btnCustomVisionClient.UseVisualStyleBackColor = true;
            this.btnCustomVisionClient.Click += new System.EventHandler(this.btnCustomVisionClient_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 201);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnCustomVisionClient);
            this.Controls.Add(this.btnTrain);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnCustomVisionClient;
    }
}

