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
    public partial class hafta3_7 : Form
    {
        private Point tıklananNokta;
        public hafta3_7(Form1 form1)
        {
            InitializeComponent();
            pictureBox1.MouseClick += PictureBox1_MouseClick;
            tıklananNokta = Point.Empty;
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // PictureBox üzerinde tıklanan noktayı al
            tıklananNokta = e.Location;

            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int Aci = Convert.ToInt16(textBox1.Text);
            double RadyanAci = Aci * 2 * Math.PI / 360;
            double x2 = 0, y2 = 0;
            int x0 = tıklananNokta.X;
            int y0 = tıklananNokta.Y;
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);

                    x2 = Math.Cos(RadyanAci) * (x1 - x0) - Math.Sin(RadyanAci) * (y1 - y0) + x0;
                    y2 = Math.Sin(RadyanAci) * (x1 - x0) + Math.Cos(RadyanAci) * (y1 - y0) + y0;
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }
    }
}
