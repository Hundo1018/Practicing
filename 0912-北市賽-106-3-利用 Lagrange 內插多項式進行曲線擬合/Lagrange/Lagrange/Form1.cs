using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lagrange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Height = panel1.Height + 10;
            readdata();
            Func();
            Draw();
        }
        bool ShowOrNot = true;
        Graphics G;
        Bitmap BMP;
        Pen pen;
        int Bei = 10;

        void Draw()
        {
            BMP = new Bitmap(panel1.Width, panel1.Height);
            G = Graphics.FromImage(BMP);
            pen = new Pen(Color.Blue, 2f);
            Pen linepen = new Pen(Color.Black, 0.5f);
            if (ShowOrNot)
            {

                for (int i = 0; i < panel1.Height; i += Bei)
                {
                    G.DrawLine(linepen, new Point(0, i), new Point(panel1.Width, i));
                }
                for (int i = 0; i < panel1.Width; i += Bei)
                {
                    G.DrawLine(linepen, new Point(i, 0), new Point(i, panel1.Height));
                }
            }
            for (int i = 0; i < spoints.Count - 1; i++)
            {
                G.DrawLine(pen, spoints[i].X, spoints[i].Y, spoints[i + 1].X, spoints[i + 1].Y);
            }
            for (int i = 0; i < points.Count; i++)
            {
                G.DrawLine(new Pen(Color.Red, 2), points[i].X - 3, points[i].Y, points[i].X + 3, points[i].Y);
                G.DrawLine(new Pen(Color.Red, 2), points[i].X, points[i].Y - 3, points[i].X, points[i].Y + 3);
            }

            panel1.BackgroundImage = BMP;
        }
        void readdata()
        {
            //points = new List<Point>()
            //{new Point(1,1),new Point(2,8),new Point(3,27) };
            points = new List<Point>()
            {new Point(0,218),new Point(377,215),new Point(638,110) };
        }
        List<Point> points = new List<Point>();
        List<Point> spoints = new List<Point>();
        Point NowMouse = new Point(0, 0);
        void Func()
        {
            spoints = new List<Point>();
            
            for (int x = 0; x < panel1.Width; x++)
            {
                spoints.Add(new Point(x, (int)P(x)));
            }

        }

        double P(int x)
        {
            double total, a, b;
            total = 0;
            for (int i = 0; i < points.Count; i++)
            {
                a = 1;
                b = 1;
                for (int j = 0; j < points.Count; j++)
                {
                    if (j != i)
                    {
                        a *= x - points[j].X;
                        b *= points[i].X - points[j].X;
                    }
                }
                total += points[i].Y * a / b;
            }
            return total;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //int X = (e.X - panel1.Width / 2) / Bei;
            //int Y = ((-e.Y) + panel1.Height / 2) / Bei;


            int X = e.X;
            int Y = e.Y;
            label1.Text = X + "/" + Y;
            NowMouse = new Point(X, Y);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points.Clear();
            spoints.Clear();
            BMP = new Bitmap(panel1.Width, panel1.Height);
            G = Graphics.FromImage(BMP);
            pen = new Pen(Color.Blue, 2f);
            Pen linepen = new Pen(Color.Black, 0.5f);
            if (ShowOrNot)
            {
                for (int i = 0; i < panel1.Height; i += Bei)
                {
                    G.DrawLine(linepen, new Point(0, i), new Point(panel1.Width, i));
                }
                for (int i = 0; i < panel1.Width; i += Bei)
                {
                    G.DrawLine(linepen, new Point(i, 0), new Point(i, panel1.Height));
                }
            }

            //G.TranslateTransform(BMP.Width * 1 / 2, BMP.Height * 1 / 2);
            panel1.BackgroundImage = BMP;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ShowOrNot = checkBox1.Checked;
            Draw();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(NowMouse);
            points = points.OrderBy(x => x.X).ToList();
            G.DrawLine(new Pen(Color.Red, 2), points.Last().X - 3, points.Last().Y, points.Last().X + 3, points.Last().Y);
            G.DrawLine(new Pen(Color.Red, 2), points.Last().X, points.Last().Y - 3, points.Last().X, points.Last().Y + 3);
            panel1.BackgroundImage = BMP;
            Application.DoEvents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (points.Count<2)
            {
                return;
            }

            Func();
            Draw();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class DPoint
    {
        public DPoint(float x, float y)
        {
            X = x;
            Y = y;
        }
        public float X, Y;
    }
}
