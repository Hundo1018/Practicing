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
            button1.Text = "Ih";
            button2.Text = "Ih";
            button3.Text = "Ih";
            button4.Text = "Ih";
            button1.Tag = 0;
            button2.Tag = 0;
            button3.Tag = 0;
            button4.Tag = 0;
            button5.Text = "Random Set";
            button6.Text = "Tansmit";
            button7.Text = "Exit";
            state.Add(0, "Ih");
            state.Add(1, "En");
            state.Add(2, "Ld");
            pictureBox1.ImageLocation = "圖片1.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        Dictionary<int, string> state = new Dictionary<int, string>();
        private void button1234_Click(object sender, EventArgs e)
        {
            Button BTM = ((Button)(sender));
            BTM.Tag = (((int)BTM.Tag + 1) % 3);
            BTM.Text = state[(int)BTM.Tag];
        }
        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 4; i++)
            {
                Controls[$"button{i}"].Tag = 0;
                Controls[$"button{i}"].Text = "Ih";
                Random rdm = new Random(Guid.NewGuid().GetHashCode());
                Controls[$"textBox{i}"].Text = Convert.ToString(rdm.Next(0, (int)(Math.Pow(2, 8))), 2).PadLeft(8, '0');
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string temp = "";
            bool OnlyFlag = false;
            for (int i = 1; i <= 4; i++)
            {
                if (!OnlyFlag && (int)Controls[$"button{i}"].Tag == 1)
                {
                    temp = Controls[$"textBox{i}"].Text;
                    OnlyFlag = true;
                }
                else if (OnlyFlag && (int)Controls[$"button{i}"].Tag == 1)
                {
                    MessageBox.Show("僅能有唯一一個En");
                    return;
                }
            }
            if (OnlyFlag)
            {
                for (int i = 1; i <= 4; i++)
                {
                    if ((int)Controls[$"button{i}"].Tag == 2)
                    {
                        Controls[$"textBox{i}"].Text = temp;
                    }
                }
            }
            else MessageBox.Show("未找到En");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
