using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paintapp
{
    //Menülere tıklandığında arka plan rengini değiştirmemize yarayan sınıf.
    class BackgroundColor  
    {
        public static void ChangeColor(Panel panelname, Color color)
        {
            panelname.BackColor = color;
        }

    }
    //Şekil çizdirmek için oluşturulan sınıf

    //Kaydetme ve okuma işlemlerinin geneli için oluşturulan sınıf.
    class Kaydet 
    {

        private static FileStream dosyaYaz; 
        private static StreamWriter yaz;
        protected static string dosyaYolu;
        //Daire veya elips şeklini kaydetmek için oluşturulan metot
        public static void daire(int n1, int n2, int n3, int n4)  
        {
            dosyaYolu = Application.StartupPath.ToString() + "\\temporary.tmp";
            dosyaYaz = new FileStream(dosyaYolu, FileMode.Append);
            yaz = new StreamWriter(dosyaYaz);
            string nn1, nn2, nn3, nn4;

            nn1 = Convert.ToString(n1);
            nn2 = Convert.ToString(n2);
            nn3 = Convert.ToString(n3);
            nn4 = Convert.ToString(n4);

            yaz.WriteLine("D," + "," + nn1 + "," + nn2 + "," + nn3 + "," + nn4);
            yaz.Close();
            dosyaYaz.Close();
        }

        //Kare,üçgen ve altıgen şekillerini kaydetmek için kullanılan metot.
        public static void cokgen(string renk, PointF[] shape)  
        {
            dosyaYolu = Application.StartupPath.ToString() + "\\temporary.tmp";
            dosyaYaz = new FileStream(dosyaYolu, FileMode.Append);
            yaz = new StreamWriter(dosyaYaz);
            int x = shape.Length;
            if (shape.Length == 4) 
            {
                yaz.Write("K,");
            }
            else if (shape.Length == 3)
            {
                yaz.Write("U,");
            }
            else if (shape.Length == 6)
            {
                yaz.Write("A,");
            }

            yaz.Write(renk);
            for (int i = 0; i < x; i++)
            {

                if (i == x - 1)
                {
                    yaz.WriteLine("," + shape[i].X + "," + shape[i].Y);
                }
                else
                {
                    yaz.Write("," + shape[i].X + "," + shape[i].Y);
                }


            }

            yaz.Close();
            dosyaYaz.Close();

        }
        


    }

    //Seçim aracı ile üzerine tıklanılan şekli seçmek için oluşturulan sınıf.
    class SelectShape
    {
        private static string secilenSek = null;
        public static void select(MouseEventArgs e, PictureBox pictureBox1)  
        {
            int bnX = e.X, bnY = e.Y;
            


            string[] oku = File.ReadAllLines(Application.StartupPath.ToString() + "\\temporary.tmp");
            for (int i = 0; i < oku.Length; i++) 
            {

                if ((oku[i].Split(','))[0] == "D")
                {
                    if (bnX > Convert.ToInt16((oku[i].Split(','))[2]) && bnY > Convert.ToInt16((oku[i].Split(','))[3]) && bnX < (Convert.ToInt16((oku[i].Split(','))[4]) + Convert.ToInt16((oku[i].Split(','))[2])) && bnY < ((Convert.ToInt16((oku[i].Split(','))[5]) + Convert.ToInt16((oku[i].Split(','))[3]))))
                    {
                        secilenSek = oku[i];
                        
                        Graphics graph = pictureBox1.CreateGraphics();
                        Pen p = new Pen(Color.Red, 3);
                        graph.Clear(Color.White);
                        
                        graph.DrawRectangle(p, Convert.ToInt16((oku[i].Split(','))[2]) - 16, Convert.ToInt16((oku[i].Split(','))[3]) - 16, Convert.ToInt16((oku[i].Split(','))[4]) + 32, Convert.ToInt16((oku[i].Split(','))[5]) + 32);
                        SolidBrush blackBrushh = new SolidBrush(Color.Red);
                        graph.FillRectangle(blackBrushh, Convert.ToInt16((oku[i].Split(','))[2]) - 16, Convert.ToInt16((oku[i].Split(','))[3]) - 16, Convert.ToInt16((oku[i].Split(','))[4]) + 32, Convert.ToInt16((oku[i].Split(','))[5]) + 32);
                        
                    }

                    

                }
                
                else if ((oku[i].Split(','))[0] == "A")
                {
                    if (bnX > Convert.ToInt16((oku[i].Split(','))[4]) && bnY > Convert.ToInt16((oku[i].Split(','))[3]) && bnX < (Convert.ToInt16((oku[i].Split(','))[10])) && bnY < ((Convert.ToInt16((oku[i].Split(','))[6]))))
                    {
                        secilenSek = oku[i];
                        
                        Graphics graph =pictureBox1.CreateGraphics();
                        Pen p = new Pen(Color.Red, 3);
                        graph.Clear(Color.Gainsboro);
                        //Kaydet.dosyaOku(pictureBox1);
                        graph.DrawRectangle(p, Convert.ToInt16((oku[i].Split(','))[4]) - 16, Convert.ToInt16((oku[i].Split(','))[3]) - 16, Convert.ToInt16((oku[i].Split(','))[10]) - Convert.ToInt16((oku[i].Split(','))[4]) + 32, Convert.ToInt16((oku[i].Split(','))[7]) - Convert.ToInt16((oku[i].Split(','))[13]) + 32);
                    }


                }
                else if ((oku[i].Split(','))[0] == "U")
                {
                    if (bnX > Convert.ToInt16((oku[i].Split(','))[4]) && bnY > Convert.ToInt16((oku[i].Split(','))[3]) && bnX < (Convert.ToInt16((oku[i].Split(','))[6])) && bnY < ((Convert.ToInt16((oku[i].Split(','))[7]))))
                    {
                        secilenSek = oku[i];
                        
                        Graphics graph = pictureBox1.CreateGraphics();
                        Pen p = new Pen(Color.Red, 3);
                        graph.Clear(Color.Gainsboro);
                        //Kaydet.dosyaOku(pictureBox1);
                        graph.DrawRectangle(p, Convert.ToInt16((oku[i].Split(','))[4]) - 16, Convert.ToInt16((oku[i].Split(','))[3]) - 16, Convert.ToInt16((oku[i].Split(','))[6]) - Convert.ToInt16((oku[i].Split(','))[4]) + 32, Convert.ToInt16((oku[i].Split(','))[5]) - Convert.ToInt16((oku[i].Split(','))[3]) + 32);
                    }


                }
            }
        }
        
        public static void yenidenRenk(string renk, PictureBox pictureBox1) //Seçilen şekli yeniden renklendirmek için kullanıl
        {
            if (secilenSek != null)
            {
                try
                {

                    FileStream dosyaYaz;
                    StreamWriter yaz;
                    dosyaYaz = new FileStream(Application.StartupPath.ToString() + "\\temporary.tmp", FileMode.Truncate);
                    yaz = new StreamWriter(dosyaYaz);
                    string[] geciciOku = File.ReadAllLines(Application.StartupPath.ToString() + "\\temporary.tmp");
                    string[] neu = new string[geciciOku.Length];
                    for (int i = 0; i < geciciOku.Length; i++)
                    {
                        if (geciciOku[i] != secilenSek)
                        {
                            yaz.WriteLine(geciciOku[i]);
                        }
                        else
                        {
                            yaz.WriteLine(geciciOku[i].Replace(geciciOku[i].Split(',')[1], renk));
                        }

                    }
                    yaz.Close();
                    dosyaYaz.Close();
                    dosyaYaz = new FileStream(Application.StartupPath.ToString() + "\\temporary.tmp", FileMode.Truncate);
                    yaz = new StreamWriter(dosyaYaz);
                    yaz.Write(File.ReadAllText(Application.StartupPath.ToString() + "\\temporaryDel.tmp"));

                    yaz.Close();
                    dosyaYaz.Close();
                    Graphics graf = pictureBox1.CreateGraphics();
                    graf.Clear(Color.Gainsboro);
                    

                }
                catch (Exception)
                {

                    throw;
                }

            }

        }
        

    }
}

















