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

            Tree<string> T = new Tree<string>();
            T.node = new Node<string>("+");
            T.node.AddChild("+", -1);
            T.node.Left.AddChild("+", -1);
            T.node.Left.AddChild("2", 1);
            T.node.Left.Left.AddChild("1", -1);
            T.node.Left.Left.AddChild("*", 1);
            T.node.Left.Left.Right.AddChild("2", -1);
            T.node.Left.Left.Right.AddChild("4", 1);
            T.node.AddChild("*", 1);
            T.node.Right.AddChild("3", -1);
            T.node.Right.AddChild("2", 1);

            textBox1.Text = T.ListPre();
            textBox2.Text = T.ListIn();
            textBox3.Text = T.ListPost();
        }
    }
    class Node<T> : List<Node<T>>
    {
        public Node<T> Parent, Left, Right;
        public T data;
        public void AddChild(T Value, int LR)
        {
            if (LR < 0)
            {
                this.Left = new Node<T>(Value);
                this.Left.Parent = this;
            }
            else
            {
                this.Right = new Node<T>(Value);
                this.Right.Parent = this;
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
            Order(node, 0);
            return STR;
        }
        public string ListIn()
        {
            STR = "";
            Order(node, 1);
            return STR;
        }
        public string ListPost()
        {
            STR = "";
            Order(node, 2);
            return STR;
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
