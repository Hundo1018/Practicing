using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q4
{
    public partial class Form1 : Form
    {
        public Form1(PointF Min, PointF Max, List<PointF> PL)
        {
            InitializeComponent();
            this.Text = "";
            this.AutoSize = true;
            chart1.Series.Clear();
            chart1.Series.Add("輸入資料");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            PL.ForEach(x => chart1.Series[0].Points.AddXY(x.X, x.Y));

            chart1.Series.Add("逼近的直線");
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].Points.AddXY(Min.X, Min.Y);
            chart1.Series[1].Points.AddXY(Max.X, Max.Y);

            chart1.ChartAreas[0].AxisX.Minimum = Math.Floor(PL.Min(x => x.X));
            chart1.ChartAreas[0].AxisX.Maximum = Math.Ceiling(PL.Max(x => x.X));

            chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(PL.Min(x => x.Y));
            chart1.ChartAreas[0].AxisY.Maximum = Math.Ceiling(PL.Max(x => x.Y));

            chart1.ChartAreas[0].AxisX.Interval = (int)1;
            chart1.ChartAreas[0].AxisY.Interval = (int)1;

            System.Windows.Forms.DataVisualization.Charting.Grid c = new System.Windows.Forms.DataVisualization.Charting.Grid();
            c.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            System.Windows.Forms.DataVisualization.Charting.Grid c2 = new System.Windows.Forms.DataVisualization.Charting.Grid();
            c2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;

            chart1.ChartAreas[0].AxisX.MajorGrid = c;
            chart1.ChartAreas[0].AxisY.MajorGrid = c2;
            chart1.BackColor = Color.LightGray;
            chart1.Titles.Add("線性回歸-最小平方逼近");
            this.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
