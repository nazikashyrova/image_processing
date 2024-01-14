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
    public partial class hafta2_2 : Form
    {
        public hafta2_2(Form1 form1)
        {
            InitializeComponent();
        }

        private void hafta2_2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }
            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ApplyDualThreshold();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            ApplyDualThreshold();
        }
        private void ApplyDualThreshold()
        {
            if (pictureBox1.Image != null)
            {
                int minThresholdValue = trackBar1.Value;
                int maxThresholdValue = trackBar2.Value;

                Bitmap originalImage = new Bitmap(pictureBox1.Image);
                Bitmap thresholdedImage = ApplyDualThreshold(originalImage, minThresholdValue, maxThresholdValue);

                pictureBox2.Image = thresholdedImage;
            }
        }
        private Bitmap ApplyDualThreshold(Bitmap originalImage, int minThreshold, int maxThreshold)
        {
            Bitmap thresholdedImage = new Bitmap(originalImage.Width, originalImage.Height);
            int ResimGenisligi = originalImage.Width;
            int ResimYuksekligi = originalImage.Height;
            Color OkunanRenk, DonusenRenk;
            int OrtalamaRenk = 0;
            int R = 0, G = 0, B = 0;

            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {

                    OkunanRenk = originalImage.GetPixel(x, y);
                    OrtalamaRenk = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3;
                    if (OrtalamaRenk >= minThreshold && OrtalamaRenk <= maxThreshold)
                        R = 255;
                    else
                        R = 0;
                    if (OrtalamaRenk >= minThreshold && OrtalamaRenk <= maxThreshold)
                        G = 255;
                    else
                        G = 0;
                    if (OrtalamaRenk >= minThreshold && OrtalamaRenk <= maxThreshold)
                        B = 255;
                    else
                        B = 0;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    thresholdedImage.SetPixel(x, y, DonusenRenk);
                }

            }
            return thresholdedImage;

        }
    }
}
