using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path = "1.bmp";
        Bitmap bmp;
        Graphics G;
        Pen P;
        private void button1_Click(object sender, EventArgs e)
        {
            P = new Pen(Color.Red,1f);
            bmp = new Bitmap(path);
            G = Graphics.FromImage(bmp);
            int top = bmp.Height, bot = 0, left = bmp.Width, right = 0;
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    int B = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3;
                    B = (int)bmp.GetPixel(j, i).GetBrightness();
                    if (B <= 0.5)
                    {
                        if (i < top)
                        {
                            top = i;
                        }
                        if (i > bot)
                        {
                            bot = i;
                        }
                        if (j < left)
                        {
                            left = j;
                        }
                        if (j > right)
                        {
                            right = j;
                        }
                    }
                }
            }
            Rectangle R = new Rectangle(new Point() { X = left, Y = top }, new Size() { Width = right - left, Height = bot - top });
            G.DrawRectangle(P, R);
            pictureBox1.Image = bmp;
        }

    }
    class GPoint
    {
        public int X, Y;
        public GPoint(int y, int x)
        {
            Y = x;
            X = y;
        }
    }
}
