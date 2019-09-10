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

namespace TotalA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] D = new int[5, 5];
            int[,] S = new int[6, 6] {
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 }
            };
            using (StreamReader sr = new StreamReader("Test.txt"))
            {
                for (int i = 0; i < 5; i++)
                {
                    string[] temp =  sr.ReadLine().Split(',');
                    for (int j = 0; j < 5; j++)
                    {
                        D[i, j] = int.Parse(temp[j]);
                    }
                }
            }

            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    S[i, j] = D[i - 1, j - 1] + S[i - 1, j] + S[i, j - 1] - S[i - 1, j - 1];
                }
            }

            StringBuilder SB1 = new StringBuilder();
            StringBuilder SB2 = new StringBuilder();
            int gap = -(8 + 2),len= 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i < 5 && j < 5)
                    {
                        len = D[i, j].ToString().Length;
                        SB1.AppendFormat("{0,"+(gap+len)+"}",D[i,j]);
                    }
                    len = S[i, j].ToString().Length;
                    SB2.AppendFormat("{0,"+(gap+len)+"}",S[i,j]);
                }
                SB1.Append("\r\n\r\n");
                SB2.Append("\r\n\r\n");
            }
            textBox1.Text = SB1.ToString();
            textBox2.Text = SB2.ToString();
        }
    }
}
