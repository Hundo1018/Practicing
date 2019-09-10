using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineIn3Point
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            itli();
            panel1.BackgroundImage = BMP;
        }
        void itli()
        {
            BMP = new Bitmap(panel1.Width, panel1.Height);
            G = Graphics.FromImage(BMP);
            G.TranslateTransform(0, BMP.Height);
            //橫
            for (int i = 0; i <= 6; i++)
            {
                Point p = new Point((int)(((panel1.Width - fix) * (i / 6d))), -fix);
                G.DrawString((i * 10).ToString(), textBox1.Font, Brushes.Black, p);
            }
            G.DrawLine(P, new Point(fix, -fix), new Point(BMP.Width, -fix));
            //縱
            for (int i = 0; i <= 6; i++)
            {
                Point p = new Point(fix / 2, -(int)(((panel1.Height - fix) * (i / 6d))));
                G.DrawString((i * 10).ToString(), textBox1.Font, Brushes.Black, p);
            }
            G.DrawLine(P, new Point(fix, -fix), new Point(fix, -BMP.Height));
            
        }
        Bitmap BMP;
        Graphics G;
        Pen P = new Pen(Color.Red,1f);
        Point[] P3;
        int fix = 25;

        double A(Point[]p3)
        {
            double a =0;
            for (int i = 0; i < 3; i++)
            {
                a += p3[i].X;
            }
            return a;
        }

        double B(Point []p3)
        {
            double b = 0;
            for (int i = 0; i < 3; i++)
            {
                b += p3[i].Y;
            }
            return b;
        }

        double C(Point[] p3)
        {
            double c = 0;
            for (int i = 0; i < 3; i++)
            {
                c += p3[i].X * p3[i].Y;
            }
            return c;
        }

        double D(Point[] p3)
        {
            double d = 0;
            for (int i = 0; i < 3; i++)
            {
                d += Math.Pow(p3[i].X, 2);
            }
            return d;
        }


        double M(Point[] p3)
        {
            double m = 0;
            m = ((3 * C(p3) - A(p3) * B(p3)) / (3 * D(p3) - Math.Pow(A(p3), 2)));
            return m;
        }

        double CC(Point[] p3)
        {
            double cc = 0;
            cc = (((D(p3) * B(p3)) - (A(p3) * C(p3))) / ((3 * D(p3)) - Math.Pow(A(p3), 2)));
            return cc;
        }
        int GetY(double x, double m, double c)
        {
            double yy = m * x + c;
            return (int)yy;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            itli();
            List<Point> LP = new List<Point>();
            for (int i = -panel1.Width; i < panel1.Width; i++)
            {
                LP.Add(new Point(i, GetY(i, MMM, CCC)));
            }
            for (int i = 0; i < LP.Count - 1; i++)
            {
                if (LP[i].Y >= 0 && LP[i].Y <= 63 && LP[i].X >= 0 && LP[i].Y <= 63)
                {
                    G.DrawLine(P,
                       XTran(LP[i].X), YTran(LP[i].Y),
                        XTran(LP[i + 1].X), YTran(LP[i + 1].Y));
                }
            }
            //G.DrawLine(P, XTran(0), YTran(0), XTran(63), YTran(63));

            panel1.BackgroundImage = BMP;
        }
        int XTran(int inx)
        {
            double inxd = inx;
            int xt = fix + (int)((inxd / 63) * panel1.Width);
            return xt;
        }
        int YTran(int iny)
        {
            double inyd = iny;
            int yt = -(int)((iny / 63d) * panel1.Height) - fix;
            //yt = 100;
            return yt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MMM = M(P3);
            CCC = CC(P3);
            label1.Text = $"m={MMM}";
            label2.Text = $"c={CCC}";
        }
        double MMM,CCC;

        private void button1_Click(object sender, EventArgs e)
        {
            P3 = new Point[3] { new Point(15, 20), new Point(20, 40), new Point(25, 50) };

        }
    }
}
