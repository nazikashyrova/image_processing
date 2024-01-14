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
    public partial class hafta1_4 : Form
    {
        private Bitmap originalImage;
        public hafta1_4(Form1 form1)
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                // Gri tonlamaya dönüştür
                Bitmap grayImage = ConvertToGray(originalImage);

                // Belirli aralıklarla mozaik yap ve yeni resmi göster
                int[] mosaicSizes = { 2, 5, 10, 25 };

                flowLayoutPanel1.Controls.Clear(); // Önceki mozaikleri temizle

                foreach (var mosaicSize in mosaicSizes)
                {
                    Bitmap mosaicImage = CreateMosaic(grayImage, mosaicSize);

                    // Oluşturulan mozaik resmi bir PictureBox içinde göster
                    PictureBox mosaicPictureBox = new PictureBox
                    {
                        Width = mosaicImage.Width,
                        Height = mosaicImage.Height,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = mosaicImage
                    };

                    flowLayoutPanel1.Controls.Add(mosaicPictureBox);
                }
            }
            else{
                MessageBox.Show("Lütfen önce bir resim seçin.");
            }
        }
        private Bitmap ConvertToGray(Bitmap originalImage)
        {
            Bitmap grayImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    int grayValue = (int)(0.299 * originalColor.R + 0.587 * originalColor.G + 0.114 * originalColor.B);
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    grayImage.SetPixel(x, y, grayColor);
                }
            }

            return grayImage;
        }
        private Bitmap CreateMosaic(Bitmap grayImage, int mosaicSize)
        {
            Bitmap mosaicImage = new Bitmap(grayImage.Width, grayImage.Height);

            for (int x = 0; x < grayImage.Width; x += mosaicSize)
            {
                for (int y = 0; y < grayImage.Height; y += mosaicSize)
                {
                    int sum = 0;
                    int count = 0;

                    for (int i = 0; i < mosaicSize && x + i < grayImage.Width; i++)
                    {
                        for (int j = 0; j < mosaicSize && y + j < grayImage.Height; j++)
                        {
                            sum += grayImage.GetPixel(x + i, y + j).R;
                            count++;
                        }
                    }

                    int average = (int)Math.Round((double)sum / count);

                    for (int i = 0; i < mosaicSize && x + i < grayImage.Width; i++)
                    {
                        for (int j = 0; j < mosaicSize && y + j < grayImage.Height; j++)
                        {
                            mosaicImage.SetPixel(x + i, y + j, Color.FromArgb(average, average, average));
                        }
                    }
                }
            }

            return mosaicImage;
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
    }
}
