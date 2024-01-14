using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GoruntuIsleme
{
    public partial class hafta1_8 : Form
    {
        private Bitmap originalImage;
        public hafta1_8(Form1 form1)
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void resim_sec_Click(object sender, EventArgs e)
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
        private Bitmap ReduceColorDepth(Bitmap originalImage, int bitDepth)
        {
            // Yeni renk çözünürlüğünde bir resim oluştur
            Bitmap reducedImage = new Bitmap(originalImage.Width, originalImage.Height, PixelFormat.Format32bppRgb);

            // Renk çözünürlüğünü düşür
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);

                    int newR = ReduceChannel(originalColor.R, bitDepth);
                    int newG = ReduceChannel(originalColor.G, bitDepth);
                    int newB = ReduceChannel(originalColor.B, bitDepth);

                    Color newColor = Color.FromArgb(newR, newG, newB);

                    reducedImage.SetPixel(x, y, newColor);
                }
            }

            return reducedImage;
        }
        private void ReduceColorDepth()
        {
            Bitmap originalImage = new Bitmap(pictureBox1.Image);

            // Renk çözünürlüğünü düşür
            int bitDepth = trackBar1.Value;
            Bitmap reducedImage = ReduceColorDepth(originalImage, bitDepth);

            // PictureBox'a göster
           pictureBox2.Image = reducedImage;
        }
       
        
        private int ReduceChannel(int channelValue, int bitDepth)
        {
            int shift = 8 - bitDepth;
            int mask = 0xFF >> shift;
            return (channelValue >> shift) << shift;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ReduceColorDepth();
        }
    }
}
