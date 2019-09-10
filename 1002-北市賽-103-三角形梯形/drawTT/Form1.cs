using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drawTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "3";
            textBox2.Text = "6";
            textBox3.Text = "8";
            textBox4.Text = "1";
            textBox5.Text = "7";
            textBox6.Text = "14";
            textBox7.Text = "20";
            textBox8.Text = "10";
        }
        double fix = 25, W, H, X;
        double YDataBigest = 1, XDataBigest;
        private void button1_Click(object sender, EventArgs e)
        {
            X = int.Parse(textBox8.Text);
            W = pictureBox1.Width;
            H = pictureBox1.Height;
            Bitmap BMP = new Bitmap((int)W, (int)H);
            Graphics G = Graphics.FromImage(BMP);
            Pen P = new Pen(Color.Red, 1f);
            G.TranslateTransform((int)fix, (int)(H - fix));

            float  A = float.Parse(textBox1.Text),
                   M = float.Parse(textBox2.Text),
                   B = float.Parse(textBox3.Text);

            List<PointF> LP = new List<PointF>();
            LP.Add(new PointF(0, 0));
            LP.Add(new PointF(A, 0));
            LP.Add(new PointF(M, 1));
            LP.Add(new PointF(B, 0));
            LP.Add(new PointF((int)X, 0));
            XDataBigest = X;
            List<PointF> LP2 = new List<PointF>();

            for (int i = 0; i < LP.Count - 1; i++)
            {
                PointF ap = T(LP[i]), bp = T(LP[i + 1]);
                LP2.Add(ap);
                LP2.Add(bp);
                G.DrawLine(P, ap, bp);
            }
            G.DrawLine(P, new Point(0, 0), new Point((int)W, 0));
            G.DrawLine(P, new Point(0, 0), new Point(0, -(int)H));
            pictureBox1.Image = BMP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            X = int.Parse(textBox8.Text);
            W = pictureBox2.Width;
            H = pictureBox2.Height;
            Bitmap BMP = new Bitmap((int)W, (int)H);
            Pen P = new Pen(Color.Blue, 1f);
            Graphics G = Graphics.FromImage(BMP);

            G.TranslateTransform((int)fix, (int)(H - fix));

            float A = float.Parse(textBox4.Text),
                B = float.Parse(textBox5.Text),
                C = float.Parse(textBox6.Text),
                D = float.Parse(textBox7.Text);
            List<PointF> LP = new List<PointF>();
            LP.Add(new PointF(0, 0));
            LP.Add(new PointF(A, 0));
            LP.Add(new PointF(B, 1));
            LP.Add(new PointF(C, 1));
            LP.Add(new PointF(D, 0));
            LP.Add(new PointF((float)X, 0));
            for (int i = 0; i < LP.Count - 1; i++)
            {
                PointF Ap = LP[i], Bp = LP[i + 1];
                G.DrawLine(P, T(Ap), T(Bp));
            }
            pictureBox2.Image = BMP;
        }

        PointF T(PointF p)
        {
            p.X = (float)
                (
                (W - fix) / (X) * //W-調整量
                (p.X)
                );
            p.Y = (float)
                (
                ((H - fix * 2) * //H - 調整量  (縮小量=圖形抬高+標籤區高度) 
                (p.Y / YDataBigest) * //繪畫比例
                (-1))//相反
                - (fix)//抬高
                );
            return p;
        }
    }
}
