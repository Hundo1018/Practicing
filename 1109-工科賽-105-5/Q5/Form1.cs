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
            button1.Text = "Random set";
            button2.Text = "Encoding";
            button3.Text = "Exit";
            for (int i = 97; i < 97 + 26; i++)
            {
                abc[i - 97] = (char)i;
            }
        }
        char[] abc = new char[26];
        private void button1_Click(object sender, EventArgs e)
        {
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < 26; i++)
            {
                int index = rdm.Next(0, 26);
                char tempchar = abc[i];
                abc[i] = abc[index];
                abc[index] = tempchar;
            }
            textBox1.Text = abc[0].ToString();
            textBox2.Text = abc[1].ToString();
            textBox3.Text = abc[2].ToString();
            textBox4.Text = abc[3].ToString();
            int[] num = new int[1000];
            for (int i = 0; i < 1000; i++) num[i]=i;
            for (int i = 0; i <= 999; i++)
            {
                int index = rdm.Next(0, 1000);
                int tempint = num[i];
                num[i] = num[index];
                num[index] = tempint;
            }
            textBox5.Text = num[0].ToString();
            textBox6.Text = num[1].ToString();
            textBox7.Text = num[2].ToString();
            textBox8.Text = num[3].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> numlist = new List<int>();
            numlist.Add(int.Parse(textBox5.Text));
            numlist.Add(int.Parse(textBox6.Text));
            numlist.Add(int.Parse(textBox7.Text));
            numlist.Add(int.Parse(textBox8.Text));
            double total1 = numlist.Sum();
            textBox9.Text = total1.ToString();
            double total2 = 0;
            numlist = numlist.OrderBy(x => x).ToList();
            total2 += numlist[0] * 3;
            total2 += numlist[1] * 3;
            total2 += numlist[2] * 2;
            total2 += numlist[3] * 1;
            textBox10.Text = total2.ToString();
            textBox11.Text = Math.Round((total2 / total1), 4).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
