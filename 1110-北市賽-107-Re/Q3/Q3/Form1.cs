using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.textBox4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            button1.Text = "Load";
            button2.Text = "Calculate";
            button3.Text = "HOG";
            textBox1.Text = "0";
            textBox2.Text = "0";
            button2_Click(null, null);
            button3_Click(null, null);
        }
        string path = "img1_5640.bmp";
        Bitmap bmp;
        double[,] Mg, Ag;

        private void button2_Click(object sender, EventArgs e)
        {
  
            textBox3.Text = "";
            textBox4.Text = "";
            bmp = new Bitmap(path);
            Mg = new double[8, 8];
            Ag = new double[8, 8];
            int xb = int.Parse(textBox1.Text), yb = int.Parse(textBox2.Text);
            int xcount = 0, ycount = 0;
            for (int i = yb * 8; i < yb * 8 + 8; i++)
            {
                for (int j = xb * 8; j < xb * 8 + 8; j++)
                {
                    Color c = bmp.GetPixel(j, i);
                    List<double> Gx = new List<double>();
                    List<double> Gy = new List<double>();
                    List<double> M = new List<double>();
                    List<double> A = new List<double>();
                    List<Color> TBLR = new List<Color>();
                    if (i - 1 < 0) TBLR.Add(Color.FromArgb(0, 0, 0, 0));
                    else TBLR.Add(bmp.GetPixel(j, i - 1));
                    if (i + 1 >= bmp.Height) TBLR.Add(Color.FromArgb(0, 0, 0, 0));
                    else TBLR.Add(bmp.GetPixel(j, i + 1));
                    if (j - 1 < 0) TBLR.Add(Color.FromArgb(0, 0, 0, 0));
                    else TBLR.Add(bmp.GetPixel(j - 1, i));
                    if (j + 1 >= bmp.Width) TBLR.Add(Color.FromArgb(0, 0, 0, 0));
                    else TBLR.Add(bmp.GetPixel(j + 1, i));

                    Gx.Add(TBLR[3].R - TBLR[2].R);
                    Gx.Add(TBLR[3].G - TBLR[2].G);
                    Gx.Add(TBLR[3].B - TBLR[2].B);

                    Gy.Add(TBLR[1].R - TBLR[0].R);
                    Gy.Add(TBLR[1].G - TBLR[0].G);
                    Gy.Add(TBLR[1].B - TBLR[0].B);
                    for (int k = 0; k < 3; k++)
                    {
                        M.Add(Math.Sqrt(Gx[k] * Gx[k] + Gy[k] * Gy[k]));
                        A.Add((Math.Atan2(Gy[k], Gx[k])));
                    }

                    int ind = M.IndexOf(M.Max());
                    M[ind] = Math.Round(M[ind], 0);
                    A[ind] = Math.Round((A[ind] * 180d / Math.PI), 0);
                    Mg[xcount, ycount] = M[ind];
                    Ag[xcount, ycount] = A[ind];
                    textBox3.Text += M[ind].ToString().PadLeft(5);
                    textBox4.Text += A[ind].ToString().PadLeft(5);
                    xcount++;
                }
                textBox3.Text += "\r\n";
                textBox4.Text += "\r\n";
                xcount = 0;
                ycount++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            double[] block = new double[10];
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    double absag = Math.Abs(Ag[x, y]);
                    double L = (Math.Floor(absag / 20d));
                    double R = (Math.Ceiling(absag / 20d));
                    double A = (absag - (L * 20d));
                    double B = (1d - A / 20);
                    double Lv = B * Mg[x, y];
                    double Rv = Mg[x, y] - Lv;
                    block[(int)L] += Lv;
                    block[(int)R] += Rv;
                }
            }
            block[0] += block[9];

            for (int i = 0; i < 9; i++)
            {
                textBox5.Text += $"{i}： {Math.Round(block[i], 0) } ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = path;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
