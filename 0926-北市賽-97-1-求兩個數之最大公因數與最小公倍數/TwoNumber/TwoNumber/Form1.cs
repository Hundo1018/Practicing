using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "100";
            textBox2.Text = "24";
            textBox3.Text = "60";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N = int.Parse(textBox1.Text);
            foreach (var item in FindZIS(N))
            {
                listBox1.Items.Add(item);
            }
        }
        List<int> FindZIS(int n)
        {
            List<int> tempL = new List<int>();
            for (int i = 2; i < n; i++)
            {
                if (IsZS(i))
                {//i是質數
                    tempL.Add(i);
                }
            }
            return tempL;
        }
        bool IsZS(int n)
        {
            for (int i = n - 1; i >= 2; i--)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        List<int>IsIS(int n)
        {
            List<int> IS = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                if (n%i==0)
                {
                    IS.Add(i);
                }
            }
            return IS;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int N1 = int.Parse(textBox2.Text);
            int N2 = int.Parse(textBox3.Text);
            bool Flag = true;
            List<int[]> LLL = new List<int[]>();
            LLL.Add(new int[3] { 0, N1, N2 });
            listBox2.Items.Add("  " + "  " + LLL.Last()[1] + "  " + LLL.Last()[2]);
            List<int> LL = new List<int>();
            while (Flag)
            {
                List<int> n1l = new List<int>(IsIS(N1));
                List<int> n2l = new List<int>(IsIS(N2));
                bool Cont = false;
                foreach (var item in n1l)
                {
                    if (Cont) break;
                    if (n2l.Contains(item))
                    {
                        LL.Add(item);
                        Cont = true;
                        N1 /= item;
                        N2 /= item;
                        LLL.Add(new int[3] { item, N1, N2 });
                        listBox2.Items.Add("------------");
                        listBox2.Items.Add(LLL.Last()[0] + "  " + LLL.Last()[1] + "  " + LLL.Last()[2]);
                        break;
                    }
                }
                if (Cont) continue;
                else break;
            }
            int Min = 1;
            foreach (var item in LL)
            {
                Min *= item;
            }
            int Max = Min * N1 * N2;
            label2.Text = "最大公因數:" + Min + "\r\n" + "最小公倍數:" + Max + "\r\n";
        }
    }
}
