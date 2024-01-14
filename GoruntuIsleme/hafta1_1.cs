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
    public partial class hafta1_1 : Form
    {
        int N = 255;
        int M = 255;
        int deger = 255;

        public hafta1_1(Form1 form1)
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DrawGrayScaleImage();
        }

        private void DrawGrayScaleImage()
        {
            Bitmap grayScaleImage = new Bitmap(N, M);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    int grayValue = (int)Math.Floor((double)(i * M + j) * deger / (N * M - 1));
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    grayScaleImage.SetPixel(i, j, grayColor);
                }
            }

            // PictureBox üzerinde görüntüyü göster
            pictureBox1.Image = grayScaleImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

        
    }

