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
    public partial class hafta7_1 : Form
    {
        public hafta7_1(Form1 form1)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mnuPrewitt_Click(sender, e,pictureBox1.Image);
            //mnuRobertCross_Click(sender, e, pictureBox1.Image);
            //mnuSobel_Click(sender, e, pictureBox1.Image);
            //toolStripButton3_Click(sender, e, pictureBox1.Image);

        }
        private void mnuPrewitt_Click(object sender, EventArgs e, Image image)
        {
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3;
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y; Color Renk;
            int P1, P2, P3, P4, P5, P6, P7, P8, P9;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++) //Resmi taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacakve bitirecek.
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    Renk = GirisResmi.GetPixel(x - 1, y - 1);
                    P1 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y - 1);
                    P2 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y - 1);
                    P3 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x - 1, y);
                    P4 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y);
                    P5 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y);
                    P6 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x - 1, y + 1);
                    P7 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y + 1);
                    P8 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y + 1);
                    P9 = (Renk.R + Renk.G + Renk.B) / 3;
                    int Gx = Math.Abs(-P1 + P3 - P4 + P6 - P7 + P9); //Dikey çizgileri Bulur
                    int Gy = Math.Abs(P1 + P2 + P3 - P7 - P8 - P9); //Yatay Çizgileri Bulur.
                    int PrewittDegeri = 0;
                    PrewittDegeri = Gx + Gy; //1. Formül
                                             //PrewittDegeri = Convert.ToInt16(Math.Sqrt(Gx * Gx + Gy * Gy)); //2.Formü
                                             //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (PrewittDegeri > 255) PrewittDegeri = 255;
                    //Eşikleme: Örnek olarak 100 değeri kullanıldı.
                    //if (PrewittDegeri > 100)
                    //PrewittDegeri = 255;
                    //else
                    //PrewittDegeri = 0;
                    CikisResmi.SetPixel(x, y, Color.FromArgb(PrewittDegeri, PrewittDegeri, PrewittDegeri));
                }
            }
            pictureBox2.Image = CikisResmi;
        }


        private void mnuRobertCross_Click(object sender, EventArgs e, Image image)
        {
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int x, y;
            Color Renk;
            int P1, P2, P3, P4;
            for (x = 0; x < ResimGenisligi - 1; x++) //Resmi taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacak ve bitirecek.
            {
                for (y = 0; y < ResimYuksekligi - 1; y++)
                {
                    Renk = GirisResmi.GetPixel(x, y);
                    P1 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y);
                    P2 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y + 1);
                    P3 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y + 1);
                    P4 = (Renk.R + Renk.G + Renk.B) / 3;
                    int Gx = Math.Abs(P1 - P4); //45 derece açı ile duran çizgileri bulur.
                    int Gy = Math.Abs(P2 - P3); //135 derece açı ile duran çizgileri bulur.
                    int RobertCrossDegeri = 0;
                    RobertCrossDegeri = Gx + Gy; //1. Formül
                                                 //RobertCrossDegeri = Convert.ToInt16(Math.Sqrt(Gx * Gx + Gy * Gy)); //2.Formül
                                                 //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (RobertCrossDegeri > 255) RobertCrossDegeri = 255; //Mutlak değer kullanıldığı için negatif değerler oluşmaz.
                                                                          //Eşikleme
                                                                          //if (RobertCrossDegeri > 50)
                                                                          // RobertCrossDegeri = 255;
                                                                          //else
                                                                          // RobertCrossDegeri = 0;
                    CikisResmi.SetPixel(x, y, Color.FromArgb(RobertCrossDegeri, RobertCrossDegeri, RobertCrossDegeri));
                }
            }
            pictureBox2.Image = CikisResmi;
        }
        private void mnuSobel_Click(object sender, EventArgs e, Image image)
        {
            Bitmap GirisResmi, CikisResmiXY, CikisResmiX, CikisResmiY;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmiX = new Bitmap(ResimGenisligi, ResimYuksekligi);
            CikisResmiY = new Bitmap(ResimGenisligi, ResimYuksekligi);
            CikisResmiXY = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3;
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y;
            Color Renk;
            int P1, P2, P3, P4, P5, P6, P7, P8, P9;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++) //Resmi taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacakve bitirecek.
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    Renk = GirisResmi.GetPixel(x - 1, y - 1);
                    P1 = (Renk.R + Renk.G + Renk.B) / 3;



                    Renk = GirisResmi.GetPixel(x, y - 1);
                    P2 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y - 1);
                    P3 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x - 1, y);
                    P4 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y);
                    P5 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y);
                    P6 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x - 1, y + 1);
                    P7 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x, y + 1);
                    P8 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = GirisResmi.GetPixel(x + 1, y + 1);
                    P9 = (Renk.R + Renk.G + Renk.B) / 3;
                    //Hesaplamayı yapan Sobel Temsili matrisi ve formülü.
                    int Gx = Math.Abs(-P1 + P3 - 2 * P4 + 2 * P6 - P7 + P9); //Dikey çizgiler
                    int Gy = Math.Abs(P1 + 2 * P2 + P3 - P7 - 2 * P8 - P9); //Yatay Çizgiler

                    //if (Gx > 100)
                    // Gx = 255;
                    //else
                    // Gx = 0;
                    //if (Gy > 100)
                    // Gy = 255;
                    //else
                    // Gy = 0;
                    int Gxy = Gx + Gy;
                    //if (Gxy > Esikleme) // Eşikleme değerine göre siyah beyaz yapacak
                    // Gxy = 255;
                    //else
                    // Gxy = 0;
                    //Renkler sınırların dışına çıktıysa, sınır değer alınacak. Negatif olamaz, formüllerde mutlak değer vardır.
                    if (Gx > 255) Gx = 255;
                    if (Gy > 255) Gy = 255;
                    if (Gxy > 255) Gxy = 255;
                    //int TetaRadyan = 0;
                    //if (Gy != 0)
                    // TetaRadyan = Convert.ToInt32(Math.Atan(Gx / Gy));
                    //else
                    // TetaRadyan = Convert.ToInt32(Math.Atan(Gx));

                    //int TetaDerece = Convert.ToInt32((TetaRadyan * 360) / (2 * Math.PI));
                    //if (TetaDerece >= 0 && TetaDerece < 45)
                    // CikisResmiXY.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    //if (TetaDerece >= 45 && TetaDerece < 90)
                    // CikisResmiXY.SetPixel(x, y, Color.FromArgb(0, 255, 0));
                    //if (TetaDerece >= 90 && TetaDerece < 135)
                    // CikisResmiXY.SetPixel(x, y, Color.FromArgb(0, 0, 255));
                    //if (TetaDerece >= 135 && TetaDerece < 180)
                    // CikisResmiXY.SetPixel(x, y, Color.FromArgb(255, 255, 0));
                    CikisResmiX.SetPixel(x, y, Color.FromArgb(Gx, Gx, Gx));
                    CikisResmiY.SetPixel(x, y, Color.FromArgb(Gy, Gy, Gy));
                    CikisResmiXY.SetPixel(x, y, Color.FromArgb(Gxy, Gxy, Gxy));
                }
            }
            pictureBox2.Image = CikisResmiXY;
            pictureBox3.Image = CikisResmiX;
            pictureBox4.Image = CikisResmiY;
        }

        private void toolStripButton3_Click(object sender, EventArgs e, Image image)
        {
            Bitmap newBitmap = (Bitmap)image;
            Bitmap newBitmap1 = new Bitmap(newBitmap.Width, newBitmap.Height);
            newBitmap1 = MakeGrayscale(newBitmap);
            newBitmap1 = MakeSmooth(newBitmap1);
            newBitmap1 = DetectEdge(newBitmap1);
            pictureBox2.Image = newBitmap1;
        }
        private Bitmap MakeGrayscale(Bitmap original)
        {
            try
            {
                Color originalColor; Color newColor;
                Bitmap newBitmap = new Bitmap(original.Width, original.Height);
                for (int i = 0; i < original.Width; i++)
                    for (int j = 0; j < original.Height; j++)
                    {
                        originalColor = original.GetPixel(i, j);
                        int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                        newColor = Color.FromArgb(grayScale, grayScale, grayScale);
                        newBitmap.SetPixel(i, j, newColor);
                    }
                return newBitmap;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        private Bitmap MakeSmooth(Bitmap original
        )
        {
            int runningSum
            = 0; int tempSum
            = 0; int xcoord
            ;
            int ycoord; Color newColor
            ;
            int[,] kernel
            = new int[5, 5]
            {
        {1,4,7,4,1}, {4,16,26,16,4}, {7,26,41,26,7}, {4,16,26,16,4}, {1,4,7,4,1} };
            Color[,] pixels
            = new Color[5, 5];
            Bitmap newBitmap
            = new Bitmap(original.Width
            , original.Height);
            for
            (int
            i
            = 0;
            i
            < original.Width
            ; i++)
                for
                (int
                j
                = 0;
                j
                < original.Height
                ; j++)
                {
                    for
                    (int
                    x
                    =
                    -2;
                    x
                    < 3; x++)
                        for
                        (int
                        y
                        =
                        -2;
                        y
                        < 3; y++)
                        {
                            xcoord
                            =
                            i
                            + x;
                            ycoord
                            =
                            j
                            + y;
                            if
                            (xcoord
                            <
                            0 || xcoord
                            > original.Width
                            - 1)
                                xcoord
                                =
                                i
                                - x;
                            if
                            (ycoord
                            <
                            0 || ycoord
                            > original.Height
                            - 1)
                                ycoord
                                =
                                j
                                - y;
                            pixels[x
                            + 2,
                            y
                            + 2]
                            = original.GetPixel
                            (xcoord
                            , ycoord);
                        }
                    for
                    (int
                    k
                    = 0;
                    k
                    < 5; k++)
                        for
                        (int
                        l
                        = 0;
                        l
                        < 5; l++)
                            tempSum += kernel[k, l]
                            * pixels[k, l].R;
                    runningSum
                    = tempSum
                    / 273;
                    newColor
                    = Color.FromArgb
                    (runningSum
                    , runningSum
                    , runningSum);
                    newBitmap.SetPixel(i
                    , j, newColor);
                    tempSum
                    = 0;
                    runningSum
                    = 0;
                }
            return newBitmap
            ;
        }

        private Bitmap DetectEdge(Bitmap original
        )
        {
            Bitmap newBitmap
            = new Bitmap(original.Width
            , original.Height);
            int xleft
            ;
            int xright
            ;
            int ytop;
            int ybot;
            double gx;
            double gy
            ;
            double tempAngle; Color color1, color2;
            double[,] magnitudes
            = new double
            [original.Width
            , original.Height];
            double[,] angles
            = new double
            [original.Width
            , original.Height];
            bool[,] isEdge
            = new bool
            [original.Width
            , original.Height];
            double maxMag
            = 0;
            for
            (int
            i
            = 0;
            i
            < original.Width
            ; i++)
                for
                (int
                j
                = 0;
                j
                < original.Height
                ; j++)
                {
                    xleft
                    =
                    i
                    - 1; xright
                    =
                    i
                    + 1; ytop
                    =
                    j
                    - 1; ybot
                    =
                    j
                    + 1;
                    if
                    (xleft
                    < 0)
                        xleft
                        = xright
                        ;
                    if
                    (xright
                    > original.Width
                    -
                    1
                    )
                        xright
                        = xleft
                        ;
                    if
                    (ytop
                    < 0)
                        ytop
                        = ybot
                        ;
                    if
                    (ybot
                    > original.Height
                    - 1)
                        ybot
                        = ytop
                        ;
                    color1 = original.GetPixel
                    (xright
                    , j);
                    color2 = original.GetPixel
                    (xleft
                    , j);
                    gx
                    = (color1.R
                    - color2.R)
                    / 2;
                    color1 = original.GetPixel(i, ybot);
                    color2 = original.GetPixel(i, ytop);
                    gy
                    = (color1.R
                    - color2.R)
                    / 2;
                    magnitudes[i, j]
                    = Math.Abs
                    (gx
                    )
                    + Math.Abs
                    (gy);

                    if (magnitudes[i, j] > maxMag)
                        maxMag = magnitudes[i, j];
                    tempAngle = Math.Atan(gy / gx); tempAngle = tempAngle * 180 / Math.PI;
                    if ((tempAngle >= 0 && tempAngle < 22.5) || (tempAngle > 157.5 && tempAngle <= 180)
                    || (tempAngle <= 0 && tempAngle > -22.5) || (tempAngle < -157.5 && tempAngle >= -180)) tempAngle = 0.0;
                    else if ((tempAngle > 22.5 && tempAngle < 67.5) || (tempAngle < -22.5 && tempAngle >
                    -67.5))
                        tempAngle = 45.0;
                    else if ((tempAngle > 67.5 && tempAngle < 112.5) || (tempAngle < -67.5 && tempAngle
                    > -112.5))
                        tempAngle = 90.0;
                    else if ((tempAngle > 112.5 && tempAngle < 157.5) || (tempAngle < -112.5 && tempAngle > -157.5))
                        tempAngle = 135.0; angles[i, j] = tempAngle;
                }
            for (int i = 0; i < original.Width; i++)
                for (int j = 0; j < original.Height; j++)
                {
                    if ((i - 1 < 0 || i + 1 > original.Width - 1 || j - 1 < 0 || j + 1 > original.Height
                    - 1))
                    {
                        isEdge[i, j] = false;
                    }
                    else if (angles[i, j] == 0.0)
                    {
                        if (magnitudes[i, j] > magnitudes[i - 1, j] && magnitudes[i, j] > magnitudes[i +
                        1, j])
                            isEdge[i, j] = true;
                        else
                            isEdge[i, j] = false;
                    }

                    else if (angles[i, j] == 90.0)
                    {
                        if (magnitudes[i, j] > magnitudes[i, j - 1] && magnitudes[i, j] > magnitudes[i, j + 1])
                            isEdge[i, j] = true;
                        else
                            isEdge[i, j] = false;
                    }
                    else if (angles[i, j] == 135.0)
                    {
                        if (magnitudes[i, j] > magnitudes[i - 1, j - 1] && magnitudes[i, j] > magnitudes[i + 1, j + 1])
                            isEdge[i, j] = true;
                        else
                            isEdge[i, j] = false;
                    }
                    else if (angles[i, j] == 45.0)
                    {
                        if (magnitudes[i, j] > magnitudes[i + 1, j - 1] && magnitudes[i, j] > magnitudes[i - 1, j + 1])
                            isEdge[i, j] = true;
                        else
                            isEdge[i, j] = false;
                    }
                }
            double lowerThreshold = maxMag * 0.10;

            for (int i = 0; i < original.Width; i++)
                for (int j = 0; j < original.Height; j++)
                {
                    if (isEdge[i, j] && magnitudes[i, j] > lowerThreshold)
                    {
                        if (angles[i, j] == 0.0)
                        {
                            if (angles[i, j] == angles[i - 1, j] || angles[i, j] == angles[i + 1, j])
                            {
                                if (magnitudes[i - 1, j] > lowerThreshold) newBitmap.SetPixel(i - 1, j, Color.White);
                                else
                                    newBitmap.SetPixel(i - 1, j, Color.Black); if (magnitudes[i + 1, j] > lowerThreshold)
                                    newBitmap.SetPixel(i + 1, j, Color.White);
                                else
                                    newBitmap.SetPixel(i + 1, j, Color.Black);
                            }
                        }
                        else if (angles[i, j] == 90.0)
                        {
                            if (angles[i, j] == angles[i, j - 1] || angles[i, j] == angles[i, j + 1])
                            {
                                if (magnitudes[i, j - 1] > lowerThreshold) newBitmap.SetPixel(i, j - 1, Color.White);
                                else
                                    newBitmap.SetPixel(i, j - 1, Color.Black); if (magnitudes[i, j + 1] > lowerThreshold)
                                    newBitmap.SetPixel(i, j + 1, Color.White);
                                else
                                    newBitmap.SetPixel(i, j + 1, Color.Black);
                            }
                        }

                        else if (angles[i, j] == 135.0)
                        {
                            if (angles[i, j] == angles[i - 1, j - 1] || angles[i, j] == angles[i + 1, j
                            + 1])
                            {
                                if (magnitudes[i - 1, j - 1] > lowerThreshold) newBitmap.SetPixel(i - 1, j - 1, Color.White);
                                else
                                    newBitmap.SetPixel(i - 1, j - 1, Color.Black);
                                if (magnitudes[i + 1, j + 1] > lowerThreshold)
                                    newBitmap.SetPixel(i + 1, j + 1, Color.White);
                                else
                                    newBitmap.SetPixel(i + 1, j + 1, Color.Black);
                            }
                        }
                        else if (angles[i, j] == 45.0)
                        {
                            if (angles[i, j] == angles[i + 1, j - 1] || angles[i, j] == angles[i - 1, j
                            + 1])
                            {
                                if (magnitudes[i + 1, j - 1] > lowerThreshold) newBitmap.SetPixel(i + 1, j - 1, Color.White);
                                else
                                    newBitmap.SetPixel(i + 1, j - 1, Color.Black);
                                if (magnitudes[i - 1, j + 1] > lowerThreshold)
                                    newBitmap.SetPixel(i - 1, j + 1, Color.White);
                                else
                                    newBitmap.SetPixel(i - 1, j + 1, Color.Black);
                            }
                        }
                    }
                    else
                        newBitmap.SetPixel(i, j, Color.Black);
                }
            return newBitmap;
        }
        private void BOLGE_BULMA_Click(object sender, EventArgs e)
        {
            Bitmap GirisResmi, CikisResmi;
            int KomsularinEnKucukEtiketDegeri = 0; GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int PikselSayisi = ResimGenisligi * ResimYuksekligi;
            Bitmap SiyahBeyazResim = ResmiGriTonaDonusturEsiklemeYap(GirisResmi);
            GirisResmi = SiyahBeyazResim;
            pictureBox2.Image = SiyahBeyazResim;
            int x, y, i, j, EtiketNo = 0;
            int[,] EtiketNumarasi = new int[ResimGenisligi, ResimYuksekligi]; //Resmin her pikselinin etiket numarası tutulacak.
                                                                              //Tüm piksellerin Etiket numarasını başlangıçta 0 olarak atayacak. Siyah ve beyaz farketmez. Zaten ileride beyaz olanlara numara verilecek.
            for (x = 0; x < ResimGenisligi; x++)
            {
                for (y = 0; y < ResimYuksekligi; y++)
                {
                    EtiketNumarasi[x, y] = 0;
                }
            }

            int IlkDeger = 0, SonDeger = 0;
            bool DegisimVar = false; //Etiket numaralarında değişim olmayana kadar dönmesi için sonsuz döngüyü kontrol edecek.
            int Esikleme = 0;
            try
            {
                Esikleme = Convert.ToInt16(textBox1.Text);
            }
            catch
            {
                Esikleme = 128;
            }
            do //etiket numaralarında değişim kalmayana kadar dönecek.
            {
                DegisimVar = false;
                // Resmi tarıyor
                for (y = 1; y < ResimYuksekligi - 1; y++) //Resmin 1 piksel içerisinden başlayıp, bitirecek. Çünkü çekirdek şablon en dış kenardan başlamalı.
                {
                    for (x = 1; x < ResimGenisligi - 1; x++)
                    {
                        //Resim siyah beyaz olduğu için tek kanala bakmak yeterli olacak. Sıradaki piksel beyaz ise işlem yap. Beyaz olduğu 255 yerine 128 kullanarak yapıldı.
                        if (GirisResmi.GetPixel(x, y).R > Esikleme)
                        {
                            //işlem öncesi ele alınan pikselin etiket değerini okuyacak. İşlemler bittikten sonra bu değer değişirse, sonsuz döngü için işlem    yapılmış demektir.
                            IlkDeger = EtiketNumarasi[x, y];
                            //Komşular arasında en küçük etiket numarasını bulacak.
                            KomsularinEnKucukEtiketDegeri = 0;

                            for (j = -1; j <= 1; j++) //Çekirdek şablon 3x3 lük bir matris. Dolayısı ile x,y nin -1 den başlayıp +1 ne kadar yer kaplar.
                            {
                                for (i = -1; i <= 1; i++)
                                {
                                    if (EtiketNumarasi[x + i, y + j] != 0 && KomsularinEnKucukEtiketDegeri == 0) //hücrenin etiketi varsa ve daha hiç en küçük atanmadı ise ilk okuduğu bu değeri en küçük olarak atayacak.
                                    {
                                        KomsularinEnKucukEtiketDegeri = EtiketNumarasi[x + i, y + j];
                                    }
                                    else if (EtiketNumarasi[x + i, y + j] < KomsularinEnKucukEtiketDegeri && EtiketNumarasi[x + i, y + j] != 0 &&
                                    KomsularinEnKucukEtiketDegeri != 0) //En küçük değer ve okunan hücreye etiket atanmışsa, içindeki değer en küçük değerden küçük ise o zaman enküçük o hücrenin değeri olmalıdır.
                                    {
                                        KomsularinEnKucukEtiketDegeri = EtiketNumarasi[x + i, y + j];
                                    }
                                }
                            }
                            if (KomsularinEnKucukEtiketDegeri != 0) //Beyaz komşu buldu ve içlerinde en küçük etiket değerine sahip numara da var. O zaman orta pikseleo numarayı ata.
                            {
                                EtiketNumarasi[x, y] = KomsularinEnKucukEtiketDegeri;
                            }
                            else if (KomsularinEnKucukEtiketDegeri == 0) //Komşuların hiç birinde etiket numarası yoksa o zaman yeni bir numara ata
                            {
                                EtiketNo = EtiketNo + 1; EtiketNumarasi[x, y] = EtiketNo;
                            }
                            SonDeger = EtiketNumarasi[x, y]; //İşlem öncesi ve işlem sonrası değerler aynı ise ve butün piksellerde hep aynı olursa artık değişim yokdemektir.

                            if (IlkDeger != SonDeger) DegisimVar = true;
                        }
                    }
                }
            } while (DegisimVar == true); // Etiket numarlarında değişik kalmayana kadar dön.
                                          // Etiket değerine bağlı resmi renklendirecek-----------------------
                                          // Pikseller üzerine yazılmış numaraları diziye atıyor. Dizi boyutu resimdeki piksel sayısınca oluyor.
            int[] DiziEtiket = new int[PikselSayisi];
            i = 0;
            for (x = 1; x < ResimGenisligi - 1; x++)
            {
                for (y = 1; y < ResimYuksekligi - 1; y++)
                {
                    i++;
                    DiziEtiket[i] = EtiketNumarasi[x, y];
                }
            }
            //Dizideki etiket numaralarını sıralıyor. Hazır fonksiyon kullanıyor.
            Array.Sort(DiziEtiket);
            //Tekrar eden etiket numaralarını çıkarıyor. Hazır fonksiyon kullanıyor. Tekil numaraları diziye atıyor.
            int[] TekrarsizEtiketNumaralari = DiziEtiket.Distinct().ToArray();
            //DİKKAT BURADA RenkDizisi ihtiyaç değil gibi. Renk adedi direk Tekrarsız numaralardan alınabilir.
            int[] RenkDizisi = new int[TekrarsizEtiketNumaralari.Length]; //Tekil numaralar aynı boyutta renk dizisini oluşturuyor.

            for (j = 0; j < TekrarsizEtiketNumaralari.Length; j++)
            {
                RenkDizisi[j] = TekrarsizEtiketNumaralari[j]; //sıradaki ilk renge, ait olacağı etiketin kaç numara olacağını atıyor.
            }
            int RenkSayisi = RenkDizisi.Length; //kaç tane numara varsa o kadar renk var demektir.
            Color[] Renkler = new Color[RenkSayisi]; Random Rastgele = new Random();
            int Kirmizi, Yesil, Mavi;
            for (int r = 0; r < RenkSayisi; r++) //sonraki renkler.
            {
                Kirmizi = Rastgele.Next(5, 25) * 10; //Açık renkler elde etmek ve 10 katları şeklinde olmasını sağlıyor. yani 150-250 arasındaki sayıları atıyor.
                Yesil = Rastgele.Next(5, 25) * 10;
                Mavi = Rastgele.Next(5, 25) * 10;
                Renkler[r] = Color.FromArgb(Kirmizi, Yesil, Mavi); //Renkler dizisi Color tipinde renkleri tutan bir dizidir.
            }
            //Color[] Renkler= { Color.Black, Color.Blue, Color.Red, Color.Orange, Color.LightPink, Color.LightYellow, Color.LimeGreen, Color.MediumPurple,
            //Color.Olive, Color.Magenta, Color.Maroon, Color.AliceBlue, Color.AntiqueWhite, Color.Aqua, Color.LightBlue, Color.Azure, Color.White };
            for (x = 1; x < ResimGenisligi - 1; x++) //Resmin 1 piksel içerisinden başlayıp, bitirecek.Çünkü çekirdek şablon en dış kenardan başlamalı.
            {
                for (y = 1; y < ResimYuksekligi - 1; y++)
                {
                    int RenkSiraNo = Array.IndexOf(RenkDizisi, EtiketNumarasi[x, y]); //Dikkat: önemli bir komut. Dizinin değerinden sıra numarasını alıyor.
                                                                                      //int[]array = { 2, 3, 5, 7, 11, 13 }; int index = Array.IndexOf(array, 11); // returns 4

                    if (GirisResmi.GetPixel(x, y).R < Esikleme) //Eğer bu pikselin rengi siyah ise aynı pikselin CikisResmi resmide siyah yapılacak.
                    {
                        CikisResmi.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        CikisResmi.SetPixel(x, y, Renkler[RenkSiraNo]);
                    }
                }
            }
            pictureBox3.Image = CikisResmi; txtKirmizi.Text = RenkSayisi.ToString();
        }




        public Bitmap ResmiGriTonaDonusturEsiklemeYap(Bitmap GirisResmi)
        {
            Color OkunanRenk, DonusenRenk;
            Bitmap CikisResmi;
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı. İçerisine görüntü yüklendi.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur. Tanımlaması globalde yapıldı.
            int i = 0, j = 0; //Çıkış resminin x ve y si olacak.
            int R = 0, G = 0, B = 0;

            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R; G = OkunanRenk.G; B = OkunanRenk.B;
                    int Gri = Convert.ToInt16(R * 0.3 + G * 0.6 + B * 0.1);
                    int Esikleme = 0;
                    try
                    {
                        Esikleme = Convert.ToInt16(textBox1.Text);
                    }
                    catch
                    {
                        Esikleme = 128;
                    }
                    //Esikleme kısmı
                    if (Gri > Esikleme) Gri = 255;
                    else
                        Gri = 0;
                    DonusenRenk = Color.FromArgb(Gri, Gri, Gri); CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            return CikisResmi;
        }







    }
}