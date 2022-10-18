using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace paintapp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Width = 1500;
            this.Height = 700;

            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pictureBox1.Image = bm;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            pictureBox1.Paint += PictureBox1_Paint;


        }

        Bitmap bm;
        bool paint = false;
        
        Pen p = new Pen(Color.Black, 2);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        int index;
        int x, y, sX, sY, cX, cY;
        Graphics g;
        Color secimRenk = Color.Black;
        string strRenk = "siyah";

        private void btn_kare_Click(object sender, EventArgs e)
        {
            index = 3;
           
            BackgroundColor.ChangeColor(kare_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(altigen_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(ellipse_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(ucgen_panel, Color.MistyRose);
            
        }

        private void btn_kare_Paint(object sender, PaintEventArgs e)
        {

        }



        private void PictureBox1_MouseDown(object? sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            paint = true;
            cX = e.X;
            cY = e.Y;
        }

        private void btn_red_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Red, 2);
            blackBrush = new SolidBrush(Color.Red);
            BackgroundColor.ChangeColor(kirmizi_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(mavi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(yesil_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(sari_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(trnc_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mor_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(kahve_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(beyaz_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(siyah_panel, Color.MistyRose);
            
        }

        private void btn_altigen_Click(object sender, EventArgs e)
        {
            index = 4;
            BackgroundColor.ChangeColor(kare_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(altigen_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(ellipse_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(ucgen_panel, Color.MistyRose);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            index = 8;
            
            BackgroundColor.ChangeColor(secim_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(silme_panel, Color.White);


        }


        private void PictureBox1_MouseMove(object? sender, MouseEventArgs e)
        {

            pictureBox1.Refresh();
            x = e.X;
            y = e.Y;
            sX = e.X - x;
            sY = e.Y - y;

        }
        private void PictureBox1_MouseUp(object? sender, MouseEventArgs e)
        {


            paint = false;
            sX = x - cX;
            sY = y - cY;


            if (index == 2)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawEllipse(p, cX, cY, sX, sY);
                g.FillEllipse(blackBrush, cX, cY, sX, sY);
                Kaydet.daire(cX, cY, sX, sY);
            }

            if (index == 3)
            {     
                g.DrawRectangle(p, cX, cY, sX, sY);
                g.FillRectangle(blackBrush, cX, cY, sX, sY);   
            }


            if (index == 4)
            {

                var graphics = g;

                //Get the middle of the panel
                var x_0 = cX;
                var y_0 = cY;

                var shape = new PointF[6];

                var r = sX; // radius 

                //Create 6 points
                for (int a = 0; a < 6; a++)
                {
                    shape[a] = new PointF(
                        x_0 + r * (float)Math.Cos(a * 60 * Math.PI / 180f),
                        y_0 + r * (float)Math.Sin(a * 60 * Math.PI / 180f));
                }

                graphics.DrawPolygon(p, shape);
                g.FillPolygon(blackBrush, shape);
                Kaydet.cokgen(strRenk, shape);

            }
            if (index == 5)
            {
                var graphics = g;
                var x_r = cX;
                var y_r = cY;
                var r = sY;


                var shape1 = new PointF[3];
                for (int a = 0; a < 3; a++)
                {
                    shape1[a] = new PointF(
                        x_r - r * (float)Math.Cos(a * 90 * Math.PI / 180f),
                        y_r - r * (float)Math.Sin(a * 90 * Math.PI / 180f));

                }
                graphics.DrawPolygon(p, shape1);
                g.FillPolygon(blackBrush, shape1);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            index = 5;
            BackgroundColor.ChangeColor(kare_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(altigen_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(ellipse_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(ucgen_panel, Color.Turquoise);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            BackgroundColor.ChangeColor(silme_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(secim_panel, Color.White);
            g.Clear(Color.White);
            pictureBox1.Image = bm;
            index = 6;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap btm = bm.Clone(new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), bm.PixelFormat);
                btm.Save(sfd.FileName, ImageFormat.Jpeg);

            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C : \\";
            ofd.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            ofd.ShowDialog();
            string fname = ofd.FileName;
            pictureBox1.ImageLocation = fname;






        }

        private void ucgen_panel_Paint(object sender, PaintEventArgs e)
        {
            //
        }

        private void ucgen_panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (index == 5)
            {
                BackgroundColor.ChangeColor(kare_panel, Color.MistyRose);
                BackgroundColor.ChangeColor(altigen_panel, Color.MistyRose);
                BackgroundColor.ChangeColor(ellipse_panel, Color.MistyRose);
                BackgroundColor.ChangeColor(ucgen_panel, Color.Turquoise);
            }

        }

        private void btn_blue_Click(object sender, EventArgs e)
        {

            p = new Pen(Color.Blue, 2);
            blackBrush = new SolidBrush(Color.Blue);
            BackgroundColor.ChangeColor(kirmizi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mavi_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(yesil_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(sari_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(trnc_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mor_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(kahve_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(beyaz_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(siyah_panel, Color.MistyRose);
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }


        private void secim_panel_Paint(object sender, PaintEventArgs e)
        {
            //
        }



        private void btn_green_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Green, 2);
            blackBrush = new SolidBrush(Color.Green);
            BackgroundColor.ChangeColor(kirmizi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mavi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(yesil_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(sari_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(trnc_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mor_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(kahve_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(beyaz_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(siyah_panel, Color.MistyRose);
        }

        private void btn_blck_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Black, 2);
            blackBrush = new SolidBrush(Color.Black);
            BackgroundColor.ChangeColor(kirmizi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mavi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(yesil_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(sari_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(trnc_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mor_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(kahve_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(beyaz_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(siyah_panel, Color.Turquoise);
        }

        private void btn_mor_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Purple, 2);
            blackBrush = new SolidBrush(Color.Purple);
            BackgroundColor.ChangeColor(kirmizi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mavi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(yesil_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(sari_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(trnc_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mor_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(kahve_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(beyaz_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(siyah_panel, Color.MistyRose);
        }

        private void btn_kahve_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Brown, 2);
            blackBrush = new SolidBrush(Color.Brown);
            BackgroundColor.ChangeColor(kirmizi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mavi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(yesil_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(sari_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(trnc_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mor_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(kahve_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(beyaz_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(siyah_panel, Color.MistyRose);
        }

        private void btn_orange_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Orange, 2);
            blackBrush = new SolidBrush(Color.Orange);
            BackgroundColor.ChangeColor(kirmizi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mavi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(yesil_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(sari_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(trnc_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(mor_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(kahve_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(beyaz_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(siyah_panel, Color.MistyRose);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (index==8)
            {
                SelectShape.select(e, pictureBox1);
            }


        }



        private void btn_white_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Black, 2);
            blackBrush = new SolidBrush(Color.White);
            BackgroundColor.ChangeColor(kirmizi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mavi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(yesil_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(sari_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(trnc_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mor_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(kahve_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(beyaz_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(siyah_panel, Color.MistyRose);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            index = 2;
            BackgroundColor.ChangeColor(kare_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(altigen_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(ellipse_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(ucgen_panel, Color.MistyRose);
        }
        private void PictureBox1_Paint(object? sender, PaintEventArgs e)
        {

            Graphics _g = e.Graphics;

            if (paint)
            {
                if (index == 2)
                {
                    _g.DrawEllipse(p, cX, cY, sX, sY);


                }
                if (index == 3)
                {
                    _g.DrawRectangle(p, cX, cY, 2 * sX, 2 * sY);
                }
                if (index == 4)
                {
                    var graphics = e.Graphics;

                    //Get the middle of the panel
                    var x_0 = cX;
                    var y_0 = cY;

                    var shape = new PointF[6];

                    var r = sX; //70 px radius 

                    //Create 6 points
                    for (int a = 0; a < 6; a++)
                    {
                        shape[a] = new PointF(
                            x_0 + r * (float)Math.Cos(a * 60 * Math.PI / 180f),
                            y_0 + r * (float)Math.Sin(a * 60 * Math.PI / 180f));
                    }

                    graphics.DrawPolygon(Pens.Red, shape);

                }



            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Yellow, 2);
            blackBrush = new SolidBrush(Color.Yellow);
            BackgroundColor.ChangeColor(kirmizi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mavi_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(yesil_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(sari_panel, Color.Turquoise);
            BackgroundColor.ChangeColor(trnc_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(mor_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(kahve_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(beyaz_panel, Color.MistyRose);
            BackgroundColor.ChangeColor(siyah_panel, Color.MistyRose);
        }


    }
}