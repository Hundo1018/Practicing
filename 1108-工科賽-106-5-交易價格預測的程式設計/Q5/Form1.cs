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

            for (int i = 1; i <= 15; i++)
            {
                textBox1.Text += i.ToString().PadRight(6);
            }
            textBox2.Text =
                "25.0  27.0  29.0  32.0  35.0  34.0  31.0  33.0  32.0  31.0  29.0  28.0  30.0  33.0  32.0  ";
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            List<string> tempa = textBox1.Text.Split(' ').ToList();
            tempa.RemoveAll(x => string.IsNullOrWhiteSpace(x));

            List<string> tempb = textBox2.Text.Split(' ').ToList();
            tempb.RemoveAll(x => string.IsNullOrWhiteSpace(x));

            List<double> X = tempa.ConvertAll<double>(double.Parse);
            List<double> Y = tempb.ConvertAll<double>(double.Parse);
            double Xave = 0, Yave = 0; ;
            List<double> bl = new List<double>();
            List<double> pl = new List<double>();
            for (int i = 0; i < X.Count; i++)
            {
                double b = 0;
                double a = 0;
                if (i >= 9)
                {
                    List<double> tempx = new List<double>();
                    List<double> tempy = new List<double>();
                    for (int j = i - 9; j <= i; j++)
                    {
                        tempx.Add(X[j]);
                        tempy.Add(Y[j]);
                    }

                    Xave = ave(tempx);
                    Yave = ave(tempy);
                    b = getb(tempx, Xave, tempy, Yave);
                    a = Yave - b * Xave;



                }
                if (i != X.Count - 1)
                {
                    double y = a + b * X[i + 1];
                    pl.Add(y);
                    textBox4.Text += pl.Last().ToString("0.0").PadRight(6);
                }
                bl.Add(b);
                textBox3.Text += bl.Last().ToString("0.0").PadRight(6);
            }

        }
        double getb(List<double> xl, double xa, List<double> yl, double ya)
        {
            double b = 0, t = 0;
            for (int i = 0; i < xl.Count; i++)
            {
                t += ((xl[i] - xa) * (yl[i] - ya));
                b += Math.Pow((xl[i] - xa), 2);
            }
            return (t / b);
        }
        double ave(List<double>i)
        {
            return (i.Sum(x => x) / i.Count);
        }
    }
}
