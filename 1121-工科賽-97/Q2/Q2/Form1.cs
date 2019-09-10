using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "957442355";
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ISBN9 = textBox1.Text;
            if (Check(ISBN9))
            {
                textBox2.Text = ISBN10(ISBN9);
                textBox3.Text = ISBN13(ISBN9);
            }
            else
            {
                textBox3.Text = "輸入號碼不對";
                textBox2.Text = "輸入號碼不對";
            }
        }
        string ISBN13(string IN)
        {
            string NEW = "";
            string temp = IN.Replace("-", "");
            temp = "978" + temp;
            bool flag = true;
            int total = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                total += (temp[i] - '0') * (flag ? 1 : 3);
                flag = !flag;
            }

            int check = 10 - (total % 10);
            if (IN.Contains('-'))
            {
                return "978-" + IN + "-" + check;
            }
            else
            {
                NEW = IN + check;
                NEW = NEW.Insert(9, "-").Insert(7, "-").Insert(3, "-");
                NEW = "978-" + NEW;
                return NEW;
            }
        }
        string ISBN10(string In)
        {
            string NEW = "";
            int Step = 10;
            int S = 0;
            string temp = In.Replace("-", "");
            for (int i = 0; i < temp.Length; i++)
            {
                S += (temp[i] - '0') * Step--;
            }
            int M = S % 11;
            int N = 11 - M;
            string Check = "";
            if (N == 10)
                Check = "X";
            else if (N == 11) Check = "O";
            else Check = N.ToString();
            if (In.Contains('-'))
            {
                return In + "-" + Check;
            }
            else
            {
                NEW = In + Check;
                NEW = NEW.Insert(9, "-").Insert(7, "-").Insert(3, "-");
                return NEW;
            }
        }
        bool Check(string a)
        {

            a = a.Replace("-", "");
            if (a.Length != 9)
            {
                return false;
            }
            for (int i = 0; i <= 9; i++)
            {
                a = a.Replace($"{i}", "");
            }
            if (a.Length > 0)
            {
                return false;
            }
            return true;
        }
    }
}
