using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GoruntuIsleme
{
    public partial class hafta5_3 : Form
    {
       
        private Bitmap originalImage;
        private Rectangle selectedRegion;
        private bool isMouseDown = false;
        public hafta5_3(Form1 form1)
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            // PictureBox'a MouseDown, MouseMove ve MouseUp olaylarını ekleyin
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Mouse tıklandığında başlangıç noktasını kaydet
            isMouseDown = true;
            selectedRegion = new Rectangle(e.Location, new Size(0, 0));
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Mouse hareket ettiğinde seçim alanını güncelle
            if (isMouseDown)
            {
                selectedRegion.Width = e.X - selectedRegion.X;
                selectedRegion.Height = e.Y - selectedRegion.Y;

                pictureBox1.Invalidate(); // PictureBox'ı yeniden çiz
            }
            }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // Mouse bırakıldığında işlemleri tamamla
            isMouseDown = false;

            // Seçili bölge içindeki resmi al
            if (selectedRegion.Width > 0 && selectedRegion.Height > 0)
            {
                // Tüm resmi al
                Bitmap fullImage = new Bitmap(originalImage);

                // Seçili bölgeyi blurla
                ApplyBlurToSelectedRegion(fullImage);

                // PictureBox2'ye atama işlemi
                pictureBox2.Image = fullImage;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Mouse hareketi sırasında seçili bölgeyi göster
            if (isMouseDown)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, selectedRegion);
                }
            }
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
        private void ApplyBlurToSelectedRegion(Bitmap image)
        {
            if (selectedRegion.Width > 0 && selectedRegion.Height > 0)
            {
                // Seçili bölgeyi al
                Bitmap selectedRegionImage = image.Clone(selectedRegion, image.PixelFormat);

                // Seçili bölgeyi blurla
                Bitmap blurredRegion = ApplyGaussianBlur(selectedRegionImage, 2.0); // 2.0, blur miktarını belirten bir örnek değerdir

                // Blurlanmış bölgeyi orijinal resmin üzerine yerleştir
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawImage(blurredRegion, selectedRegion.Location);
                }
            }
        }

        private Bitmap ApplyGaussianBlur(Bitmap image, double sigma)
        {
            int size = (int)Math.Ceiling(sigma) * 3 * 2 + 1;
            float[,] gaussianMatrix = GenerateGaussianMatrix(size, sigma);

            Bitmap blurredImage = new Bitmap(image);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = CalculateWeightedAverage(image, x, y, gaussianMatrix);
                    blurredImage.SetPixel(x, y, color);
                }
            }

            return blurredImage;
        }
        private float[,] GenerateGaussianMatrix(int size, double sigma)
        {
            float[,] matrix = new float[size, size];
            double sum = 0;
            int halfSize = size / 2;

            for (int x = -halfSize; x <= halfSize; x++)
            {
                for (int y = -halfSize; y <= halfSize; y++)
                {
                    double exponent = -(x * x + y * y) / (2 * sigma * sigma);
                    double weight = Math.Exp(exponent) / (2 * Math.PI * sigma * sigma);
                    matrix[x + halfSize, y + halfSize] = (float)weight;
                    sum += weight;
                }
            }
            // Normalize the matrix
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] /= (float)sum;
                }
            }

            return matrix;
        }
        private Color CalculateWeightedAverage(Bitmap image, int x, int y, float[,] matrix)
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
    }
}