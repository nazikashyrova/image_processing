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
    public partial class hafta5_1 : Form
    {
        public hafta5_1(Form1 form1)
        {
            InitializeComponent();
        }


        public void mean_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi = new Bitmap(pictureBox4.Image);
            Bitmap CikisResmi = new Bitmap(GirisResmi.Width, GirisResmi.Height);
            mean_filtresi(GirisResmi, ref CikisResmi);
            pictureBox8.Image = CikisResmi; 

            Bitmap GirisResmi1 = new Bitmap(pictureBox5.Image);
            Bitmap CikisResmi1 = new Bitmap(GirisResmi1.Width, GirisResmi1.Height);
            mean_filtresi(GirisResmi1, ref CikisResmi1);
            pictureBox1.Image = CikisResmi1;

            Bitmap GirisResmi2 = new Bitmap(pictureBox6.Image);
            Bitmap CikisResmi2 = new Bitmap(GirisResmi2.Width, GirisResmi2.Height);
            mean_filtresi(GirisResmi2, ref CikisResmi2);
            pictureBox3.Image = CikisResmi2;

            Bitmap GirisResmi3 = new Bitmap(pictureBox7.Image);
            Bitmap CikisResmi3 = new Bitmap(GirisResmi3.Width, GirisResmi3.Height);
            mean_filtresi(GirisResmi3, ref CikisResmi3);
            pictureBox2.Image = CikisResmi3;



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void mean_filtresi(Bitmap GirisResmi, ref Bitmap CikisResmi)
        {
            Color OkunanRenk;
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;

            int SablonBoyutu;
            if (int.TryParse(textBox1.Text, out SablonBoyutu))
            {
                int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;

                for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
                {
                    for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                    {
                        toplamR = 0;
                        toplamG = 0;
                        toplamB = 0;

                        for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                        {
                            for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                            {
                                OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                                toplamR += OkunanRenk.R;
                                toplamG += OkunanRenk.G;
                                toplamB += OkunanRenk.B;
                            }
                        }

                        ortalamaR = toplamR / (SablonBoyutu * SablonBoyutu);
                        ortalamaG = toplamG / (SablonBoyutu * SablonBoyutu);
                        ortalamaB = toplamB / (SablonBoyutu * SablonBoyutu);

                        CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                    }
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir sayı girin.");
            }
        }

        private void median_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi = new Bitmap(pictureBox4.Image);
            Bitmap CikisResmi = new Bitmap(GirisResmi.Width, GirisResmi.Height);
            medianFiltresi(GirisResmi, ref CikisResmi);
            pictureBox8.Image = CikisResmi;

            Bitmap GirisResmi1 = new Bitmap(pictureBox5.Image);
            Bitmap CikisResmi1 = new Bitmap(GirisResmi1.Width, GirisResmi1.Height);
            medianFiltresi(GirisResmi1, ref CikisResmi1);
            pictureBox1.Image = CikisResmi1;

            Bitmap GirisResmi2 = new Bitmap(pictureBox6.Image);
            Bitmap CikisResmi2 = new Bitmap(GirisResmi2.Width, GirisResmi2.Height);
            medianFiltresi(GirisResmi2, ref CikisResmi2);
            pictureBox3.Image = CikisResmi2;

            Bitmap GirisResmi3 = new Bitmap(pictureBox7.Image);
            Bitmap CikisResmi3 = new Bitmap(GirisResmi3.Width, GirisResmi3.Height);
            medianFiltresi(GirisResmi3, ref CikisResmi3);
            pictureBox2.Image = CikisResmi3;

        }

        public void medianFiltresi(Bitmap GirisResmi, ref Bitmap CikisResmi)
        {
            Color OkunanRenk;
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            int SablonBoyutu = 0;
            try
            {
                SablonBoyutu = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                SablonBoyutu = 3;
            }
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int[] R = new int[ElemanSayisi];
            int[] G = new int[ElemanSayisi];
            int[] B = new int[ElemanSayisi];
            int[] Gri = new int[ElemanSayisi];
            int x, y, i, j;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                    int k = 0;
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            R[k] = OkunanRenk.R;
                            G[k] = OkunanRenk.G;
                            B[k] = OkunanRenk.B;
                            Gri[k] = Convert.ToInt16(R[k] * 0.299 + G[k] * 0.587 + B[k] * 0.114); //Gri ton formülü
                            k++;
                        }
                    }
                    // Gri tona göre sıralama yapıyor. Aynı anda üç rengide değiştiriyor.
                    int GeciciSayi = 0;
                    for (i = 0; i < ElemanSayisi; i++)
                    {
                        for (j = i + 1; j < ElemanSayisi; j++)
                        {
                            if (Gri[j] < Gri[i])
                            {
                                GeciciSayi = Gri[i];
                                Gri[i] = Gri[j];
                                Gri[j] = GeciciSayi;
                                GeciciSayi = R[i];
                                R[i] = R[j];
                                R[j] = GeciciSayi;
                                GeciciSayi = G[i];
                                G[i] = G[j];
                                G[j] = GeciciSayi;
                                GeciciSayi = B[i];
                                B[i] = B[j];
                                B[j] = GeciciSayi;
                            }
                        }
                    }
                    //Sıralama sonrası ortadaki değeri çıkış resminin piksel değeri olarak atıyor.
                    CikisResmi.SetPixel(x, y, Color.FromArgb(R[(ElemanSayisi - 1) / 2], G[(ElemanSayisi - 1) / 2], B[(ElemanSayisi - 1) / 2]));
                }
            }
        }

        private void gauss_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi = new Bitmap(pictureBox4.Image);
            Bitmap CikisResmi = new Bitmap(GirisResmi.Width, GirisResmi.Height);
            gauss_Filter(GirisResmi, ref CikisResmi);
            pictureBox8.Image = CikisResmi;

            Bitmap GirisResmi1 = new Bitmap(pictureBox5.Image);
            Bitmap CikisResmi1 = new Bitmap(GirisResmi1.Width, GirisResmi1.Height);
            gauss_Filter(GirisResmi1, ref CikisResmi1);
            pictureBox1.Image = CikisResmi1;

            Bitmap GirisResmi2 = new Bitmap(pictureBox6.Image);
            Bitmap CikisResmi2 = new Bitmap(GirisResmi2.Width, GirisResmi2.Height);
            gauss_Filter(GirisResmi2, ref CikisResmi2);
            pictureBox3.Image = CikisResmi2;

            Bitmap GirisResmi3 = new Bitmap(pictureBox7.Image);
            Bitmap CikisResmi3 = new Bitmap(GirisResmi3.Width, GirisResmi3.Height);
            gauss_Filter(GirisResmi3, ref CikisResmi3);
            pictureBox2.Image = CikisResmi3;
        }

        private void gauss_Filter(Bitmap GirisResmi, ref Bitmap CikisResmi)
        {
            Color OkunanRenk;
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            int SablonBoyutu = Convert.ToInt32(textBox1.Text); //Çekirdek matrisin boyutu
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;
            int[] Matris = null;
            int MatrisToplami = 0;
            if (SablonBoyutu == 5)
            {
                Matris = new int[] { 1, 4, 7, 4, 1, 4, 20, 33, 20, 4, 7, 33, 55, 33, 7, 4, 20, 33, 20, 4, 1, 4, 7, 4, 1 };
                MatrisToplami = 1 + 4 + 7 + 4 + 1 + 4 + 20 + 33 + 20 + 4 + 7 + 33 + 55 + 33 + 7 + 4 + 20 + 33 + 20 + 4 + 1 + 4 + 7 + 4 + 1;

            }
            else if (SablonBoyutu == 3)
            {
                Matris = new int[] { 1, 2, 1, 2, 4, 2, 1, 2, 1 };
                MatrisToplami = 16;
            }
            else if (SablonBoyutu == 7)
            {
                Matris = new int[] { 1, 1, 2, 2, 2, 1, 1, 1, 2, 2, 4, 2, 2, 1, 2, 2, 4, 8, 4, 2, 2, 2, 4, 8, 16, 8, 4, 2, 2, 2, 4, 8, 4, 2, 2, 1, 2, 2, 4, 2, 2, 1, 1, 1, 2, 2, 2, 1, 1 };
                MatrisToplami = 64;
            }
            else if (SablonBoyutu == 9)
            {
                Matris = new int[] { 1, 1, 2, 2, 2, 2, 2, 1, 1, 1, 2, 2, 4, 4, 4, 2, 2, 1, 2, 2, 4, 8, 8, 8, 4, 2, 2, 2, 4, 8, 16, 16, 16, 8, 4, 2, 2, 4, 8, 16, 16, 16, 8, 4, 2, 2, 4, 8, 16, 16, 16, 8, 4, 2, 2, 2, 4, 8, 8, 8, 4, 2, 2, 1, 2, 2, 4, 4, 4, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 1, 1 };
                MatrisToplami = 121;
            }
            
            
                for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
                //Resmi taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacakve bitirecek.
                {
                    for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                    {
                        toplamR = 0;
                        toplamG = 0;
                        toplamB = 0;
                        //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                        int k = 0; //matris içindeki elemanları sırayla okurken kullanılacak.
                        for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                        {
                            for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                            {
                                OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                                toplamR = toplamR + OkunanRenk.R * Matris[k];
                                toplamG = toplamG + OkunanRenk.G * Matris[k];
                                toplamB = toplamB + OkunanRenk.B * Matris[k];
                                k++;
                            }
                        }
                        ortalamaR = toplamR / MatrisToplami;
                        ortalamaG = toplamG / MatrisToplami;
                        ortalamaB = toplamB / MatrisToplami;
                        CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                    }
                }
            
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
}
