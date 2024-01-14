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
    public partial class hafta6_1 : Form
    {
        public hafta6_1(Form1 form1)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                Bitmap originalImage = new Bitmap(imagePath);

                pictureBox1.Image = originalImage;
                Bitmap smoothedImage = ApplyMedianFilter(originalImage);

                pictureBox2.Image = smoothedImage;

            }
        }
        private Bitmap ApplyMedianFilter(Bitmap originalImage)
        {
            int width = originalImage.Width;
            int height = originalImage.Height;

            Bitmap smoothedImage = new Bitmap(width, height);

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    Color[] neighborColors = new Color[9];

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            neighborColors[(i + 1) * 3 + (j + 1)] = originalImage.GetPixel(x + i, y + j);
                        }
                    }

                    Array.Sort(neighborColors, (a, b) => a.GetBrightness().CompareTo(b.GetBrightness()));

                    Color medianColor = neighborColors[4];
                    smoothedImage.SetPixel(x, y, medianColor);
                }
            }

            return smoothedImage;
        }
    }
}
