using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string RUN(string A)
        {
            int R = 34943;
            string Ai = "";
            string Ans = "";
            for (int i = 0; i < A.Length; i++)
            {
                int temp = A[i];
                if (A[i] == ' ')
                {
                    temp = 0;
                }
                Ai += temp.ToString("X");
            }
            for (int i = 0; i <= R; i++)
            {
                string temp = i.ToString("X");
                int fix = temp.Length % 2;
                temp = temp.PadLeft(temp.Length + fix, '0');
                string Temp = Ai + temp;
                if (H2D(Temp) % R == 0)
                {
                    Ans = temp;
                    break;
                }
            }
            return Ans;
        }

        Int64 H2D(string H)
        {
            int pow = 0;
            Int64 ou = 0;
            for (int i = H.Count() - 1; i >= 0; i--)
            {
                string t = H[i].ToString();
                ou += Convert.ToByte(t, 16) * (long)Math.Pow(16, pow++);
            }
            return ou;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Source = textBox1.Text;
            string Data = Source;
            //Data = Encoding.Default.GetString(Encoding.ASCII.GetBytes(Source));
            textBox2.Text = RUN(Data);
        }
    }
}
