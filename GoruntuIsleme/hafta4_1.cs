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
    public partial class hafta4_1 : Form
    {
        public hafta4_1(Form1 form1)
        {
            InitializeComponent();
        }
        public double[,] MatrisTersiniAl(double[,] GirisMatrisi)
        {
            int MatrisBoyutu = Convert.ToInt16(Math.Sqrt(GirisMatrisi.Length));
            double[,] CikisMatrisi = new double[MatrisBoyutu, MatrisBoyutu];
            for (int i = 0; i < MatrisBoyutu; i++)
            {
                for (int j = 0; j < MatrisBoyutu; j++)
                {
                    if (i == j)
                        CikisMatrisi[i, j] = 1;
                    else
                        CikisMatrisi[i, j] = 0;
                }
            }
            double d, k;
            for (int i = 0; i < MatrisBoyutu; i++)
            {
                d = GirisMatrisi[i, i];

                for (int j = 0; j < MatrisBoyutu; j++)
                {
                    if (d == 0)
                    {
                        d = 0.0001;
                    }
                    GirisMatrisi[i, j] = GirisMatrisi[i, j] / d; CikisMatrisi[i, j] = CikisMatrisi[i, j] / d;
                }
                for (int x = 0; x < MatrisBoyutu; x++)
                {
                    if (x != i)
                    {
                        k = GirisMatrisi[x, i];
                        for (int j = 0; j < MatrisBoyutu; j++)
                        {
                            GirisMatrisi[x, j] = GirisMatrisi[x, j] - GirisMatrisi[i, j] * k; CikisMatrisi[x, j] = CikisMatrisi[x, j] - CikisMatrisi[i, j] * k;
                        }
                    }
                }
            }
            return CikisMatrisi;
        }

        public void PerspektifDuzelt(double a00, double a01, double a02, double a10, double a11, double a12, double a20, double a21, double a22)
        {
            Bitmap GirisResmi, CikisResmi;
            Color OkunanRenk;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;

            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            double X, Y, z;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    z = a20 * x + a21 * y + 1;
                    X = (a00 * x + a01 * y + a02) / z; Y = (a10 * x + a11 * y + a12) / z;

                    if (X > 0 && X < ResimGenisligi && Y > 0 && Y < ResimYuksekligi)



                        CikisResmi.SetPixel((int)X, (int)Y, OkunanRenk);

                }
            }
            pictureBox2.Image = CikisResmi;

        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int xCoordinate = e.X;
            int yCoordinate = e.Y;


            points.Add(new Point(xCoordinate, yCoordinate));


            if (points.Count == 1)
            {
                textBox1.Text = Convert.ToString(xCoordinate);
                textBox5.Text = Convert.ToString(yCoordinate);
            }
            else if (points.Count == 2)
            {
                textBox2.Text = Convert.ToString(xCoordinate);
                textBox6.Text = Convert.ToString(yCoordinate);
            }
            else if (points.Count == 3)
            {
                textBox3.Text = Convert.ToString(xCoordinate);
                textBox7.Text = Convert.ToString(yCoordinate);
            }
            else if (points.Count == 4)
            {
                textBox4.Text = Convert.ToString(xCoordinate);
                textBox8.Text = Convert.ToString(yCoordinate);



            }
            else if (points.Count == 5)
            {
                textBox16.Text = Convert.ToString(xCoordinate);
                textBox12.Text = Convert.ToString(yCoordinate);
            }
            else if (points.Count == 6)
            {
                textBox15.Text = Convert.ToString(xCoordinate);
                textBox11.Text = Convert.ToString(yCoordinate);
            }
            else if (points.Count == 7)
            {
                textBox14.Text = Convert.ToString(xCoordinate);
                textBox10.Text = Convert.ToString(yCoordinate);
            }
            else if (points.Count == 8)
            {
                textBox13.Text = Convert.ToString(xCoordinate);
                textBox9.Text = Convert.ToString(yCoordinate);
                pictureBox1.MouseClick -= PictureBox_MouseClick;
            }
        }









        private List<Point> points = new List<Point>();
        
        public Color GetAverageColor(Bitmap image, int x, int y)
        {
            int totalRed = 0;
            int totalGreen = 0;
            int totalBlue = 0;

            for (int offsetY = -1; offsetY <= 1; offsetY++)
            {
                for (int offsetX = -1; offsetX <= 1; offsetX++)
                {
                    Color neighborColor = image.GetPixel(x + offsetX, y + offsetY);

                    totalRed += neighborColor.R;
                    totalGreen += neighborColor.G;
                    totalBlue += neighborColor.B;
                }
            }

            // Ortalamayý al
            int averageRed = totalRed / 9;
            int averageGreen = totalGreen / 9;
            int averageBlue = totalBlue / 9;

            return Color.FromArgb(averageRed, averageGreen, averageBlue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(textBox1.Text);
            double y1 = Convert.ToDouble(textBox5.Text);
            double x2 = Convert.ToDouble(textBox2.Text);
            double y2 = Convert.ToDouble(textBox6.Text);
            double x3 = Convert.ToDouble(textBox3.Text);
            double y3 = Convert.ToDouble(textBox7.Text);
            double x4 = Convert.ToDouble(textBox4.Text);
            double y4 = Convert.ToDouble(textBox8.Text);
            double X1 = Convert.ToDouble(textBox16.Text);
            double Y1 = Convert.ToDouble(textBox12.Text);
            double X2 = Convert.ToDouble(textBox15.Text);
            double Y2 = Convert.ToDouble(textBox11.Text);
            double X3 = Convert.ToDouble(textBox14.Text);
            double Y3 = Convert.ToDouble(textBox10.Text);
            double X4 = Convert.ToDouble(textBox13.Text);
            double Y4 = Convert.ToDouble(textBox9.Text);

            /*double x1 = Convert.ToDouble(65);
            double y1 = Convert.ToDouble(39);
            double x2 = Convert.ToDouble(132);
            double y2 = Convert.ToDouble(19);
            double x3 = Convert.ToDouble(137);
            double y3 = Convert.ToDouble(181);
            double x4 = Convert.ToDouble(56);
            double y4 = Convert.ToDouble(185);
            double X1 = Convert.ToDouble(61);
            double Y1 = Convert.ToDouble(3);
            double X2 = Convert.ToDouble(150);
            double Y2 = Convert.ToDouble(0);
            double X3 = Convert.ToDouble(158);
            double Y3 = Convert.ToDouble(272);
            double X4 = Convert.ToDouble(31);
            double Y4 = Convert.ToDouble(271);*/

            double[,] GirisMatrisi = new double[8, 8];

            GirisMatrisi[0, 0] = x1;
            GirisMatrisi[0, 1] = y1;
            GirisMatrisi[0, 2] = 1;
            GirisMatrisi[0, 3] = 0;
            GirisMatrisi[0, 4] = 0;
            GirisMatrisi[0, 5] = 0;
            GirisMatrisi[0, 6] = -x1 * X1;
            GirisMatrisi[0, 7] = -y1 * X1;

            GirisMatrisi[1, 0] = 0;
            GirisMatrisi[1, 1] = 0;
            GirisMatrisi[1, 2] = 0;
            GirisMatrisi[1, 3] = x1;
            GirisMatrisi[1, 4] = y1;
            GirisMatrisi[1, 5] = 1;
            GirisMatrisi[1, 6] = -x1 * Y1;
            GirisMatrisi[1, 7] = -y1 * Y1;

            GirisMatrisi[2, 0] = x2;
            GirisMatrisi[2, 1] = y2;
            GirisMatrisi[2, 2] = 1;
            GirisMatrisi[2, 3] = 0;
            GirisMatrisi[2, 4] = 0;
            GirisMatrisi[2, 5] = 0;
            GirisMatrisi[2, 6] = -x2 * X2;
            GirisMatrisi[2, 7] = -y2 * X2;

            GirisMatrisi[3, 0] = 0;
            GirisMatrisi[3, 1] = 0;
            GirisMatrisi[3, 2] = 0;
            GirisMatrisi[3, 3] = x2;
            GirisMatrisi[3, 4] = y2;
            GirisMatrisi[3, 5] = 1;
            GirisMatrisi[3, 6] = -x2 * Y2;
            GirisMatrisi[3, 7] = -y2 * Y2;

            GirisMatrisi[4, 0] = x3;
            GirisMatrisi[4, 1] = y3;
            GirisMatrisi[4, 2] = 1;
            GirisMatrisi[4, 3] = 0;
            GirisMatrisi[4, 4] = 0;
            GirisMatrisi[4, 5] = 0;
            GirisMatrisi[4, 6] = -x3 * X3;
            GirisMatrisi[4, 7] = -y3 * X3;

            GirisMatrisi[5, 0] = 0;
            GirisMatrisi[5, 1] = 0;
            GirisMatrisi[5, 2] = 0;
            GirisMatrisi[5, 3] = x3;
            GirisMatrisi[5, 4] = y3;
            GirisMatrisi[5, 5] = 1;
            GirisMatrisi[5, 6] = -x3 * Y3;
            GirisMatrisi[5, 7] = -y3 * Y3;

            GirisMatrisi[6, 0] = x4;
            GirisMatrisi[6, 1] = y4;
            GirisMatrisi[6, 2] = 1;
            GirisMatrisi[6, 3] = 0;
            GirisMatrisi[6, 4] = 0;
            GirisMatrisi[6, 5] = 0;
            GirisMatrisi[6, 6] = -x4 * X4;
            GirisMatrisi[6, 7] = -y4 * X4;

            GirisMatrisi[7, 0] = 0;
            GirisMatrisi[7, 1] = 0;
            GirisMatrisi[7, 2] = 0;
            GirisMatrisi[7, 3] = x4;
            GirisMatrisi[7, 4] = y4;
            GirisMatrisi[7, 5] = 1;
            GirisMatrisi[7, 6] = -x4 * Y4;
            GirisMatrisi[7, 7] = -y4 * Y4;

            double[,] matrisTers = MatrisTersiniAl(GirisMatrisi);
            double a00 = 0;
            double a01 = 0;
            double a02 = 0;
            double a10 = 0;
            double a11 = 0;
            double a12 = 0;
            double a20 = 0;
            double a21 = 0;
            double a22 = 0;

            a00 = matrisTers[0, 0] * X1 + matrisTers[0, 1] * Y1 + matrisTers[0, 2] * X2 + matrisTers[0, 3] * Y2 + matrisTers[0, 4] * X3 + matrisTers[0, 5] * Y3 + matrisTers[0, 6] * X4 + matrisTers[0, 7] * Y4;
            a01 = matrisTers[1, 0] * X1 + matrisTers[1, 1] * Y1 + matrisTers[1, 2] * X2 + matrisTers[1, 3] * Y2 + matrisTers[1, 4] * X3 + matrisTers[1, 5] * Y3 + matrisTers[1, 6] * X4 + matrisTers[1, 7] * Y4;
            a02 = matrisTers[2, 0] * X1 + matrisTers[2, 1] * Y1 + matrisTers[2, 2] * X2 + matrisTers[2, 3] * Y2 + matrisTers[2, 4] * X3 + matrisTers[2, 5] * Y3 + matrisTers[2, 6] * X4 + matrisTers[2, 7] * Y4;
            a10 = matrisTers[3, 0] * X1 + matrisTers[3, 1] * Y1 + matrisTers[3, 2] * X2 + matrisTers[3, 3] * Y2 + matrisTers[3, 4] * X3 + matrisTers[3, 5] * Y3 + matrisTers[3, 6] * X4 + matrisTers[3, 7] * Y4;
            a11 = matrisTers[4, 0] * X1 + matrisTers[4, 1] * Y1 + matrisTers[4, 2] * X2 + matrisTers[4, 3] * Y2 + matrisTers[4, 4] * X3 + matrisTers[4, 5] * Y3 + matrisTers[4, 6] * X4 + matrisTers[4, 7] * Y4;
            a12 = matrisTers[5, 0] * X1 + matrisTers[5, 1] * Y1 + matrisTers[5, 2] * X2 + matrisTers[5, 3] * Y2 + matrisTers[5, 4] * X3 + matrisTers[5, 5] * Y3 + matrisTers[5, 6] * X4 + matrisTers[5, 7] * Y4;
            a20 = matrisTers[6, 0] * X1 + matrisTers[6, 1] * Y1 + matrisTers[6, 2] * X2 + matrisTers[6, 3] * Y2 + matrisTers[6, 4] * X3 + matrisTers[6, 5] * Y3 + matrisTers[6, 6] * X4 + matrisTers[6, 7] * Y4;
            a21 = matrisTers[7, 0] * X1 + matrisTers[7, 1] * Y1 + matrisTers[7, 2] * X2 + matrisTers[7, 3] * Y2 + matrisTers[7, 4] * X3 + matrisTers[7, 5] * Y3 + matrisTers[7, 6] * X4 + matrisTers[7, 7] * Y4;
            a22 = 1;




            PerspektifDuzelt(a00, a01, a02, a10, a11, a12, a20, a21, a22);

            //Düzeltme
            Bitmap cks_rsm = new Bitmap(pictureBox2.Image);
            for (int i = 1; i < pictureBox2.Image.Width - 1; i++)
            {
                for (int j = 1; j < pictureBox2.Image.Height - 1; j++)
                {
                    Color pixel_color = cks_rsm.GetPixel(i, j);

                    if (pixel_color.R == 0 && pixel_color.G == 0 && pixel_color.B == 0)
                    {
                        Color avgcolor = GetAverageColor(cks_rsm, i, j);
                        cks_rsm.SetPixel(i, j, avgcolor);

                    }

                }
            }
            pictureBox3.Image = cks_rsm;





        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyasý |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {
                string DosyaYolu = dosya.FileName;
                pictureBox1.ImageLocation = DosyaYolu;
            }
        }



    }
}
