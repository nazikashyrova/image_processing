using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoruntuIsleme
{
    public partial class hafta3_12 : Form
    {

        private Bitmap orijinalResim;

        public hafta3_12(Form1 form1)
        {
            InitializeComponent();
            orijinalResim = new Bitmap(pictureBox1.Image);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = orijinalResim;

            pictureBox1.MouseClick += PictureBox1_MouseClick;
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                float aci = 45.0f;
                DondurVeDuzelt(aci);
            }
        }

        private void DondurVeDuzelt(float aci)
        {
            Bitmap yeniResim = Dondur(orijinalResim, aci);
            Bitmap duzeltilmisResim = Duzelt(yeniResim);

            pictureBox1.Image = duzeltilmisResim;
        }

        private Bitmap Dondur(Bitmap resim, float aci)
        {
            Bitmap yeniResim = new Bitmap(resim.Width, resim.Height);

            using (Graphics g = Graphics.FromImage(yeniResim))
            {
                g.TranslateTransform(resim.Width / 2, resim.Height / 2);
                g.RotateTransform(aci);
                g.TranslateTransform(-resim.Width / 2, -resim.Height / 2);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(resim, Point.Empty);
            }

            return yeniResim;
        }

        private Bitmap Duzelt(Bitmap resim)
        {
            Bitmap duzeltilmisResim = new Bitmap(resim.Width, resim.Height);

            using (Graphics g = Graphics.FromImage(duzeltilmisResim))
            {
                g.DrawImage(resim, Point.Empty);
            }

            for (int y = 1; y < resim.Height - 1; y++)
            {
                for (int x = 1; x < resim.Width - 1; x++)
                {
                    if (resim.GetPixel(x, y) == Color.Black)
                    {
                        Color renk = OrtalamaRenk(resim, x, y);
                        duzeltilmisResim.SetPixel(x, y, renk);
                    }
                }
            }

            return duzeltilmisResim;
        }

        private Color OrtalamaRenk(Bitmap resim, int x, int y)
        {
            int toplamR = 0, toplamG = 0, toplamB = 0;
            int pikselSayisi = 0;

            for (int dy = -1; dy <= 1; dy++)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    if (dx == 0 && dy == 0)
                        continue;

                    int pikselX = x + dx;
                    int pikselY = y + dy;

                    if (pikselX >= 0 && pikselX < resim.Width && pikselY >= 0 && pikselY < resim.Height)
                    {
                        Color pikselRenk = resim.GetPixel(pikselX, pikselY);
                        toplamR += pikselRenk.R;
                        toplamG += pikselRenk.G;
                        toplamB += pikselRenk.B;
                        pikselSayisi++;
                    }
                }
            }

            int ortalamaR = toplamR / pikselSayisi;
            int ortalamaG = toplamG / pikselSayisi;
            int ortalamaB = toplamB / pikselSayisi;

            return Color.FromArgb(ortalamaR, ortalamaG, ortalamaB);
        }
    }
}
