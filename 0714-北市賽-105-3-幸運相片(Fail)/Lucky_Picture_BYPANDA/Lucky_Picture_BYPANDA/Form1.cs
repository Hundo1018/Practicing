using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lucky_Picture_BYPANDA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap("exam1.bmp");
            string R="", G="", B="";
            string[] Pix = new string[3];
            for (int i = 0; i< bmp.Height; i++)
            {
                for(int j = 0; j< bmp.Width; j++)
                {
                    Color bmp_c = bmp.GetPixel(j, i);
                    Pix[0] += bmp_c.R % 2;
                    Pix[1] += bmp_c.G % 2;
                    Pix[2] += bmp_c.B % 2;
                }
                
            }
            
            while (Pix[1].IndexOf("00000000")!= -1)
            {
                string result = "";
                string temp = "";
                int index = Pix[1].IndexOf("00000000");
                Pix[1].Remove(index, 8);
                int index_move = 1;
                while (true)
                {
                    while (temp.Length <= 8)
                    {
                        temp += Pix[1][index - index_move];
                        index_move++;
                    }
                    temp = reverse(temp);
                    if (Convert.ToInt32(temp, 2) > 127)
                        break;
                    else
                        result += (char)Convert.ToInt32(temp, 2);
                    temp = "";
                }
            }


            textBox1.Text = Pix[0];
            textBox2.Text = Pix[1];
            textBox3.Text = Pix[2];
        }
        string reverse(string a)
        {
            char[] k = a.ToCharArray();
            Array.Reverse(k);
            a = new string(k);
            return a;
        }
    }
}
