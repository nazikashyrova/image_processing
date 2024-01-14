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
    public partial class hafta3_4 : Form
    {
        public hafta3_4(Form1 form1)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int BuyutmeKatsayisi = Convert.ToInt32(textBox1.Text);
            int x2 = 0, y2 = 0;
            for (int x1 = 0; x1 < ResimGenisligi; x1++)
            {
                for (int y1 = 0; y1 < ResimYuksekligi; y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);
                    for (int i = 0; i < BuyutmeKatsayisi; i++)
                    {
                        for (int j = 0; j < BuyutmeKatsayisi; j++)
                        {
                            x2 = x1 * BuyutmeKatsayisi + i;
                            y2 = y1 * BuyutmeKatsayisi + j;
                            if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi) CikisResmi.SetPixel(x2, y2, OkunanRenk);
                        }
                    }
                }
            }
            pictureBox2.Image = CikisResmi;
        }
    }
}
