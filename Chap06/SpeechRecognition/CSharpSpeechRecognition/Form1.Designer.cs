
namespace CSharpSpeechRecognition
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
            this.btnSpeech2TextMic = new System.Windows.Forms.Button();
            this.btnSpeech2TextFile = new System.Windows.Forms.Button();
            this.btnDetectLanguage = new System.Windows.Forms.Button();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.btnText2Speech = new System.Windows.Forms.Button();
            this.btnSpeech2Speech = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSpeech2TextMic
            // 
            this.btnSpeech2TextMic.Location = new System.Drawing.Point(278, 16);
            this.btnSpeech2TextMic.Name = "btnSpeech2TextMic";
            this.btnSpeech2TextMic.Size = new System.Drawing.Size(156, 47);
            this.btnSpeech2TextMic.TabIndex = 0;
            this.btnSpeech2TextMic.Text = "語音辨識(麥克風)";
            this.btnSpeech2TextMic.UseVisualStyleBackColor = true;
            this.btnSpeech2TextMic.Click += new System.EventHandler(this.btnSpeech2TextMic_Click);
            // 
            // btnSpeech2TextFile
            // 
            this.btnSpeech2TextFile.Location = new System.Drawing.Point(278, 73);
            this.btnSpeech2TextFile.Name = "btnSpeech2TextFile";
            this.btnSpeech2TextFile.Size = new System.Drawing.Size(156, 47);
            this.btnSpeech2TextFile.TabIndex = 1;
            this.btnSpeech2TextFile.Text = "語音辨識(語音檔案)";
            this.btnSpeech2TextFile.UseVisualStyleBackColor = true;
            this.btnSpeech2TextFile.Click += new System.EventHandler(this.btnSpeech2TextFile_Click);
            // 
            // btnDetectLanguage
            // 
            this.btnDetectLanguage.Location = new System.Drawing.Point(278, 130);
            this.btnDetectLanguage.Name = "btnDetectLanguage";
            this.btnDetectLanguage.Size = new System.Drawing.Size(156, 47);
            this.btnDetectLanguage.TabIndex = 2;
            this.btnDetectLanguage.Text = "判斷語言";
            this.btnDetectLanguage.UseVisualStyleBackColor = true;
            this.btnDetectLanguage.Click += new System.EventHandler(this.btnDetectLanguage_Click);
            // 
            // btnTranslate
            // 
            this.btnTranslate.Location = new System.Drawing.Point(278, 192);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(156, 46);
            this.btnTranslate.TabIndex = 3;
            this.btnTranslate.Text = "翻譯";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // btnText2Speech
            // 
            this.btnText2Speech.Location = new System.Drawing.Point(278, 254);
            this.btnText2Speech.Name = "btnText2Speech";
            this.btnText2Speech.Size = new System.Drawing.Size(156, 51);
            this.btnText2Speech.TabIndex = 4;
            this.btnText2Speech.Text = "文字轉語音";
            this.btnText2Speech.UseVisualStyleBackColor = true;
            this.btnText2Speech.Click += new System.EventHandler(this.btnText2Speech_Click);
            // 
            // btnSpeech2Speech
            // 
            this.btnSpeech2Speech.Location = new System.Drawing.Point(278, 322);
            this.btnSpeech2Speech.Name = "btnSpeech2Speech";
            this.btnSpeech2Speech.Size = new System.Drawing.Size(156, 43);
            this.btnSpeech2Speech.TabIndex = 5;
            this.btnSpeech2Speech.Text = "語音轉語音";
            this.btnSpeech2Speech.UseVisualStyleBackColor = true;
            this.btnSpeech2Speech.Click += new System.EventHandler(this.btnSpeech2Speech_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 395);
            this.Controls.Add(this.btnSpeech2Speech);
            this.Controls.Add(this.btnText2Speech);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.btnDetectLanguage);
            this.Controls.Add(this.btnSpeech2TextFile);
            this.Controls.Add(this.btnSpeech2TextMic);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSpeech2TextMic;
        private System.Windows.Forms.Button btnSpeech2TextFile;
        private System.Windows.Forms.Button btnDetectLanguage;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.Button btnText2Speech;
        private System.Windows.Forms.Button btnSpeech2Speech;
    }
}

