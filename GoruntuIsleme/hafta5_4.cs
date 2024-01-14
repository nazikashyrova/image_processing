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
    public partial class hafta5_4 : Form
    {
        private Bitmap originalImage;
       
        

        public hafta5_4(Form1 form1)
        {
            InitializeComponent();
            

        }

        private void Form16_Load(object sender, EventArgs e)
        {
           
            
        }
        //Standart sapma, Gauss fonksiyonunun genişliğini ve bu nedenle
        //filtreyi kontrol eder. Daha büyük standart sapma,
        //daha fazla bulanıklık anlamına gelir.

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

        private void gauss_Click(object sender, EventArgs e)
        {

            // Farklı standart sapma değerleri için Gauss filtresini uygula ve sonuçları göster
            Bulaniklastir(1.0, pictureBox2);
            Bulaniklastir(5.0, pictureBox3);
            


        }

        private void Bulaniklastir(double standsapma, PictureBox pictureBox)
        {
            Bitmap bulanikresim = GaussUygula(originalImage, standsapma);
            pictureBox.Image = bulanikresim;
        }
        private Bitmap GaussUygula(Bitmap image, double standsapma)
        {
            int size = (int)Math.Ceiling(standsapma) * 3 * 2 + 1;
            float[,] gaussianMatrix = GaussMatrisiHesapla(size, standsapma);

            Bitmap bulanikresim = new Bitmap(image);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = AgirlikHesapla(image, x, y, gaussianMatrix);
                    bulanikresim.SetPixel(x, y, color);
                }
            }

            return bulanikresim;
        }
        private float[,] GaussMatrisiHesapla(int size, double standsapma)
        {
            float[,] matrix = new float[size, size];
            double sum = 0;
            int halfSize = size / 2;

            for (int x = -halfSize; x <= halfSize; x++)
            {
                for (int y = -halfSize; y <= halfSize; y++)
                {
                    double expX = -(x * x) / (2 * standsapma * standsapma);
                    double expY = -(y * y) / (2 * standsapma * standsapma);
                    double weight = Math.Exp(expX) * Math.Exp(expY) / (2 * Math.PI * standsapma * standsapma);
                    matrix[x + halfSize, y + halfSize] = (float)weight;
                    sum += weight;
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] /= (float)sum;
                }
            }

            return matrix;
        }
        private Color AgirlikHesapla(Bitmap image, int x, int y, float[,] matrix)
        {
            int size = matrix.GetLength(0);
            int halfSize = size / 2;
            double totalWeight = 0;
            double totalRed = 0, totalGreen = 0, totalBlue = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int pixelX = x + i - halfSize;
                    int pixelY = y + j - halfSize;

                    if (pixelX >= 0 && pixelX < image.Width && pixelY >= 0 && pixelY < image.Height)
                    {
                        Color color = image.GetPixel(pixelX, pixelY);
                        float weight = matrix[i, j];
                        totalRed += color.R * weight;
                        totalGreen += color.G * weight;
                        totalBlue += color.B * weight;
                        totalWeight += weight;
                    }
                }
            }

            byte red = (byte)Math.Min(255, Math.Max(0, totalRed / totalWeight));
            byte green = (byte)Math.Min(255, Math.Max(0, totalGreen / totalWeight));
            byte blue = (byte)Math.Min(255, Math.Max(0, totalBlue / totalWeight));

            return Color.FromArgb(red, green, blue);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
