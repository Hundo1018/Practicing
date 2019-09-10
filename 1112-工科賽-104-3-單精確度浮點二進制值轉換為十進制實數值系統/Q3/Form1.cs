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
            textBox1.Text = "1";
            textBox2.Text = "10000110";
            textBox3.Text = "01000011110000000000000";
            label1.Text = "IEEE超127單精確度浮點二進制值轉換為十進制實數值系統";
            label2.Text = "IEEE Excess-127:";
            label3.Text = "Real number:";
            button1.Text = "Random";
            button2.Text = "Convert";
            button3.Text = "Exit";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            string b = Convert.ToString(rdm.Next(0, Int32.MaxValue), 2).PadLeft(32, '0');
            textBox1.Text = Convert.ToString(rdm.Next(0, 2), 2);
            textBox2.Text = Convert.ToString(rdm.Next(0, 256), 2);
            textBox3.Text = b.Substring(9, 23);
            textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string M = textBox3.Text;
            textBox4.Text = "";
            int E = (int)(Convert.ToInt32(textBox2.Text, 2) - 127);
            if (E < 0)
            {
                //for (int i = 0; i < Math.Abs(E); i++)
                //{
                //    M = M.Insert(0, "0");
                //}
            }
            M = M.Insert(0, ".");
            M = M.Insert(0, "1");
            string temp = RInt(M.Split('.')[0]) + LFloat(M.Split('.')[1]);
            double tempdouble = Convert.ToDouble(temp) * Math.Pow(2, E);
            textBox4.Text = (textBox1.Text == "1" ? "-" : "") + Math.Round( tempdouble,10).ToString();
            //textBox4.Text += RInt(M.Split('.')[0]);
            //textBox4.Text += LFloat(M.Split('.')[1]);
            //textBox4.Text = textBox4.Text.Insert(0, (textBox1.Text == "1" ? "-" : ""));
        }
        string RInt(string i)
        {
            long Rint = Convert.ToInt64(i, 2);
            return Rint.ToString();
        }
        string LFloat(string f)
        {
            double d = 0;
            for (int i = 0; i < f.Length; i++)
            {
                double po = Math.Pow(2, -(i + 1));
                d += (f[i] - '0') * po;
            }
            return d.ToString().Substring(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
