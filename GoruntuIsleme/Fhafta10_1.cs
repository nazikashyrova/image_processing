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
    public partial class Fhafta10_1 : Form
    {
        public Fhafta10_1(Form1 form1)
        {
            InitializeComponent();
        }

        private void Fhafta10_1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                Bitmap originalImage = new Bitmap(imagePath);


                Color targetColor = Color.Red;
                int threshold = 100;


                Bitmap highlightedImage = DetectObject(originalImage, targetColor, threshold);


                pictureBox1.Image = originalImage;
                pictureBox2.Image = highlightedImage;
            }
        }
        private Bitmap DetectObject(Bitmap originalImage, Color targetColor, int threshold)
        {
            int width = originalImage.Width;
            int height = originalImage.Height;

            Bitmap highlightedImage = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);


                    if (Math.Abs(pixelColor.R - targetColor.R) < threshold &&
                        Math.Abs(pixelColor.G - targetColor.G) < threshold &&
                        Math.Abs(pixelColor.B - targetColor.B) < threshold)
                    {

                        highlightedImage.SetPixel(x, y, Color.White);
                    }
                    else
                    {

                        highlightedImage.SetPixel(x, y, pixelColor);
                    }
                }
            }

            return highlightedImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
