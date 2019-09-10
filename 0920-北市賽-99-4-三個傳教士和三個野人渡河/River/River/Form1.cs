using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace River
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Gogogo(3, 3, 1, 0, 0, 0, new List<string>());
        }
        bool done = false;
        List<string> Ans = new List<string>();
        //野,教,船 , 野,教,船
        void Gogogo(int W1, int M1, int B1, int W2, int M2, int B2, List<string> Path)
        {
            string NowState = $"{W1},{M1},{B1},{W2},{M2},{B2}";
            if ((M1 > 0 && W1 > M1) || (M2 > 0 && W2 > M2) ||
                 W1 < 0 || M1 < 0 || W2 < 0 || M2 < 0 ||
                 W1 > 3 || M1 > 3 || W2 > 3 || M2 > 3 ||
                 Path.Contains(NowState) || done)
            {
                return;
            }
            Path.Add(NowState);
            if (W1 == 0 && M1 == 0 && W2 == 3 && M2 == 3)
            {
                 Ans = Path;
                done = true;
                return; 
            }
            if (B1 == 1)
            {
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        if (i + j > 0 && i + j < 3)
                        {
                            Gogogo(W1 - i, M1 - j, 0, W2 + i, M2 + j, 1, new List<string>(Path));
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        if (i + j > 0 && i + j < 3)
                        {
                            Gogogo(W1 + i, M1 + j, 1, W2 - i, M2 - j, 0, new List<string>(Path));
                        }
                    }
                }
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ans = new List<string>();
            done = false;
            string[] S = textBox1.Text.Split(',');
            List<int> ass = new List<int>();
            foreach (var item in S)
            {
                ass.Add(int.Parse( item));
            }
            Gogogo(ass[0],ass[1],ass[2],ass[3],ass[4],ass[5],new List<string>());
            if (done)
            {
                textBox2.Text = "";
                foreach (var item in Ans)
                {
                    textBox2.Text += item + "\r\n";

                }
            }
            else
            {
                textBox2.Text = "不符合題意";
            }


            return;
            string Now = textBox1.Text;
            int ind = Ans.IndexOf(Now);
            if (ind<0)
            {
                textBox2.Text = "無解";
                return;
            }
            string Ansstr = "";
            for (int i = ind; i < Ans.Count; i++)
            {
                Ansstr += Ans[i] + "\r\n";
            }
            textBox2.Text = Ansstr;
        }
        
    }
}
