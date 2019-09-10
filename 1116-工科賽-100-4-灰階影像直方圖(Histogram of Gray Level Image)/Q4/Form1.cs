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
        public Form1()
        {
            InitializeComponent();
            label1.Text = "最小灰階(亮度)為：";
            label2.Text = "最大灰階(亮度)為：";
            label3.Text = "出現最多之灰階(亮度)為：";
            label4.Text = "最多灰階(亮度)之機率為：";
            label5.Text = "彩色影像(Color Image)";
            label6.Text = "灰階影像 (Gray Level Image)";
        }
        string path = "";
        Bitmap obmp;
        Bitmap nbmp;
        List<int> graylist = new List<int>();
        private void 開啟彩色影像檔OpenColorImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
        }

        private void 彩色影像與灰階影像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obmp = new Bitmap(path);
            nbmp = new Bitmap(obmp.Width, obmp.Height);
            graylist = new List<int>();
            for (int i = 0; i < obmp.Height; i++)
            {
                for (int j = 0; j < obmp.Width; j++)
                {
                    Color c = obmp.GetPixel(j, i);
                    int gray = (int)(c.R * 0.3d + c.G * 0.59d + c.B * 0.11d);
                    graylist.Add(gray);
                    nbmp.SetPixel(j, i, Color.FromArgb(255, gray, gray, gray));
                }
            }
            pictureBox1.Image = obmp;
            pictureBox2.Image = nbmp;
        }
        List<Point> total_count;
        void process()
        {
            List<int> temp = graylist.Distinct().ToList();
            temp = temp.OrderBy(x => x).ToList();
            total_count = new List<Point>();
            for (int i = 0; i < temp.Count; i++)
            {
                total_count.Add(new Point(temp[i], graylist.Count(x => x == temp[i])));
            }
        }
        private void 畫出灰階影像直方圖ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            process();
            chart1.Series.Clear();
            chart1.Series.Add("灰度出現次數");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].Color = Color.Red;

            chart1.Titles.Add("直方圖");
            chart1.ChartAreas[0].AxisX.Title = "梯度振幅";
            chart1.ChartAreas[0].AxisY.Title = "次數";
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 60;
            chart1.ChartAreas[0].AxisX.Maximum = 300;

            total_count.ForEach(x =>
            chart1.Series[0].Points.AddXY(x.X, x.Y)
            );

            chart1.Series.Add("");
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[1].Color = Color.Red;
            total_count.ForEach(x =>
            chart1.Series[1].Points.AddXY(x.X, x.Y)
            );
        }

        private void 求最小灰階和最大灰階ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            process();
            textBox1.Text = total_count.Min(x => x.X).ToString();
            textBox2.Text = total_count.Max(x => x.X).ToString();
        }

        private void 求出現最多灰階和此機率ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double N = graylist.Count;
            double ng =total_count.Find(y=>y.Y == total_count.Max(x=>x.Y)).X;
            textBox3.Text = ng.ToString();
            textBox4.Text = (total_count.Max(x => x.Y) / N).ToString();
        }

        private void 結束離開ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
