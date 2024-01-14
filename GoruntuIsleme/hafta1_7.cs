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
    public partial class hafta1_7 : Form
    {
        private Bitmap originalImage;
        public hafta1_7(Form1 form1)
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }


        private void resim_sec_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.png;*.gif;*.tif|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        originalImage = new Bitmap(openFileDialog.FileName);
                        ana_resim.Image = originalImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim açma hatası: " + ex.Message);
                    }
                }
            }
        }

        private Bitmap CreateArtificialColorImage(Bitmap originalImage)
        {
            int width = originalImage.Width;
            int height = originalImage.Height;

            // Yapay renkli resmi oluştur
            Bitmap artificialImage = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Orijinal renkleri al
                    Color originalColor = originalImage.GetPixel(x, y);

                    // RGB renklerini sırala
                    Color artificialColor = Color.FromArgb(originalColor.G, originalColor.R, originalColor.B);

                    // Yapay renkli resme ata
                    artificialImage.SetPixel(x, y, artificialColor);
                }
            }
            return artificialImage;
        }

        private void yapay_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = CreateArtificialColorImage(originalImage);
        }
    }
}
