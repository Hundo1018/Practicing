using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hershe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Size = new Size(500, 400);
            //MessageBox.Show(pictureBox1.Width+"/"+""+pictureBox1.Height);
            button1_Click(null, null);
        }
        public float M, H, W, fix, max, min;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Row = textBox1.Text;
            string[] Row2 = Row.Split(',');
            List<double> NumList = new List<double>();
            foreach (var item in Row2)
            {
                NumList.Add(int.Parse(item));
            }

            NumList = NumList.OrderBy(x => x).ToList();

            double Max, Min, Median, Q1, Q2, Q3, IQR, MaxZ, MinZ, Count;
            Max = NumList.Max();
            max = (float)Max;
            Min = NumList.Min();
            min = (float)Min;
            Count = NumList.Count;
            if (Count % 2 == 0) //0123 4 
            {
                int c = (int)Count;
                Median = ((NumList[c / 2] + NumList[c / 2 - 1]) / 2d);
            }
            else//01234 5 4/2 = 2
            {
                Median = NumList[(int)((Count - 1) / 2d)];
            }



            Q1 = NumList[(int)(Count / 4d)];
            Q2 = NumList[(int)(Count / 4d * 2d)];
            Q3 = NumList[(int)(Count / 4d * 3d)];


            //double temp2 = Count / 4d; //每份有幾個
            IQR = Q3 - Q1;
            MaxZ = Q3 + IQR;
            MinZ = Q1 - IQR;

            fix = 25;

            W = pictureBox1.Width - fix;//縮小空出標籤空間
            H = pictureBox1.Height - fix * 2;//上縮下縮
            M = W / 2f;//中間X座標
            int wid = 10;
            Bitmap BMP = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics G = Graphics.FromImage(BMP);

            G.TranslateTransform(fix, H + fix);//向右推向下  但是不縮上

            List<PointF> lp = new List<PointF>();

            lp.Add(new PointF(M, (float)MaxZ));
            lp.Add(new PointF(M, (float)Q3));
            lp.Add(new PointF(M, (float)Median));
            lp.Add(new PointF(M, (float)Q1));
            lp.Add(new PointF(M, (float)MinZ));

            List<PointF> lp2 = new List<PointF>();
            for (int i = 0; i < lp.Count; i++)
            {
                lp2.Add(TF(lp[i]));
            }

            //上橫
            G.DrawLine(new Pen(Color.Black, 1f),
                lp2[0].X - wid / 2f, lp2[0].Y,
                lp2[0].X + wid / 2f, lp2[0].Y);
            //上虛線
            G.DrawLine(new Pen(Color.Black, 1f),
                lp2[0].X, lp2[0].Y,
                lp2[1].X, lp2[1].Y);

            //矩形
            G.DrawRectangle(new Pen(Color.Blue),
                new Rectangle(
                    (int)lp2[1].X - wid, (int)lp2[1].Y,//左上
                    wid * 2,
                    (int)(lp2[3].Y - lp2[1].Y)
                    )
               );

            //中位
            G.DrawLine(new Pen(Color.Red, 1f),
                lp2[2].X - wid, lp2[2].Y,
                lp2[2].X + wid, lp2[2].Y);

            //下虛線
            G.DrawLine(new Pen(Color.Black),
                lp2[3].X, lp2[3].Y,
                lp2[4].X, lp2[4].Y);

            //下橫
            G.DrawLine(new Pen(Color.Black),
                lp2[4].X - wid / 2f, lp2[4].Y,
                lp2[4].X + wid / 2f, lp2[4].Y);

            G.DrawLine(new Pen(Color.Black),
                new Point(0, 0), new Point(0, -(int)(H + fix)));
            List<string> LS = new List<string>();
            double Step = (max - Min) / 10d;
            for (double i = Min; i <= max; i += Step)
            {
                LS.Add(i.ToString());
            }
            for (int i = 0; i < LS.Count; i++)
            {
                G.DrawString(LS[i], new Font("細明體", 10), Brushes.Black,
                   new Point(
                       -(int)fix,
                        (int)(-((double)i / LS.Count * H) - fix)
                        ));
            }


            G.DrawLine(new Pen(Color.Black),
                new Point(0, 0), new Point((int)W, 0));

            pictureBox1.Image = BMP;
        }
        PointF TF(PointF p)
        {
            p.Y = -((p.Y - min) / (max - min)) * (H);
            return p;
        }
    }
}
