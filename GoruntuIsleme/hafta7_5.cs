using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GoruntuIsleme
{
    public partial class hafta7_5 : Form
    {
        private Bitmap canvas;
        public hafta7_5(Form1 form1)
        {
            InitializeComponent();
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = canvas;
        }

        private void hafta7_5_Load(object sender, EventArgs e)
        {

        }
        private void DrawLine()
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.Black);


                Pen pen = new Pen(Color.White);
                g.DrawLine(pen, 50, 100, 250, 200);
            }
            pictureBox1.Refresh();
        }
        private void CalculateAngleSobel()
        {

            double angle = CalculateSobelAngle(canvas);
            textBox1.Text = angle.ToString();
        }
        private void CalculateAngleCompass()
        {

            double angle = CalculateCompassAngle(canvas);
            textBox2.Text = angle.ToString();
        }
        private double CalculateSobelAngle(Bitmap image)
        {

            int[,] sobelX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] sobelY = { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            int width = image.Width;
            int height = image.Height;

            double angleSumX = 0;
            double angleSumY = 0;

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    Color pixel00 = image.GetPixel(x - 1, y - 1);
                    Color pixel01 = image.GetPixel(x, y - 1);
                    Color pixel02 = image.GetPixel(x + 1, y - 1);
                    Color pixel10 = image.GetPixel(x - 1, y);
                    Color pixel11 = image.GetPixel(x, y);
                    Color pixel12 = image.GetPixel(x + 1, y);
                    Color pixel20 = image.GetPixel(x - 1, y + 1);
                    Color pixel21 = image.GetPixel(x, y + 1);
                    Color pixel22 = image.GetPixel(x + 1, y + 1);

                    int gx = (sobelX[0, 0] * pixel00.R + sobelX[0, 1] * pixel01.R + sobelX[0, 2] * pixel02.R +
                              sobelX[1, 0] * pixel10.R + sobelX[1, 1] * pixel11.R + sobelX[1, 2] * pixel12.R +
                              sobelX[2, 0] * pixel20.R + sobelX[2, 1] * pixel21.R + sobelX[2, 2] * pixel22.R);

                    int gy = (sobelY[0, 0] * pixel00.R + sobelY[0, 1] * pixel01.R + sobelY[0, 2] * pixel02.R +
                              sobelY[1, 0] * pixel10.R + sobelY[1, 1] * pixel11.R + sobelY[1, 2] * pixel12.R +
                              sobelY[2, 0] * pixel20.R + sobelY[2, 1] * pixel21.R + sobelY[2, 2] * pixel22.R);

                    angleSumX += gx * gx;
                    angleSumY += gy * gy;
                }
            }

            double angleRadians = Math.Atan2(angleSumY, angleSumX);
            double angleDegrees = angleRadians * (180.0 / Math.PI);

            return angleDegrees;
        }
        private double CalculateCompassAngle(Bitmap image)
        {

            int[,] compass = { { -1, -1, 0 }, { -1, 1, 1 }, { 0, 1, 1 } };

            int width = image.Width;
            int height = image.Height;

            double angleSum = 0;

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    Color pixel00 = image.GetPixel(x - 1, y - 1);
                    Color pixel01 = image.GetPixel(x, y - 1);
                    Color pixel02 = image.GetPixel(x + 1, y - 1);
                    Color pixel10 = image.GetPixel(x - 1, y);
                    Color pixel11 = image.GetPixel(x, y);
                    Color pixel12 = image.GetPixel(x + 1, y);
                    Color pixel20 = image.GetPixel(x - 1, y + 1);
                    Color pixel21 = image.GetPixel(x, y + 1);
                    Color pixel22 = image.GetPixel(x + 1, y + 1);

                    int sum = (compass[0, 0] * pixel00.R + compass[0, 1] * pixel01.R + compass[0, 2] * pixel02.R +
                               compass[1, 0] * pixel10.R + compass[1, 1] * pixel11.R + compass[1, 2] * pixel12.R +
                               compass[2, 0] * pixel20.R + compass[2, 1] * pixel21.R + compass[2, 2] * pixel22.R);

                    angleSum += Math.Abs(sum);
                }
            }

            double angleRadians = Math.Atan(angleSum);
            double angleDegrees = angleRadians * (180.0 / Math.PI);

            return angleDegrees;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DrawLine();
            CalculateAngleSobel();
            CalculateAngleCompass();
        }
    }
}
