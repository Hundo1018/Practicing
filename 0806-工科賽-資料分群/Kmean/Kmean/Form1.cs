using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Kmean
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



        }
        int N, Q, K = 3;
        double[] MSE;
        Data[] datas;
        Random RDM;
        PointD[] U;
        Color[] colors = new Color[7] {Color.Red,Color.Orange,Color.Yellow,Color.Green,Color.Blue,Color.Purple,Color.Black };
        Color[] ncolors = new Color[3] { Color.Black, Color.Blue, Color.Red };
        private void button1_Click(object sender, EventArgs e)
        {
            N = int.Parse(textBox1.Text);
            Q = int.Parse(textBox2.Text);
         
            datas = new Data[N];
            MSE = new double[Q];
            
            textBox3.Text = "";
            textBox4.Text = "";
            for (int i = 0; i < N; i++)
            {
                RDM = new Random(Guid.NewGuid().GetHashCode());
                datas[i] = new Data(K);
                datas[i].X.X = RDM.Next(0, 101);
                RDM = new Random(Guid.NewGuid().GetHashCode());
                datas[i].X.Y = RDM.Next(0, 101);
                int XL = datas[i].X.X.ToString().Length;
                int YL = datas[i].X.Y.ToString().Length;
                int fix=0, fiy=0;
                if (XL == 1) fix = 1;
                else if (XL == 2) fix = 0;
                else if (XL == 3) fix = -1;
                if (YL == 1) fiy = 1;
                else if (YL == 2) fiy = 0;
                else if (YL == 3) fiy = -1;
                textBox3.Text += datas[i].X.X.ToString().PadRight(6 + fix, ' ');

                textBox4.Text += datas[i].X.Y.ToString().PadRight(6 + fiy, ' ');

            }


        }

        void TestData()
        {
            N = 15;
            Q = 11;
            K = 2;
            datas = new Data[N];
            MSE = new double[Q];
            U = new PointD[K];
            textBox3.Text = "";
            textBox4.Text = "";
            datas[0] = new Data(K) { X = new PointD(28, 57) };
            datas[1] = new Data(K) { X = new PointD(67, 33) };
            datas[2] = new Data(K) { X = new PointD(66, 46) };
            datas[3] = new Data(K) { X = new PointD(12, 71) };
            datas[4] = new Data(K) { X = new PointD(41, 88) };
            datas[5] = new Data(K) { X = new PointD(28, 72) };
            datas[6] = new Data(K) { X = new PointD(72, 2) };
            datas[7] = new Data(K) { X = new PointD(28, 67) };
            datas[8] = new Data(K) { X = new PointD(90, 44) };
            datas[9] = new Data(K) { X = new PointD(83, 44) };
            datas[10] = new Data(K) { X = new PointD(39, 12) };
            datas[11] = new Data(K) { X = new PointD(50, 81) };
            datas[12] = new Data(K) { X = new PointD(69, 32) };
            datas[13] = new Data(K) { X = new PointD(83, 25) };
            datas[14] = new Data(K) { X = new PointD(61, 34) };
            U[0] = datas[0].X;
            U[1] = datas[1].X;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            K =int.Parse( textBox6.Text);
            // TestData();
            U = new PointD[K];
            for (int i = 0; i < K; i++)
            U[i] = datas[i].X;
            for (int i = 0; i < N; i++)
            {
                datas[i].Dists = new double[K];
            }


            for (int i = 0; i < Q; i++)
            {
                //算出每個點所在的群
                for (int j = 0; j < N; j++)
                {
                    int minlab = 0;
                    for (int k = 0; k < K; k++)
                    {
                        datas[j].Dists[k] = CulDis(datas[j].X, U[k]);
                        if (datas[j].Dists[minlab] > datas[j].Dists[k])
                        {
                            minlab = k;
                        }
                    }
                    datas[j].label = minlab;
                }
                //算出每個群的重心 作為新的U
                PointD[] DisTotal = new PointD[K];
                for (int j = 0; j < K; j++) DisTotal[j] = new PointD(0, 0);
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < K; k++)
                    {
                        if (datas[j].label == k)
                        {
                            DisTotal[k].X += datas[j].X.X;
                            DisTotal[k].Y += datas[j].X.Y;
                        }
                    }
                }
                int[] KCount = new int[K];
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < K; k++)
                    {
                        if (datas[j].label == k)
                        {
                            KCount[k]++;
                        }
                    }
                }
                for (int j = 0; j < K; j++)
                {
                    U[j].X = DisTotal[j].X / KCount[j];
                    U[j].Y = DisTotal[j].Y / KCount[j];
                }

                //計算MSE
                double[] msetemp = new double[K];
                double temptemp = 0;
                for (int j = 0; j < K; j++) msetemp[j] = 0;
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < K; k++)
                    {
                        if (datas[j].label == k)
                        {
                            temptemp += Math.Pow(CulDis(datas[j].X, U[k]), 1);
                        }
                    }
                }
                MSE[i] = temptemp / N;
            }
            textBox5.Text = "";
            chart2.Series.Clear();
            
            for (int i = 0; i < N; i++)
            {
                int fix = 0;
                int temp = datas[i].label.ToString().Length;
                if (temp == 1) fix = 1;
                else if (temp == 2) fix = 0;
                else if (temp == 3) fix = -1;
                textBox5.Text += datas[i].label.ToString().PadRight(6 + fix, ' ');
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Series.Add("DatasMSE");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            int z = 0;
            foreach (var item in MSE)
            {
                chart1.Series[0].Points.AddXY(z++, item);
            }
            chart2.Series.Clear();
            for (int i = 0; i < K; i++)
            {
                chart2.Series.Add(i.ToString());
                chart2.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chart2.Series[i].Color = colors[i];
                for (int j = 0; j < N; j++)
                {
                    if (datas[j].label == i)
                    {
                        chart2.Series[i].Points.AddXY(datas[j].X.X,datas[j].X.Y);
                    }
                }
            }
        }
        double CulDis(PointD X, PointD U)
        {
            return Math.Sqrt(Math.Pow((U.X - X.X), 2) + Math.Pow((U.Y - X.Y), 2));
        }
    }
    class Data
    {
        public PointD X;
        public double[] Dists;
        public int label;
        public Data(int Set)
        {
            X = new PointD(0,0);
            Dists = new double[Set];
        }
    }
    class PointD
    {
        public double X;
        public double Y;
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
    
}