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
    public partial class hafta5_2 : Form
    {
        private Bitmap originalImage;
        public hafta5_2(Form1 form1)
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

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

        private void bulanik_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);
            Bitmap CikisResmi = ConservativeSmoothing(GirisResmi);
            pictureBox2.Image = CikisResmi;
        }
        private Bitmap ConservativeSmoothing(Bitmap GirisResmi)
        {
            int width = GirisResmi.Width;
            int height = GirisResmi.Height;

            Bitmap cikis = new Bitmap(width, height);

            int SablonBoyutu = 3;

            for (int x = SablonBoyutu / 2; x < width - SablonBoyutu / 2; x++)
            {
                for (int y = SablonBoyutu / 2; y < height - SablonBoyutu / 2; y++)
                {
                    int totalR = 0;
                    int totalG = 0;
                    int totalB = 0;

                    for (int i = -SablonBoyutu / 2; i <= SablonBoyutu / 2; i++)
                    {
                        for (int j = -SablonBoyutu / 2; j <= SablonBoyutu / 2; j++)
                        {
                            Color pixel = GirisResmi.GetPixel(x + i, y + j);
                            totalR += pixel.R;
                            totalG += pixel.G;
                            totalB += pixel.B;
                        }
                    }

                    int ortalamaR = totalR / (SablonBoyutu * SablonBoyutu);
                    int ortalamaG = totalG / (SablonBoyutu * SablonBoyutu);
                    int ortalamaB = totalB / (SablonBoyutu * SablonBoyutu);

                    cikis.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                }
            }

            return cikis;
        }
    }
}
