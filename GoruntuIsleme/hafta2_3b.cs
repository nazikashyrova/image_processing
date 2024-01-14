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
    public partial class hafta2_3b : Form
    {
        public hafta2_3b(Form1 form1)
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

        public void NewHistogram(object sender, EventArgs e)
        {
            ArrayList DiziPiksel = new ArrayList();
            int OrtalamaRenk = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            int R = 0, G = 0, B = 0;
            int min = trackBar1.Value;
            int max = trackBar2.Value;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;

                    if (R > max || G > max || B > max || R < min || G < min || B < min)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                    }

                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox3.Image = CikisResmi;

            for (int x = 0; x < CikisResmi.Width; x++)
            {
                for (int y = 0; y < CikisResmi.Height; y++)
                {
                    OkunanRenk = CikisResmi.GetPixel(x, y);
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

        private void Coordinates(object sender, MouseEventArgs e)
        {
            if (pictureBox3.Image != null)
            {
                int x = e.X;
                int y = e.Y;
                string coordinates = $"X: {x}, Y: {y}";

                textBox3.Text = coordinates;
                Bitmap bitmap = new Bitmap(pictureBox3.Image);

                if (e.X >= 0 && e.X < bitmap.Width && e.Y >= 0 && e.Y < bitmap.Height)
                {
                    Color color = bitmap.GetPixel(e.X, e.Y);

                    // Display RGB values
                    string rgbValues = $"R: {color.R}, G: {color.G}, B: {color.B}";
                    textBox3.AppendText(Environment.NewLine + rgbValues);
                }
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
            NewHistogram(sender, e);
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            NewHistogram(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }
    }
}
