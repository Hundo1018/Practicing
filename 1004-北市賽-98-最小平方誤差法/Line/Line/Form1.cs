using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Line
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "10";
            textBox2.Text = "20";
            textBox3.Text = "20";
            textBox4.Text = "40";
            textBox5.Text = "25";
            textBox6.Text = "50";
            BMP = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            G = Graphics.FromImage(BMP);
            G.TranslateTransform(fix, pictureBox1.Height - fix);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }
        float fix = 20;
        List<PointF> pl = new List<PointF>();
        Bitmap BMP;
        Graphics G;

        //標示
        private void button1_Click(object sender, EventArgs e)
        {
            pl.Add(new PointF(float.Parse(textBox1.Text), float.Parse(textBox2.Text)));
            pl.Add(new PointF(float.Parse(textBox3.Text), float.Parse(textBox4.Text)));
            pl.Add(new PointF(float.Parse(textBox5.Text), float.Parse(textBox6.Text)));
            float w = pictureBox1.Width;
            float h = pictureBox1.Height;
            for (int i = 0; i < pl.Count; i++)
            {
                G.DrawRectangle(new Pen(Color.Red, 1f),
                     TF(pl[i], w, h).X, TF(pl[i], w, h).Y, 2, 2
                    );
            }
            pictureBox1.Image = BMP;
            G.DrawLine(new Pen(Color.Black, 1f), new PointF(0, 0), new PointF(w - fix, 0));
            G.DrawLine(new Pen(Color.Black, 1f), new PointF(0, 0), new PointF(0, -(h - fix)));
            float maxx = pl.Max(x => x.X);
            float maxy = pl.Max(x => x.Y);
            float minx = pl.Min(x => x.X);
            float miny = pl.Min(x => x.Y);
            float stepx = 10;
            float stepy = 10;
            for (int i = 0; i <= 10; i++)
            {
                G.DrawString((stepx * i).ToString(), new Font("細明體", 10), Brushes.Black,
                    new PointF((stepx * i)/63 * pictureBox1.Width, 0)
                    );
                G.DrawString((stepy * i).ToString(), new Font("細明體", 10), Brushes.Black,
                    new PointF(-fix, -(stepy * i)/63 * pictureBox1.Height)
                    );
            }
          
        }
        //計算
        float m;
        float c;
        private void button2_Click(object sender, EventArgs e)
        {
             m = M();
             c = C();
            label1.Text = "m:" + m + "    " + "c:" + c;
        }
        //畫線
        private void button3_Click(object sender, EventArgs e)
        {
            List<PointF> FL = new List<PointF>();
            for (int i = 0; i <= 63; i++)
            {
                FL.Add(TF( new PointF(i,Y(m,i,c)),pictureBox1.Width,pictureBox1.Height));
            }
            for (int i = 0; i < FL.Count - 1; i++)
            {
                G.DrawLine(new Pen(Color.Blue), FL[i], FL[i + 1]);
            }
            pictureBox1.Image = BMP;
        }

        float AF()
        {
            float a = 0;
            for (int i = 0; i < pl.Count; i++)
            {
                a += pl[i].X;
            }
            return a;
        }
        float BF()
        {
            float b = 0;
            for (int i = 0; i < pl.Count; i++)
            {
                b += pl[i].Y;
            }
            return b;
        }
        float CF()
        {
            float c = 0;
            for (int i = 0; i < pl.Count; i++)
            {
                c += pl[i].X * pl[i].X;
            }
            return c;
        }
        float DF()
        {
            float d = 0;
            for (int i = 0; i < pl.Count; i++)
            {
                d += pl[i].X * pl[i].Y;
            }
            return d;
        }
        float EF()
        {
            float e = (3 * CF() - AF() * AF());
            return e;
        }

        float M()
        {
            float m = (3 * DF() - AF() * BF()) / EF();
            return m;
        }

        float C()
        {
            float c = (CF() * BF() - AF() * DF()) / EF();
            return c;
        }

        float Y(float m,float x, float c)
        {
            float y;
            y = m * x + c;
            return y;
        }
        PointF TF(PointF p, float W, float H)
        {
            float xmax = 63, xmin = 0, ymax = 63, ymin = 0;
            PointF op = new PointF(p.X, p.Y);
            op.X = ((op.X - xmin) / xmax) * (W - fix) + fix;
            op.Y = -(((op.Y - ymin) / ymax) * (H - fix) + fix);
            return op;
        }
    }
}
