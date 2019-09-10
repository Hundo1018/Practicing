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

namespace Lucky_Picture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1_Click(null, null);
        }
        string Path = @"exam1.bmp";
        Bitmap B = new Bitmap(@"exam1.bmp");
        private void button1_Click(object sender, EventArgs e)
        {
            int tt = B.Height * B.Width;
            List<int> RL = new List<int>();
            List<int> GL = new List<int>();
            List<int> BL = new List<int>();
            bool[] RGBflag = new bool[3] { true,true,true};
            int[] RGBCount = new int[3] { 0,0,0};
            for (int i = 0; i < B.Height; i++)
            {
                for (int j = 0; j < B.Width; j++)
                {
                    if (RGBflag[0])
                    {
                        int temp = B.GetPixel(j, i).R % 2;
                        if (temp == 0) RGBCount[0]++;
                        else RGBCount[0] = 0;

                        RL.Add(temp);
                        if (RGBCount[0] == 8) RGBflag[0] = false;
                    }

                    if (RGBflag[1])
                    {
                        int temp = B.GetPixel(j, i).G % 2;
                        if (temp == 0) RGBCount[1]++;
                        else RGBCount[1] = 0;

                        GL.Add(temp);
                        if (RGBCount[1] == 8) RGBflag[1] = false;
                    }
                    if (RGBflag[2])
                    {
                        int temp = B.GetPixel(j, i).B % 2;
                        if (temp == 0) RGBCount[2]++;
                        else RGBCount[2] = 0;

                        BL.Add(temp);
                        if (RGBCount[2] == 8) RGBflag[2] = false;
                    }
                }
            }
          
            string RA = F(RL);
            string GA = F(GL);
            string BA = F(BL);
            //string Ra= F(RL);
            //string Ga = F(GL);
            //string Ba = F(BL);

            //int RLIndex = 0, GLIndex = 0, BLIndex = 0;
            //int Count = 0;
            //for (int i = 0; i < RL.Count; i++)
            //{
            //    if (RL[i] == 0) Count++;
            //    else Count = 0;
            //    if (Count == 8)
            //    {
            //        RLIndex = i;
            //        break;
            //    }
            //}
            //Count = 0;
            //for (int i = 0; i < GL.Count; i++)
            //{
            //    if (GL[i] == 0) Count++;
            //    else Count = 0;
            //    if (Count == 8)
            //    {
            //        GLIndex = i;
            //        break;
            //    }
            //}
            //Count = 0;
            //for (int i = 0; i < BL.Count; i++)
            //{
            //    if (BL[i] == 0) Count++;
            //    else Count = 0;
            //    if (Count == 8)
            //    {
            //        BLIndex = i;
            //        break;
            //    }
            //}

            //string RA= F(RLIndex, RL);
            //string GA = F(GLIndex, GL);
            //string BA = F(BLIndex, BL);


        }

        string F(List<int>In)
        {
            if (In.Count % 8 != 0 ) return "\0";
            string temp = "";
            
            for (int i = In.Count-1; i >= 8; i -=8)
            {
                temp += byte2char(new int[] { In[i], In[i - 1], In[i - 2], In[i - 3], In[i - 4], In[i - 5], In[i - 6], In[i - 7] });
            }
            string STR = "";
            foreach (var item in temp.Reverse().ToArray())
            {
                STR += item.ToString();
            }
            return STR;
        }
       

        string byte2char(int[] In)//0LSB-7MSB
        {
            int ans = 0;
            for (int i = 0; i < 8; i++)
            {
                ans += (int)(In[i] * Math.Pow(2, i));
            }
            return char.ConvertFromUtf32(ans);
            return (Convert.ToString(Convert.ToChar(ans)));
        }
    }
}
