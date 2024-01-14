
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoruntuIsleme
{
    public partial class hafta5_6a : Form
    {
        private Bitmap originalImage;
        private int blurRadius;
        int blurAmount = 5;
        public hafta5_6a(Form1 form1)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.pictureBox1.Paint += PictureBox1_Paint;
            this.pictureBox1.MouseMove += PictureBox1_MouseMove;
        
        }

        private void hafta5_6a_Load(object sender, EventArgs e)
        {
           
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            blurRadius = hScrollBar1.Value; // Varsayılan blur yarıçapı
            ApplyBlurToRegion();

        }

      
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Mouse hareketi sırasında seçili bölgeyi göster
            Point mouseLocation = pictureBox1.PointToClient(Cursor.Position);
            int diameter = 2 * blurRadius;

            using (Pen pen = new Pen(Color.Red, 2))
            {
                // Graphics nesnesi üzerine yuvarlak çiz
                e.Graphics.DrawEllipse(pen, mouseLocation.X - blurRadius, mouseLocation.Y - blurRadius, diameter, diameter);
            }
        }
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Mouse hareket ettiğinde blur işlemini gerçekleştir
            if (e.Button == MouseButtons.Left)
            {
                ApplyBlurToRegion();
            }
        }
        private void ApplyBlurToRegion()
        {
            if (originalImage != null)
            {
                // Seçili bölgeyi al
                Point mouseLocation = pictureBox1.PointToClient(Cursor.Position);
                Rectangle blurRectangle = new Rectangle(
                    mouseLocation.X - blurRadius,
                    mouseLocation.Y - blurRadius,
                    2 * blurRadius,
                    2 * blurRadius
                );

                // Seçili bölgeyi blurla
                Bitmap blurredRegion = ApplyMeanBlur(originalImage.Clone(blurRectangle, originalImage.PixelFormat), 2.0);

                // Blurlanmış bölgeyi orijinal resmin üzerine yerleştir
                using (Graphics g = Graphics.FromImage(originalImage))
                {
                    g.DrawImage(blurredRegion, blurRectangle.Location);
                }

                // PictureBox'ı güncelle
                pictureBox1.Invalidate();
            }
        }
        private Bitmap ApplyMeanBlur(Bitmap inputImage, double factor)
        {
            Bitmap resultImage = new Bitmap(inputImage);

            int kernelSize = (int)(blurRadius * factor); // Blur çekirdek boyutu

            for (int x = 0; x < inputImage.Width; x++)
            {
                for (int y = 0; y < inputImage.Height; y++)
                {
                    resultImage.SetPixel(x, y, CalculateMeanColor(inputImage, x, y, kernelSize));
                }
            }

            return resultImage;
        }
        private Color CalculateMeanColor(Bitmap image, int x, int y, int kernelSize)
        {
            int halfKernel = kernelSize / 2;

            int totalR = 0, totalG = 0, totalB = 0;

            for (int i = -halfKernel; i <= halfKernel; i++)
            {
                for (int j = -halfKernel; j <= halfKernel; j++)
                {
                    int newX = x + i;
                    int newY = y + j;

                    if (newX >= 0 && newX < image.Width && newY >= 0 && newY < image.Height)
                    {
                        Color pixelColor = image.GetPixel(newX, newY);
                        totalR += pixelColor.R;
                        totalG += pixelColor.G;
                        totalB += pixelColor.B;
                    }
                }
            }

            int averageR = totalR / (kernelSize * kernelSize);
            int averageG = totalG / (kernelSize * kernelSize);
            int averageB = totalB / (kernelSize * kernelSize);

            return Color.FromArgb(averageR, averageG, averageB);
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            int blurAmount = hScrollBar1.Value;

            Bitmap tempImage = new Bitmap(originalImage);

            for (int x = coordinates.X - blurAmount; x < coordinates.X + blurAmount; x++)
            {
                for (int y = coordinates.Y - blurAmount; y < coordinates.Y + blurAmount; y++)
                {
                    try
                    {
                        int newX = Math.Max(0, Math.Min(originalImage.Width - 1, x));
                        int newY = Math.Max(0, Math.Min(originalImage.Height - 1, y));

                        Color prevX = originalImage.GetPixel(newX - blurAmount, newY);
                        Color nextX = originalImage.GetPixel(newX + blurAmount, newY);
                        Color prevY = originalImage.GetPixel(newX, newY - blurAmount);
                        Color nextY = originalImage.GetPixel(newX, newY + blurAmount);

                        int avgR = (int)((prevX.R + nextX.R + prevY.R + nextY.R) / 4.0);
                        int avgG = (int)((prevX.G + nextX.G + prevY.G + nextY.G) / 4.0);
                        int avgB = (int)((prevX.B + nextX.B + prevY.B + nextY.B) / 4.0);

                        tempImage.SetPixel(newX, newY, Color.FromArgb(Math.Max(0, Math.Min(255, avgR)), Math.Max(0, Math.Min(255, avgG)), Math.Max(0, Math.Min(255, avgB))));
                    }
                    catch (Exception) { }
                }
            }

            pictureBox1.Image = tempImage;
        }
    }
  }

