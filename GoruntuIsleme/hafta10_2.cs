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
    public partial class hafta10_2 : Form
    {
        public hafta10_2(Form1 form1)
        {
            InitializeComponent();
        }

        private void hafta10_2_Load(object sender, EventArgs e)
        {

        }
        
        private Bitmap ConvertTo0Bit(Bitmap originalImage)
        {
            Bitmap convertedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);


                    int newColorValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3 > 128 ? 255 : 0;


                    convertedImage.SetPixel(x, y, Color.FromArgb(newColorValue, newColorValue, newColorValue));
                }
            }

            return convertedImage;
        }
        private Bitmap ConvertTo5Bit(Bitmap originalImage)
        {
            Bitmap convertedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);


                    int red = pixelColor.R >> 3;
                    int green = pixelColor.G >> 3;
                    int blue = pixelColor.B >> 3;


                    int newColorValue = (red << 10) | (green << 5) | blue;


                    convertedImage.SetPixel(x, y, Color.FromArgb(newColorValue));
                }
            }

            return convertedImage;
        }
        private Bitmap CombineImages(Bitmap image1, Bitmap image2)
        {
            int width = Math.Max(image1.Width, image2.Width);
            int height = Math.Max(image1.Height, image2.Height);

            Bitmap combinedImage = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color1 = x < image1.Width && y < image1.Height ? image1.GetPixel(x, y) : Color.Black;
                    Color color2 = x < image2.Width && y < image2.Height ? image2.GetPixel(x, y) : Color.Black;

                    int combinedRed = Math.Min(color1.R + color2.R, 255);
                    int combinedGreen = Math.Min(color1.G + color2.G, 255);
                    int combinedBlue = Math.Min(color1.B + color2.B, 255);

                    combinedImage.SetPixel(x, y, Color.FromArgb(combinedRed, combinedGreen, combinedBlue));
                }
            }

            return combinedImage;
        }
        private Bitmap SubtractImages(Bitmap image1, Bitmap image2)
        {
            int width = Math.Max(image1.Width, image2.Width);
            int height = Math.Max(image1.Height, image2.Height);

            Bitmap subtractedImage = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color1 = x < image1.Width && y < image1.Height ? image1.GetPixel(x, y) : Color.Black;
                    Color color2 = x < image2.Width && y < image2.Height ? image2.GetPixel(x, y) : Color.Black;

                    int subtractedRed = Math.Max(color1.R - color2.R, 0);
                    int subtractedGreen = Math.Max(color1.G - color2.G, 0);
                    int subtractedBlue = Math.Max(color1.B - color2.B, 0);

                    subtractedImage.SetPixel(x, y, Color.FromArgb(subtractedRed, subtractedGreen, subtractedBlue));
                }
            }

            return subtractedImage;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                string dosyaYolu1 = openFileDialog.FileName;


                Bitmap sifirBitlikResim1 = ConvertTo0Bit(new Bitmap(dosyaYolu1));
                Bitmap besBitlikResim1 = ConvertTo5Bit(new Bitmap(dosyaYolu1));



                pictureBox1.Image = sifirBitlikResim1;
                pictureBox2.Image = besBitlikResim1;



                Bitmap yeniResim1 = CombineImages(sifirBitlikResim1, besBitlikResim1);


                Bitmap yeniResim2 = SubtractImages(besBitlikResim1, sifirBitlikResim1);


                pictureBox3.Image = yeniResim1;
                pictureBox4.Image = yeniResim2;

            }
        }
    }
}
