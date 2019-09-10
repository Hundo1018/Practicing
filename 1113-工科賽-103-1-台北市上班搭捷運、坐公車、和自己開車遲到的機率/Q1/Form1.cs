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
            textBox7.BackColor = Color.Black;
            textBox7.ForeColor = Color.White;
            label1.Text = "已知";
            label2.Text = "1.搭捷運上班的機率";
            label3.Text = "2.坐公車上班的機率";
            label4.Text = "3.自己開車上班的機率";
            label5.Text = "X+Y+Z=1";
            label6.Text = "4.搭捷運遲到的機率";
            label7.Text = "5.坐公車遲到的機率";
            label8.Text = "6.開車遲到的機率";
            label9.Text = "求解";
            label10.Text = "(1)在台北市的上班族遲到的機率是多少?";
            label11.Text = "(2)如果已知有一個人上班遲到，那他是自己開車的機率為何?";
            label12.Text = "x(0≦x≦1)";
            label13.Text = "y(0≦y≦1)";
            label14.Text = "z(0≦z≦1)";
            label15.Text = "a(0≦a≦1)";
            label16.Text = "b(0≦b≦1)";
            label17.Text = "c(0≦c≦1)";
            label18.Text = "答案";
            button1.Text = "第一題";
            button2.Text = "第二題";
            button3.Text = "離開";
            textBox1.Text = "0.7";
            textBox2.Text = "0.2";
            textBox3.Text = "0.1";
            textBox4.Text = "0.02";
            textBox5.Text = "0.06";
            textBox6.Text = "0.15";
        }

        double x, y, z, a, b, c;

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!read()) return;
            textBox7.Text = $"如果已知有一個人上班遲到，那他是自己開車的機率為何:{c * z / (a * x + b * y + c * z)}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!read()) return;
            textBox7.Text = $"在台北市的上班族遲到的機率為:{a * x + b * y + c * z}";
        }
        bool read()
        {
            x = double.Parse(textBox1.Text);
            y = double.Parse(textBox2.Text);
            z = double.Parse(textBox3.Text);
            a = double.Parse(textBox4.Text);
            b = double.Parse(textBox5.Text);
            c = double.Parse(textBox6.Text);
            if (x + y + z > 1 ||
                x > 1 || y > 1 || z > 1 ||
                x < 0 || y < 0 || z < 0 ||
                a > 1 || b > 1 || c > 1 ||
                a < 0 || b < 0 || c < 0)
            {
                textBox7.Text = "無解";
                return false;
            }
            return true;
        }
    }
}
