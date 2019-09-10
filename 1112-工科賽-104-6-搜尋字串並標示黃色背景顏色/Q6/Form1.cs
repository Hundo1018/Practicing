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
using System.Threading;
namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = "請輸入欲搜尋的字串";
            label3.Text = "";
            button2.Text = "開啟文字檔顯示在下面方塊中";
            button1.Text = "搜尋";
            textBox1.Text = "資訊安全";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            using (StreamReader sr = new StreamReader(ofd.FileName, Encoding.Default))
            {
                richTextBox1.Text = sr.ReadToEnd();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;
            List<char> Searchstr = textBox1.Text.ToList();
            if (Searchstr.Count == 0)
            {
                MessageBox.Show("未輸入欲搜尋的字串");
                return;
            }
            int charcount = 0, stringcount = 0, index = -1;
            for (int i = 0; i < richTextBox1.Text.Length; i++)
            {
                if (richTextBox1.Text[i] == Searchstr[0]) index = i;
                if (richTextBox1.Text[i] == Searchstr[charcount++])
                {
                    if (charcount == Searchstr.Count)
                    {
                        charcount = 0;
                        richTextBox1.Select(index, Searchstr.Count);
                        richTextBox1.SelectionBackColor = Color.Yellow;
                        stringcount++;
                    }
                }
                else charcount = 0;
            }
            label3.Text = $"找到的個數\r\n{stringcount}";
        }
    }
}
