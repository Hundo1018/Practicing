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
            this.button6.Click += new System.EventHandler(this.button6_Click);
            for (int i = 0; i < 4; i++)//粽
            {
                List<TextBox> tbl = new List<TextBox>();
                for (int j = 0; j < 4; j++)//恆
                {
                    TextBox tb = new TextBox()
                    {
                        Size = new Size(40, 22),
                        Location = new Point(57 + j * 50, 34 + i * 30),
                    };
                    tb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_MouseClick);
                    Controls.Add(tb);
                    tbl.Add(tb);
                }
                TBL.Add(tbl);
            }
            for (int i = 0; i < 4; i++)
            {
                TBL[i][i].Text = $"{i + 1}";
            }
            button3.Text = "1";
            button4.Text = "2";
            button5.Text = "3";
            button6.Text = "4";
            label1.Text = "";
            button1.Text = "產生提示";
            button2.Text = "Check";
            button1_Click(null, null);
        }
        List<List<TextBox>> TBL = new List<List<TextBox>>();
        int[,] Line = new int[4, 4];
        TextBox temp;
        private void button1_Click(object sender, EventArgs e)
        {
            Check(false);
        }
        void Check(bool flag)
        {
            FillIn();
            if (flag) label1.Text = "錯誤";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Line[i, j] != 0 && !flag) continue;
                    if (flag && Line[i, j] == 0)
                    {
                        label1.Text = "錯誤";
                        return;
                    }
                    List<int> CheckL = new List<int>() { 1, 2, 3, 4 };
                    List<int> CheckA = new List<int>() { 1, 2, 3, 4 };
                    List<int> CheckB = new List<int>() { 1, 2, 3, 4 };
                    for (int k = -4; k < 4; k++)//縱
                    {
                        if (i + k < 0) continue;
                        if (i + k > 3) continue;
                        CheckL.Remove(Line[i + k, j]);
                        CheckA.Remove(Line[i + k, j]);
                    }
                    for (int l = -4; l < 4; l++)//橫
                    {
                        if (j + l < 0) continue;
                        if (j + l > 3) continue;
                        CheckL.Remove(Line[i, j + l]);
                        CheckB.Remove(Line[i, j + l]);
                    }
                    if (flag && CheckA.Count + CheckB.Count > 0)//
                    {
                        label1.Text = "錯誤";
                        return;
                    }
                    TBL[i][j].Text = "";
                    CheckL.ForEach(x => TBL[i][j].Text += $"{x},");
                    if (!flag)
                        TBL[i][j].Text = TBL[i][j].Text.Substring(0, TBL[i][j].Text.Length - 1);
                }
            }
            if (flag) label1.Text = "正確";
        }

        void FillIn()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int res;
                    int.TryParse(TBL[i][j].Text, out res);
                    Line[i, j] = res;
                }
            }
        }


        private void tb_MouseClick(object sender, MouseEventArgs e)
        {
            temp = (TextBox)sender;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            temp.Text = "1";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temp.Text = "2";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temp.Text = "3";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            temp.Text = "4";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Check(true);
        }
    }
}
