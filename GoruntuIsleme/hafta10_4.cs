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
    public partial class hafta10_4 : Form
    {
        private Bitmap originalImage;
        public hafta10_4(Form1 form1)
        {
            InitializeComponent();
        }

        private void hafta10_4_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = originalImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {

                Bitmap shiftedImage = RightShiftImage(originalImage);
                pictureBox2.Image = shiftedImage;
            }
        }
        private Bitmap RightShiftImage(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            Bitmap shiftedImage = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);


                    int newRed = originalColor.R >> 1;
                    int newGreen = originalColor.G >> 1;
                    int newBlue = originalColor.B >> 1;

                    Color newColor = Color.FromArgb(newRed, newGreen, newBlue);
                    shiftedImage.SetPixel(x, y, newColor);
                }
            }

            return shiftedImage;
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

                Bitmap shiftedImage = RightShiftImage(originalImage);
                pictureBox2.Image = shiftedImage;
            }
        }
    }
}
