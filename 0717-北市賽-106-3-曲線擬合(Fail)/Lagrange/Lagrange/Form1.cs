using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lagrange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2_Click(null,null);
        }
        int XSi=50, YSi=10;
        List<Point> OriList = new List<Point>();
        List<Point> ListZoom = new List<Point>();
        List<Point> NewList = new List<Point>();
        Bitmap B;
        Graphics G;
        Pen P = new Pen(Color.Blue,1.0f);
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OriList = new List<Point>() { new Point(1, 1), new Point(2, 8), new Point(3, 27) };
            XSi = (pictureBox1.Width / OriList.Max(x=>x.X));
            YSi = (pictureBox1.Height / OriList.Max(x=>x.Y));

            ListZoom = new List<Point>();
            ListZoom.Add(new Point(0, 0));
            foreach (var item in OriList) ListZoom.Add(new Point(item.X * XSi, item.Y * YSi));
            for (int x = ListZoom.First().X; x < ListZoom.Last().X; x++)
            {
                NewList.Add(new Point(x, P2(x)));
            }
            B = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            G = Graphics.FromImage(B);
            G.Transform.Translate(0, (B.Height / 2));
            for (int y = 0; y < NewList.Count - 1; y++)
            {
                G.DrawLine(P, NewList[y], NewList[y + 1]);
            }
            pictureBox1.Image = B;
        }
        int  P2(int x)
        {
            int A = 0;
            for (int i = 0; i < ListZoom.Count(); i++)
            {
                A+= ListZoom[i].Y * L(x);
            }
            return A;
        }
        int L(int x)
        {
            int tempa=1,tempb=1;
            for (int i = 0; i < ListZoom.Count; i++)
            {
                for (int j = 0; j < ListZoom.Count; j++)
                {
                    if (i == j) continue;
                    tempa *= (x- ListZoom[j].X);
                    tempb *= (ListZoom[i].X - ListZoom[j].X);
                }
            }
            return (tempa / tempb);
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
