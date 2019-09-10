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
            textBox1.Text = "-161.875";
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = textBox1.Text;
            int Bound = (int)Math.Pow(2, 15);
            string[] temp2 = temp.Split('.');
            if (long.Parse(temp2[0]) > Bound)
            {
                textBox2.Text = "overflow";
                return;
            }
            string Ans1;
            if (temp2[0][0] == '-')
            {
                Ans1 = Convert.ToString(int.Parse(temp2[0].Substring(1, temp2[0].Length - 1)), 2);
            }
            else
            {
                Ans1 = Convert.ToString(int.Parse(temp2[0]), 2);
            }
            if (Ans1.Length > 15)
            {
                textBox2.Text = "overflow";
                return;
            }
          Ans1 =  Ans1.PadLeft(15, '0');
            if (temp2[0][0] == '-')
            {
                Ans1 = "1" + Ans1;
            }
            else
            {
                Ans1 = "0" + Ans1;
            }
        
 
            if (temp2.Count() > 1)
            {
                double p = 0;
                string Ans2 = "";
                double tempdouble = double.Parse(temp2[1]);
                p = Math.Pow(10, temp2[1].Length);
                for (int i = 0; i < 8; i++)
                {
                    tempdouble *= 2;
                    Ans2 += (int)(tempdouble / p);
                    tempdouble %= p;
                }
                textBox2.Text = Ans1 + "." + Ans2;
            }
            else
            {
                textBox2.Text = Ans1;
            }
        }
    }
}
