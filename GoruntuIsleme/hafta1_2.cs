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
    public partial class hafta1_2 : Form
    {
        int deger = 512;
   
        public hafta1_2(Form1 form1)
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DrawCustomImage();
        }
        private void DrawCustomImage()
        {
            // Gri tonlu görüntü oluştur
            Bitmap customImage = new Bitmap(deger, deger); 

            // Merkez noktası
            int centerX = deger / 2;
            int centerY = deger / 2;

            // Belirli bir koşula göre piksel değerlerini belirle
            for (int i = 1; i < deger; i++)
            {
                for (int j = 1; j < deger; j++)
                {
                    double distance = Math.Sqrt(Math.Pow(i - centerX, 2) + Math.Pow(j - centerY, 2));

                    if (distance >= 100)
                    {
                        customImage.SetPixel(i, j, Color.FromArgb(0, 0, 0)); // siyah renk
                    }
            

                }
            }
            // PictureBox üzerinde görüntüyü göster
            pictureBox1.Image = customImage;
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
