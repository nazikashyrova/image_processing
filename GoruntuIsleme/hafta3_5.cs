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
    public partial class hafta3_5 : Form
    {
        public hafta3_5(Form1 form1)
        {
            InitializeComponent();
        }

        private Point ilkNokta;
        private Point ikinciNokta;
        private Bitmap resim;
        private bool ilkNoktaSecildi = false;
        private Pen cetvelKalemi = new Pen(Color.Red, 2);

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap resim = new Bitmap(pictureBox1.Image);

            if (!ilkNoktaSecildi)
            {

                ilkNokta = e.Location;





                ilkNoktaSecildi = true;
            }
            else
            {

                ikinciNokta = e.Location;



                Color OkunanRenk;
                Bitmap GirisResmi, CikisResmi;
                GirisResmi = new Bitmap(pictureBox1.Image);
                int Tx = ilkNokta.X - ikinciNokta.X;
                int Ty = ilkNokta.Y - ikinciNokta.Y;
                int minx, miny, maxx, maxy;
                if (ilkNokta.X > ikinciNokta.X)
                {
                    minx = ikinciNokta.X;
                    maxx = ilkNokta.X;
                }
                else if (ilkNokta.X < ikinciNokta.X)
                {
                    minx = ilkNokta.X;
                    maxx = ikinciNokta.X;
                }
                else return;
                if (ilkNokta.Y > ikinciNokta.Y)
                {
                    miny = ikinciNokta.Y;
                    maxy = ilkNokta.Y;
                }
                else if (ilkNokta.Y < ikinciNokta.Y)
                {
                    miny = ilkNokta.Y;
                    maxy = ikinciNokta.Y;
                }
                else return;

                pictureBox1.Invalidate();
                CikisResmi = new Bitmap(GirisResmi.Height, GirisResmi.Width);


                for (int x1 = minx; x1 < maxx - 1; x1++)
                {
                    for (int y1 = miny; y1 < maxy - 1; y1++)
                    {
                        OkunanRenk = GirisResmi.GetPixel(x1, y1);

                        CikisResmi.SetPixel(x1, y1, OkunanRenk);

                    }
                }
                pictureBox2.Image = CikisResmi;





            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


            int x = Math.Min(ilkNokta.X, ikinciNokta.X);
            int y = Math.Min(ilkNokta.Y, ikinciNokta.Y);
            int width = Math.Abs(ilkNokta.X - ikinciNokta.X);
            int height = Math.Abs(ilkNokta.Y - ikinciNokta.Y);

            Rectangle dikdortgen = new Rectangle(x, y, width, height);
            e.Graphics.DrawRectangle(cetvelKalemi, dikdortgen);

        }
    }
}
