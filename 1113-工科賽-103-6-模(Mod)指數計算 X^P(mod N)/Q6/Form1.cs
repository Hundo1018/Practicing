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
            button1.Text = "計算";
            button2.Text = "清除";
            button3.Text = "結束";
            label1.Text = "輸入X";
            label2.Text = "輸入P";
            label3.Text = "輸入N";
            textBox1.Text = "62";
            textBox2.Text = "65";
            textBox3.Text = "133";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double X = double.Parse(textBox1.Text);
            double P = double.Parse(textBox2.Text);
            double N = double.Parse(textBox3.Text);
            BigInteger NX = BigInteger.Parse( textBox1.Text);
            int  NP = int.Parse(textBox2.Text);
            BigInteger NN = BigInteger.Parse(textBox3.Text);
            double ans = X;
            while (P > -1)
            {
                ans = (ans * ans) % N;
                P--;
            }
            ans = X * ans % N;

            label4.Text = $"餘數={ans}";
           label4.Text =  BigInteger.Remainder( BigInteger.Pow(NX, NP),NN).ToString() ;
            //label4.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label4.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
