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
            textBox1.Text = "44030001";
            textBox2.Text = "44030050";
            textBox3.Text = "44020291,44010312  44010313,";
            label1.Text = "數字範圍(8位的數字)";
            label2.Text = "個別數字(8位的數字,用逗號或空格分割)";
            label3.Text = "~";
            dic.Add(0, 0);
            dic.Add(1, 7);
            dic.Add(2, 4);
            dic.Add(3, 1);
            dic.Add(4, 8);
            dic.Add(5, 5);
            dic.Add(6, 2);
            dic.Add(7, 9);
            dic.Add(8, 6);
            dic.Add(9, 3);
        }
        Dictionary<int, int> dic = new Dictionary<int, int>();
        StringBuilder sb = new StringBuilder();
        private void button1_Click(object sender, EventArgs e)
        {
            sb = new StringBuilder();
            string StartStr = textBox1.Text;
            string EndStr = textBox2.Text;
            textBox4.Text = "";
            int Start;
            int End;
            if (int.TryParse(StartStr, out Start) && int.TryParse(EndStr, out End))
            {
                Start = int.Parse(Start.ToString() + "0");
                End = int.Parse(End.ToString() + "0");
                for (int i = Start; i <= End; i++)
                {
                    string temp = i.ToString();
                    if (Check(temp)) sb.Append($"{temp}@antu.edu.tw; ");
                }
                OneByOne();
            }
            else
            {
                OneByOne();
            }
            textBox4.Text = sb.ToString().Substring(0, sb.Length - 2);
        }
        void OneByOne()
        {
            string o = textBox3.Text;
            o = o.Replace(' ', ',');
            List<string> n = o.Split(',').ToList();
            List<string> nn = new List<string>();
            foreach (var item in n)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    nn.Add(item);
                }
            }
            foreach (var item in nn)
            {
                for (int i = 0; i <= 9; i++)
                {
                    string temp = item + $"{i}";
                    if (Check(temp)) sb.Append($"{temp}@antu.edu.tw; ");
                }
            }
        }
        bool Check(string instr)
        {
            int sum = 0;
            for (int i = 0; i < instr.Length - 1; i++)
            {
                int temp = instr[i] - '0';
                sum += temp * (i + 1);
            }
            if (dic[sum % 10] == int.Parse(instr.Last().ToString()))
            {
                return true;
            }
            return false;
        }
    }
}
