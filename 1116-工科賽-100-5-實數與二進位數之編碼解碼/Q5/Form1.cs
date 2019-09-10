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
            /* 注意
             * 輸入1 有可能是十進制也可能是二進制的1
             */
            InitializeComponent();
            textBox1.Text = "-1";
            textBox2.Text = "2";
            textBox3.Text = "6";
            textBox4.Text = "1000101110110101000111";
            textBox4.Text = "0.637197";
            label1.Text = "x的範圍=";
            label2.Text = "~";
            label3.Text = "精確度小數點下幾位";
            label4.Text = "輸入時數值或二進位字串";
            button1.Text = "轉換";
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double MinBound = double.Parse(textBox1.Text);
            double MaxBound = double.Parse(textBox2.Text);
            double Round = double.Parse(textBox3.Text);
            double temp_double = (double)(Math.Pow(10, Round) * (MaxBound - MinBound));
            string temp_bits = Convert.ToString((int)temp_double, 2);
            int bit_len = temp_bits.Length;
            string input = textBox4.Text;
            bool isbits = false;
            var a = input.ToList();
            var b = a.Distinct().ToList();
            b.Remove('0');
            b.Remove('1');
            if (b.Count > 0) isbits = false;
            else isbits = true;
            if (isbits)
            {
                int Xp = Convert.ToInt32(input, 2);
                double X = MinBound + Xp * (MaxBound - MinBound) / (Math.Pow(2, bit_len) - 1);
                label5.Text = X.ToString();
            }
            else
            {
                double x = double.Parse(input);
                double x2 = ((x - MinBound) / (MaxBound - MinBound));
                double x3 = Math.Pow(2, bit_len + 1) - 1;
                double x4 = x2 * x3;
                string x5 = Convert.ToString((int)x4, 2).PadLeft(bit_len, '0');
                label5.Text = x5.ToString().Substring(0, bit_len);
            }
        }
    }
}
