using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i <= 9; i++)
            {
                Controls[$"button{i}"].Text = i.ToString();
            }
            textBox1.TextAlign = HorizontalAlignment.Right;
            button10.Text = "0";
            button11.Text = "+";
            button12.Text = "-";
            button13.Text = "*";
            button14.Text = "/";
            button15.Text = "Log";
            button16.Text = "+/-";
            button17.Text = ".";
            button18.Text = "AC";
        }
        double A, B;

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        bool flagA = true;
        int sign = 0;
        void In(bool s)
        {
            if (s) A = double.Parse(textBox1.Text);
            else B = double.Parse(textBox1.Text);
            textBox1.Text = "";
        }
        private void button11_Click(object sender, EventArgs e)
        {
            In(true);
            sign = 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            In(true);
            sign = 2;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            In(true);
            sign = 3;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            In(true);
            sign = 4;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            In(false);
            switch (sign)
            {
                case 0:
                    A = double.Parse( textBox1.Text);
                    break;
                case 1:
                    A = A + B;
                    break;
                case 2:
                    A = A - B;
                    break;
                case 3:
                    A = A * B;
                    break;
                case 4:
                    A = A / B;
                    break;
                default:
                    break;
            }
            textBox1.Text = A.ToString();
        }

        void button_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            string str = btn.Text;
            if (str == "0" && textBox1.Text.Length > 0)
                if (textBox1.Text[0] == '0')
                    return;
            if (str == "." && textBox1.Text.Contains('.'))
            {
                return;
            }
            if (str == "+/-")
            {
                if (textBox1.Text.Length > 0)
                {

                    if (textBox1.Text[0] == '-')
                    {
                        textBox1.Text = textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                    }
                    else
                    {
                        textBox1.Text = str + textBox1.Text;
                    }
                }
                else
                {
                    textBox1.Text = "-0";
                }
            }
            else
            {
                textBox1.Text = textBox1.Text + str;
            }
        }



        private void button18_Click(object sender, EventArgs e)
        {
            A = 0;
            B = 0;
            textBox1.Text = "0";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            A = double.Parse(textBox1.Text);
            A = Math.Log10(A);
            textBox1.Text = A.ToString();
        }

    }
    class BigDe
    {

    }
}
