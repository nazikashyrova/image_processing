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
    public partial class hafta3_9 : Form
    {
        private Bitmap orijinalResim;
        private Bitmap pikselDegistirmeResim;
        private Bitmap pikselInterpolasyonResim;
        public hafta3_9(Form1 form1)
        {
            InitializeComponent();
            orijinalResim = new Bitmap(pictureBox1.Image);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = orijinalResim;

            pikselDegistirmeResim = Buyut_PikselDegistirme(orijinalResim, 2);
            pictureBox2.Image = pikselDegistirmeResim;
            pikselInterpolasyonResim = Buyut_PikselInterpolasyon(orijinalResim, 2);
            pictureBox3.Image = pikselInterpolasyonResim;




        }

        private Bitmap Buyut_PikselDegistirme(Bitmap resim, int olcek)
        {
            int genislik = resim.Width * olcek;
            int yukseklik = resim.Height * olcek;

            Bitmap buyukResim = new Bitmap(genislik, yukseklik);

            for (int y = 0; y < yukseklik; y++)
            {
                for (int x = 0; x < genislik; x++)
                {
                    Color piksel = resim.GetPixel(x / olcek, y / olcek);
                    buyukResim.SetPixel(x, y, piksel);
                }
            }

            return buyukResim;
        }

        private Bitmap Buyut_PikselInterpolasyon(Bitmap resim, int olcek)
        {
            int genislik = resim.Width * olcek;
            int yukseklik = resim.Height * olcek;

            Bitmap buyukResim = new Bitmap(genislik, yukseklik);

            for (int y = 0; y < yukseklik; y++)
            {
                for (int x = 0; x < genislik; x++)
                {
                    float oranX = x / (float)genislik * (resim.Width - 1);
                    float oranY = y / (float)yukseklik * (resim.Height - 1);

                    Color c1 = resim.GetPixel((int)oranX, (int)oranY);
                    Color c2 = resim.GetPixel((int)oranX + 1, (int)oranY);
                    Color c3 = resim.GetPixel((int)oranX, (int)oranY + 1);
                    Color c4 = resim.GetPixel((int)oranX + 1, (int)oranY + 1);

                    int R = (int)(c1.R * (1 - (oranX - (int)oranX)) * (1 - (oranY - (int)oranY)) +
                                  c2.R * ((oranX - (int)oranX)) * (1 - (oranY - (int)oranY)) +
                                  c3.R * (1 - (oranX - (int)oranX)) * (oranY - (int)oranY) +
                                  c4.R * ((oranX - (int)oranX)) * (oranY - (int)oranY));

                    int G = (int)(c1.G * (1 - (oranX - (int)oranX)) * (1 - (oranY - (int)oranY)) +
                                  c2.G * ((oranX - (int)oranX)) * (1 - (oranY - (int)oranY)) +
                                  c3.G * (1 - (oranX - (int)oranX)) * (oranY - (int)oranY) +
                                  c4.G * ((oranX - (int)oranX)) * (oranY - (int)oranY));

                    int B = (int)(c1.B * (1 - (oranX - (int)oranX)) * (1 - (oranY - (int)oranY)) +
                                  c2.B * ((oranX - (int)oranX)) * (1 - (oranY - (int)oranY)) +
                                  c3.B * (1 - (oranX - (int)oranX)) * (oranY - (int)oranY) +
                                  c4.B * ((oranX - (int)oranX)) * (oranY - (int)oranY));

                    buyukResim.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }

            return buyukResim;
        }
    }
}
