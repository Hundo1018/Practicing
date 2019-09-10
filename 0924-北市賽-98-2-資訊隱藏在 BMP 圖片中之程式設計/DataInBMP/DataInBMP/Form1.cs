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

namespace DataInBMP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string A = textBox3.Text;
            List<int> datas = new List<int>();
            A = "b1.bmp";
            using (FileStream FS = new FileStream(A, FileMode.Open))
            {
                for (int i = 0; i < FS.Length; i++)
                {
                    datas.Add(FS.ReadByte());
                }
            }
            int SwitchFlag = 1;
            for (int i = 64; i <= 95; i++)
            {
                if ((datas[i] % 2) == SwitchFlag)
                {
                    MessageBox.Show("圖檔未被嵌入隱藏資訊");
                    return;
                }
                else
                {
                    SwitchFlag = (SwitchFlag == 0 ? 1 : 0);
                }
            }
            string Lenstr = "";
            for (int i = 96; i <= 111; i++)
            {
                Lenstr = (i % 2).ToString() + Lenstr;
            }
            int LenBy = Convert.ToInt32(Lenstr, 2);
            string Ans = "";
            for (int i = 112; i < 112 + LenBy; i += 8)
            {
                string temp = "";
                bool done = false;
                for (int j = i; j < i + 8 && j < datas.Count; j++)
                {
                    temp = (datas[j] % 2).ToString() + temp;
                    done = true;
                }
                if (done)
                    Ans += ((char)(Convert.ToInt32(temp, 2))).ToString();
            }
            textBox4.Text = Ans;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "a1.bmp";
            List<int> odatas = new List<int>();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                for (int i = 0; i < fs.Length; i++)
                {
                    odatas.Add(fs.ReadByte());
                }
            }
            int SwitchFlag = 0;

            for (int i = 65; i <= 95; i++)
            {
                if (odatas[i] % 2 == 0 && odatas[i] % 2 != SwitchFlag)
                {
                    if (odatas[i] + 1 > 255)
                    {
                        odatas[i] -= 1;
                    }
                    else if (odatas[i] - 1 < 0)
                    {
                        odatas[i] += 1;
                    }
                    else
                    {
                        odatas[i] += 1;
                    }
                }
                SwitchFlag = (SwitchFlag == 0 ? 1 : 0);
            }
            string MYSstr = textBox1.Text;
            string a = Convert.ToString(MYSstr.Length, 2).PadRight('0');
            int count = 0;
            for (int i = 96; i <= 111; i++)
            {
                if (odatas[i] % 2 != a[count])
                {
                    if (odatas[i] + 1 > 255)
                    {
                        odatas[i] -= 1;
                    }
                    else if (odatas[i] - 1 < 0)
                    {
                        odatas[i] += 1;
                    }
                    else
                    {
                        odatas[i] += 1;
                    }
                }
                count++;
            }
            List<string> asa = new List<string>();
            for (int i = 0; i < MYSstr.Length; i++)
            {
                asa.Add(Convert.ToString(MYSstr[i], 2).PadLeft('0'));
                asa.Last().Reverse();
            }
            count = 0;
            int count2 = 0;
            for (int i = 112; i < odatas.Count; i++)
            {

                if (odatas[i] % 2 != asa[count][count2])
                {
                    if (odatas[i] + 1 > 255)
                    {
                        odatas[i] -= 1;
                    }
                    else if (odatas[i] - 1 < 0)
                    {
                        odatas[i] += 1;
                    }
                    else
                    {
                        odatas[i] += 1;
                    }
                }
                count2++;
                if (count2 == 8)
                {
                    count2 = 0;
                    count++;
                }
            }
            using (FileStream fs =new FileStream("a2.bmp",FileMode.Create))
            {
                for (int i = 0; i < odatas.Count; i++)
                {

                    fs.WriteByte((byte)odatas[i]);
                }
                
                fs.Flush();
            }
        }
    }
}
    

