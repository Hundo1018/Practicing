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
            int j = 65;
            for (int i = 0; i < 16; i++)
            {
                if (i<10)
                {
                    H2T_Dic.Add(i.ToString(),i);
                    T2H_Dic.Add(i,i.ToString());
                }
                else
                {
                    H2T_Dic.Add( char.ConvertFromUtf32(j),i);
                    T2H_Dic.Add(i,char.ConvertFromUtf32(j));
                    j++;
                }
            }
            button1_Click(null,null);
        }
        Dictionary<string, int> H2T_Dic = new Dictionary<string, int>();

        Dictionary<int, string> T2H_Dic = new Dictionary<int, string>();
        private void button1_Click(object sender, EventArgs e)
        {
            int CRCCheck = int.Parse(textBox2.Text);
            string Input = textBox1.Text;
            string Hexstr = "";
            for (int i = 0; i < Input.Count(); i++)
            {
                Hexstr+= Ten2Hex(char.ConvertToUtf32(Input, i));
            }
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    for (int k = 0; k < 16; k++)
                    {
                        for (int l = 0; l < 16; l++)
                        {
                            string temp =
                             T2H_Dic[i] + T2H_Dic[j] + T2H_Dic[k] + T2H_Dic[l];
                            if(Check(Input,temp,CRC))
                            {
                                textBox3.Text = temp;
                                return;
                            }
                            else
                            {
                                textBox3.Text = "無";
                            }
                        }
                    }
                }
            }
        }
        string Ten2Hex(int In)
        {
            string Instr = In.ToString();
            int pbei = 4;
            string OUT = "";
            while (pbei>=0)
            {
                if (In-(int)Math.Pow(16,pbei)>=0)
                {
                    int bei = 9;
                    while (bei>=0)
                    {
                        if (In - ((int)Math.Pow(16, pbei) * bei) >= 0)
                        {
                            OUT += (bei.ToString());
                        }
                        bei--;
                    }
                }
                pbei--;
                
            }
            return OUT;
        }
        bool Check(string OriStr,string InCRC,int CRCCheck)
        {
            string NewString = (OriStr + InCRC);
            int j = 0;
            //HexStr2Ten
            int ans = 0;
            for (int i = NewString.Count() - 1; i >= 0; i++)
            {
                string Hs = NewString[i].ToString();//H為16進制 可能有英文
                int Ti = H2T_Dic[Hs];//Hi轉為十進制
                ans += (Ti * (int)Math.Pow(16, j));
                j++;
            }
            if (ans % CRCCheck == 0) return true;

           
            return false;
        }
    }
}
