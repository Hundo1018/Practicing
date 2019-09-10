using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string Q = "1+2*4+2+3*2";


            Tree<string> T = new Tree<string>();
            T.node = new Node<string>("1");
            //T.node.AddParent("+",-1);
            //T.node = new Node<string>("+");
            //T.node.AddParent("+", -1);
            //T.node.Left.AddParent("+", -1);
            //T.node.Left.AddParent("2", 1);
            //T.node.Left.Left.AddParent("1", -1);
            //T.node.Left.Left.AddParent("*", 1);
            //T.node.Left.Left.Right.AddParent("2", -1);
            //T.node.Left.Left.Right.AddParent("4", 1);
            //T.node.AddParent("*", 1);
            //T.node.Right.AddParent("3", -1);
            //T.node.Right.AddParent("2", 1);

            textBox1.Text = T.ListPre();
            textBox2.Text = T.ListIn();
            textBox3.Text = T.ListPost();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    class Node<T> : List<Node<T>>
    {
        public Node<T> Parent, Left, Right;
        public T data;
        public void AddParent(T Value, int LR)
        {
            if (LR < 0)
            {
                this.Parent = new Node<T>(Value);
                this.Parent.Left = this;
            }
            else
            {
                this.Parent = new Node<T>(Value);
                this.Parent.Right = this;
            }
        }
        public Node(T d)
        {
            data = d;
        }
    }
    class Tree<T>
    {
        public Node<T> node;
        string STR = "";
        public string ListPre()
        {
            STR = "";
            Order(FindRoot(node), 0);
            return STR;
        }
        public string ListIn()
        {
            STR = "";
            Order(FindRoot(node), 1);
            return STR;
        }
        public string ListPost()
        {
            STR = "";
            Order(FindRoot(node), 2);
            return STR;
        }
        Node<T> FindRoot(Node<T> nownode)
        {
            if (nownode.Parent != null)
            {
                return FindRoot(nownode.Parent);
            }
            else
            {
                return nownode;
            }
        }
        void Order(Node<T> Nownode, int Mode)
        {
            if (Nownode == null) return;
            if (Mode == 0) STR += Nownode.data.ToString() + " ";
            if (Nownode.Left != null) Order(Nownode.Left, Mode);
            if (Mode == 1) STR += Nownode.data.ToString() + " ";
            if (Nownode.Right != null) Order(Nownode.Right, Mode);
            if (Mode == 2) STR += Nownode.data.ToString() + " ";
        }
    }
}
