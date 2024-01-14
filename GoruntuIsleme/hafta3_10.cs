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
    public partial class hafta3_10 : Form
    {
        private Point mouseBaslangicKonumu;
        private Point resimOrtaNokta;
        private bool donduruluyor = false;
        private Bitmap orijinalResim;
        private float donmeAcisi = 0.0f;

        public hafta3_10(Form1 form1)
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            orijinalResim = new Bitmap(pictureBox1.Image); // Resminizin yolunu uygun şekilde belirtin
            pictureBox1.Image = orijinalResim;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                donduruluyor = true;
                mouseBaslangicKonumu = e.Location;
                resimOrtaNokta = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (donduruluyor)
            {
                float deltaX = e.Location.X - mouseBaslangicKonumu.X;
                float deltaY = e.Location.Y - mouseBaslangicKonumu.Y;

                float yeniDonmeAcisi = (float)(Math.Atan2(deltaY, deltaX) * 180 / Math.PI);
                donmeAcisi = yeniDonmeAcisi;

                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                donduruluyor = false;
                pictureBox1.Image = DondurulmusResim(orijinalResim, donmeAcisi);
            }
        }

        private Bitmap DondurulmusResim(Bitmap resim, float aci)
        {
            Bitmap yeniResim = new Bitmap(resim.Width, resim.Height);

            using (Graphics g = Graphics.FromImage(yeniResim))
            {
                g.TranslateTransform(resim.Width / 2, resim.Height / 2);
                g.RotateTransform(aci);
                g.TranslateTransform(-resim.Width / 2, -resim.Height / 2);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(resim, Point.Empty);
            }

            return yeniResim;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (donduruluyor)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.TranslateTransform(resimOrtaNokta.X, resimOrtaNokta.Y);
                    e.Graphics.RotateTransform(donmeAcisi);
                    e.Graphics.TranslateTransform(-resimOrtaNokta.X, -resimOrtaNokta.Y);
                    e.Graphics.DrawRectangle(pen, 0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height);
                }
            }
        }
    }
}
