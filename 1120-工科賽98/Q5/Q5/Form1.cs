using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Visible = false;
            label4.Text = "距離";
            button1.Text = "求最大距離";
            button2.Text = "求最小距離";
            button3.Text = "求平均距離";
            button4.Text = "畫出點的分布";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Process();
            }
        }
        GroupBox G1;
        GroupBox G2;
        List<PointF> PL;
        void Process()
        {

            int N = int.Parse(textBox1.Text);
            G1 = new GroupBox() { Location = new Point(12, 65), AutoSize = true, Text = $"請輸入{N}個點座標：x和y值" };
            G2 = new GroupBox() { Location = new Point(G1.Right + 50, 65), AutoSize = true, Text = $"請輸入{N}測試點座標：x和y值" };
            int count = 2;
            for (int i = 0; i < N; i++)
            {
                Label lbl = new Label() { Location = new Point(12, 24 + i * 24), Text = $"第x{i + 1}點座標" };
                TextBox Tbx1 = new TextBox()
                {
                    Location = new Point(lbl.Right, lbl.Top),
                    Size = new Size(55, 22),
                    Name = count.ToString()
                };
                count++;
                TextBox Tbx2 = new TextBox()
                {
                    Location = new Point(Tbx1.Right + 3, Tbx1.Top),
                    Size = new Size(55, 22),
                    Name = count.ToString()
                };
                count++;
                G1.Controls.Add(lbl);
                G1.Controls.Add(Tbx1);
                G1.Controls.Add(Tbx2);
            }
            TextBox Px = new TextBox()
            {
                Location = new Point(12, 24),
                Size = new Size(55, 22),
                Name = "0"
            };
            TextBox Py = new TextBox()
            {
                Location = new Point(Px.Right + 3, Px.Top),
                Size = new Size(55, 22),
                Name = "1"
            };
            G2.Controls.Add(Px);
            G2.Controls.Add(Py);
            Controls.Add(G1);
            Controls.Add(G2);
        }
        bool flag = true;
        void Read()
        {
            PL = new List<PointF>();
            int count = 0;
            float[] XY = new float[2];
            foreach (var item in G1.Controls)
            {
                if (item is TextBox)
                {
                    count %= 2;
                    XY[count] = float.Parse(((TextBox)item).Text);
                    if (count == 1) PL.Add(new PointF(XY[0], XY[1]));
                    count++;
                }
            }
             TP = new PointF();
            foreach (var item in G2.Controls)
            {
                if (item is TextBox)
                {
                    count %= 2;
                    XY[count] = float.Parse(((TextBox)item).Text);
                    if (count == 1) TP = new PointF(XY[0], XY[1]);
                    count++;
                }
            }
            Dis = new List<double>();
            for (int i = 0; i < PL.Count; i++)
            {
                double temp1 = Math.Pow((PL[i].X - TP.X), 2);
                double temp2 = Math.Pow((PL[i].Y - TP.Y), 2);
                Dis.Add(Math.Sqrt(temp1 + temp2));
            }
            MinDis = Dis.Min();
            MinID = Dis.IndexOf(MinDis);

            MaxDis = Dis.Max();
            MaxID = Dis.IndexOf(MaxDis);

            AveDis = Dis.Average();
        }
        List<double> Dis;
        double MinDis, MinID, MaxDis, MaxID,AveDis;
        PointF TP;
        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            chart1.Series.Clear();

            int max = (int)(Math.Max(TP.Y, (Math.Max(TP.X, Math.Max(PL.Max(x => x.Y), PL.Max(x => x.X))))));
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = max;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = max;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.Series.Add(" ");

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[0].Color = Color.Blue;
            chart1.Series[0].Label = "";
            int count = 1;
            foreach (var item in PL)
            {
                chart1.Series[0].Points.AddXY(item.X, item.Y);
                chart1.Series[0].Points[count - 1].Label = "x" + count++.ToString();
            }
            chart1.Series.Add("  ");

            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[1].Color = Color.Red;
            chart1.Series[1].Points.AddXY(TP.X, TP.Y);
            chart1.Series[1].Points[0].Label = "x";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                Read();
                flag = false;
            }
            textBox2.Text = MaxDis.ToString();
            label2.Text = $"測試點與第x{MaxID+1}點距離最遠";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                Read();
                flag = false;
            }
            textBox3.Text = MinDis.ToString();
            label3.Text = $"測試點與第x{MinID+1}點距離最近";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                Read();
                flag = false;
            }
            textBox4.Text = AveDis.ToString();
        }
    }


}
