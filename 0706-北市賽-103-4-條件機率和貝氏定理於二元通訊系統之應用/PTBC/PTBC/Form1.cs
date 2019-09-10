using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTBC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double x,b,y,z;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Pre())
            {
                textBox5.Text = "通道輸出為1的機率為："+ ((x * y) + b * (1 - z));
                return;
            }
            else
            {
                textBox5.Text = "無解";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Pre())
            {
                textBox5.Text = "假設我們已經觀察到通道輸出為1，這時候通道輸入為1的機率為何:"+ ((1-x)*(1-z))/(x*y + (1-x)*(1-z));//ans = 0.962264
                return;
            }
            else
            {
                textBox5.Text = "無解";
            }
        }
        bool Pre()
        {
            x = double.Parse(textBox1.Text);
            b = double.Parse(textBox2.Text);
            y = double.Parse(textBox3.Text);
            z = double.Parse(textBox4.Text);
            if (x > 1 || b > 1 || y > 1 || z > 1 || !(b == (1-x)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
