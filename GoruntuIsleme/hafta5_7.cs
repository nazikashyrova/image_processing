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
    public partial class hafta5_7 : Form
    {
        public hafta5_7(Form1 form1)
        {
            InitializeComponent();
        }

        private void hafta5_7_Load(object sender, EventArgs e)
        {

        }
        private void median_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);
            Bitmap CikisResmi = new Bitmap(GirisResmi.Width, GirisResmi.Height);

            int SablonBoyutu;
            if (int.TryParse(textBox1.Text, out SablonBoyutu) && SablonBoyutu % 2 == 1 && SablonBoyutu > 1)
            {
                medianFiltresi(GirisResmi, ref CikisResmi, SablonBoyutu);
                pictureBox2.Image = CikisResmi;
            }
            else
            {
                MessageBox.Show("Geçersiz şablon boyutu. Lütfen tek ve 1'den büyük bir sayı girin.");
            }
        }

        public void medianFiltresi(Bitmap GirisResmi, ref Bitmap CikisResmi, int SablonBoyutu)
        {
            Color OkunanRenk;
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;

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
                    // Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                    int k = 0;
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            R[k] = OkunanRenk.R;
                            G[k] = OkunanRenk.G;
                            B[k] = OkunanRenk.B;
                            Gri[k] = Convert.ToInt32(R[k] * 0.299 + G[k] * 0.587 + B[k] * 0.114); // Gri ton formülü
                            k++;
                        }
                    }
                    int ensikrenk = EnSikRengiBul(Gri, ElemanSayisi);
                    CikisResmi.SetPixel(x, y, Color.FromArgb(ensikrenk, ensikrenk, ensikrenk));
                }
            }
        }

        private int EnSikRengiBul(int[] Gri, int ElemanSayisi)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

            for (int i = 0; i < ElemanSayisi; i++)
            {
                if (frequencyMap.ContainsKey(Gri[i]))
                {
                    frequencyMap[Gri[i]]++;
                }
                else
                {
                    frequencyMap[Gri[i]] = 1;
                }
            }

            int ensikrenk = frequencyMap.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return ensikrenk;
        }
    }
}
