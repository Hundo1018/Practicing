using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //path = "Q2_一個牆面166cm.jpg";
            button1.Text = "載入圖檔";
            button2.Text = "右邊圖案身高(mm)";
            button3.Text = "右邊圖案體寬(mm)";
            //button1_Click(null, null);
            //button1_Click(null, null);
            //button2_Click(null, null);
            //button3_Click(null, null);
        }
        string path = "Q2_站立男2.jpg";

        Bitmap bmp;
        double IZT = 0, IZB = 0, IZH = 0,
                IZL = 0, IZR = 0, IZW = 0,
                ManT = 0, ManB = 0, ManH = 0,
                ManL = 0, ManR = 0, ManW = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = ManRealWidth.ToString();
        }

        double IZRealHeight = 830, IZRealWidth, ManRealHeight, ManRealWidth;
        int[,] Matrix;
        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            bmp = new Bitmap(path);
            bool IZ = false, Man = false, IZdone = false, Mandone = false;
            Matrix = new int[bmp.Width, bmp.Height];
            for (int y = xz; y < bmp.Height - xz; y++)
            {
                for (int x = xz; x < bmp.Width - xz; x++)
                {
                    Color temp = bmp.GetPixel(x, y);
                    double cv = (temp.R * 0.3d + temp.G * 0.59d + temp.B * 0.11d);
                    if (cv <= 200)
                    {
                        Matrix[x, y] = 1;
                        //bmp.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                    }
                }
            }
            int tag = 2;
            int yy = bmp.Height / 5 * 4;
            int xx = 0;
            for (xx = xz; xx < bmp.Width - xz; xx++)
            {
                if (Matrix[xx, yy] == 1 && (count0(xx, yy) > 0))
                {
                    Dihue(xx, yy, tag++);
                }
            }

            IZL = PL1.Min(z => z.X);
            IZR = PL1.Max(z => z.X);
            IZT = PL1.Min(z => z.Y);
            IZB = PL1.Max(z => z.Y);

            ManL = PL2.Min(z => z.X);
            ManR = PL2.Max(z => z.X);
            ManT = PL2.Min(z => z.Y);
            ManB = PL2.Max(z => z.Y);

            ManH = ManB - ManT;
            ManW = ManR - ManL;

            IZH = IZB - IZT;
            IZW = IZR - IZL;


            ManRealHeight = ManH * IZRealHeight / IZH;
            ManRealWidth = ManRealHeight * ManW / ManH;



            pictureBox1.Image = bmp;
            Application.DoEvents();
        }
        List<Point> PL1 = new List<Point>();
        List<Point> PL2 = new List<Point>();
        int xz = 1;
        void Dihue(int x, int y, int tag)
        {

            label1.Text = $"{tag-1}";
            if (x < xz || y < xz || x >= bmp.Width - xz || y >= bmp.Height - xz) return;
            if (count0(x, y) < 1) return;
            if (Matrix[x, y] != 1) return;
            Matrix[x, y] = tag;
            if (tag == 2) PL1.Add(new Point(x, y));
            if (tag == 3) PL2.Add(new Point(x, y));
            Dihue(x + 1, y, tag);
            Dihue(x - 1, y, tag);
            Dihue(x, y + 1, tag);
            Dihue(x, y - 1, tag);
            Dihue(x + 1, y + 1, tag);
            Dihue(x - 1, y - 1, tag);
            Dihue(x + 1, y - 1, tag);
            Dihue(x - 1, y + 1, tag);
            //bmp.SetPixel(x, y, Color.Red);
            //pictureBox1.Image = bmp;
            Application.DoEvents();
        }
        int count0(int x, int y)
        {
            List<int> C = new List<int>();
            for (int i = -xz; i <= xz; i++)
            {
                for (int j = -xz; j <= xz; j++)
                {
                    if (i == 0 && j == 0) continue;
                    C.Add(Matrix[x + i, y + j]);
                }
            }
            return C.Count(z => (z == 0));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ManRealHeight.ToString();
        }
    }
}
