using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  1
            //ab2
            //cd3
            //654
            ASD();
        }
        bool ASD()
        {
            int Q1;
             int Q2;
             int Q3;
             int Q4;
             int Q5;
             int Q6;
            try
            {
                Q1 = int.Parse(textBox1.Text);
                Q2 = int.Parse(textBox2.Text);
                Q3 = int.Parse(textBox3.Text);
                Q4 = int.Parse(textBox4.Text);
                Q5 = int.Parse(textBox5.Text);
                Q6 = int.Parse(textBox6.Text);
            }
            catch 
            {
                label1.Text = "數字超過範圍";
                return false ;
                
            
            }
            if (Q1 < -20 || Q2 < -20 || Q3 < -20 || Q4 < -20 ||
                Q1 > 20 || Q2 > 20 || Q3 > 20 || Q4 > 20)
            {
                label1.Text = "數字超過範圍";
                return false;
            }
            for (int a = -40; a <= 40; a++)
            {
                for (int b = -40; b <= 40; b++)
                {
                    for (int c = -40; c <= 40; c++)
                    {
                        for (int d = -40; d <= 40; d++)
                        {
                            if (a + b == Q2 &&
                                c + d == Q3 &&
                                c + b == Q1 &&
                                a + d == Q4 &&
                                b + d == Q5 &&
                                a + c == Q6)
                            {
                                A_T.Text = a.ToString();
                                B_T.Text = b.ToString();
                                C_T.Text = c.ToString();
                                D_T.Text = d.ToString();
                                label1.Text = "";
                                return true;
                            }
                        }
                    }
                }
            }
            label1.Text = "無解";
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
