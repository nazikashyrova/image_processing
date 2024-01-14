namespace GoruntuIsleme
{
    partial class hafta1_5
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
            this.kirmizi = new System.Windows.Forms.PictureBox();
            this.mavi = new System.Windows.Forms.PictureBox();
            this.ana_resim = new System.Windows.Forms.PictureBox();
            this.yesil = new System.Windows.Forms.PictureBox();
            this.resim_sec = new System.Windows.Forms.Button();
            this.ayir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.kirmizi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mavi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ana_resim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yesil)).BeginInit();
            this.SuspendLayout();
            // 
            // kirmizi
            // 
            this.kirmizi.Location = new System.Drawing.Point(736, 521);
            this.kirmizi.Name = "kirmizi";
            this.kirmizi.Size = new System.Drawing.Size(475, 346);
            this.kirmizi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kirmizi.TabIndex = 0;
            this.kirmizi.TabStop = false;
            // 
            // mavi
            // 
            this.mavi.Location = new System.Drawing.Point(86, 521);
            this.mavi.Name = "mavi";
            this.mavi.Size = new System.Drawing.Size(470, 346);
            this.mavi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mavi.TabIndex = 1;
            this.mavi.TabStop = false;
            // 
            // ana_resim
            // 
            this.ana_resim.Location = new System.Drawing.Point(586, 28);
            this.ana_resim.Name = "ana_resim";
            this.ana_resim.Size = new System.Drawing.Size(578, 357);
            this.ana_resim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ana_resim.TabIndex = 2;
            this.ana_resim.TabStop = false;
            this.ana_resim.Click += new System.EventHandler(this.ana_resim_Click);
            // 
            // yesil
            // 
            this.yesil.Location = new System.Drawing.Point(1367, 521);
            this.yesil.Name = "yesil";
            this.yesil.Size = new System.Drawing.Size(430, 346);
            this.yesil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.yesil.TabIndex = 3;
            this.yesil.TabStop = false;
            // 
            // resim_sec
            // 
            this.resim_sec.Location = new System.Drawing.Point(648, 407);
            this.resim_sec.Name = "resim_sec";
            this.resim_sec.Size = new System.Drawing.Size(164, 40);
            this.resim_sec.TabIndex = 4;
            this.resim_sec.Text = "resim sec";
            this.resim_sec.UseVisualStyleBackColor = true;
            this.resim_sec.Click += new System.EventHandler(this.resim_sec_Click);
            // 
            // ayir
            // 
            this.ayir.Location = new System.Drawing.Point(937, 407);
            this.ayir.Name = "ayir";
            this.ayir.Size = new System.Drawing.Size(172, 40);
            this.ayir.TabIndex = 5;
            this.ayir.Text = "ayir";
            this.ayir.UseVisualStyleBackColor = true;
            this.ayir.Click += new System.EventHandler(this.ayir_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1896, 1050);
            this.Controls.Add(this.ayir);
            this.Controls.Add(this.resim_sec);
            this.Controls.Add(this.yesil);
            this.Controls.Add(this.ana_resim);
            this.Controls.Add(this.mavi);
            this.Controls.Add(this.kirmizi);
            this.Name = "Form8";
            this.Text = "Form8";
            this.Load += new System.EventHandler(this.Form8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kirmizi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mavi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ana_resim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yesil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox kirmizi;
        private System.Windows.Forms.PictureBox mavi;
        private System.Windows.Forms.PictureBox ana_resim;
        private System.Windows.Forms.PictureBox yesil;
        private System.Windows.Forms.Button resim_sec;
        private System.Windows.Forms.Button ayir;
    }
}