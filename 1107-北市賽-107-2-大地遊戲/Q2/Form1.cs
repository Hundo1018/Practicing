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
            textBox1.Text = "5";
            textBox2.Text = "3";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int M = int.Parse(textBox1.Text);
            int N = int.Parse(textBox2.Text);
            List<int> people = new List<int>();
            for (int i = 1; i <= M; i++)
            {
                people.Add(i);
            }
            for (int index = 0, count = 1; people.Count > 1; index++, count++)
            {
                index %= people.Count;
                if (count == N)
                {
                    textBox3.Text += people[index].ToString() + " ";
                    people.RemoveAt(index);
                    count = 1;
                }
            }
            textBox4.Text = people[0].ToString();
        }
    }
}
