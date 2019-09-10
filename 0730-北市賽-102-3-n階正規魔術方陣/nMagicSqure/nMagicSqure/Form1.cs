using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nMagicSqure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //button1_Click(null, null);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //58,58 22*22
            int N = int.Parse(textBox1.Text);
            if (N % 2 == 0 || N < 3)
            {
                textBox2.Text = "錯誤";
                return;
            }
            int?[,] Sq = new int?[N, N];
            TextBox[,] TB = new TextBox[N,N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    TB[i, j] = new TextBox();
                    TB[i, j].Size = new Size(22,22);
                    TB[i, j].Location = new Point(58+j*22,58+i*22);

                    this.Controls.Add(TB[i, j]);
                }
            }


            int Cou = 2;
            int X = N / 2;
            int Y = 0;
            bool KeepDo = true;
            Sq[Y, X] = 1;
            while (KeepDo)
            {
                int OX = X, OY = Y;
                if (X - 1 < 0)
                {
                    X = N - 1;
                }
                else
                {
                    X = X - 1;
                }
                if (Y - 1 < 0)
                {
                    Y = N - 1;
                }
                else
                {
                    Y = Y - 1;
                }
                if (Sq[Y, X] is null)//空可放
                {
                    Sq[Y, X] = Cou;
                }
                else //不空
                {
                    Y = OY+1;
                    X = OX;
                    Sq[Y, X] = Cou;
                    
                }
                    Cou++;

                KeepDo = false;
                foreach (var item in Sq)if (item is null) KeepDo = true;
            }
            Application.DoEvents();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    TB[i, j].Text = Sq[i, j].ToString();
                }
            }
        }
    }
}
