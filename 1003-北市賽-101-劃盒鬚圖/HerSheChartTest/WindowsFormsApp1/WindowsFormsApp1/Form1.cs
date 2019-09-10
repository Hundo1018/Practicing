using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            string[] temp = textBox1.Text.Split(',');
            double[] datas = new double[temp.Count()];
            for (int i = 0; i < datas.Count(); i++)
            {
                datas[i] = double.Parse(temp[i]);
            }
            datas = datas.OrderBy(x => x).ToArray();
            datas.Reverse();
            chart1.Series.Add("Box");
            chart1.Series.Last().ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            //chart1.Series.Last().Points.Add(datas);

            chart1.Series.Last().Points.Add(datas);

            chart1.Series.Last()["BoxPlotPercentile"] = Test.ToString();
            chart1.Series.Last()["BoxPlotWhiskerPercentile"] = Test.ToString();

            chart1.Series.Last()["BoxPlotShowAverage"] = "True";
            chart1.Series.Last()["BoxPlotShowMedian"] = "True";
            chart1.Series.Last()["BoxPlotShowUnusualValues"] = "True";
            //chart1.Series.Last()["BoxPlotShowAverage"] = "True";

        }
        int Test = 0;
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Test = e.NewValue;
            button1_Click(null, null);
        }
    }
}
