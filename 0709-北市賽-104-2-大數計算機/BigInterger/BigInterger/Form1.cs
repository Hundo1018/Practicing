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

namespace BigInterger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// +
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            BigInteger A = BigInteger.Parse( textBox1.Text), B = BigInteger.Parse(textBox2.Text);
            textBox3.Text = A + B + "";
        }
        /// <summary>
        /// -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            BigInteger A = BigInteger.Parse(textBox1.Text), B = BigInteger.Parse(textBox2.Text);
            textBox3.Text = A - B + "";
        }
        /// <summary>
        /// *
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            BigInteger A = BigInteger.Parse(textBox1.Text), B = BigInteger.Parse(textBox2.Text);
            textBox3.Text = A * B + "";
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            BigInteger A = BigInteger.Parse(textBox1.Text), B = BigInteger.Parse(textBox2.Text);
            textBox3.Text = A / B + "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
