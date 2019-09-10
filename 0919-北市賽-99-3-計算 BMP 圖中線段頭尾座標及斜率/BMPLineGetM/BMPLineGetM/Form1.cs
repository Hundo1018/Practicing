using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPLineGetM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path = "A";

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap BMP;
                BMP = new Bitmap(ofd.FileName);
                Pointd a = GetL(BMP);
                Pointd b = GetR(BMP);
                pictureBox1.Image = BMP;

                double m = -1*(b.Y - a.Y) / (b.X - a.X);
                string mm = ((((double)((int)(m*100)))/100)).ToString();
                textBox1.Text = $"線段左邊端點座標：（{a.X},{a.Y}）\r\n" +
                                $"線段左邊端點座標：（{b.X},{b.Y}）\r\n" +
                                $"線段斜率　{mm}";
            }
        }
        Pointd GetL(Bitmap BMP)
        {

            for (int i = 0; i < BMP.Width; i++)
            {
                for (int j = 0; j < BMP.Height; j++)
                {
                    if (BMP.GetPixel(i, j).GetBrightness() < 0.5)
                    {
                        return (new Pointd(i, j));
                    }
                }
            }
            return new Pointd(-1, -1);
        }
        Pointd GetR(Bitmap BMP)
        {

            for (int i = BMP.Width-1; i >=0; i--)
            {
                for (int j = 0; j < BMP.Width; j++)
                {
                    if (BMP.GetPixel(i, j).GetBrightness() < 0.5)
                    {
                        return (new Pointd(i, j));
                    }
                }
            }
            return new Pointd(-1, -1);
        }
    }
    class Pointd
    {
        public double X=0, Y=0;
        public Pointd(int x,int y)
        {
            X = (double)x;
            Y = (double)y;
        }
    }
}
