using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "請輸入有幾個矩陣相乘";
            textBox1.Text = "3";
            label2.Text = "";
        }
        List<Point> matrix = new List<Point>() { new Point(10, 100), new Point(100, 5), new Point(5, 50) };
        List<List<int>> CL = new List<List<int>>();
        List<int> Result = new List<int>();
        #region 動態生成
        bool flag = false;
        List<List<TextBox>> TBX = new List<List<TextBox>>();
        List<List<Label>> LBL = new List<List<Label>>();
        int n;
        string Ans1, Ans2;
        int dy = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                matrix = new List<Point>();
                for (int i = 0; i < n; i++)
                {
                    Point p = new Point(int.Parse(TBX[i][0].Text), int.Parse(TBX[i][1].Text));
                    matrix.Add(p);
                }
                Do();
                int Minindex = Result.FindIndex(y => y == Result.Min(x => x));
                Ans1 = "矩陣相乘的次序為：<";
                for (int i = 0; i < CL[Minindex].Count; i++)
                {
                    Ans1 += $"m{CL[Minindex][i] + 1} ";
                }
                Ans2 = $"最少的乘法運算次數：{Result[Minindex]}";
                int ndy = dy;
                ndy += 40;
                Label ans1_lbl = new Label()
                {
                    Text = $"{Ans1}>",
                    Location = new Point(22, ndy),
                    AutoSize = true
                };
                ndy += 40;
                Label ans2_lbl = new Label()
                {
                    Text = Ans2,
                    Location = new Point(22, ndy),
                    AutoSize = true
                };
                Controls.Add(ans1_lbl);
                Controls.Add(ans2_lbl);
            }
            else
            {
                TBX = new List<List<TextBox>>();
                LBL = new List<List<Label>>();
                n = int.Parse(textBox1.Text);
                label2.Text = $"請輸入m1~m{n}的矩陣大小<維度>：";
                for (int i = 0; i < n; i++)
                {
                    TBX.Add(new List<TextBox>());
                    for (int j = 0; j < 2; j++)
                    {
                        TBX[i].Add(new TextBox()
                        {
                            Size = new Size(44, 22),
                            Location = new Point(220 + j * 50, 90 + i * 30)
                        });
                        Controls.Add(TBX[i].Last());
                    }
                    LBL.Add(new List<Label>());
                    LBL[i].Add(new Label()
                    {
                        Location = new Point(22, 90 + i * 30),
                        Text = $"m{i + 1}的矩陣大小："
                    });
                    dy = 90 + i * 30;
                    Controls.Add(LBL[i].Last());
                    flag = !flag;
                }
            }
        }
        #endregion
        void Do()
        {
            GenC(new List<int>(), 3);
            //跑遍排列組合

            for (int i = 0; i < CL.Count; i++)
            {
                int sum = 0;
                Point p = matrix[CL[i][0]];//0
                for (int j = 1; j < CL[i].Count; j++)//1
                {
                    sum += p.X * matrix[CL[i][j]].X * matrix[CL[i][j]].Y;
                    p = new Point(p.X, matrix[CL[i][j]].Y);
                }
                Result.Add(sum);
            }
        }
        void GenC(List<int> now, int len)
        {
            if (now.Count == len)
            {
                CL.Add(now);
            }
            List<int> posiblelist = new List<int>();
            for (int i = 0; i < len; i++)
            {
                posiblelist.Add(i);
            }
            for (int i = 0; i < now.Count; i++)
            {
                posiblelist.Remove(now[i]);
            }
            for (int i = 0; i < posiblelist.Count; i++)
            {
                List<int> temp = new List<int>();
                now.ForEach(x => temp.Add(x));
                temp.Add(posiblelist[i]);
                GenC(temp, len);
            }
        }
    }
}
