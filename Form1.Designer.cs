namespace LSB
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Encode_btn = new System.Windows.Forms.Button();
            this.message_textBox = new System.Windows.Forms.TextBox();
            this.Decode_btn = new System.Windows.Forms.Button();
            this.chooseImg_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Encode_btn
            // 
            this.Encode_btn.Location = new System.Drawing.Point(38, 250);
            this.Encode_btn.Name = "Encode_btn";
            this.Encode_btn.Size = new System.Drawing.Size(101, 23);
            this.Encode_btn.TabIndex = 0;
            this.Encode_btn.Text = "Закодировать";
            this.Encode_btn.UseVisualStyleBackColor = true;
            this.Encode_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // message_textBox
            // 
            this.message_textBox.Location = new System.Drawing.Point(38, 224);
            this.message_textBox.Name = "message_textBox";
            this.message_textBox.Size = new System.Drawing.Size(208, 20);
            this.message_textBox.TabIndex = 1;
            // 
            // Decode_btn
            // 
            this.Decode_btn.Location = new System.Drawing.Point(145, 250);
            this.Decode_btn.Name = "Decode_btn";
            this.Decode_btn.Size = new System.Drawing.Size(101, 23);
            this.Decode_btn.TabIndex = 2;
            this.Decode_btn.Text = "Раскодировать";
            this.Decode_btn.UseVisualStyleBackColor = true;
            this.Decode_btn.Click += new System.EventHandler(this.Decode_btn_Click);
            // 
            // chooseImg_btn
            // 
            this.chooseImg_btn.Location = new System.Drawing.Point(38, 180);
            this.chooseImg_btn.Name = "chooseImg_btn";
            this.chooseImg_btn.Size = new System.Drawing.Size(208, 23);
            this.chooseImg_btn.TabIndex = 3;
            this.chooseImg_btn.Text = "Выберите изображение";
            this.chooseImg_btn.UseVisualStyleBackColor = true;
            this.chooseImg_btn.Click += new System.EventHandler(this.chooseImg_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(39, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 146);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 302);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chooseImg_btn);
            this.Controls.Add(this.Decode_btn);
            this.Controls.Add(this.message_textBox);
            this.Controls.Add(this.Encode_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Encode_btn;
        private System.Windows.Forms.TextBox message_textBox;
        private System.Windows.Forms.Button Decode_btn;
        private System.Windows.Forms.Button chooseImg_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

