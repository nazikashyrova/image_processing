using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoruntuIsleme
{
    public partial class hafta1_5 : Form
    {
        private Bitmap originalImage;

        private Form1 form1;

        public hafta1_5(Form1 form1)
        {
            InitializeComponent();
        }
        private void Form8_Load(object sender, EventArgs e)
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
                        ana_resim.Image = originalImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim açma hatası: " + ex.Message);
                    }
                }
            }
        }

        private void ayir_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                // Kırmızı, yeşil ve mavi bantlara ait görüntüleri oluştur
                Bitmap redImage = ExtractChannel(originalImage, Channel.Red);
                Bitmap greenImage = ExtractChannel(originalImage, Channel.Green);
                Bitmap blueImage = ExtractChannel(originalImage, Channel.Blue);

                // Oluşturulan görüntüleri göster
                kirmizi.Image = redImage;
                yesil.Image = greenImage;
                mavi.Image = blueImage;
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim seçin.");
            }
        }

        private Bitmap ExtractChannel(Bitmap originalImage, Channel channel)
        {
            Bitmap channelImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    Color channelColor = Color.Black;

                    switch (channel)
                    {
                        case Channel.Red:
                            channelColor = Color.FromArgb(originalColor.R, 0, 0);
                            break;
                        case Channel.Green:
                            channelColor = Color.FromArgb(0, originalColor.G, 0);
                            break;
                        case Channel.Blue:
                            channelColor = Color.FromArgb(0, 0, originalColor.B);
                            break;
                    }

                    channelImage.SetPixel(x, y, channelColor);
                }
            }

            return channelImage;
        }
        private enum Channel
        {
            Red,
            Green,
            Blue
        }

        private void ana_resim_Click(object sender, EventArgs e)
        {

        }
    }
}
