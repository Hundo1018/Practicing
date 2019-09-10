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
            textBox1.Text = "AAA";
        }

        string Ostr = "";
        List<string> ans = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Ostr = textBox1.Text;
            Get("");
            textBox2.Text = listBox1.Items.Count.ToString();

        }
        void Get(string s)
        {
            if (s.Length == Ostr.Length)
            {
                listBox1.Items.Add(s);
                ans.Add(s.ToString());
                return;
            }
            List<char> posiblel = new List<char>();
            posiblel = Ostr.ToList();
            s.ToList().ForEach(x => posiblel.Remove(x));
            for (int i = 0; i < posiblel.Count; i++)
            {
                Get(s + posiblel[i].ToString());
            }
        }

    }
}
