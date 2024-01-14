using System;
using System.Collections;
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
    public partial class hafta2_4 : Form
    {
        public hafta2_4(Form1 form1)
        {
            InitializeComponent();
        }

        public void Histogram(object sender, EventArgs e)
        {
            ArrayList DiziPiksel = new ArrayList();
            int OrtalamaRenk = 0;
            Color OkunanRenk;
            Bitmap GirisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            for (int x = 0; x < GirisResmi.Width; x++)
            {
                for (int y = 0; y < GirisResmi.Height; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    OrtalamaRenk = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3;
                    DiziPiksel.Add(OrtalamaRenk);
                }
            }

            int[] DiziPikselSayilari = new int[256];
            for (int r = 0; r <= 255; r++)
            {
                int PikselSayisi = 0;
                for (int s = 0; s < DiziPiksel.Count; s++)
                {
                    if (r == Convert.ToInt16(DiziPiksel[s]))
                        PikselSayisi++;
                }
                DiziPikselSayilari[r] = PikselSayisi;
            }

            int RenkMaksPikselSayisi = 0;
            for (int k = 0; k <= 255; k++)
            {
                if (DiziPikselSayilari[k] > RenkMaksPikselSayisi)
                {
                    RenkMaksPikselSayisi = DiziPikselSayilari[k];
                }
            }
            int max = 255;
            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Yellow, 1);
            Pen Kalem2 = new Pen(System.Drawing.Color.Red, 1);
            CizimAlani = pictureBox2.CreateGraphics();

            pictureBox2.Refresh();
            int GrafikYuksekligi = 250;
            double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi;
            double OlcekX = 2.5;
            int X_kaydirma = 20;
            for (int x = 0; x <= 255; x++)
            {

                if (x <= max)
                {
                    CizimAlani.DrawLine(Kalem1, (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi,
                        (int)(X_kaydirma + x * OlcekX), (GrafikYuksekligi - (int)(DiziPikselSayilari[x] / OlcekY)));
                }
                else
                {

                    CizimAlani.DrawLine(Kalem1, (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi,
                        (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi);
                }
            }

        }


        private void Contrast(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int X1 = Convert.ToInt16(textBox1.Text);
            int Y1 = Convert.ToInt16(textBox2.Text);
            int X2 = Convert.ToInt16(textBox3.Text);
            int Y2 = Convert.ToInt16(textBox4.Text);
            int i = 0, j = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);

                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;
                    int Gri = (R + G + B) / 3;
                    //*********** Kontrast Formülü***************
                    int X = Gri;
                    int Y = (((X - X1) * (Y2 - Y1) / (X2 - X1) + Y1));
                    if (Y > 255) Y = 255;
                    if (Y < 0) Y = 0;
                    DonusenRenk = Color.FromArgb(Y, Y, Y); CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox3.Refresh();
            pictureBox3.Image = null;
            pictureBox3.Image = CikisResmi;
            NewHistogram(sender, e);
        }

        public void NewHistogram(object sender, EventArgs e)
        {
            ArrayList DiziPiksel = new ArrayList();
            int OrtalamaRenk = 0;
            Color OkunanRenk;
            Bitmap GirisResmi;
            GirisResmi = new Bitmap(pictureBox3.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            for (int x = 0; x < GirisResmi.Width; x++)
            {
                for (int y = 0; y < GirisResmi.Height; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    OrtalamaRenk = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3;
                    DiziPiksel.Add(OrtalamaRenk);
                }
            }

            int[] DiziPikselSayilari = new int[256];
            for (int r = 0; r <= 255; r++)
            {
                int PikselSayisi = 0;
                for (int s = 0; s < DiziPiksel.Count; s++)
                {
                    if (r == Convert.ToInt16(DiziPiksel[s]))
                        PikselSayisi++;
                }
                DiziPikselSayilari[r] = PikselSayisi;
            }

            int RenkMaksPikselSayisi = 0;
            for (int k = 0; k <= 255; k++)
            {
                if (DiziPikselSayilari[k] > RenkMaksPikselSayisi)
                {
                    RenkMaksPikselSayisi = DiziPikselSayilari[k];
                }
            }
            int max = 255;
            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Yellow, 1);
            Pen Kalem2 = new Pen(System.Drawing.Color.Red, 1);
            CizimAlani = pictureBox4.CreateGraphics();

            pictureBox4.Refresh();
            int GrafikYuksekligi = 250;
            double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi;
            double OlcekX = 2.5;
            int X_kaydirma = 20;
            for (int x = 0; x <= 255; x++)
            {

                if (x <= max)
                {
                    CizimAlani.DrawLine(Kalem1, (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi,
                        (int)(X_kaydirma + x * OlcekX), (GrafikYuksekligi - (int)(DiziPikselSayilari[x] / OlcekY)));
                }
                else
                {

                    CizimAlani.DrawLine(Kalem1, (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi,
                        (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.DefaultExt = ".jpg";
                openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                openFileDialog1.ShowDialog();
                String ResminYolu = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(ResminYolu);
            }
            catch { }
            Histogram(sender, e);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Contrast(sender, e);
        }


        private void Coordinates(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    textBox1.Text = e.X.ToString();
                    textBox2.Text = e.Y.ToString();

                }
                if (e.Button == MouseButtons.Right)
                {

                    textBox3.Text = e.X.ToString();
                    textBox4.Text = e.Y.ToString();
                }
            }
        }
    }
}
