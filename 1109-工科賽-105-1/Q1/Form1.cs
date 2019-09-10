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
            char a = 'A';
            for (int i = 0; i <= 9; i++)
            {
                Dic.Add(i, $"{i}");
            }
            for (int i = 10; i <= 20; i++)
            {
                Dic.Add(i, char.ConvertFromUtf32(55 + i));
            }

            textBox1.Text = "25";
            textBox2.Text = "-2";
            button1_Click(null, null);
        }
        Dictionary<double, string> Dic = new Dictionary<double, string>();
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            List<string> ans = new List<string>();
            double Ten = double.Parse(textBox1.Text);
            double baseV = double.Parse(textBox2.Text);
            while (Ten != 0)
            {
                double temp = Math.Floor(Ten / baseV);
                if (temp * baseV > Ten) temp++;
                double temp2 = Math.Abs(Math.Abs(Ten) - Math.Abs(baseV * temp));
                ans.Add(Dic[temp2]);
                Ten = temp;
            }
            ans.Reverse();
            foreach (var item in ans)
            {
                textBox3.Text += item;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
    }
}
