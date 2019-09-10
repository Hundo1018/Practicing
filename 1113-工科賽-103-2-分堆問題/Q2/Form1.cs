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

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1_Click(null, null);
        }
        string path = "Sample.txt";
        List<People> PL = new List<People>();
        List<Group> GL = new List<Group>();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            PL = new List<People>();
            GL = new List<Group>();
            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine();
                string temp = "";
                int idcount = 0;
                while (!sr.EndOfStream)
                {
                    string[] tempstrar = sr.ReadLine().Split(' ');
                    People p = new People();
                    p.W = double.Parse(tempstrar[0]);
                    p.H = double.Parse(tempstrar[1]);
                    p.GroupID = -1;
                    p.ID = idcount++;
                    PL.Add(p);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                GL.Add(new Group());
            }
            textBox1.Text = "";
            PL.ForEach(x => textBox1.Text += $"{x.ID.ToString().PadLeft(3)}{x.W.ToString().PadLeft(8)}{x.H.ToString().PadLeft(8)}\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                GL[i] = new Group() { CenterH = PL[i].H, CenterW = PL[i].W, ID = i };
                PL[i].GroupID = i;
            }
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 3; i < PL.Count; i++)
            {
                PL[i].GroupID = rdm.Next(0, 3);//012
            }
            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < GL.Count; j++)
                {
                    GL[j].UpdateMenber(PL);
                }
                for (int j = 0; j < PL.Count; j++)
                {
                    PL[j].JoinGroup(GL);
                }
                for (int j = 0; j < GL.Count; j++)
                {
                    GL[j].UpdateMenber(PL);
                }
                
            }
            textBox2.Text = "";
            for (int i = 0; i < PL.Count; i++)
            {
                textBox2.Text += $"第{i}筆屬於{PL[i].GroupID}堆\r\n";
            }
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            GL[0].PL.ForEach(x => textBox3.Text += $"{x.ID.ToString().PadLeft(3)}{x.W.ToString().PadLeft(8)}{x.H.ToString().PadLeft(8)}\r\n");
            GL[1].PL.ForEach(x => textBox4.Text += $"{x.ID.ToString().PadLeft(3)}{x.W.ToString().PadLeft(8)}{x.H.ToString().PadLeft(8)}\r\n");
            GL[2].PL.ForEach(x => textBox5.Text += $"{x.ID.ToString().PadLeft(3)}{x.W.ToString().PadLeft(8)}{x.H.ToString().PadLeft(8)}\r\n");
            chart1.Series.Clear();
            List<Color> CL = new List<Color>() { Color.Red, Color.Green, Color.Blue };
            for (int i = 0; i < 3; i++)
            {
                chart1.Series.Add($"{i}");
                chart1.Series[i].Points.Clear();
                chart1.Series[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chart1.Series[i].Color = CL[i];
                GL[i].PL.ForEach(x => chart1.Series[i].Points.AddXY(x.W, x.H));
            }
        }
    }
    class People
    {
        public double W, H;
        public int GroupID,ID;
        public void JoinGroup(List<Group> GL)
        {
            double dis_min = double.MaxValue;
            foreach (var item in GL)
            {
                double dis = Math.Sqrt(Math.Pow((item.CenterW - W), 2) + Math.Pow((item.CenterH - H), 2));
                if (dis < dis_min)
                {
                    dis_min = dis;
                    GroupID = item.ID;
                }
            }
        }
    }
    class Group
    {
        public List<People> PL = new List<People>();
        public int ID;
        public double CenterW, CenterH;
        public void UpdateMenber(List<People> pl)
        {
            PL.Clear();
            PL = pl.FindAll(x => x.GroupID == ID).ToList();
            UpdateCenter();
        }
        void UpdateCenter()
        {
            CenterH = (double)PL.Sum(x => x.H) / (double)PL.Count;
            CenterW = (double)PL.Sum(x => x.W) / (double)PL.Count;
        }
    }
}
