using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOXXYourSelf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[,] buttons;
        int left = 50, top = 50, lp=50, tp=50, px=50;
        string []Player;
        int Switch = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox1.Text == textBox2.Text||(string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text)) || ((textBox1.Text.Count() != 1) && (textBox2.Text.Count() != 1)))
            {
                MessageBox.Show("雙方輸入的符號無效");
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || (textBox1.Text.Count() != 1))
                {
                    MessageBox.Show("甲方輸入的符號無效");
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox2.Text) || (textBox2.Text.Count() != 1))
                {
                    MessageBox.Show("乙方輸入的符號無效");
                    return;
                }
            }
            Player = new string[2];
            Player[0] = textBox1.Text;
            Player[1] = textBox2.Text;
            button1.Visible = false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Ge();
        }
        void Ge()
        {
            buttons = new Button[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Location = new Point(125 + j  * px + left * j,50 +  i * px + top * i);
                    buttons[i, j].Size = new Size(50, 50);
                    buttons[i, j].BackColor = Color.White;
                    buttons[i, j].MouseClick += new MouseEventHandler(BuMouseClick);
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }
        void BuMouseClick(object sender,MouseEventArgs e)
        {
            Button Bu = (Button)(sender);

            if ( (Bu.Text == Player[0] || Bu.Text == Player[1]) )
            {
                MessageBox.Show("這裡按過ㄌ!!!");
                return;
            }
            Bu.Enabled = false;
            Bu.Text = Player[Switch];
            Switch = (Switch == 0 ? 1 : 0);
            int win = Check();
            if (win == 0)//甲贏
            {
                label3.Text = "甲方獲勝";
            }
            else if(win == 1)//乙贏
            {
                label3.Text = "乙方獲勝";
            }
            else if(win == 2)//和局
            {
                label3.Text = "和局";
            }
            else//繼續
            {

            }
        }
        int Check()
        {
            for (int j = 0; j < 3; j++)
            {
                int Ac = 0, Bc = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (string.IsNullOrWhiteSpace(buttons[j, i].Text)) continue;
                    if (buttons[j, i].Text == Player[0]) Ac++;
                    if (buttons[j, i].Text == Player[1]) Bc++;
                }
                if (Ac >= 3) return 0;
                else if (Bc >= 3) return 1;
            }
            for (int j = 0; j < 3; j++)
            {
                int Ac = 0, Bc = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (string.IsNullOrWhiteSpace(buttons[i, j].Text)) continue;
                    if (buttons[i, j].Text == Player[0]) Ac++;
                    if (buttons[i, j].Text == Player[1]) Bc++;
                }
                if (Ac >= 3)return 0;
                else if (Bc >= 3)return 1;
            }
            if ((buttons[1, 1].Text == Player[0] && buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text) ||
                (buttons[1, 1].Text == Player[0] && buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 0].Text))return 0;
            else if ((buttons[1, 1].Text == Player[1] && buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text) ||
                     (buttons[1, 1].Text == Player[1] && buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 0].Text))return 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrWhiteSpace( buttons[i,j].Text))
                    {
                        return -1;
                    }
                }
            }
            return 2;
        }
    }
}
