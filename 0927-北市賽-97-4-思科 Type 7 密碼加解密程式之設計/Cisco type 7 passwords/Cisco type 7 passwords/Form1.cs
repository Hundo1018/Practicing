using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cisco_type_7_passwords
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            Seed.Add(Convert.ToInt32("0x64", 16));
            Seed.Add(Convert.ToInt32("0x73", 16));
            Seed.Add(Convert.ToInt32("0x66", 16));
            Seed.Add(Convert.ToInt32("0x64", 16));
            Seed.Add(Convert.ToInt32("0x3b", 16));
            Seed.Add(Convert.ToInt32("0x6b", 16));
            Seed.Add(Convert.ToInt32("0x66", 16));
            Seed.Add(Convert.ToInt32("0x6f", 16));
            Seed.Add(Convert.ToInt32("0x41", 16));
            Seed.Add(Convert.ToInt32("0x2c", 16));
            Seed.Add(Convert.ToInt32("0x2e", 16));
            Seed.Add(Convert.ToInt32("0x69", 16));
            Seed.Add(Convert.ToInt32("0x79", 16));

            Seed.Add(Convert.ToInt32("0x65", 16));
            Seed.Add(Convert.ToInt32("0x77", 16));
            Seed.Add(Convert.ToInt32("0x72", 16));
            Seed.Add(Convert.ToInt32("0x6b", 16));
            Seed.Add(Convert.ToInt32("0x6c", 16));
            Seed.Add(Convert.ToInt32("0x64", 16));
            Seed.Add(Convert.ToInt32("0x4a", 16));
            Seed.Add(Convert.ToInt32("0x4b", 16));
            Seed.Add(Convert.ToInt32("0x44", 16));
            Seed.Add(Convert.ToInt32("0x48", 16));
            Seed.Add(Convert.ToInt32("0x53", 16));
            Seed.Add(Convert.ToInt32("0x55", 16));
            Seed.Add(Convert.ToInt32("0x42", 16));
            //Table.Add(0, 0);
            button1_Click(null, null);
        }
        List<int> Seed = new List<int>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Code = "";
            string P = textBox1.Text;
            int I = int.Parse(textBox2.Text);
            string Istr = Convert.ToString(I, 16);
            Code += Istr.PadLeft(2, '0');
            int J = 0;
            while (J < P.Length)
            {
                int Temp = P[J] ^ Seed[I];
                Code += Convert.ToString(Temp, 16).PadLeft(2, '0');
                I++;
                J++;
            }
            textBox3.Text = Code;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string STR = textBox3.Text;
            int I = Convert.ToInt32(STR[0] + "" + STR[1], 10);
            int Len = STR.Length / 2 - 1;
            List<int> strl = new List<int>();
            string Ans = "";
            for (int i = 2; i < STR.Length; i += 2)
            {
                strl.Add(Convert.ToInt32(STR[i] + "" + STR[i + 1], 16));
            }
            int j = 0;
            while (j < strl.Count)
            {


                int temp = Seed[I] ^ strl[j];
                Ans += (char)temp;
                j++;
                I++;
            }
            label1.Text = Ans;
        }
    }
}
