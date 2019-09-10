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
namespace 飛機飛行任務
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            chart1.ChartAreas[0].AxisX.Interval = 1.0d;
            chart1.ChartAreas[0].AxisX.Crossing = 0.0d;
            chart1.ChartAreas[0].AxisX.Maximum = 6.0d;
            chart1.ChartAreas[0].AxisX.Minimum = 0.0d;

            chart1.ChartAreas[0].AxisY.Interval = 1.0d;
            chart1.ChartAreas[0].AxisY.Crossing = 0.0d;
            chart1.ChartAreas[0].AxisY.Maximum = 6.0d;
            chart1.ChartAreas[0].AxisY.Minimum = 0.0d;
        }

        int costlimit = 9;
        PointD End;
        int tempindex = 0;
        List<Tower> TL = new List<Tower>();
        List<Jet> JL = new List<Jet>();

        List<List<Point>> PL = new List<List<Point>>();

        double w;
        void Recu(Jet NowJet)
        {
            Graphics g;
            double distemp = PointD.GetDistance(NowJet.Now, End);
            distemp = (distemp < 0.01d ? 0d : distemp);
            if (distemp == 0)
            {
                JL.Add(new Jet(NowJet));
                int FCindex = JL.FindIndex(x => x.FlyCost == JL.Min(y => y.FlyCost));
                if (tempindex != FCindex)
                {
                    tempindex = FCindex;
                    Show(JL[tempindex].Path);
                }
                Application.DoEvents();
                return;
            }
            if (NowJet.NowOil < 0)//沒油了
            {
                return;
            }
            if (distemp > NowJet.NowOil)
            {
                return;
            }

            Jet TempJet;
            if (true)//Point
            {
                int tempdis = (int)Math.Round(NowJet.NowOil, 0);
                if (tempdis < 0) return;
                for (int i = 0; i <= tempdis; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        for (int k = 0; k <= i; k++)
                        {
                            TempJet = new Jet(NowJet);
                            PointD NP = new PointD(TempJet.Now.X + j, TempJet.Now.Y + k);

                            bool flag = false;
                            foreach (var item in TempJet.Path)
                            {
                                if (item.X == NP.X && item.Y == NP.Y)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag) continue;
                            TempJet.FlyPoint(new PointD(i, j), TL, w);
                            Recu(TempJet);
                        }
                    }
                }
            }
            else//Angle
            {
                for (int i = 0; i <= 90; i += 1)
                {
                    TempJet = new Jet(NowJet);
                    TempJet.FlyAngle(i, TL, w);
                    Recu(TempJet);
                }
            }
        }
        List<Point> SetTowerLine(Tower item)
        {
            List<Point> PL = new List<Point>();
            Bitmap bmp = new Bitmap(100, 100);
            Graphics G = Graphics.FromImage(bmp);
            G.Clear(Color.White);
            G.DrawEllipse(new Pen(Color.Black, 0.5f), new RectangleF(
                new PointF((float)item.Place.X - ((float)(item.R / 2d)), (float)item.Place.Y - ((float)(item.R / 2d))), new SizeF((float)item.R, (float)item.R)
                ));



            pictureBox1.Image = bmp;
            Application.DoEvents();
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (bmp.GetPixel(i, j).GetBrightness() < 0.5f)
                    {
                        PL.Add(new Point(j, i));
                    }
                }
            }
            return PL;
        }
        void Show(List<PointD> j)
        {
            chart1.Series.Clear();
            chart1.Series.Add("路徑");

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            j.ForEach(x =>
            chart1.Series[0].Points.AddXY(x.X, x.Y)
            );
            chart1.Series[0].Color = Color.Blue;

            chart1.Series.Add("轉角");
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            j.ForEach(x =>
            chart1.Series[1].Points.AddXY(x.X, x.Y)
            );
            chart1.Series[1].Color = Color.BlueViolet;

            chart1.Series.Add("塔範圍");
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[2].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            var ax = chart1.ChartAreas.First().Axes[0];
            var ay = chart1.ChartAreas.First().Axes[1];


            chart1.Series[2].Color = Color.Black;


            chart1.Series.Add("塔");
            chart1.Series.Last().ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            TL.ForEach(x =>
            chart1.Series.Last().Points.AddXY(x.Place.X, x.Place.Y)
            );
            chart1.Series.Last().MarkerSize = 5;
            chart1.Series.Last().Color = Color.Red;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            End = new PointD(5, 5);
            TL.Add(new Tower() { P = 2, Place = new PointD(2, 5), R = 2 });
            TL.Add(new Tower() { P = 2, Place = new PointD(4, 2), R = 2 });
            TL.Add(new Tower() { P = 1, Place = new PointD(5, 4), R = 3 });
            w = 1;
            for (int i = 0; i <= costlimit; i++)
            {
                Jet j = new Jet(new PointD(1, 1), i);
                Recu(j);
            }
        }

        private void chart1_PrePaint(object sender, System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs e)
        {
            var ax = chart1.ChartAreas[0].AxisX;
            var ay = chart1.ChartAreas[0].AxisY;
            for (int i = 0; i < TL.Count; i++)
            {
                float xc = (float)ax.ValueToPixelPosition(TL[i].Place.X);
                float yc = (float)ay.ValueToPixelPosition(TL[i].Place.Y);

                float rad = (float)TL[i].R;
                rad = (float)(ax.ValueToPixelPosition(0) - ax.ValueToPixelPosition(rad));

                //RectangleF r = new RectangleF(0, 0, rad * 2, rad * 2);

                RectangleF r = new RectangleF(xc - rad, yc - rad, rad * 2, rad * 2);
                e.ChartGraphics.Graphics.DrawEllipse(Pens.Black, r);
            }

            //e.ChartGraphics.Graphics.DrawEllipse(Pens.Black, new RectangleF(0, 0, 5, 5));

        }
    }
    public class Tower
    {
        public PointD Place;
        public double P,R;

    }
    public class Jet
    {
        public PointD Now;
        public List<PointD> Path;
        public double NowOil;
        public double MaxOil;
        public double L;
        public double FlyCost;
        public List<double> angles;
        public Jet(Jet N)
        {
            Now = (PointD)N.Now;
            Path = N.Path.ToList();
            NowOil = N.NowOil;
            MaxOil = N.MaxOil;
            L = N.L;
            FlyCost = N.FlyCost;
        }
        public Jet(PointD Start, double Oil)
        {
            MaxOil = Oil;
            NowOil = Oil;
            Path = new List<PointD>();
            Now = Start;
            Path.Add(new PointD(Now.X, Now.Y));
        }
        public void FlyPoint(PointD NewNow, List<Tower> tl, double w)
        {
            double dis = PointD.GetDistance(Now, NewNow);
            NowOil -= dis;
            Path.Add(new PointD(NewNow.X, NewNow.Y));
            CL(tl);
            CFC(w);
            Now = new PointD(NewNow.X, NewNow.Y);
        }
        public void FlyAngle(double Angle, List<Tower> tl, double w)
        {
            Angle = Angle / 180d * Math.PI;
            PointD NewNow = new PointD(
                Now.X + Math.Cos(Angle),
                Now.Y + Math.Sin(Angle)
                 );
            double dis = 1;/*PointD.GetDistance(Now, NewNow);*/
            NowOil -= dis;
            Path.Add(new PointD(NewNow.X, NewNow.Y));
            CL(tl);
            CFC(w);
            Now = new PointD(NewNow.X, NewNow.Y);
        }
        void CFC(double w)
        {
            angles = new List<double>();
            for (int i = 0; i < Path.Count - 1; i++)
            {
                angles.Add(PointD.GetAnlge(Path[i], Path[i + 1]));
            }
            List<PointD> pl = new List<PointD>();
            List<int> index = new List<int>();
            for (int i = 0; i < angles.Count - 1; i++)
            {
                if (angles[i] != angles[i + 1])
                {
                    index.Add(i);
                }
            }
            FlyCost = L + w * (index.Count - 1);
        }
        void CL(List<Tower> tl)
        {
            L = 0;
            Path.ForEach(jp =>
            {
                tl.ForEach(tp =>
                {
                    double dis = PointD.GetDistance(jp, tp.Place);
                    if (tp.R != 0)
                    {
                        double temp = tp.P * ((tp.R - dis) / tp.R);
                        if (temp > 0)
                            L += temp;
                    }
                });
            });
        }
    }
    public class PointD
    {
        public double X, Y;
        public static double GetDistance(PointD A, PointD B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static double GetAnlge(PointD A, PointD B)
        {
            return Math.Atan2(B.Y - A.Y, B.X - A.X);
        }
    }
}
