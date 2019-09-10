using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap B;
        double H, W;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
                B = new Bitmap(ofd.FileName);
                H = B.Height;
                W = B.Width;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<double> AL = new List<double>();
            List<double> BL = new List<double>();
            List<double> NL = new List<double>();
            List<double> SigmaL = new List<double>();
            double n =H*W;
            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++)
                {
                    int r=B.GetPixel(x,y).R, g=B.GetPixel(x,y).G, b=B.GetPixel(x,y).B;
                    AL.Add(r-g);
                    BL.Add(((r+g)/2-b));
                }
            }
            double microA, sigmaA2, microB, sigmaB2;
            microA = (1 / n) * AL.Sum();
            double temp=0;
            for (int i = 0; i < n; i++)
            {
                temp += ((AL[i] * AL[i]) - (microA * microA));
            }
            sigmaA2 = (1 / n) * temp;


            microB = (1 / n) * BL.Sum();
            temp = 0;
            for (int i = 0; i < n; i++)
            {
                temp += ((BL[i] * BL[i]) - (microB * microB));
            }
            sigmaB2 = (1 / n) * temp;
            double QM1,QM2;
            QM1 = ((Math.Sqrt(sigmaA2 + sigmaB2) + 0.3d * (Math.Sqrt(Math.Pow(microA, 2) + Math.Pow(microB, 2)))) / 85.59d);
            QM2 = (0.02 * (Math.Log((sigmaA2 / Math.Pow(Math.Abs(microA), 0.2)))) * (Math.Log((sigmaB2 / Math.Pow(Math.Abs(microB), 0.2)))));
            textBox1.Text = QM1 + "";
            textBox2.Text = QM2 + "";
        }
    }
}
