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
    public partial class hafta3_13 : Form
    {


        private Rectangle kırpmaAlani;
        private Point baslangicNoktasi;
        private bool ciziliyor = false;

        public hafta3_13(Form1 form1)
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = new Bitmap(pictureBox1.Image);
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ciziliyor = true;
            baslangicNoktasi = e.Location;
            kırpmaAlani = new Rectangle(e.Location, new Size());
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ciziliyor)
            {
                kırpmaAlani.Width = e.X - kırpmaAlani.X;
                kırpmaAlani.Height = e.Y - kırpmaAlani.Y;
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ciziliyor = false;
            if (kırpmaAlani.Width < 1 || kırpmaAlani.Height < 1)
                return;

            Bitmap resim = new Bitmap(pictureBox1.Image);
            Bitmap kırpılmısResim = new Bitmap(kırpmaAlani.Width, kırpmaAlani.Height);

            using (Graphics g = Graphics.FromImage(kırpılmısResim))
            {
                g.DrawImage(resim, new Rectangle(0, 0, kırpmaAlani.Width, kırpmaAlani.Height), kırpmaAlani, GraphicsUnit.Pixel);
            }

            pictureBox2.Image = kırpılmısResim;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (ciziliyor)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetKırpmaAlanı(baslangicNoktasi, Control.MousePosition));
            }
        }

        private Rectangle GetKırpmaAlanı(Point startPoint, Point endPoint)
        {
            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);

            return new Rectangle(x, y, width, height);
        }
    }
}
