using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoruntuIsleme
{
    public partial class hafta1_6 : Form
    {

        private Bitmap originalImage; 
        public hafta1_6(Form1 form1)
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

     

        private void resimSec_Click(object sender, EventArgs e)
        {
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

        private void kirmizi_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                // Kırmızı banta ait görüntüleri oluştur
                Bitmap redImage = ExtractChannel(originalImage, Channel.Red);

                // Gri tonlamaya dönüştür
                Bitmap grayrImage = ConvertToGray(redImage);

                // Oluşturulan görüntüleri göster
                pictureBox3.Image = grayrImage;
                    
              
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim seçin.");
            }
        }
        private void yesil_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                // Yeşil banta ait görüntüleri oluştur
                Bitmap greenImage = ExtractChannel(originalImage, Channel.Green);

                // Gri tonlamaya dönüştür
                Bitmap graygImage = ConvertToGray(greenImage);
                // Oluşturulan görüntüleri göster
                pictureBox4.Image = graygImage;
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim seçin.");
            }
        }

        private void mavi_Click(object sender, EventArgs e)
        {
            // Mavi banta ait görüntüleri oluştur
            Bitmap blueImage = ExtractChannel(originalImage, Channel.Blue);
            // Gri tonlamaya dönüştür
            Bitmap graybImage = ConvertToGray(blueImage);
            // Oluşturulan görüntüleri göster
            pictureBox2.Image = graybImage;
        }

        private Bitmap ExtractChannel(Bitmap originalImage, Channel channel)
        {
            Bitmap channelImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    Color channelColor = Color.Black;

                    switch (channel)
                    {
                        case Channel.Red:
                            channelColor = Color.FromArgb(originalColor.R, 0, 0);
                            break;
                        case Channel.Green:
                            channelColor = Color.FromArgb(0, originalColor.G, 0);
                            break;
                        case Channel.Blue:
                            channelColor = Color.FromArgb(0, 0, originalColor.B);
                            break;
                    }

                    channelImage.SetPixel(x, y, channelColor);
                }
            }

            return channelImage;
        }
        private enum Channel
        {
            Red,
            Green,
            Blue
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

        
    }
}
