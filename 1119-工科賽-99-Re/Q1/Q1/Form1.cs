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
            textBox1.Text = "0000001000000010000000001100000000000000";
            button2_Click(null, null);
            label1.Text = "0-1 Run-Length Encoding System";
            label2.Text = "Original Data:";
            label3.Text = "Compressed Data";
            label4.Text = "Compressed Rate";
            button1.Text = "Random Set";
            button2.Text = "Encoding";
            button3.Text = "Exit";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            List<string> a= new List<string>();
            a.AddRange(Enumerable.Repeat("1", 4).ToList());
            a.AddRange( Enumerable.Repeat("0", 36).ToList());

            for (int i = 0; i < a.Count; i++)
            {
                int index = rdm.Next(0, 40);
                string temp = a[i];
                a[i] = a[index];
                a[index] = temp;
            }

            string C = "";
            foreach (var item in a)
            {
                C += item.ToString();
            }
            textBox1.Text = C;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ostr = textBox1.Text;
            if (ostr.First() == '1')
            {
                ostr = ostr.Substring(1, ostr.Length - 1);
            }
            if (ostr.Last() == '1')
            {
                ostr = ostr.Substring(0, ostr.Length - 1);
            }
            string[] temp = ostr.Split('1');
            string Ans = "";
            foreach (var item in temp)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    Ans += "0";
                }
                else
                {
                    Ans += Convert.ToString(item.Length, 2);
                }
                Ans += " ";
            }
            Ans = Ans.Substring(0, Ans.Length - 1);
            textBox2.Text = Ans;
            double a = textBox1.Text.Length;
            double b = Ans.Length;
            double c = b / a * 100;
            textBox3.Text = c.ToString() + "%";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
