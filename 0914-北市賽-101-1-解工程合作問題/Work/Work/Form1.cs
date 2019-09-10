using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            work();
        }
        double N1 = 24, N2 = 6, N3 = 15, N4 = 20;
        double Af = 0, Bf = 0;//一天做多少

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            N1 = double.Parse(textBox1.Text);
            N2 = double.Parse(textBox2.Text);
            N3 = double.Parse(textBox3.Text);
            N4 = double.Parse(textBox4.Text);
            work();
        }
        double Ad, Bd;//多少天做完一個工作
        double w;//工作總量
        void work()
        {
            double max = N1 + N2 + N3 + N4;

            for (Af = 2; Af <= max; Af++)
            {
                for (Bf = 2; Bf <= max; Bf++)
                {
                    if (Af * N1 + Bf * N1 == (Af * N2 + Bf * N2) + Af * N3 + Bf * N4)
                    {
                        w = Af * N1 + Bf * N1;
                        Ad = w / Af;
                        Bd = w / Bf;
                        if ((int)Ad == Ad || (int)Bd == Bd)
                        {
                            textBox5.Text = "X=" + Ad + "\r\n" + "Y=" + Bd + "";
                            return;
                        }
                    }
                }
            }
            textBox5.Text = "無解";
        }
    }
}
