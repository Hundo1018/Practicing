using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "ABC";
            textBox2.ScrollBars = ScrollBars.Vertical;
        }
        List<string> Ans = new List<string>();
        string Ostr = "";
        private void button1_Click(object sender, EventArgs e)
        {
            Ans = new List<string>();
            Ostr = textBox1.Text;
            P("");
            textBox2.Text = "";
            Ans.ForEach(x => textBox2.Text += x+"\r\n");
            textBox3.Text = Get(Ostr.Length).ToString();
        }
        int Get(int i)
        {
            if (i == 0)
            {
                return 1;
            }
            return (Get(i - 1) * i);
        }
        void P(string now)
        {
            if (now.Length == Ostr.Length)
            {
                Ans.Add(now.ToString());
                return;
            }
            List<char> Posible = Ostr.ToList();
            now.ToList().ForEach(x => Posible.Remove(x));
            for (int i = 0; i < Posible.Count; i++)
            {
                P(now + Posible[i].ToString());
            }
        }
    }
}
