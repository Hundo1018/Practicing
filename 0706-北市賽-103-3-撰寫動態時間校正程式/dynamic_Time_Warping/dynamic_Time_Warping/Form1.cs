using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dynamic_Time_Warping
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();
        
        private void button1_Click(object sender, EventArgs e)
        {
            List<int> A = new List<int>();
            List<int> B = new List<int>();
            List<List<int>> C = new List<List<int>>();
            A = new List<int>();
            B = new List<int>();
            A = textBox1.Text.Split(',').ToList().FindAll(x => x != "").ConvertAll<int>(int.Parse).ToList();
            B = textBox2.Text.Split(',').ToList().FindAll(x => x != "").ConvertAll<int>(int.Parse).ToList();
            C = new List<List<int>>();
            textBox3.Text += 0.ToString().PadLeft(3, ' ') + "\r\r\r\r";
            foreach (var item in A)
            {
                textBox3.Text += item.ToString().PadLeft(3, ' ').PadRight(3, ' ') + "\r\r\r\r";
            }
            textBox3.Text += "\r\n";
            for (int i = 0; i < B.Count; i++)//縱向尋訪
            {
                textBox3.Text += B[i].ToString().PadLeft(3, ' ').PadRight(3, ' ') + "\r\r\r\r";
                List<int> templist = new List<int>();
                for (int j = 0; j < A.Count; j++)//橫向尋訪
                {
                    int tempa = Math.Abs(A[j] - B[i]);
                    if (i == 0 && j == 0)//左上:=自己
                    {
                        templist.Add(tempa);
                    }
                    else if (i == 0 && j != 0)//中上:=自己+左
                    {
                        templist.Add(tempa + templist[j - 1]);
                    }
                    else if (i != 0 && j == 0)//左中側:=自己+上
                    {
                        templist.Add(tempa + C[i - 1][j]);
                    }
                    else//內部:=自己+min{左 上 左上}
                    {
                        templist.Add(tempa + (Math.Min(Math.Min((templist[j - 1]), (C[i - 1][j])), (C[i - 1][j - 1]))));
                    }
                }
                foreach (var item in templist)
                {
                    textBox3.Text += item.ToString().PadLeft(3, ' ').PadRight(3, ' ') + "\r\r\r\r";
                }
                textBox3.Text += "\r\n";
                C.Add(templist);
            }
        }
    }
}
