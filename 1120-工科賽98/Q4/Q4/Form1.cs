using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "inp.txt";
            textBox2.Text = "out.txt";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            button1.Text = "執行";
            button2.Text = "結束";
            button1_Click(null, null);
        }
        List<double> OData = new List<double>();
        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader SR = new StreamReader(textBox1.Text))
            {
                while (!SR.EndOfStream)
                {
                    string temp = SR.ReadLine();
                    OData = temp.Split(' ').ToList().ConvertAll<double>(double.Parse);
                }
            }
            for (int i = 19; i < OData.Count + 4; i++)
            {
                if (i < OData.Count)
                {
                    double temptotal5 = 0, temptotal20 = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        temptotal5 += OData[i - j];
                    }
                    for (int j = 0; j < 20; j++)
                    {
                        temptotal20 += OData[i - j];
                    }
                    temptotal5 /= 5d;
                    temptotal20 /= 20d;
                    textBox3.Text += OData[i].ToString("00.00").PadLeft(8);
                    textBox4.Text += temptotal5.ToString("00.00").PadLeft(8);
                    textBox5.Text += temptotal20.ToString("00.00").PadLeft(8);
                    textBox6.Text += (temptotal5 - temptotal20).ToString("00.00").PadLeft(8);
                }
                else
                {
                    textBox3.Text += "00.00".PadLeft(8);
                    textBox4.Text += "00.00".PadLeft(8);
                    textBox5.Text += "00.00".PadLeft(8);
                    textBox6.Text += "00.00".PadLeft(8);
                }
                textBox7.Text += ((4 * OData[i - 4] - OData[i - 19]) / 3).ToString("00.00").PadLeft(8);
            }
            using (StreamWriter SW = new StreamWriter(textBox2.Text))
            {
                for (int i = 3; i <= 7; i++)
                {
                    SW.WriteLine(Controls[$"textBox{i}"].Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
