namespace CoinCounter
{
    partial class Form1
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.uploadImage = new System.Windows.Forms.Button();
            this.processImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(37, 42);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(344, 266);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // uploadImage
            // 
            this.uploadImage.BackColor = System.Drawing.SystemColors.Highlight;
            this.uploadImage.Location = new System.Drawing.Point(406, 51);
            this.uploadImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uploadImage.Name = "uploadImage";
            this.uploadImage.Size = new System.Drawing.Size(139, 65);
            this.uploadImage.TabIndex = 1;
            this.uploadImage.Text = "Upload an Image";
            this.uploadImage.UseVisualStyleBackColor = false;
            this.uploadImage.Click += new System.EventHandler(this.uploadImage_Click);
            // 
            // processImage
            // 
            this.processImage.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.processImage.Location = new System.Drawing.Point(406, 224);
            this.processImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.processImage.Name = "processImage";
            this.processImage.Size = new System.Drawing.Size(139, 58);
            this.processImage.TabIndex = 2;
            this.processImage.Text = "Count Me";
            this.processImage.UseVisualStyleBackColor = false;
            this.processImage.Click += new System.EventHandler(this.processImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Let\'s Count Coin Activity";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 354);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.processImage);
            this.Controls.Add(this.uploadImage);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button uploadImage;
        private System.Windows.Forms.Button processImage;
        private System.Windows.Forms.Label label1;
    }
}

