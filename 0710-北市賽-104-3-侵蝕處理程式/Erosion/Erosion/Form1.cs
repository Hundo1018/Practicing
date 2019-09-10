using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Erosion
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button5.Enabled = false;
        }
        Bitmap B;
        Bitmap OB;
        Bitmap PreView;
        Graphics G;
        string path;
        bool[,] RecordFlags;
        bool [,,]RecordedFlags;
        float Threshold = 0.5f;
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                    OB = new Bitmap(path);
                    B = new Bitmap(OB.Width, OB.Height);
                    for (int i = 0; i < OB.Height; i++)
                    {
                        for (int j = 0; j < OB.Width; j++)
                        {
                            B.SetPixel(j, i, (OB.GetPixel(j, i).GetBrightness() > 0.5f ? Color.White : Color.Black));
                        }
                    }
                    pictureBox1.Image = OB;
                    RecordFlags = new bool[B.Height, B.Width];
                    RecordedFlags = new bool[B.Height, B.Width,8];

                    for (int i = 0; i < B.Height; i++)
                    {

                        for (int j = 0; j < B.Width; j++)
                        {
                            RecordFlags[i, j] = false;
                            for (int k = 0; k < 8; k++)
                            {

                            RecordedFlags[i, j, k] = false;
                            }
                        }
                    }
                    
                    MessageBox.Show("OK");
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            B = OB;
            pictureBox1.Image = OB;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < B.Height; i++)
            {
                for (int j = 0; j < B.Width; j++)
                {
                    RecordFlags[i, j] = false;
                    for (int k = 0; k < 8; k++)
                    {
                    RecordedFlags[i, j,k] = false;
                    }
                }
            }
            //01234567 上 上右 右 下右 下 下左 左 上左

            /*上左*/
            GoGoReturn( 0, 0, (B.GetPixel(0, 0).GetBrightness() > Threshold ? true : false),0,2);
            /*上右*/
            GoGoReturn( B.Width-1, 0, (B.GetPixel(0, 0).GetBrightness() > Threshold ? true : false),6,6);
            /*下左*/
            GoGoReturn( 0, B.Height-1, (B.GetPixel(0, 0).GetBrightness() > Threshold ? true : false),2,2);
            /*下右*/
            GoGoReturn( B.Width-1, B.Height-1, (B.GetPixel(0, 0).GetBrightness() > Threshold ? true : false),3,6);

            PreView = B;
            for (int i = 0; i < B.Width; i++)
            {
                for (int j = 0; j < B.Height; j++)
                {
                    PreView.SetPixel(i, j, (RecordFlags[j, i] ? Color.Red : PreView.GetPixel(i, j)));
                }
            }
            pictureBox2.Image = PreView;
            button5.Enabled = true;
        }

        void GoGoReturn( int x, int y, bool pre,int mod,int vector)
        {
            if (x < 0 || y < 0 || x >= B.Width || y >= B.Height || (RecordFlags[y, x]) || (RecordedFlags[y,x,vector])) 
            {
                //GoGoReturn(x, y + 1, pre, 0);

                return;
            }
            else
            {
                RecordedFlags[y, x,vector] = true;

                //白True黑False
                //前黑現黑 Pre=False
                //前黑現白 Pre=True
                //前白現黑 Pre=False
                //前白現白 Pre=Tr

                bool now = (B.GetPixel(x, y).GetBrightness() > Threshold ? true : false);
                B.SetPixel(x, y, Color.Red);
                pictureBox1.Image = B;
                Application.DoEvents();
                //Thread.Sleep(100);

                B.SetPixel(x, y, (now ? Color.White : Color.Black));

                if (((pre) && (!now)))
                {
                    RecordFlags[y, x] = true;
                }
                switch (mod)
                {
                    //01234567 0上 1上右 2右 3下右 4下 5下左 6左 7上左
                    case 0://TL
                        GoGoReturn( x + 1, y, now, 0,2);//右
                        GoGoReturn( x, y + 1, now, 0,4);//下
                        GoGoReturn( x + 1, y + 1, now, 0,3);//右下
                        break;
                    case 1://TR
                        GoGoReturn( x - 1, y, now, 1,6);//左
                        GoGoReturn( x, y + 1, now, 1,4);//下
                        GoGoReturn( x - 1, y + 1, now, 1,5);//左下
                        break;
                    case 2://BL
                        GoGoReturn( x + 1, y, now, 2,2);//右
                        GoGoReturn( x, y - 1, now, 2,0);//上
                        GoGoReturn( x + 1, y - 1, now, 2,1);//右上
                        break;
                    case 3://BR
                        GoGoReturn( x - 1, y, now, 3,6);//左
                        GoGoReturn( x, y - 1, now, 3,0);//上
                        GoGoReturn( x - 1, y - 1, now, 3,7);//左上
                        break;
                    default:
                        break;
                }


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < B.Height; i++)
            {
                for (int j = 0; j < B.Width; j++)
                {
                    if (RecordFlags[i, j])
                    {
                        B.SetPixel(j, i, Color.White);
                    }
                }
            }
            pictureBox1.Image = B;
            button5.Enabled = false;
        }
    }
}
