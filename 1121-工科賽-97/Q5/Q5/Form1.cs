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
using System.Diagnostics;

namespace Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "inp.txt";
            textBox2.Text = "out.txt";
            textBox3.Text = "8";
            textBox4.Text = "68.12";
            textBox5.Text = "69.64";
            button1.Text = "執行";
            button2.Text = "驗證";
            button3.Text = "結束";
            label1.Text = "輸入檔路徑名稱";
            label2.Text = "輸出檔路徑名稱";
            label3.Text = "第幾日";
            label4.Text = "第幾日K值";
            label5.Text = "第幾日D值";
            button1_Click(null, null);
            button2_Click(null, null);
        }
        string path = "";
        private void button1_Click(object sender, EventArgs e)
        {
            path = textBox1.Text;
            using (StreamReader SR = new StreamReader(path))
            {
                HL = SR.ReadLine().Split(' ').ToList().ConvertAll<double>(double.Parse).ToList();
                LL = SR.ReadLine().Split(' ').ToList().ConvertAll<double>(double.Parse).ToList();
                VL = SR.ReadLine().Split(' ').ToList().ConvertAll<double>(double.Parse).ToList();
            }
            SetDay = int.Parse(textBox3.Text);
            label4.Text = $"第{SetDay}日K值";
            label5.Text = $"第{SetDay}日K值";
        }
        List<double>
            HL = new List<double>(),
            LL = new List<double>(),
            VL = new List<double>(),
            KL = new List<double>(),
            DL = new List<double>();

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int SetDay = 0;
        double SetDay_K = 0, SetDay_D = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            SetDay = int.Parse(textBox3.Text);
            SetDay_K = double.Parse(textBox4.Text);
            SetDay_D = double.Parse(textBox5.Text);
            KL.Add(SetDay_K);
            DL.Add(SetDay_D);
            for (int i = SetDay; i < HL.Count; i++)
            {
                var h = HL.GetRange(i - SetDay, SetDay+1).ToList();
                var l = LL.GetRange(i - SetDay, SetDay+1).ToList();
                var v = VL.GetRange(i - SetDay, SetDay+1).ToList();
                double max = h.Max();
                double min = l.Min();
                double RSV = ((v.Last() - min) / (max - min)) * 100d;
                double k = ((2d / 3d) * KL.Last()) + ((1d / 3d) * RSV);
                double d = ((2d / 3d) * DL.Last()) + ((1d / 3d) * k);
                KL.Add(k);
                DL.Add(d);
            }
            using (StreamWriter sw = new StreamWriter(textBox2.Text))
            {
                for (int i = 0; i < KL.Count; i++)
                {
                    sw.Write(KL[i].ToString("0.00") + " ");
                }
                sw.WriteLine("");
                for (int i = 0; i < KL.Count; i++)
                {
                    sw.Write(DL[i].ToString("0.00") + " ");
                }
                sw.WriteLine("");
            }
            Process.Start(textBox2.Text);
        }
    }
}
