namespace GoruntuIsleme
{
    partial class hafta5_2
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.resim_sec = new System.Windows.Forms.Button();
            this.bulanik = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(581, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(500, 500);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // resim_sec
            // 
            this.resim_sec.Location = new System.Drawing.Point(160, 551);
            this.resim_sec.Name = "resim_sec";
            this.resim_sec.Size = new System.Drawing.Size(130, 50);
            this.resim_sec.TabIndex = 2;
            this.resim_sec.Text = "resim sec";
            this.resim_sec.UseVisualStyleBackColor = true;
            this.resim_sec.Click += new System.EventHandler(this.resim_sec_Click);
            // 
            // bulanik
            // 
            this.bulanik.Location = new System.Drawing.Point(749, 551);
            this.bulanik.Name = "bulanik";
            this.bulanik.Size = new System.Drawing.Size(130, 50);
            this.bulanik.TabIndex = 3;
            this.bulanik.Text = "bulanıklaştır";
            this.bulanik.UseVisualStyleBackColor = true;
            this.bulanik.Click += new System.EventHandler(this.bulanik_Click);
            // 
            // Form14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 695);
            this.Controls.Add(this.bulanik);
            this.Controls.Add(this.resim_sec);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form14";
            this.Text = "Form14";
            this.Load += new System.EventHandler(this.Form14_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button resim_sec;
        private System.Windows.Forms.Button bulanik;
    }
}