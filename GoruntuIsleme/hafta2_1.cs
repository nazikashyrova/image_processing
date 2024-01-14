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
    public partial class hafta2_1 : Form
    {
        private Bitmap originalImage;
        public hafta2_1(Form1 form1)
        {
            InitializeComponent();
        }

        private void hafta2_1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";
            openFileDialog.Title = "Bir resim dosyası seçin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                originalImage = new Bitmap(selectedImagePath);
                pictureBox1.Image = originalImage;
                ApplyBrightness(trackBar1.Value);
            }
        }
        private void ApplyBrightness(int brightnessValue)
        {
            if (originalImage != null)
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                    new float[][]
                    {
                        new float[] {1, 0, 0, 0, 0}, // Red
                        new float[] {0, 1, 0, 0, 0}, // Green
                        new float[] {0, 0, 1, 0, 0}, // Blue
                        new float[] {0, 0, 0, 1, 0}, // Alpha
                        new float[] {brightnessValue / 100f, brightnessValue / 100f, brightnessValue / 100f, 0, 1}
                    });

                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix);

                Bitmap adjustedImage = new Bitmap(originalImage.Width, originalImage.Height);

                using (Graphics graphics = Graphics.FromImage(adjustedImage))
                {
                    graphics.DrawImage(originalImage,
                        new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height),
                        0, 0, originalImage.Width, originalImage.Height,
                        GraphicsUnit.Pixel, imageAttributes);
                }

                pictureBox2.Image = adjustedImage;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ApplyBrightness(trackBar1.Value);
        }
    }
}
