using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //pictureBox1.ImageLocation = path;
            //bmp = new Bitmap(path);
            button2.Enabled = false;
            button2.Text = "What song is he singing?";
        }
        string path = "Q6_dn_test1.bmp";
        Bitmap bmp,nbmp;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
                bmp = new Bitmap(ofd.FileName);
            }
            nbmp = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color thisp = bmp.GetPixel(j, i);
                    nbmp.SetPixel(j, i, Color.FromArgb(255,
                        (thisp.R % 2 == 0 ? 235 : 16),
                        (thisp.G % 2 == 0 ? 235 : 16),
                        (thisp.B % 2 == 0 ? 235 : 16)
                        ));
                }
            }
            button2.Enabled = true;
            button2.Text = "Reveal The Image Behind";
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            
           pictureBox1.ImageLocation = e.Data.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = nbmp;
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox1.ImageLocation = e.Data.ToString();
        }
    }
}
