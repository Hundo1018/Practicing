using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maximum_Power_Transfer_to_a_Load
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float Rmin = int.Parse(textBox1.Text);
            float Rmax = int.Parse(textBox2.Text);
            float RDelta = int.Parse(textBox3.Text);
            float V = int.Parse(textBox4.Text);
            float R1 = int.Parse(textBox5.Text);
            List<PointF> W = new List<PointF>();
            List<float> RL = new List<float>();

            int fix = 25;
            float minu = Rmax - Rmin;
            float WW = (float)pictureBox1.Width - fix;
            float HH = (float)pictureBox1.Height - fix;

            //比例: 整個橫向Rmax == ww Rmin == fix (fix,ww) (fix,hh)
            for (float i = Rmin; i <= Rmax; i += RDelta)
            {
                W.Add(new PointF((i), ((float)(Math.Pow((V / (R1 + i)), 2)) * i)));
            }
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics G = Graphics.FromImage(bmp);
            G.TranslateTransform(0, pictureBox1.Height);
            float maxmaxy = W.Max(x => x.Y);
            float maxmaxx = W.Max(x => x.X);
            float maxmarkx = 0, maxmarky = 9999;
            for (int i = 0; i < W.Count - 1; i++)
            {
                float
                    X1 = W[i].X / maxmaxx * WW + fix,
                    Y1 = -1 * W[i].Y / maxmaxy * HH - fix,
                    X2 = W[i + 1].X / maxmaxx * WW + fix,
                    Y2 = -1 * W[i + 1].Y / maxmaxy * HH - fix;
                G.DrawLine(new Pen(Color.Blue, 1),
                       X1,
                       Y1,
                       X2,
                       Y2);
                if (Y1 <= maxmarky)
                {
                    maxmarky = Y1;
                    maxmarkx = X1;
                }
            }
            G.DrawString("＊", new Font("新細明體", 5), Brushes.Red, new PointF(maxmarkx, maxmarky));
            G.DrawLine(new Pen(Color.Black, 0.5f), new Point(fix, -fix), new Point(pictureBox1.Width, -fix));
            for (float i = 0; i <= Rmax; i += 10)
            {
                G.DrawString(i.ToString(), new Font("新細明體", 10), Brushes.Black,
                    new PointF(i/Rmax * (WW), -fix));
            }
            G.DrawLine(new Pen(Color.Black, 0.5f), new Point(fix, -fix), new Point(fix,- pictureBox1.Height));
            for (float i = 0; i <= W.Max(x => x.Y); i += 10)
            {
                G.DrawString((i).ToString(), new Font("新細明體", 10), Brushes.Black,
                    new PointF(0, i / W.Max(x=>x.Y) * (-HH) - fix));
            }
            pictureBox1.Image = bmp;
        }
    }
}
