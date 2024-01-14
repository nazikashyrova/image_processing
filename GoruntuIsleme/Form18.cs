using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GoruntuIsleme
{
    public partial class Form18 : Form
    {
        private Bitmap originalImage;
        public Form18(Form1 form1)
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {

        }

        public void ResminHistograminiCiz()
        {
            ArrayList DiziPiksel = new ArrayList();
            int OrtalamaRenk = 0;
            Color OkunanRenk;
            Bitmap GirisResmi; //Histogram için giriş resmi gri-ton olmalıdır.
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            for (int x = 0; x < GirisResmi.Width; x++)
            {
                for (int y = 0; y < GirisResmi.Height; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    OrtalamaRenk = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3; //Griton resimde üç kanal rengi aynı değere sahiptir.
                    DiziPiksel.Add(OrtalamaRenk); //Resimdeki tüm noktaları diziye atıyor.
                }
            }
            int[] DiziPikselSayilari = new int[256];
            for (int r = 0; r <= 255; r++) //256 tane renk tonu için dönecek.
            {
                int PikselSayisi = 0;
                for (int s = 0; s < DiziPiksel.Count; s++) //resimdeki piksel sayısınca dönecek.
                {
                    if (r == Convert.ToInt16(DiziPiksel[s]))
                        PikselSayisi++;
                }
                DiziPikselSayilari[r] = PikselSayisi;
            }
            //Değerleri listbox'a ekliyor.
            int RenkMaksPikselSayisi = 0; //Grafikte y eksenini ölçeklerken kullanılacak.
            for (int k = 0; k <= 255; k++)
            {
                listBox1.Items.Add("Renk:" + k + "=" + DiziPikselSayilari[k]);
                //Maksimum piksel sayısını bulmaya çalışıyor.
                if (DiziPikselSayilari[k] > RenkMaksPikselSayisi)
                {
                    RenkMaksPikselSayisi = DiziPikselSayilari[k];
                }
            }
            //Grafiği çiziyor.
            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Yellow, 1);
            Pen Kalem2 = new Pen(System.Drawing.Color.Red, 1);
            CizimAlani = pictureBox2.CreateGraphics();
            pictureBox2.Refresh();
            int GrafikYuksekligi = 250;
            double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi;
            double OlcekX = 1.5;
            int X_kaydirma = 10;
            for (int x = 0; x <= 255; x++)
            {
                if (x % 50 == 0)
                    CizimAlani.DrawLine(Kalem2, (int)(X_kaydirma + x * OlcekX),
                    GrafikYuksekligi, (int)(X_kaydirma + x * OlcekX), 0);
                CizimAlani.DrawLine(Kalem1, (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi,
                (int)(X_kaydirma + x * OlcekX), (GrafikYuksekligi - (int)(DiziPikselSayilari[x] / OlcekY)));
                //Dikey kırmızı çizgiler.
            }
            textBox1.Text = "Maks.Piks=" + RenkMaksPikselSayisi.ToString();
        }

        private void resim_sec_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.png;*.gif;*.tif|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        originalImage = new Bitmap(openFileDialog.FileName);
                        pictureBox1.Image = originalImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim açma hatası: " + ex.Message);
                    }
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ResminHistograminiCiz();
        }
    }
    }
