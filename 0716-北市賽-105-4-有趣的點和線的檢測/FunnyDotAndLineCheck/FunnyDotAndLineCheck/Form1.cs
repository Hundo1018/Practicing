using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyDotAndLineCheck
{
    public partial class Form1 : Form
    {
        public Form1()  
        {
            InitializeComponent();
        }
        Bitmap Original_B;
        Bitmap I_B;
        string Path;
        int IdontKnow = 255;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Path=ofd.FileName;
                Original_B = new Bitmap(Path);
                I_B = new Bitmap(Original_B.Width, Original_B.Height);
                pictureBox1.Image = Original_B;
            }
        }
        /// <summary>
        /// Gray
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Original_B.Height; i++)
            {
                for (int j = 0; j < Original_B.Width; j++)
                {
                    int R = Original_B.GetPixel(j, i).R;
                    int G = Original_B.GetPixel(j, i).G;
                    int B = Original_B.GetPixel(j, i).B;
                    int Gray = (int)((0.2125 * R) + (0.7154 * G) + (0.0721 * B));
                    I_B.SetPixel(j, i, Color.FromArgb(Gray, Gray, Gray));
                }
            }
            pictureBox2.Image = I_B;
        }

        Bitmap HorB;
        /// <summary>
        /// Horizon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
             HorB = new Bitmap(I_B.Width, I_B.Height);
            for (int i = 0; i < Original_B.Height; i++)
            {
                for (int j = 0; j < Original_B.Width; j++)
                {
                    if (i-1<0 || j-1<0 || j+1>= Original_B.Width || i + 1 >= Original_B.Height)
                    {
                        continue;
                    }
                        int TOP = I_B.GetPixel(j - 1, i - 1).R + I_B.GetPixel(j, i - 1).R + I_B.GetPixel(j + 1, i - 1).R;
                        int BOT = I_B.GetPixel(j - 1, i + 1).R + I_B.GetPixel(j, i + 1).R + I_B.GetPixel(j + 1, i + 1).R;
                        int Horint = (int)((TOP - BOT) * 0.166666667);
                    if (Horint<0 || Horint>255)
                    {
                        Horint = IdontKnow;
                    }
                        HorB.SetPixel(j, i, Color.FromArgb(Horint, Horint, Horint));
                }
            }
            pictureBox2.Image = HorB;
        }
        Bitmap Vir_B;
        /// <summary>
        /// Virtical
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Vir_B = new Bitmap(I_B.Width, I_B.Height);
            for (int i = 0; i < Original_B.Height; i++)
            {
                for (int j = 0; j < Original_B.Width; j++)
                {
                    if (i - 1 < 0 || j - 1 < 0 || j + 1 >= Original_B.Width || i + 1 >= Original_B.Height)
                    {
                        continue;
                    }
                    int Left = I_B.GetPixel(j - 1, i - 1).R + I_B.GetPixel(j - 1, i).R + I_B.GetPixel(j - 1, i + 1).R;
                    int Right = I_B.GetPixel(j + 1, i - 1).R + I_B.GetPixel(j + 1, i).R + I_B.GetPixel(j + 1, i + 1).R;
                    int Virint = (int)((Left - Right) * 0.166666667);
                    if (Virint < 0 || Virint > 255)
                    {
                        Virint = IdontKnow;
                    }
                    Vir_B.SetPixel(j, i, Color.FromArgb(Virint, Virint, Virint));
                }
            }
            pictureBox2.Image = Vir_B;
        }
        Bitmap Hor_B2;
        /// <summary>
        /// Hor2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);
            Hor_B2 = new Bitmap(I_B.Width, I_B.Height);
            for (int i = 0; i < Original_B.Height; i++)
            {
                for (int j = 0; j < Original_B.Width; j++)
                {
                    if (i - 1 < 0 || j - 1 < 0 || j + 1 >= Original_B.Width || i + 1 >= Original_B.Height)
                    {
                        continue;
                    }
                    int HG2 = HorB.GetPixel(j,i).R * HorB.GetPixel(j, i).R;
                    if (HG2<0 || HG2>255)
                    {
                        HG2 = IdontKnow;
                    }
                    Hor_B2.SetPixel(j, i, Color.FromArgb(HG2, HG2, HG2));
                }
            }
            pictureBox2.Image = Hor_B2;
        }
        Bitmap Vir_B2;
        /// <summary>
        /// Vir2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            button4_Click(null, null);
            Vir_B2 = new Bitmap(I_B.Width, I_B.Height);
            for (int i = 0; i < Original_B.Height; i++)
            {
                for (int j = 0; j < Original_B.Width; j++)
                {
                    if (i - 1 < 0 || j - 1 < 0 || j + 1 >= Original_B.Width || i + 1 >= Original_B.Height)
                    {
                        continue;
                    }
                    int VG2 = Vir_B.GetPixel(j, i).R * Vir_B.GetPixel(j, i).R;
                    if (VG2 < 0 || VG2 > 255)
                    {
                        VG2 = IdontKnow;
                    }
                    Vir_B2.SetPixel(j, i, Color.FromArgb(VG2, VG2, VG2));
                }
            }
            pictureBox2.Image = Vir_B2;
        }
        Bitmap VH;
        /// <summary>
        /// VH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);
            button4_Click(null, null);
            VH = new Bitmap(I_B.Width, I_B.Height);
            for (int i = 0; i < Original_B.Height; i++)
            {
                for (int j = 0; j < Original_B.Width; j++)
                {
                    if (i - 1 < 0 || j - 1 < 0 || j + 1 >= Original_B.Width || i + 1 >= Original_B.Height)
                    {
                        continue;
                    }
                    int VHint = Vir_B.GetPixel(j, i).R * HorB.GetPixel(j, i).R;
                    if (VHint < 0 || VHint > 255)
                    {
                        VHint = IdontKnow;
                    }
                    VH.SetPixel(j, i, Color.FromArgb(VHint, VHint, VHint));
                }
            }
            pictureBox2.Image = VH;
        }
    }
}
