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
namespace Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Text = "讀檔";
            button2.Text = "膨脹";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tempbmp = new Bitmap(Nbmp.Width, Nbmp.Height);
            for (int i = 0; i < Nbmp.Height; i++)
            {
                for (int j = 0; j < Nbmp.Width; j++)
                {
                    Tempbmp.SetPixel(j, i, Nbmp.GetPixel(j, i));
                }
            }
            for (int i = 0; i < Obmp.Height; i++)
            {
                for (int j = 0; j < Obmp.Width; j++)
                {
                    if (Set(j, i, Tempbmp)) Nbmp.SetPixel(j, i, Color.Black);
                }
            }
            pictureBox1.Image = Nbmp;
        }
        bool Set(int x, int y, Bitmap bmp)
        {
            int countblack = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (y + i < 0 ||
                        y + i >= bmp.Height ||
                        x + j < 0 ||
                        x + j >= bmp.Width) continue;
                    if (bmp.GetPixel(x + j, y + i).GetBrightness() < 0.5d) return true;
                }
            }
            return false;
        }
        string path = "AB.bmp";
        Bitmap Obmp,Tempbmp,Nbmp;
        private void button1_Click(object sender, EventArgs e)
        {
            Obmp = new Bitmap(path);
            Nbmp = new Bitmap(Obmp.Width, Obmp.Height);
            for (int i = 0; i < Obmp.Height; i++)
            {
                for (int j = 0; j < Obmp.Width; j++)
                {
                    Nbmp.SetPixel(j, i, Obmp.GetPixel(j, i));
                }
            }
            pictureBox1.Image = Obmp;
        }
   
    }
}
