using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TowersOfHanoi
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();
        private void Form1_Shown(object sender, EventArgs e)
        {

        }
        List<Stack<int>> vs = new List<Stack<int>>();
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            int n=int.Parse(textBox1.Text);
            Stack<int> temp = new Stack<int>();
            for (int i = n; i>0; i--)
            {
                temp.Push(i);
            }
            vs.Add(temp);
            vs.Add(new Stack<int>());
            vs.Add(new Stack<int>());
            Hanoi(n,"A","B","C");
        }
        void Hanoi(int n, string A, string B, string C)
        {

            if (n == 1)
            {
                textBox2.Text += A + C + "\r\n";
            }
            else
            {
                Hanoi(n - 1, A, C, B);
                Hanoi(1, A, B, C);
                Hanoi(n - 1, B, A, C);
            }
        }

    }
}

