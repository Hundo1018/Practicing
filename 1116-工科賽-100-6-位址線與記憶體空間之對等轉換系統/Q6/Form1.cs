using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dic.Add(0, "B");
            dic.Add(1, "KB");
            dic.Add(2, "MB");
            dic.Add(3, "GB");
            dic.Add(4, "TB");
            dic.Add(5, "TB");
            dicr.Add("K", 10);
            dicr.Add("M", 20);
            dicr.Add("G", 30);
            dicr.Add("T", 40);
            //dicr.Add("0T", 5);
            textBox1.Text = "36";
            textBox2.Text = "4B";
            textBox4.Text = "12TB";
            textBox5.Text = "8B";
            button2_Click(null, null);
            button4_Click(null, null);
            button1.Text = "F-rand";
            button2.Text = "F-conv";
            button3.Text = "R-rand";
            button4.Text = "R-conv";
            label1.Text = "Address bus:\r\n# 16 ~ 52";
            label2.Text = "Bytes per address:\r\n # 1B~8B";
            label3.Text = "Memory space:\r\n # 512KB ~ 32768TB";
        }
        Dictionary<int, string> dic = new Dictionary<int, string>();
        Dictionary<string, int> dicr = new Dictionary<string, int>();
        private void button2_Click(object sender, EventArgs e)
        {
            long N = long.Parse(textBox1.Text);
            long M = long.Parse(textBox2.Text.Replace("B", ""));
            long newvalue = (long)Math.Pow(2, N) * M;
            int p = 0;
            while (p < 5 && newvalue >= 1024)
            {
                newvalue /= 1024;
                p++;
            }
            string ans = newvalue.ToString() + dic[p];
            textBox3.Text = ans.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            textBox5.Text = rdm.Next(1, 9).ToString() + "B";
            textBox6.Text = rdm.Next(16, 53).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string A = textBox4.Text.Replace("B", "");
            double p = 1;
            if (dicr.ContainsKey(A.Last().ToString()))
            {
                p = dicr[A.Last().ToString()];
                A = A.Replace(A.Last().ToString(), "");
            }
            long a = long.Parse(A);
            long b = long.Parse(textBox5.Text.Replace("B", ""));
            long a2 = (long)(a * Math.Pow(2, p));
            long c = (a2 / b);
            int ans = 0;
            long temp = 1;
            while (temp < c)
            {
                temp *= 2;
                ans++;
            }

            textBox6.Text = ans.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            textBox1.Text = rdm.Next(16, 53).ToString();
            textBox2.Text = rdm.Next(1, 9).ToString() + "B";
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            clearB();
        }
        void clearB()
        {
            return;
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            clearB();
        }
        void clearA()
        {
            return;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            clearA();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            clearA();
        }
    }
}
