using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "10.168.137.64/26";
            label1.Text = "輸入的IP位址：";
            label2.Text = "網路位址：";
            label3.Text = "廣播位址：";
            label4.Text = "該網路的可用IP數：";
            button1.Text = "計算網路位址、廣播位址、該網路的可用IP數";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip = textBox1.Text;
            int n = int.Parse(ip.Split('/').Last());
            int CanUse = (int)Math.Pow(2, 32 - n) - 2;
            textBox4.Text = CanUse.ToString();
            string[] nipa = ip.Split('/')[0].Split('.');
            string nstr = "";
            foreach (var item in nipa)
            {
                nstr += Convert.ToString(int.Parse(item), 2).PadLeft(8, '0');
            }
            string nnstr = "";
            for (int i = 0; i < nstr.Length; i++)
            {
                if (i > n - 1)
                {
                    nnstr += "0";
                }
                else
                {
                    nnstr += nstr[i].ToString();
                }
            }
            int count = 0;
            string temp = "";
            List<int> net = new List<int>();
            for (int i = 0; i < nnstr.Length; i++)
            {
                count++;
                temp += nnstr[i].ToString();
                if (count == 8)
                {
                    int t = Convert.ToInt32(temp, 2);
                    net.Add(t);
                    textBox2.Text += t.ToString() + ".";
                    temp = "";
                    count = 0;
                }
            }
            int temp_i = (32 - n);
            temp = "";
            count = 0;
            List<int> mask = new List<int>();
            for (int i = 0; i < 32; i++)
            {
                count++;
                if (i >= 32 - temp_i)
                {
                    temp += "1";
                }
                else
                {
                    temp += "0";
                }
                if (count == 8)
                {
                    mask.Add(Convert.ToInt32(temp, 2));
                    count = 0;
                    temp = "";
                }
            }
            List<int> Broadcast = new List<int>();
            for (int i = 0; i < mask.Count; i++)
            {
                Broadcast.Add(mask[i] + net[i]);
                textBox3.Text += Broadcast.Last() + ".";
            }
            textBox3.Text = textBox3.Text.Substring(0, textBox3.Text.Length - 1);
            textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);

        }
    }
}
