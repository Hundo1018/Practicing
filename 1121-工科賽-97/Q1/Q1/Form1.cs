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
            textBox1.Text = "-15";
            textBox2.Text = "15";
            label3.Text = "Min X";
            label4.Text = "Max X";
            button1.Text = "Replot";
            button1_Click(null, null);
        }
        List<PointF> PL = new List<PointF>();
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Series.Add(" ");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            float a = float.Parse(textBox1.Text);
            float b = float.Parse(textBox2.Text);
            chart1.ChartAreas[0].AxisX.Minimum = a;
            chart1.ChartAreas[0].AxisX.Maximum = b;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisY.Interval = 0.2d;
            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;
            chart1.ChartAreas[0].AxisX.MajorGrid = new System.Windows.Forms.DataVisualization.Charting.Grid() { Enabled = false};
            chart1.ChartAreas[0].AxisY.MajorGrid = new System.Windows.Forms.DataVisualization.Charting.Grid() { Enabled = false };
            for (float x = a; x <= b; x += 0.1f)
            {
                float y = (float)(Math.Sin(x) / x);
                if (x == 0)
                {
                    y = 1;
                }
                PL.Add(new PointF(x, -y));
                chart1.Series[0].Points.AddXY(x, y);
            }
        }
    }
}
