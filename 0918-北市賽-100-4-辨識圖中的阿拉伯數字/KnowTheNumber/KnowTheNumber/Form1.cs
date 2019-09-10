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
namespace KnowTheNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                Paths.Add(i + ".bmp");
            }
            Paths.AddRange(new List<string>() { "c.bmp","d.bmp","f.bmp","g.bmp","qq.bmp"});
            Train();
        }
        List<string> Paths = new List<string>();
        Dictionary<string, int> P2N = new Dictionary<string, int>();
        void Train()
        {
            for (int i = 0; i < 9; i++)
            {
                Bitmap BMP = new Bitmap(Paths[i]);
                P2N.Add(getLB(BMP).B + "/" +
                        getLB(BMP).L + "/" +
                        getLB(BMP).R + "/" +
                        getLB(BMP).T , i);
            }
        }
        NumberData getLB(Bitmap bmp)
        {
            NumberData ND = new NumberData();
            //L
            int Count = 0;
            bool FindBlack = false;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (bmp.GetPixel(x, y).GetBrightness() < 0.5)
                    {
                        FindBlack = true;
                        Count++;
                    }
                }
                if (FindBlack)
                {
                    break;
                }
            }
            ND.L = Count;
            //B
            Count = 0;
            FindBlack = false;
            for (int y = bmp.Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (bmp.GetPixel(x, y).GetBrightness() < 0.5)
                    {
                        FindBlack = true;
                        Count++;
                    }
                }
                if (FindBlack)
                {
                    break;
                }
            }
            ND.B = Count;
            //R
            Count = 0;
            FindBlack = false;
            for (int x = bmp.Width - 1; x >= 0; x--)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (bmp.GetPixel(x, y).GetBrightness() < 0.5)
                    {
                        FindBlack = true;
                        Count++;
                    }
                }
                if (FindBlack)
                {
                    break;
                }
            }
            ND.R = Count;
            //T
            Count = 0;
            FindBlack = false;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = bmp.Width - 1; x >= 0; x--)
                {
                    if (bmp.GetPixel(x, y).GetBrightness() < 0.5)
                    {
                        FindBlack = true;
                        Count++;
                    }
                }
                if (FindBlack)
                {
                    break;
                }
            }
            ND.T = Count;


            return ND;
        }
        class NumberData
        {
            public int L, B,R,T;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(ofd.FileName);
                NumberData temp = getLB(bmp);
                try
                {

                    textBox1.Text = P2N[temp.B + "/" + temp.L.ToString() + "/" + temp.R.ToString() + "/" + temp.T.ToString()].ToString();
                }
                catch
                {
                    textBox1.Text = "無法辨識";
                }
                finally
                {

                    pictureBox1.Image = bmp;
                }
            }
        }
    }
}
