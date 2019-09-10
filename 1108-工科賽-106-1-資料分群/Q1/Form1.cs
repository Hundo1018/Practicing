using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "15";
            textBox2.Text = "11";
            textBox6.Text = "2";
            button1_Click(null, null);
            button2_Click(null, null);
            button3_Click(null, null);
        }
        List<Score> SL = new List<Score>();
        List<Group> GL = new List<Group>();
        int N, Q,K;
        private void button1_Click(object sender, EventArgs e)
        {
            SL = new List<Score>();
            GL = new List<Group>();
            N = int.Parse(textBox1.Text);
            Q = int.Parse(textBox2.Text);
            K = int.Parse(textBox6.Text);
            Random RDM = new Random(Guid.NewGuid().GetHashCode());
            textBox3.Text = "";
            textBox4.Text = "";
            for (int i = 0; i < N; i++)
            {
                int scorea = RDM.Next(0, 101);
                int scoreb = RDM.Next(0, 101);
                SL.Add(new Score() { P = new Pointd(scorea, scoreb), Groupid = -1 });
                textBox3.Text += scorea.ToString().PadRight(4);
                textBox4.Text += scoreb.ToString().PadRight(4);
            }
            for (int i = 0; i < K; i++)
            {
                GL.Add(new Group() { chi = new List<Score>(), ID = (i + 1), U = new Pointd(SL[i].P.X, SL[i].P.Y) });
            }
        }
        List<double> MSE = new List<double>();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MSE = new List<double>();
            for (int p = 0; p < Q; p++)
            {
                foreach (var item in SL)
                {
                    item.wherego(GL);//配置
                }
                foreach (var item in GL)
                {
                    item.update(SL);//更新
                }
                foreach (var item in GL)
                {
                    item.CalU();
                }
                //mse
                double mse = 0;
                foreach (var item in SL)
                {
                    mse += item.GetMSE(GL);
                }
                double t = mse / SL.Count();
                MSE.Add(t);
            }
            textBox5.Text = "";
            foreach (var item in SL)
            {
                textBox5.Text += item.Groupid.ToString().PadRight(4);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Series.Add("MSE");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i < Q; i++)
            {
                chart1.Series[0].Points.AddXY(i, MSE[i]);
            }
            chart2.Series.Clear();
            List<Color> CL = new List<Color>() { Color.Red,Color.Orange,Color.Green,Color.Blue };
            for (int i = 0; i < GL.Count; i++)
            {
                chart2.Series.Add($"{GL[i].ID}");
                chart2.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chart2.Series[i].Color = CL[i];
            }
            foreach (var item in GL)
            {
                foreach (var p in item.chi)
                {
                    chart2.Series[$"{item.ID}"].Points.AddXY(p.P.X, p.P.Y);
                }

            }
        }
    }
    class Group
    {
        public int ID;
        public List<Score> chi = new List<Score>();
        public Pointd U;
        public void CalU()
        {
            double x = 0, y = 0;
            foreach (var item in chi)
            {
                x += item.P.X;
                y += item.P.Y;
            }
            U.X = x / chi.Count;
            U.Y = y / chi.Count;
        }
        public void update(List<Score> sl)
        {
            chi.Clear();
            foreach (var item in sl)
            {
                if (item.Groupid == ID)
                {
                    chi.Add(item);
                }
            }
        }
    }
    class Score
    {
        public Pointd P;
        public int Groupid;
        public void wherego(List<Group> GL)
        {
            List<double> d = new List<double>();
            for (int i = 0; i < GL.Count; i++)
            {
                d.Add(Math.Sqrt(
                    Math.Pow((P.X - GL[i].U.X), 2) +
                    Math.Pow((P.Y - GL[i].U.Y), 2)));
            }
            int index = d.IndexOf(d.Min());
            Groupid = GL[index].ID;
        }
        public double GetMSE(List<Group> GL)
        {
            Group g = GL.Find(x => x.ID == Groupid);
            double temp = Math.Pow((P.X - g.U.X), 2) + Math.Pow((P.Y - g.U.Y), 2);
            return Math.Sqrt( temp);
        }
    }
    class Pointd
    {
        public double X, Y;
        public Pointd(double x,double y)
        {
            X = x;
            Y = y;
        }
    }
}
