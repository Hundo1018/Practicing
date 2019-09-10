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

namespace DATA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Catchdata();

            chart1.Series.Clear();
            chart1.Series.Add("Blue");//0
            chart1.Series.Add("Red");//1
            chart1.Series[0].ChartType =
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[1].ChartType =
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[1].Color = Color.Red;
            CHART();
            Pic();
        }
        void CHART()
        {
            if (index >= Datas.Count)
            {
                return;
            }
            for (int i = 0; i < Datas[index].Count; i++)
            {
                chart1.Series[Datas[index][i].TYPE].Points.AddXY(Datas[index][i].X, Datas[index][i].Y);
            }
        }
        List<List<Data>> Datas = new List<List<Data>>();

        List<Data> NowDatas = new List<Data>();

        void Pic()
        {
            if (index >= Datas.Count)
            {
                return;
            }
            // pictureBox1.Image = null;
            int h = pictureBox1.Height;
            int w = pictureBox1.Width;
            Bitmap BMP = new Bitmap(w, h);
            Graphics G = Graphics.FromImage(BMP);
            int fix = 20;
            G.TranslateTransform(fix, h - fix);


            for (int i = 0; i < Datas[index].Count; i++)
            {
                NowDatas.Add(Datas[index][i]);
            }
            int xmin = NowDatas.Min(x => x.X);
            int xman = NowDatas.Max(x => x.X);
            int ymin = NowDatas.Min(x => x.Y);
            int ymax = NowDatas.Max(x => x.Y);
            string[] STR = new string[] {
                "ｏ",
                "＊" };
            Brush[] CLR = new Brush[]
            {
                Brushes.Blue,
                Brushes.Red
            };
            for (int i = 0; i < NowDatas.Count; i++)
            {
                G.DrawString(STR[NowDatas[i].TYPE], new Font("細明體", 8), CLR[NowDatas[i].TYPE],
                    TF(NowDatas[i], xman, xmin, ymax, ymin, fix, h, w)
                    );
            }
            G.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(w, 0));
            G.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(0, -h));
            int Xstep = xman / 10;
            int Ystep = ymax / 10;
            for (int i = 0; i <= 10; i++)
            {
                G.DrawString((Xstep * i).ToString(), new Font("細明體", 8), Brushes.Black,
                    new Point(
                        TF(new Data((fix + Xstep * i),0,0), xman, xmin, ymax, ymin, fix, h, w).X
                        ,
                        0)
                    );
                G.DrawString((Ystep * i).ToString(), new Font("細明體", 8), Brushes.Black,
                    new Point(
                        -fix,
                        TF(new Data(0, ( Ystep * i), 0), xman, xmin, ymax, ymin, fix, h, w).Y)
                    );

                //G.DrawString((Xstep * i).ToString(), new Font("細明體", 8), Brushes.Black,
                //    TF(new Data(fix + Xstep * i, fix + Xstep * i, 0),
                //    xman, xmin, ymax, ymin, fix, h, w)
                //    );
                //G.DrawString((Xstep * i).ToString(), new Font("細明體", 8), Brushes.Black,
                //    TF(new Data(new Point(-fix, (-fix - Ystep * i)).X, new Point(-fix, (-fix - Ystep * i)).Y, 0),
                //    xman, xmin, ymax, ymin, fix, h, w)
                //    );
            }

            pictureBox1.Image = BMP;
        }
        Point TF(Data p, int xmax, int xmin, int ymax, int ymin, int fix, int H, int W)
        {
            Data temp = new Data(p.X,p.Y,p.TYPE);
            temp.X = (int)(
                ((double)(p.X - xmin) / (double)(xmax - xmin) * (double)(W - fix))
                );
            temp.Y = -(int)(
                ((double)(p.Y - ymin) / (double)(ymax - ymin) * (double)(H - fix)) 
                );

            return new Point(temp.X, temp.Y);
        }



        void Catchdata()
        {
            string temp = "";
            using (StreamReader SR = new StreamReader("DataXY.txt"))
            {
                temp = SR.ReadToEnd();
            }
            temp = temp.Replace("\r\n", ",");
            for (int i = 0; i < temp.Split(',').Count(); i++)//3資料
            {
                var a = temp.Split(',')[i].Split(' ').ToList();
                List<Data> dl = new List<Data>();
                for (int j = 2; j < a.Count; j += 3)
                {
                    Data tempdata = new Data(int.Parse(a[j]), int.Parse(a[j + 1]), int.Parse(a[j + 2]));
                    dl.Add(tempdata);
                }
                if (dl.Count > 0)
                {
                    Datas.Add(new List<Data>(dl));
                }
            }
        }






        private void button1_Click(object sender, EventArgs e)
        {
            index++;
            CHART();
            Pic();
        }
        int index = 0;
       
    }
    class Data
    {
        public int TYPE, X, Y;
        public Data(int x,int y,int ty)
        {
            X = x;
            Y = y;
            TYPE = ty;
        }
    }
}
