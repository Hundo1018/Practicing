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
        Dictionary<char, int> Dic_C2I = new Dictionary<char, int>();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "LEE\r\nKUHNE\r\nEBELL\r\nEBELSON\r\nSCHAEFER\r\nSCHAAK";
            string[] str = new string[7] { "AEIOUWH", "BPFV", "CSKGJQXZ", "DT", "L", "MN", "R" };
            int count = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < str[i].Length; j++)
                {
                    Dic_C2I.Add(str[i][j], count);
                }
                count++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            List<string> Names =
            textBox1.Text.Replace("\n", "").Split('\r').ToList();
            for (int i = 0; i < Names.Count; i++)
            {
                List<int> code = new List<int>();
                string temp = Names[i][0].ToString();
                code.Add((Dic_C2I[Names[i][0]]));
                for (int j = 1; j < Names[i].Length; j++)
                {
                    if (Dic_C2I[Names[i][j]] != code.Last())
                        code.Add(Dic_C2I[Names[i][j]]);
                    else
                        code.Add(0);
                }
                for (int j = 1; j < code.Count; j++)
                {
                    temp += $"{(code[j] <= 0 ? "" : code[j].ToString())}";
                }
                temp = temp.PadRight(4, '0').Substring(0,4);
                textBox2.Text += temp + "\r\n";
            }
        }
    }
}
