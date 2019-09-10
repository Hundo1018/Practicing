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
            textBox1.Text = "19.561";
            button2_Click(null, null);
            button1.Text = "Random";
            button2.Text = "Covnert";
            button3.Text = "Exit";
            label1.Text = "Real value";
            label2.Text = "Binary value";
            label3.Text = "Final Binary value";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            string[] temp = double.Parse(textBox1.Text).ToString().Split('.');
            string A = Convert.ToString(int.Parse(temp[0]), 2);
            if (temp.Count() == 1)
            {
                textBox2.Text = A.ToString();
                textBox3.Text = A.ToString();
                return;
            }
            string B = convert(temp[1]);
            string anstr = A + "." + B;
            textBox2.Text = anstr;
            for (int i = anstr.Length - 1; i >= 0; i--)
            {
                if (anstr[i] == '1')
                {
                    textBox3.Text = anstr.Substring(0, i + 1);
                    break;
                }
            }
        }
        
        string convert(string instr)
        {
            double Od = double.Parse($"0.{instr}");
            string ans = "";
            int count = 0;
            while (Od != 0 && count < 10)
            {
                double Nd = Od * 2;
                string[] temp = Nd.ToString().Split('.');
                ans += temp[0].ToString();
                Od = double.Parse($"0.{temp[1]}");
                count++;
            }
            return ans;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            textBox1.Text = (rdm.NextDouble() * 9999.999999d).ToString();
        }
    }
}
