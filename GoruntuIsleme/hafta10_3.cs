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
    public partial class hafta10_3 : Form
    {
        private Bitmap originalImage;
        public hafta10_3(Form1 form1)
        {
            InitializeComponent();
        }

        private void hafta10_3_Load(object sender, EventArgs e)
        {

        }
        private Bitmap MirrorImageWithoutZeroBit(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            Bitmap mirroredImage = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);


                    int newRed = originalColor.R & ~1;
                    int newGreen = originalColor.G & ~1;
                    int newBlue = originalColor.B & ~1;

                    Color newColor = Color.FromArgb(newRed, newGreen, newBlue);
                    mirroredImage.SetPixel(width - x - 1, y, newColor);
                }
            }

            return mirroredImage;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = originalImage;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (originalImage != null)
            {

                Bitmap mirroredImage = MirrorImageWithoutZeroBit(originalImage);
                pictureBox2.Image = mirroredImage;
            }
        }
    }
}
