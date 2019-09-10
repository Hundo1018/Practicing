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
            textBox1.Text = "22";
            textBox2.Text = "25";
            label1.Text = "被乘數範圍：1~50";
            label2.Text = "乘數範圍：1~50";
            button1_Click(null, null);
        }
        int A1 = 0, A10 = 0, B1 = 0, B10 = 0;
        string Astr, Bstr;
        int Tv = 0, Hv = 0;

        Bitmap bmp;
        Graphics G;
        private void button1_Click(object sender, EventArgs e)
        {
            A1 = 0;
            A10 = 0;
            B1 = 0;
            B10 = 0;
            Astr = textBox1.Text;
            Bstr = textBox2.Text;
            if (Astr.Length > 1)
            {
                A10 = Astr[0] - '0';
                A1 = Astr[1] - '0';
            }
            else
            {
                A1 = Astr[0] - '0';
            }
            if (Bstr.Length > 1)
            {
                B10 = Bstr[0] - '0';
                B1 = Bstr[1] - '0';
            }
            else
            {
                B1 = Bstr[0] - '0';
            }
            bmp = new Bitmap(500, 500);
            G = Graphics.FromImage(bmp);
            Draw(A10, A1, 1);
            Draw(B10, B1, -1);
        }
        void Draw(int a10, int a1, int Rt)
        {
            G.TranslateTransform(50, 200);
            G.RotateTransform(45 * Rt);
            G.TranslateTransform(0, -200);
            for (int i = 0; i < a10; i++)
            {
                G.DrawLine(new Pen((Rt == 1 ? Color.Red : Color.Blue), 2), new Point(i * 10, -800), new Point(i * 10, 800));

            }
            if (a1 == 0 && a10 > a1)
            {
                G.DrawLine(new Pen((Rt == 1 ? Color.Red : Color.Blue), 0.1f), new Point(200, -800), new Point(200, 800));
            }
            else
            {
                for (int j = 0; j < a1; j++)
                {
                    G.DrawLine(new Pen((Rt == 1 ? Color.Red : Color.Blue), 2), new Point(j * 10 + 200, -800), new Point(j * 10 + 200, 800));
                }
            }
            pictureBox1.Image = bmp;
            G.TranslateTransform(0, 200);
            G.RotateTransform(-45 * Rt);
            G.TranslateTransform(-50, -200);
        }
    }
}
