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
    public partial class Form20 : Form
    {
        private Bitmap originalImage;
        private Rectangle selectedRegion;
        private bool isMouseDown = false;
        public Form20(Form1 form1)
        {
            InitializeComponent();
        }
        private void Form19_Load(object sender, EventArgs e)
        {
            // TrackBar olaylarını tanımla
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 255;
            trackBar1.Value = 255;
            trackBar1.Scroll += trackBar1_Scroll;

            
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
            int EsiklemeDegeri = trackBar1.Value;
        }
    }
}
