using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 圖形識別
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Text = "尋找";
            textBox1.Text = "0";
            label1.Text = "誤差(pixel)：";
            this.AutoSize = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            Bitmap temp = new Bitmap("test.bmp");
            BinaryBmp = new Bitmap(temp.Width, temp.Height);
            for (int i = 0; i < temp.Height; i++)
            {
                for (int j = 0; j < temp.Width; j++)
                {
                    Color c = temp.GetPixel(j, i);
                    c = (c.GetBrightness() < 0.5d ? Color.Black : Color.White);
                    BinaryBmp.SetPixel(j, i, c);
                }
            }
            pictureBox1.Image = BinaryBmp;
            ShowBMP = (Bitmap)BinaryBmp.Clone();
            ShowBMP.Save("NEW.bmp");
            Omap = new int[BinaryBmp.Width, BinaryBmp.Height];
            for (int i = 0; i < BinaryBmp.Height; i++)
            {
                for (int j = 0; j < BinaryBmp.Width; j++)
                {
                    Omap[j, i] = (BinaryBmp.GetPixel(j, i).GetBrightness() < 0.5f ? 1 : -1);
                }
            }
            //ShowBMPTemp;
        }
        int[,] Omap;
        Bitmap BinaryBmp;
        Bitmap ShowBMP;
        Bitmap ShowBMPTemp;
        List<Point> PL = new List<Point>();
        private void button1_Click(object sender, EventArgs e)
        {
            error = int.Parse(textBox1.Text);
            PL = new List<Point>();
            for (int y = 0; y < BinaryBmp.Height - maskH; y++)
            {
                for (int x = 0; x < BinaryBmp.Width - maskW; x++)
                {
                    if (MASK(x, y))
                    {
                        PL.Add(new Point(x, y));
                    }
                }
            }
            Bitmap Showbmp2 = new Bitmap((Bitmap)ShowBMP.Clone());
            Graphics G = Graphics.FromImage(Showbmp2);
            foreach (var item in PL)
            {
                G.DrawRectangle(new Pen(Color.Red,0.5f),item.X,item.Y,maskW,maskH);
            }
            pictureBox3.Image = Showbmp2;
            
        }
        bool MASK(int X, int Y)
        {
            int countx = 0, county = 0;
            int score = 0;
            for (int y = Y; y < Y + maskH; y++)
            {
                for (int x = X; x < X + maskW; x++)
                {
                    if (mask[countx, county] == Omap[x, y])
                    {
                        score++;
                    }
                    else
                    {
                        score--;
                    }
                    countx++;
                }
                countx = 0;
                county++;
            }
            if (score == Stand) return true;
            else if (Like(score, Stand)) return true;
            else return false;
        }
        int error = 5;
        bool Like(int A, int S)
        {
            if (A < 0) return false;
            if (Math.Abs(A - S) < error || Math.Abs(S - A) < error) return true;
            else return false;
        }
        Rectangle Target = new Rectangle();
        Point A, B;
        bool down = false;

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            down = true;
            A = e.Location;

        }
        int W, H;
        int[,] mask;
        int Stand = 0;
        int maskW, maskH;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
            W = Target.X + Target.Width;
            H = Target.Y + Target.Height;
            int L = int.MaxValue, R = int.MinValue, T = int.MaxValue, B = int.MinValue;
            for (int y = Target.Y; y < H; y++)
            {
                for (int x = Target.X; x < W; x++)
                {
                    if (Omap[x, y] == 1)
                    {
                        if (x < L) L = x;
                        if (y < T) T = y;
                        if (x > R) R = x;
                        if (y > B) B = y;
                    }
                }
            }
            maskW = R - L +1;
            maskH = B - T + 1;
            mask = new int[maskW,maskH];
            int countx=0, county = 0;
            Stand = 0;
            for (int y = T; y <= B; y++)
            {
                for (int x = L; x <= R; x++)
                {
                    mask[countx++, county] = (Omap[x, y]);
                    Stand++;
                    //Stand += (Omap[x, y] == 1 ? 0 : 1);
                }
                countx = 0;
                county++;
            }
            Bitmap temp = new Bitmap(maskW, maskH);
          
            for (int i = 0; i < maskH; i++)
            {
                for (int j = 0; j < maskW; j++)
                {
                    temp.SetPixel(j, i, (mask[j, i] == 1 ?Color.Black:Color.White));
                }
            }
            pictureBox2.Image = temp;
            textBox2.Text = "";
            for (int i = 0; i < maskH; i++)
            {
                for (int j = 0; j < maskW; j++)
                {
                    string temp2 = (mask[j, i] == 1 ? "●" : "○");
                    textBox2.Text += temp2.PadLeft(2);
                }
                textBox2.Text += "\r\n";
            }
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            B = new Point(e.X, e.Y );
            if (down)
            {
                Target = new Rectangle(A, new Size(B.X - A.X+1, B.Y - A.Y+1));
                ShowBMPTemp = (Bitmap)ShowBMP.Clone();
                Graphics G = Graphics.FromImage(ShowBMPTemp);
                G.DrawRectangle(new Pen(Color.Black, 0.5f), Target);
                pictureBox1.Image = ShowBMPTemp;
                Application.DoEvents();
            }
        }


        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {

        }

    }
}
