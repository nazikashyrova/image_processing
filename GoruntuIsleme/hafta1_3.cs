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
    public partial class hafta1_3 : Form
    {
        private Bitmap originalImage;
        public hafta1_3(Form1 form1)
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void resim_sec_Click(object sender, EventArgs e)
        {
            // Bir resim dosyası seçme işlemi
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.png;*.gif;*.tif|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        originalImage = new Bitmap(openFileDialog.FileName);
                        pictureBox1.Image = originalImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim açma hatası: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                // Belirtilen aralıklarla resmi örnekleyerek yeni resimleri oluştur
                int[] samplingIntervals = { 2, 5, 10, 25, 50 };

                foreach (var interval in samplingIntervals)
                {
                    Bitmap sampledImage = SampleImage(originalImage, interval);
                   flowLayoutPanel1.Controls.Add(new PictureBox
                    {
                        Width = sampledImage.Width,
                        Height = sampledImage.Height,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = sampledImage
                    });
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim seçin.");
            }
        }

        private Bitmap SampleImage(Bitmap originalImage, int interval)
        {
            Bitmap sampledImage = new Bitmap(originalImage.Width / interval, originalImage.Height / interval);

            for (int x = 0; x < originalImage.Width; x += interval)
            {
                for (int y = 0; y < originalImage.Height; y += interval)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    Color roundedColor = RoundToNearestMultiple(originalColor, 10);

                    sampledImage.SetPixel(x / interval, y / interval, roundedColor);
                }
            }

            return sampledImage;
        }

        private Color RoundToNearestMultiple(Color originalColor, int multiple)
        {
            int roundedR = (int)(Math.Round((double)originalColor.R / multiple) * multiple);
            int roundedG = (int)(Math.Round((double)originalColor.G / multiple) * multiple);
            int roundedB = (int)(Math.Round((double)originalColor.B / multiple) * multiple);

            // Renk değerlerini sınırla (0-255 aralığına)
            roundedR = Math.Max(0, Math.Min(255, roundedR));
            roundedG = Math.Max(0, Math.Min(255, roundedG));
            roundedB = Math.Max(0, Math.Min(255, roundedB));

            return Color.FromArgb(roundedR, roundedG, roundedB);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
    