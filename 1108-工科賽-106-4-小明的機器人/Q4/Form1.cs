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
namespace Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1_Click(null, null);
            textBox2.Text = "9999";
            textBox3.Text = "0.1";
            textBox4.Text = "1.0;-1.0;0.0";
            button2_Click(null, null);
            textBox6.Text = "1.0;1.0;1.0";
            button3_Click(null, null);
        }
        string path;
        List<double[]> traindata_list = new List<double[]>();
        List<double> weight = new List<double>();
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            path = "data.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
            else
            {
                return;
            }

            using (StreamReader SR = new StreamReader(path))
            {
                while (!SR.EndOfStream)
                {
                    string temp = SR.ReadLine();
                    string[] str = temp.Split('\t');
                    traindata_list.Add(new double[4] {
                        double.Parse(str[0]),
                        double.Parse(str[1]),
                        double.Parse(str[2]),
                        double.Parse(str[3])
                    });
                    textBox1.Text += temp;
                    textBox1.Text += "\r\n";
                }
            }
        }
        int a, b, c, d, e, f, g;
        double MaxRound = 9999;
        double n = 0.1;
        double E = 0;
        double f = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            MaxRound = double.Parse(textBox2.Text);
            n = double.Parse(textBox3.Text);
            weight = textBox4.Text.Split(';').ToList().ConvertAll<double>(double.Parse).ToList();
            double round = 0;
            do//訓練週期
            {
                for (int i = 0; i < traindata_list.Count; i++)//每個訓練測資
                {
                    double f = 0, y = traindata_list[i].Last();
                    for (int j = 0; j < traindata_list[i].Count() - 1; j++)//每層網路
                    {
                        f += traindata_list[i][j] * weight[j];
                    }
                    double o = (f >= 0 ? 1 : -1);
                    if (o != y)
                    {
                        for (int j = 0; j < weight.Count; j++)
                        {
                            weight[j] = weight[j] + n * (y - o) * traindata_list[i][j];
                        }
                        E += Math.Pow((y - o), 2) / 2;
                    }
                }
                round++;
                if (round == MaxRound) break;
            } while (E != 0);
            textBox5.Text = "";
            foreach (var item in weight)
            {
                textBox5.Text += Math.Round(item, 2).ToString("0.00") + ";";
            }
            textBox5.Text = textBox5.Text.Substring(0, textBox5.Text.Length - 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<double> temp = textBox6.Text.Split(';').ToList().ConvertAll<double>(double.Parse).ToList();
            double f = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                f += temp[i] * weight[i];
            }
            label1.Text = "機器人往" + (f < 0 ? "右" : "左");
        }
    }
}
