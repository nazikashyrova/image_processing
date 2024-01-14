namespace GoruntuIsleme
{
    partial class hafta1_7
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
            this.ana_resim = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.resim_sec = new System.Windows.Forms.Button();
            this.yapay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ana_resim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ana_resim
            // 
            this.ana_resim.Location = new System.Drawing.Point(12, 11);
            this.ana_resim.Name = "ana_resim";
            this.ana_resim.Size = new System.Drawing.Size(421, 444);
            this.ana_resim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ana_resim.TabIndex = 0;
            this.ana_resim.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(474, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(420, 443);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // resim_sec
            // 
            this.resim_sec.Location = new System.Drawing.Point(78, 473);
            this.resim_sec.Name = "resim_sec";
            this.resim_sec.Size = new System.Drawing.Size(271, 53);
            this.resim_sec.TabIndex = 4;
            this.resim_sec.Text = "Resim Seç";
            this.resim_sec.UseVisualStyleBackColor = true;
            this.resim_sec.Click += new System.EventHandler(this.resim_sec_Click_1);
            // 
            // yapay
            // 
            this.yapay.Location = new System.Drawing.Point(560, 474);
            this.yapay.Name = "yapay";
            this.yapay.Size = new System.Drawing.Size(258, 52);
            this.yapay.TabIndex = 5;
            this.yapay.Text = "yapay hale getir";
            this.yapay.UseVisualStyleBackColor = true;
            this.yapay.Click += new System.EventHandler(this.yapay_Click);
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1967, 708);
            this.Controls.Add(this.yapay);
            this.Controls.Add(this.resim_sec);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ana_resim);
            this.Name = "Form10";
            this.Text = "Form10";
            this.Load += new System.EventHandler(this.Form10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ana_resim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ana_resim;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button resim_sec;
        private System.Windows.Forms.Button yapay;
    }
}