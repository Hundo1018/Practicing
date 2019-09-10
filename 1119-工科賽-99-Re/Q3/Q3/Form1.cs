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
            
            label1.Text = "請問要輸入的資料總共有幾筆？";
            label2.Text = "";
            textBox2.Enabled = false;
            dataGridView1.AutoSize = true;
            this.AutoSize = true;
            R(0);
            //
        }
        bool StartFlag = false;
        int N = 0;
        double n = 0;
        List<double> Data = new List<double>();
        private void button1_Click(object sender, EventArgs e)
        {
            if (!StartFlag)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("0", "資料筆數");
                dataGridView1.Columns.Add("1", "輸入資料");
                dataGridView1.Columns.Add("2", "算術平均數");
                dataGridView1.Columns.Add("3", "標準差");
                dataGridView1.Columns.Add("4", "幾何平均數");
                dataGridView1.Columns.Add("5", "均方根平均數");
                dataGridView1.Columns.Add("6", "調和平均數");
                N = int.Parse(textBox1.Text);
                Data = new List<double>();
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                label2.Text = $"請輸入第{1}筆資料";
            }
            else
            {
                Data.Add(double.Parse(textBox2.Text));
                label2.Text = $"請輸入第{Data.Count + 1}筆資料";
                n = Data.Count;
                Process();
                if (Data.Count == N)
                {
                    label2.Text = "資料已輸入完畢！";
                    textBox1.Enabled = true;
                }
            }
            StartFlag = true;
        }
        void Process()
        {
            int n = Data.Count;
            double[] Ans = new double[7];
            Ans[0] = n;
            Ans[1] = Data.Last();
            Ans[2] = Data.Average();
            Ans[3] = SD();
            Ans[4] = GM();
            Ans[5] = RMS();
            Ans[6] = HM();
            dataGridView1.Rows.Add(
                n,
                Data.Last(),
                R(Data.Average()).ToString("0.000"),
                R(SD()).ToString("0.000"),
                R(GM()).ToString("0.000"),
                R(RMS()).ToString("0.000"),
                R(HM()).ToString("0.000")
                );
        }
        double R(double a)
        {
            a= ((double)((int)(a * 1000)) / 1000);
            return a;
        }
        double SD()
        {
            double ans = 0;
            double sum1 = 0, sum2 = 0;
            foreach (var item in Data)
            {
                sum2 += (item * item);
                sum1 += item;
            }
            ans = Math.Sqrt((((n * sum2) - (sum1 * sum1)) / (n * (n - 1d))));
            if (double.IsNaN(ans))
            {
                ans = 0;
            }
            
            return ans;
        }
        double GM()
        {
            double ans = 1;
            foreach (var item in Data)
            {
                ans *= item;
            }
            ans = Math.Pow(ans, (1d / n));
            return ans;
        }
        double RMS()
        {
            double ans = 0;
            foreach (var item in Data)
            {
                ans += item * item;
            }
            ans /= n;
            ans = Math.Sqrt(ans);
            return ans;
        }
        double HM()
        {
            double ans = 0;
            foreach (var item in Data)
            {
                ans += (1d / item);
            }
            ans = n / ans;
            return ans;
        }
    }
}
