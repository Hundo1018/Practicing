using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Object_Connect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap B;
        int W=0, H=0;
        string path;
        ObjectC[,] ans;
        int[,] que;

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                B = new Bitmap(path);
                textBox1.Text = B.Height + "";
                textBox2.Text = B.Width + "";
                textBox3.Text = path;
                textBox4.Text = "";
                W = B.Width;
                H = B.Height;
                ans = new ObjectC[H,W];
                que = new int[H, W];
                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++)
                    {
                        ans[i, j] = new ObjectC();
                        que[i, j] = (B.GetPixel(j, i).GetBrightness() > 0.5f ? 255 : 0);
                        ans[i, j].Light = que[i, j];

                        textBox4.Text += que[i, j] + "\r\r";
                    }
                    textBox4.Text += "\r\n";
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            int tagnow=1;
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                   
                    Circle(j, i, tagnow);
                    if (flag)
                    {
                    tagnow += 1;
                        flag = false;
                    }
                }
            }
            for (int i = 0; i < H; i++)
            { 
                for (int j = 0; j < W; j++)
                {
                    textBox5.Text += ans[i, j].Tag + "\r\r"; 
                }
                textBox5.Text += "\r\n";
            }
        }
            bool flag = false;
        void Circle(int x,int y , int tagnow)
        {
            if ( x >= W || y >= H||ans[y, x].Light == 0 || ans[y, x].Tag != 0)
            {
                return;
            }
            else
            {
                flag = true;
                ans[y, x].Tag = tagnow;
                Circle(x + 1, y, tagnow);
                Circle(x + 1, y + 1, tagnow);
                Circle(x, y + 1, tagnow);
            }
        }
    }
    class ObjectC
    {
        public int Light;
        public int Tag;
    }
}
