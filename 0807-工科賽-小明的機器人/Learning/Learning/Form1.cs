using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //button1_Click(null, null);
        }
        List<Tran> T;
        List<double> FirstW;
        List<List<double>>Ww;
        int Times, timescount = 0;
        double L;
        int Count;
        double E = 0;
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        void SetTest()
        {
            Ww = new List<List<double>>();

            Tran Temp = new Tran();
            Temp.Add(new double[] { 1, 0, 1 }, -1);
            T.Add(Temp);


            Temp = new Tran();
            Temp.Add(new double[] { 0, -1, -1 }, 1);
            T.Add(Temp);


            Temp = new Tran();
            Temp.Add(new double[] { -1, -0.5, -1 }, 1);
            T.Add(Temp);


            FirstW = new List<double>();
            FirstW.AddRange(new double[] { 1, -1, 0 });
            Ww.Add(FirstW);

            Times = 9999;
            L = 0.1d;
            Count = T.Count;
        }
        void Inputdata()
        {
            Ww = new List<List<double>>();
            T = new List<Tran>();
            for (int i = 0; i < textBox1.Lines.Count(); i++)
            {
                Tran Temp = new Tran();
                double[] dd = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    dd[j] = double.Parse(textBox1.Lines[i].Split(';')[j]);
                }
                Temp.Add(dd, double.Parse(textBox2.Lines[i]));
                T.Add(Temp);
            }
            int z = 0;
            ++z;
            z++;
            z = z;
            FirstW = new List<double>();
            // double.Parse( textBox3.Text.Split(';'));
            FirstW.AddRange(new double[] { 1, -1, 0 });
            Ww.Add(FirstW);

            Times = int.Parse(textBox4.Text);
            L = double.Parse(textBox5.Text);
            Count = T.Count;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Inputdata();
            T = new List<Tran>();
            SetTest();
            int K = 0;
            E = 0;
            while (K < Count)
            {
                timescount++;
                double f;

                f = F(Ww[timescount - 1], T[K].XTrans);

                double O = (f >= 0 ? 1 : -1);
                if (O != T[K].Y)
                {
                    List<double> temp = new List<double>();
                    for (int i = 0; i < FirstW.Count; i++)
                    {
                        temp.Add(Ww[timescount - 1][i] + L * (T[K].Y - O) * T[K].XTrans[i]);
                    }
                    Ww.Add(temp);
                }
                else
                {
                    List<double> temp = new List<double>();
                    for (int i = 0; i < FirstW.Count; i++)
                    {
                        temp.Add(Ww[timescount - 1][i]);
                    }
                    Ww.Add(temp);
                }
                E = E + 0.5 * Math.Pow(Math.Abs(T[K].Y - O), 2);
                if (timescount == Times) break;
                if (K == Count - 1)
                {
                    if (E == 0) break;
                    E = 0;
                    K = 0;
                }
                else
                {
                    K++;
                }
            }
            textBox7.Text = Ww.Last()[0].ToString() + ";" + Ww.Last()[1].ToString() + ";" + Ww.Last()[2].ToString() ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double D1 = double.Parse(textBox6.Text.Split(';')[0]);
            double D2 = double.Parse(textBox6.Text.Split(';')[1]);
            double D3 = double.Parse(textBox6.Text.Split(';')[2]);

            double f = Ww.Last()[0] * D1 + Ww.Last()[1] * D2 + Ww.Last()[2] * D3;
            label6.Text = "機器人向:";
            if (f < 0) label6.Text += "右";
            else if (f > 0) label6.Text += "左";
            else label6.Text += "中";
        }

        double F(List<double> w0, List<double> X1)
        {
            double temp = 0;
            for (int i = 0; i < X1.Count; i++)
            {
                temp += w0[i] * X1[i];
            }
            return temp;
        }
    }
    class Tran
    {
        public List<double> XTrans = new List<double>();
        public double Y;
        public List<double> W = new List<double>();
        public Tran()
        {
            XTrans = new List<double>();
            W = new List<double>();
        }
        public void Add(double[] InX, double InY)
        {
            foreach (var item in InX)
            {
                XTrans.Add(item);
            }
            Y = InY;
        }

        public void AddW(double InW)
        {
            W.Add(InW);
        }
        public void SetW(int ind, double Inw)
        {
            W[ind] = Inw;
        }
    }

}
