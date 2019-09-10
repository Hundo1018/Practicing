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
namespace Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = @".\A.TXT";
            textBox2.Text = "al syst";
            button1.Text = "搜尋字串";
            button2.Text = "替換";

            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            string OSTR = "";
            using (StreamReader SR = new StreamReader(path))
            {
                OSTR = SR.ReadToEnd();
            }
            richTextBox1.Text = OSTR;
            OSTR = OSTR.Replace("\r\n", "");
            richTextBox1.Select(OSTR.IndexOf(textBox2.Text, 0), textBox2.Text.Length+1);
           
            richTextBox1.SelectionColor = Color.Red;

            if(flag)
            richTextBox1.SelectedText = ReplaceStr;

            int temp = OSTR.IndexOf(textBox2.Text, 0) +1 ;

            if (temp == 0)
            {
                textBox3.Text = $"未找到{textBox2.Text}字串";
            }
            else
            {
            textBox3.Text =  temp.ToString();
            }
        }
        bool flag = false;
        string ReplaceStr = "";
        private void button2_Click(object sender, EventArgs e)
        {
            flag = true;
            ReplaceStr =  textBox4.Text;
            button1_Click(null, null);
            flag = false;
        }
    }
}
