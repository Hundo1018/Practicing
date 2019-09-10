using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
namespace Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "第1段線段座標";
            label2.Text = "第2段線段座標";
            label3.Text = "兩條線段";
            label4.Text = "相交點座標";
            button1.Text = "重畫及判斷";
            button2.Text = "清除";
            textBox1.Text = "-12,12";
            textBox2.Text = "12,-12";
            textBox3.Text = "-10,5";
            textBox4.Text = "18,15";
            //process(0, 0, 0, 0);
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs ee)
        {
            bmp = new Bitmap(W, H);
            G = Graphics.FromImage(bmp);
            DrawT();
            string[] temp = textBox1.Text.Split(',');
            string[] temp2 = textBox2.Text.Split(',');
            PointF[] P1 = new PointF[2];
            P1[0] = new PointF(float.Parse(temp[0]), float.Parse(temp[1]));
            P1[1] = new PointF(float.Parse(temp2[0]), float.Parse(temp2[1]));
            temp = textBox3.Text.Split(',');
            temp2 = textBox4.Text.Split(',');
            PointF[] P2 = new PointF[2];
            P2[0] = new PointF(float.Parse(temp[0]), float.Parse(temp[1]));
            P2[1] = new PointF(float.Parse(temp2[0]), float.Parse(temp2[1]));



            double a = GetA(P1);
            double b = GetB(P1);
            double c = GetC(P1);

            double d = GetA(P2);
            double e = GetB(P2);
            double f = GetC(P2);

            double N = (c * e - b * f) / (a * e - b * d);
            double O = (c * d - a * f) / (b * d - a * e);
            if (CheckN(N, P1) && CheckN(N, P2) &&
                CheckO(O, P1) && CheckO(O, P2))
            {
                textBox5.Text = "有相交";
                textBox6.Text = $"{Math.Round(N, 2)},{Math.Round(O, 2)}";
            }
            else
            {
                textBox5.Text = "未相交";
                textBox6.Text = "";
            }
            DrawLine(P1);
            DrawLine(P2);
            pictureBox1.Image = bmp;
        }
        Bitmap bmp;
        Graphics G;
        int W = 800, H = 600;
        void DrawLine(PointF[] P)
        {
            G.DrawLine(new Pen(Color.Black, 0.1f),
                P[0].X, -P[0].Y,
                P[1].X, -P[1].Y);
        }
        void DrawT()
        {
            G.TranslateTransform((int)W / 2, (int)H / 2);
            G.ScaleTransform(10f, 10f);
            G.DrawLine(new Pen(Color.Black, 0.1f), new Point(-30, 0), new Point(30, 0));
            G.DrawLine(new Pen(Color.Black, 0.1f), new Point(0, -40), new Point(0, 40));
        }
        double GetA(PointF[] P)
        {
            return -(P[1].Y - P[0].Y);
            return P[1].Y - P[0].Y;
        }
        double GetB(PointF[] P)
        {
            return (P[1].X - P[0].X);
            return P[1].X - P[0].X;
        }
        double GetC(PointF[] P)
        {
            return ((P[0].Y * (P[1].X - P[0].X)) - (P[0].X * (P[1].Y - P[0].Y)));
            return ((P[0].X * (P[1].Y - P[0].Y)) - (P[0].Y * (P[1].X - P[0].X)));
        }

        bool CheckN(double n, PointF[] p)
        {
            p = p.OrderBy(x => x.X).ToArray();
            if (n >= p[0].X && n <= p[1].X)
            {
                return true;
            }
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(W, H);
            G = Graphics.FromImage(bmp);
            DrawT();
            pictureBox1.Image = bmp;
            for (int i = 1; i <= 6; i++)
            {
                Controls[$"textBox{i}"].Text = "";
            }
        }

        bool CheckO(double n, PointF[] p)
        {
            p = p.OrderBy(x => x.Y).ToArray();
            if (n >= p[0].Y && n <= p[1].Y)
            {
                return true;
            }
            return false;
        }
    }
}
