using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "9";
            button1.Text = "執行";
            button2.Text = "正向";
            button3.Text = "垂直反轉";
            button4.Text = "設為中空";
            button5.Text = "清除畫面";
            button6.Text = "離開";
            label1.Text = "";
            button1_Click(null, null);
        }
        bool F = false, MidEmpty = false;
        StringBuilder SB = new StringBuilder();

        private void button2_Click(object sender, EventArgs e)
        {
            F = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            F = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MidEmpty = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            F = false;
            MidEmpty = false;
            label1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SB = new StringBuilder();
            int N = int.Parse(textBox1.Text);
            SB.AppendLine("");
            SB.AppendLine($"數值                      {N}");
            SB.AppendLine($"顯示方向：{(F ? "垂直反轉" : "正向")}");
            if (MidEmpty)
            {
                SB.AppendLine("設為中空");
            }
            StringBuilder NSB = new StringBuilder();
            int H = (N - 1) / 2;
            for (int i = 0; i <= H; i++)
            {
                for (int j = 0; j < H - (i - 1); j++)
                {
                    NSB.Append("　");
                }
                NSB.Append("＊");
                for (int j = 0; j < (i - 1) * 2 + 1; j++)
                {
                    if (i == H) NSB.Append("＊");
                    else
                    {
                        if (MidEmpty) NSB.Append("　");
                        else NSB.Append("＊");
                    }
                }
                if (i != 0) NSB.Append("＊");
                for (int j = 0; j < H - (i - 1); j++)
                {
                    NSB.Append("　");
                }
                if (F) NSB.Append("\n\r");
                else NSB.Append("\r\n");
            }
            if (F)
            {
                for (int i = NSB.Length - 1; i >= 0; i--)
                {
                    SB.Append(NSB[i]);
                }
            }
            else
            {
                SB.Append(NSB.ToString());
            }
            label1.Text += SB.ToString();
        }
    }
}
