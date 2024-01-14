using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GoruntuIsleme
{
    public partial class hafta5_5 : Form
    {
        private List<int> noktalarX = new List<int>();
        private List<int> noktalarY = new List<int>();
        String ResminYolu;
        private Bitmap originalImage;

        public hafta5_5(Form1 form1)
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }

        private void Form17_Load(object sender, EventArgs e)
        {
            pictureBox1.MouseDown += PictureBox1_MouseDown;
           
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
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                noktalarX.Add(e.X);
                noktalarY.Add(e.Y);
            }
            pictureBox1.Invalidate();
        }

      

       
       
        private void mean_Click(object sender, EventArgs e)
        {
            mean_filtresi();
        }

        private void mean_filtresi()
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = Convert.ToInt32(textBox1.Text); //şablon boyutu 3 den büyük tek rakam olmalıdır (3,5,7 gibi).
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    if (PointInsidePolygon(x, y, noktalarX, noktalarY))
                    {
                        OkunanRenk = GirisResmi.GetPixel(x, y);
                        CikisResmi.SetPixel(x, y, Color.FromArgb(OkunanRenk.R, OkunanRenk.G, OkunanRenk.B));
                    }
                    else
                    {
                        toplamR = 0;
                        toplamG = 0;
                        toplamB = 0;
                        for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                        {
                            for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                            {
                                OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                                toplamR = toplamR + OkunanRenk.R;
                                toplamG = toplamG + OkunanRenk.G;
                                toplamB = toplamB + OkunanRenk.B;
                            }
                        }
                        ortalamaR = toplamR / (SablonBoyutu * SablonBoyutu);
                        ortalamaG = toplamG / (SablonBoyutu * SablonBoyutu);
                        ortalamaB = toplamB / (SablonBoyutu * SablonBoyutu);
                        CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                    }
                }
            }
            pictureBox2.Image = CikisResmi;
        }
        private bool PointInsidePolygon(int x, int y, List<int> polyX, List<int> polyY)
        {
            int i, j;
            bool c = false;
            for (i = 0, j = polyX.Count - 1; i < polyX.Count; j = i++)
            {
                if (((polyY[i] > y) != (polyY[j] > y)) &&
                    (x < (polyX[j] - polyX[i]) * (y - polyY[i]) / (polyY[j] - polyY[i]) + polyX[i]))
                {
                    c = !c;
                }
            }
            return c;
        }

        private void ciz(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < noktalarX.Count; i++)
            {
                e.Graphics.FillEllipse(Brushes.Red, noktalarX[i] - 2, noktalarY[i] - 2, 4, 4);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            noktalarX.Clear();
            noktalarY.Clear();
            pictureBox1.Image = System.Drawing.Image.FromFile(ResminYolu);
        }


    }
}
