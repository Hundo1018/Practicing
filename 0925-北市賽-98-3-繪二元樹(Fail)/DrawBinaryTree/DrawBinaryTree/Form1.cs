using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawBinaryTree
{
    class Node
    {
        public bool LB, RB;
        public Node LChild, RChild;
        public Node(bool sw)
        {
            LB = false;
            RB = false;
            if (sw)
            {
                LChild = new Node(0);
                RChild = new Node(0);
            }
        }
        public Node(int i)
        {
            LChild = new Node(false);
            RChild = new Node(false);
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "5";
            N = int.Parse(textBox1.Text);
            BTree();
            button1_Click(null, null);
        }
        void CTree(int n, int LR)
        {
            CTree(n + 1, 1);
            CTree(n + 1, 0);
        }
        void BTree()
        {
            int x = (int)(Math.Pow(2, N) - 1);
            for (int i = 0; i <= x; i++)
            {
                TL.Add(Convert.ToString(i, 2).PadLeft(N, '0'));
            }
        }
        List<string> TL = new List<string>();
        Bitmap BMP;
        Graphics G;
        Pen P;
        int N;
        private void button1_Click(object sender, EventArgs e)
        {
            BMP = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            G = Graphics.FromImage(BMP);
            P = new Pen(Color.Black, 1f);
            pictureBox1.Image = BMP;
        }
    }
}
