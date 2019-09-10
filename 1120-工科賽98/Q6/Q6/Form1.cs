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

namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Net";
            label2.Text = "Mask";
            button1.Text = "Search";
            label3.Text = "/";
            Nets.Add("192.168.0.1");
            Nets.Add("168.95.1.1");
            Nets.Add("168.95.128.1");
            comboBox1.Items.AddRange(Nets.ToArray());
            Masks = Enumerable.Range(24, 32 - 24 + 1).ToList();
            foreach (var item in Masks)
            {
                comboBox2.Items.Add(item);
            }
            using (StreamReader sr = new StreamReader("IP.txt"))
            {
                while (!sr.EndOfStream)
                {
                    ONets.Add(sr.ReadLine());
                }
            }
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("A", 0);
            dic.Add("B", 64);
            dic.Add("C", 192);
            foreach (var item in ONets)
            {

                string temp = item.Split(',')[0] + ",";

                temp += dic[item.Split(',')[0]] + ".";

                var a = item.Split(',')[1].Split('.');
                for (int i = 1; i <= 3; i++)
                {
                    temp += a[i] + ".";
                }
                temp = temp.Substring(0, temp.Length - 1) + ",";
                temp += item.Split(',')[2];

                FixNets.Add(temp);
            }
            foreach (var item in FixNets)
            {
                CleanNets.Add(item.Split(',')[1].Split('.').ToList().ConvertAll<int>(int.Parse).ToList().ToArray());
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.Text = "24";
            button1_Click(null, null);
        }
        List<string> ONets = new List<string>();
        List<string> FixNets = new List<string>();
        List<int[]> CleanNets = new List<int[]>();
        int[] MaskedNet;
        List<string> Nets = new List<string>();
        List<int> Masks = new List<int>();
        private void button1_Click(object sender, EventArgs e)
        {
            int[] cleannet = (comboBox1.Text.Split('.').ToList().ConvertAll<int>(int.Parse).ToList().ToArray());
            string tempmask = "";
            for (int i = 0; i < int.Parse(comboBox2.Text); i++)
            {
                tempmask += "1";
            }
            tempmask = tempmask.PadRight(32, '0');

            string a = AND(comboBox1.Text, tempmask);
            List<int> indexlist = new List<int>();
            for (int i = 0; i < CleanNets.Count; i++)
            {
                var b = AND(FixNets[i].Split(',')[1], tempmask);
                if (a == b)
                {
                    indexlist.Add(i);
                }
            }
            textBox1.Text = "";
            textBox1.Text = $"Net：{a}\r\n";
            textBox1.Text += $"Mask：{convert(tempmask)}\r\n";
            textBox1.Text += "------------------------------------------------------\r\n";
            for (int i = 0; i < indexlist.Count; i++)
            {
                textBox1.Text += $"IP：{FixNets[i].Split(',')[1]}, Message：{FixNets[i].Split(',')[2]}\r\n";
            }
        }
        string convert(string mask)
        {
            string temp = "";
            for (int i = 0; i < 4; i++)
            {
                temp += Convert.ToInt32(mask.Substring(i * 8, 8), 2) + ".";
            }
            return temp.Substring(0, temp.Length - 1);
        }
        string AND(string a, string mask)
        {
            string ans = "";
            int[] nets = a.Split('.').ToList().ConvertAll<int>(int.Parse).ToArray();
            int[] tempmask = new int[5];
            for (int i = 0; i < 4; i++)
            {
                tempmask[i] = Convert.ToInt32(mask.Substring(i * 8, 8), 2);
            }
            for (int i = 0; i < 4; i++)
            {
                ans += (tempmask[i] & nets[i]) + ".";
            }
            ans = ans.Substring(0, ans.Length - 1);
            return ans;
        }
    }
}
