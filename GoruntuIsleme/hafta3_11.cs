using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoruntuIsleme
{
    public partial class hafta3_11 : Form
    {
        
        private Bitmap orijinalResim;
        private Bitmap döndürülmüsResim;
        private int kaydirmaMiktar = 50;

        public hafta3_11(Form1 form1)
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            orijinalResim = new Bitmap(pictureBox1.Image);
            döndürülmüsResim = new Bitmap(orijinalResim.Width, orijinalResim.Height);
            pictureBox1.Image = orijinalResim;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void DondurVeKaydir(bool saatYonunde)
        {
            using (Graphics g = Graphics.FromImage(döndürülmüsResim))
            {
                g.Clear(Color.White);
                Matrix matrix = new Matrix();
                matrix.Translate(orijinalResim.Width / 2, orijinalResim.Height / 2);

                if (saatYonunde)
                    matrix.Rotate(45);
                else
                    matrix.Rotate(-45);

                matrix.Translate(-orijinalResim.Width / 2, -orijinalResim.Height / 2);
                g.Transform = matrix;
                g.DrawImage(orijinalResim, new Point(kaydirmaMiktar, kaydirmaMiktar));
            }

            pictureBox1.Image = döndürülmüsResim;
        }

        private void SaatYonundeButton_Click(object sender, EventArgs e)
        {
            DondurVeKaydir(true);
        }

        private void TersYonundeButton_Click(object sender, EventArgs e)
        {
            DondurVeKaydir(false);
        }
    }
}
