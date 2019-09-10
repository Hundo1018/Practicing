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
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    TBX[i, j] = new TextBox()
                    {
                        Location = new Point(40 + j * 47, 47 + i * 25),
                        Size = new Size(44, 22),
                        Text = "100"
                    };
                    groupBox1.Controls.Add(TBX[i, j]);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    TBX2[i, j] = new TextBox()
                    {
                        Location = new Point(40 + j * 47, 47 + i * 25),
                        Size = new Size(44, 22)
                    };
                    groupBox2.Controls.Add(TBX2[i, j]);
                }
            }

            groupBox1.Text = "1輸入資料";
            groupBox2.Text = "2權重遮罩設定";
            groupBox3.Text = "3輸入要運算的3x3區域之左上角座標";
            button1.Text = "4計算";
            groupBox4.Text = "5編碼結果";
            TBX[1, 1].Text = "55";
            TBX[1, 2].Text = "35";
            TBX[1, 3].Text = "28";
            TBX[2, 1].Text = "52";
            TBX[2, 2].Text = "43";
            TBX[2, 3].Text = "38";
            TBX[3, 1].Text = "26";
            TBX[3, 2].Text = "65";
            TBX[3, 3].Text = "45";

            TBX2[0, 0].Text = "1";
            TBX2[0, 1].Text = "2";
            TBX2[0, 2].Text = "4";
            TBX2[1, 0].Text = "8";
            TBX2[1, 1].Text = "0";
            TBX2[1, 2].Text = "6";
            TBX2[2, 0].Text = "32";
            TBX2[2, 1].Text = "64";
            TBX2[2, 2].Text = "128";

            textBox1.Text = "1";
            textBox2.Text = "1";
        }
        TextBox[,] TBX = new TextBox[6, 6];
        TextBox[,] TBX2 = new TextBox[3, 3];
        private void button1_Click(object sender, EventArgs e)
        {
            int[,] OMaxtrix = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    OMaxtrix[j, i] = int.Parse(TBX[j, i].Text);
                }
            }
            int[,] Kernal = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Kernal[j, i] = int.Parse(TBX2[j, i].Text);
                }
            }
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            int sum = 0;
            for (int i = y; i < y + 3; i++)
            {
                for (int j = x; j < x + 3; j++)
                {
                    int temp1 = (OMaxtrix[j, i] - OMaxtrix[x + 1, y + 1]);
                    int temp2 = (temp1 >= 0 ? 1 : 0);
                    int temp3 = temp2 * Kernal[j - x, i - y];
                    sum += temp3;
                }
            }
            textBox3.Text = sum.ToString();
        }
    }
}
