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
    public partial class hafta2_5 : Form
    {
        public hafta2_5(Form1 form1)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void CoordinateRed(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    textBox1.Text = e.X.ToString();
                    textBox2.Text = e.Y.ToString();

                }
            }
        }
        private void CoordinateGreen(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    textBox3.Text = e.X.ToString();
                    textBox4.Text = e.Y.ToString();

                }
            }
        }
        private void CoordinateBlue(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    textBox5.Text = e.X.ToString();
                    textBox6.Text = e.Y.ToString();

                }
            }
        }

        public void HistogramRed(object sender, EventArgs e)
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
                    OrtalamaRenk = (int)(OkunanRenk.R);
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

            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Red, 1);
            CizimAlani = pictureBox2.CreateGraphics();

            pictureBox2.Refresh();
            int GrafikYuksekligi = 250;
            double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi;
            double OlcekX = 2.5;
            int X_kaydirma = 20;

            for (int x = 0; x <= 255; x++)
            {
                CizimAlani.DrawLine(Kalem1, (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi,
                    (int)(X_kaydirma + x * OlcekX), (GrafikYuksekligi - (int)(DiziPikselSayilari[x] / OlcekY)));
            }
        }

        public void HistogramGreen(object sender, EventArgs e)
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
                    OrtalamaRenk = (int)(OkunanRenk.G);
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
            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Green, 1);
            CizimAlani = pictureBox3.CreateGraphics();

            pictureBox3.Refresh();
            int GrafikYuksekligi = 250;
            double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi;
            double OlcekX = 2.5;
            int X_kaydirma = 20;
            for (int x = 0; x <= 255; x++)
            {
                CizimAlani.DrawLine(Kalem1, (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi,
                    (int)(X_kaydirma + x * OlcekX), (GrafikYuksekligi - (int)(DiziPikselSayilari[x] / OlcekY)));
            }
        }

        public void HistogramBlue(object sender, EventArgs e)
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
                    OrtalamaRenk = (int)(OkunanRenk.B);
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
            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Blue, 1);
            CizimAlani = pictureBox4.CreateGraphics();

            pictureBox4.Refresh();
            int GrafikYuksekligi = 250;
            double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi;
            double OlcekX = 2.5;
            int X_kaydirma = 20;
            for (int x = 0; x <= 255; x++)
            {
                CizimAlani.DrawLine(Kalem1, (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi,
                    (int)(X_kaydirma + x * OlcekX), (GrafikYuksekligi - (int)(DiziPikselSayilari[x] / OlcekY)));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Contrast(sender, e);
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
            int X3 = Convert.ToInt16(textBox5.Text);
            int Y3 = Convert.ToInt16(textBox6.Text);

            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);

                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;

                    int Red = (((R - X1) * (Y1 - 0) / (255 - X1)) + 0);
                    Red = (Red > 255) ? 255 : (Red < 0) ? 0 : Red;

                    int Green = (((R - X2) * (Y2 - 0) / (255 - X2)) + 0);
                    Green = (Green > 255) ? 255 : (Green < 0) ? 0 : Green;

                    int Blue = (((R - X3) * (Y3 - 0) / (255 - X3)) + 0);
                    Blue = (Blue > 255) ? 255 : (Blue < 0) ? 0 : Blue;

                    DonusenRenk = Color.FromArgb(Red, Green, Blue); CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox5.Refresh();
            pictureBox5.Image = null;
            pictureBox5.Image = CikisResmi;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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
            HistogramRed(sender, e);
            HistogramGreen(sender, e);
            HistogramBlue(sender, e);
        }
    }
}
