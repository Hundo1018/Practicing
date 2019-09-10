using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Draw();
        }
        Color c;
        void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics G = Graphics.FromImage(bmp);
            G.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
            int r = hScrollBar1.Value,
                N = hScrollBar2.Value;
            List<PointF> PL = new List<PointF>();
            PointF center = new PointF(0, 0);
            for (int n = 1; n <= N; n++)
            {
                double pi = Math.PI;

                PL.Add(new PointF(
                    (float)(r * (Math.Cos(2 * pi * n / N + pi / 2)) + center.X),
                    -(float)(r * (Math.Sin(2 * pi * n / N + pi / 2)) + center.Y)));
            }
            for (int i = 0; i < PL.Count; i++)
            {
                for (int j = 0; j < PL.Count; j++)
                {
                    G.DrawLine(new Pen(c),
                        PL[i],
                        PL[j]);
                }
            }

            G.DrawRectangle(new Pen(Color.Black),
                new Rectangle(new Point(0,0),new Size(5,5)));
            pictureBox1.Image = bmp;

        }
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            Draw();
            label2.Text = e.NewValue.ToString();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Draw();
            label1.Text = e.NewValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                c = cd.Color;
            }
        }
    }
}
