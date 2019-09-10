using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1_Click(null, null);
            this.Focus();
        }
        string path = "input1.txt";
        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        bool flag = true;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            sb = new StringBuilder();
            sb2 = new StringBuilder();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) path = ofd.FileName;
            else return;
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                sb.Append(sr.ReadToEnd());
            }
            string temp = "";
            sb.Insert(0, " ");
            bool start = false;
            for (int i = sb.ToString().Length - 1; i >= 0; i--)
            {
                string tempch = sb.ToString()[i].ToString();
                if (!start && tempch == "?") continue;
                start = true;
                temp += tempch;
                if (tempch == "：") flag = true;
                if ((flag && tempch == " "))
                {
                    flag = false;
                    cutstr(temp);
                    temp = "";
                }
            }
            textBox1.Text = sb2.ToString();
        }
        void cutstr(string temp)
        {
            temp = ProcessExtention(temp);
            string ntemp = "";
            for (int j = temp.Length - 2; j >= 0; j--)
                ntemp += temp[j].ToString();
            sb2.Insert(0, ntemp + "\r\n");
        }
        string ProcessExtention(string str)
        {
            if (str.Contains("課"))
            {
                int indexL = -1, indexR = -1;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ')') indexL = i;
                    if (str[i] == '(') indexR = i;
                    if (indexL != -1 && indexR != -1) break;
                }
                str = str.Remove(indexR, 1);
                str = str.Remove(indexL, 1);
                str = str.Insert(indexR - 1, "\n\r");
            }
            if (str.Contains("學")) str = str.Replace("/", "\n\r");
            return str.Replace("：：", "：");
        }
    }
}
