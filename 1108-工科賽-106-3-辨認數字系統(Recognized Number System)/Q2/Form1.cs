using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 4; i < 4 + 7; i++)
            {
                sev[i - 4] = (Button)this.Controls[$"button{i}"];
                sev[i - 4].Click += new System.EventHandler(this.click);
            }
            DC.Add("1111110", "0");
            DC.Add("0110000", "1");
            DC.Add("0000110", "1");
            DC.Add("1101101", "2");
            DC.Add("1111001", "3");
            DC.Add("0110011", "4");
            DC.Add("1011011", "5");
            DC.Add("1011111", "6");
            DC.Add("0011111", "6");
            DC.Add("1110000", "7");
            DC.Add("1111111", "8");
            DC.Add("1111011", "9");
            DC.Add("1110011", "9");
        }
        Button[] sev = new Button[7];
        string rec = "";
        Dictionary<string, string> DC = new Dictionary<string, string>();
        private void click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor != Color.Red)
                ((Button)sender).BackColor = Color.Red;
            else ((Button)sender).BackColor = SystemColors.Control;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                Random rdm = new Random(Guid.NewGuid().GetHashCode());
                sev[i].BackColor = (rdm.Next(0, 2) == 0 ? Color.Red : SystemColors.Control);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rec = "";
            for (int i = 0; i < 7; i++)
            {
                rec += (sev[i].BackColor == Color.Red ? "1" : "0");
            }
            try
            {
                textBox1.Text = DC[rec];
            }
            catch
            {
                textBox1.Text = "非數字";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
