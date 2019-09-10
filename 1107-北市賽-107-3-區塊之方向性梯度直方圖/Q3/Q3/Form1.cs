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
            textBox1.Text = "0";
            textBox2.Text = "0";
            bmp = new Bitmap("img1_5640.bmp");
            button2_Click(null, null);
            button3_Click(null, null);
        }
        int padsize = 5;
        Bitmap bmp;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(ofd.FileName);
                pictureBox1.Image = bmp;
            }
        }
        int xblock, yblock;
        double[,] Mgh;
        double[,] Agh;

        private void button3_Click(object sender, EventArgs e)
        {
            //0 20 40 60 80 100 120 140 160 180
            double[] block = new double[10];
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    double absag = Math.Abs(Agh[x, y]);
                    double Lindex = Math.Floor(absag / 20d);
                    double Rindex = Math.Ceiling(absag / 20d);
                    double minus = absag - Lindex * 20;
                    double Lv = (1 - minus / 20) * Mgh[x, y];
                    double Rv = (minus / 20) * Mgh[x, y];
                    block[(int)Lindex] += Lv;
                    block[(int)Rindex] += Rv;
                }
            }
            block[0] += block[9];
            for (int i = 0; i < 9; i++)
            {
                textBox5.Text += $"{i}:{Math.Round(block[i]).ToString()}".PadRight(7);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            xblock = int.Parse(textBox1.Text);
            yblock = int.Parse(textBox2.Text);
            Mgh = new double[8, 8];
            Agh = new double[8, 8];
            int xcount = 0, ycount = 0;
            for (int i = 8 * yblock; i < 8 * yblock + 8; i++)
            {
                xcount = 0;
                for (int j = 8 * xblock; j < 8 * xblock + 8; j++)
                {
                    Color T = Color.FromArgb(0, 0, 0, 0);
                    Color B = Color.FromArgb(0, 0, 0, 0);
                    Color L = Color.FromArgb(0, 0, 0, 0);
                    Color R = Color.FromArgb(0, 0, 0, 0);
                    if (j - 1 >= 0)
                        L = bmp.GetPixel(j - 1, i);
                    if (j + 1 < bmp.Width)
                        R = bmp.GetPixel(j + 1, i);
                    if (i - 1 >= 0)
                        T = bmp.GetPixel(j, i - 1);
                    if (i + 1 < bmp.Height)
                        B = bmp.GetPixel(j, i + 1);
                    double gxr = R.R - L.R;
                    double gyr = B.R - T.R;
                    double gxg = R.G - L.G;
                    double gyg = B.G - T.G;
                    double gxb = R.B - L.B;
                    double gyb = B.B - T.B;
                    List<double> M = new List<double>();
                    M.Add(Math.Sqrt(gxr * gxr + gyr * gyr));
                    M.Add(Math.Sqrt(gxg * gxg + gyg * gyg));
                    M.Add(Math.Sqrt(gxb * gxb + gyb * gyb));
                    List<double> A = new List<double>();
                    A.Add(Math.Atan2(gyr, gxr));
                    A.Add(Math.Atan2(gyg, gxg));
                    A.Add(Math.Atan2(gyb, gxb));
                    int ind = M.IndexOf(M.Max());
                    Mgh[xcount, ycount] = Math.Round(M[ind]);
                    Agh[xcount, ycount] = Math.Round(A[ind] * 180 / Math.PI);
                    textBox3.Text += Mgh[xcount, ycount].ToString().PadLeft(padsize);
                    textBox4.Text += Agh[xcount, ycount].ToString().PadLeft(padsize);
                    xcount++;
                }
                textBox3.Text += "\r\n";
                textBox4.Text += "\r\n";
                ycount++;
            }
        }
    }
}
