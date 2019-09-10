using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "01001010";
            textBox2.Text = "11001010";
            button2_Click(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string astr = textBox1.Text;
            string bstr = textBox2.Text;
            char asign = astr[0], bsign = bstr[0];
            string nastr = astr.Substring(1);
            string nbstr = bstr.Substring(1);
            int aint = Convert.ToInt32(nastr, 2);
            int bint = Convert.ToInt32(nbstr, 2);
            aint = aint - (asign == '1' ? 128 : 0);
            bint = bint - (bsign == '1' ? 128 : 0);
            int realans = aint + bint;
            textBox5.Text = aint.ToString();
            textBox6.Text = bint.ToString();
            textBox7.Text = "";
            label1.Text = realans.ToString();
            List<int> asl = astr.Reverse().ToList().ConvertAll<string>(Convert.ToString).ConvertAll<int>(int.Parse).ToList();
            List<int> bsl = bstr.Reverse().ToList().ConvertAll<string>(Convert.ToString).ConvertAll<int>(int.Parse).ToList();
            int c = 0;
            List<int> csl = new List<int>();
            while (csl.Count < asl.Count) csl.Add(0);
            for (int i = 0; i < asl.Count; i++)
            {
                csl[i] += asl[i] + bsl[i] + c;
                c = csl[i] / 2;
                csl[i] %= 2;
            }
            csl.Add(c);
            csl.Reverse();
            string temp = "";
            textBox3.Text = "";
            csl.ForEach(x => temp += x.ToString());
            textBox3.Text = temp.Substring(temp.Length - 8);
            textBox7.Text = Convert.ToInt32(textBox3.Text, 2).ToString();
            if (realans < -128)
            {
                textBox8.Text = "不足位";
                textBox4.Text = "underflow";
            }
            if (realans > 127)
            {
                textBox8.Text = "溢位";
                textBox4.Text = "overflow";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
