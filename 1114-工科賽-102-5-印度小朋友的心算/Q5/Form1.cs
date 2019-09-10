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
            textBox1.Text = "16";
            textBox2.Text = "17";
            textBox3.Text = "272";
            label1.Text = "被乘數m";
            label2.Text = "乘數n";
            label3.Text = "X";
            label4.Text = "=";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            button1.Text = "檢驗答案";
            button2.Text = "清除";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = textBox2.Text;
            string c = textBox3.Text;
            int t1 = int.Parse(a) + (b[1] - '0');
            int t2 = t1 * (a[0] - '0') * 10;
            int t3 = (a[1] - '0') * (b[1] - '0');
            int t4 = t2 + t3;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"(1){int.Parse(a)} + {(b[1] - '0')} = {t1}");
            sb.AppendLine($"(2){t1} X {(a[0] - '0') * 10} = {t2}");
            sb.AppendLine($"(3){(a[1] - '0')} X {(b[1] - '0')} = {t3}");
            sb.AppendLine($"(4){t2} + {t3} = {t4}");
            if (int.Parse( textBox3.Text) != t4)
            {
                label6.Text = "is wrong";
                label7.Text = sb.ToString();
                label5.Text = "";
            }
            else
            {
                label5.Text = "Very Good!";
                label6.Text = "";
                label7.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }
    }
}
