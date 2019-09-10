using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallFly
{
    class pointd
    {
        public double X, Y;
        public pointd(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Cul();
            Draw();
        }
        double G = -9.8;
        double V = 20;
        List<List<pointd>> pdl = new List<List<pointd>>();
        void Cul()
        {
            for (int j = 0; j <= 180; j++)
            {
                double a = j / 180d * Math.PI;
                double Vy0 = V * Math.Sin(a);
                double Vx0 = V * Math.Cos(a);
                pointd p = new pointd(0, 0);
                List<pointd> temp = new List<pointd>();
                for (double i = 0; i <= 50; i += 0.1)
                {
                    temp.Add(new pointd(p.X, p.Y));
                    p.X = 0 + Vx0 * i;
                    p.Y = 0 + Vy0 * i + (0.5 * G * i * i);
                    if (p.Y <= 0 && i != 0)
                    {
                        break;
                    }
                }
                pdl.Add(new List<pointd>(temp));
            }
        }
        void Draw()
        {
            int W = pictureBox1.Width;
            int H = pictureBox1.Height;
            Bitmap bmp = new Bitmap(W, H);
            Graphics G = Graphics.FromImage(bmp);
            G.TranslateTransform(0, H);
            float fix = 40;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            for (int i = 5 * 2; i < (pdl.Count / 2); i += 5)
            {
                for (int j = 0; j < pdl[i].Count - 1; j++)
                {
                    G.DrawLine(new Pen((i == 45 ? Color.Red : Color.Black), 1f),
                        (float)pdl[i][j].X * (W / fix),
                       -(float)pdl[i][j].Y * (H / fix),
                        (float)pdl[i][j + 1].X * (W / fix),
                       -(float)pdl[i][j + 1].Y * (H / fix));
                }
            }
            pictureBox1.Image = bmp;

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
