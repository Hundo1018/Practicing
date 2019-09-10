using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuckyPhoto
{
    public partial class Form1 : Form
    {

        string Path = "";
        public Form1()
        {
            InitializeComponent();
            string temp = "0x00";
            int tempint = Convert.ToInt32(temp, 16);
            temp = Convert.ToString(tempint, 16);
            //Run();
            pictureBox1.AllowDrop = true;
        }
        Bitmap BMP;
        void Run()
        {
            BMP = new Bitmap(Path);
            pictureBox1.ImageLocation = Path;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;


            List<string> FtempRL = new List<string>(); 
            List<string> FtempGL= new List<string>();
            List<string> FtempBL= new List<string>();

            for (int i = 0; i < BMP.Height-1; i++)
            {

                string Rs = "", Gs = "", Bs = "";
                for (int j = 0; j < BMP.Width; j++)
                {
                    //取每個pixel的lsb
                    Rs += (BMP.GetPixel(j, i).R % 2).ToString();
                    Gs += (BMP.GetPixel(j, i).G % 2).ToString();
                    Bs += (BMP.GetPixel(j, i).B % 2).ToString();
                }
                //每個row的bits
                FtempRL.Add(Rs);
                FtempGL.Add(Gs);
                FtempBL.Add(Bs);
            }
           
            int R=-1,G=-1,B=-1;
            string Ans = "";
            foreach (var item in FtempRL)
            {
                R= item.IndexOf("0000000000000000"+"00000000");
                if (R>=0)
                {
                    R = R + R % 8;
                    textBox1.Text = "R";
                    Ans = item.Substring(0, R);
                    break;
                }
            }
            foreach (var item in FtempGL)
            {
                G = item.IndexOf("0000000000000000"+"00000000");
                if (G >= 0)
                {
                    G = G + G % 8;
                    textBox1.Text = "G";
                    Ans = item.Substring(0, G);
                    break;
                }
            }
            foreach (var item in FtempBL)
            {
                B = item.IndexOf("0000000000000000"+"00000000");
                if (B >= 0)
                {
                    B = B + B % 8;
                    textBox1.Text = "B";
                    Ans = item.Substring(0, B);
                    break;
                }
            }
            int count = 0;
            string temp = "";
            string NAns = "";
            for (int i = 0; i < Ans.Length; i++)
            {
                count++;
                temp +=( Ans[i]/* * Math.Pow(2,count)*/);
                if (count==8)
                {
                    int temptemp = 
                     Convert.ToInt32(temp, 2);
                   NAns += ((char)temptemp).ToString();
                    count = 0;
                    temp = "";
                }
            }
            #region
            //List<string> RL = new List<string>(), GL = new List<string>(), BL = new List<string>();
            /*
            for (int i = 0; i < BMP.Height; i++)//跑每個Row
            {
                
                string strR = "", strG = "", strB = "";
                int FtempR = 0;
                int FtempG = 0;
                int FtempB = 0;
                int count = 8;
                for (int j = 0; j < BMP.Width; j++)//跑每個Row裡面的每個channel
                {
                    //取得每個channel的LSB
                    FtempR += (int)((BMP.GetPixel(j, i).R % 2) * Math.Pow(2, count));
                    FtempG += (int)((BMP.GetPixel(j, i).G % 2) * Math.Pow(2, count));
                    FtempB += (int)((BMP.GetPixel(j, i).B % 2) * Math.Pow(2, count));
                    count--;
                    if (count == 0)//取到8bits了
                    {
                        //轉ascii
                        if (FtempR <= 127)
                            strR += ((char)FtempR).ToString();
                        else
                            strR = "";
                        if (FtempG <= 127)
                            strG += ((char)FtempG).ToString();
                        else
                            strG = "";
                        if (FtempB <= 127)
                            strB += ((char)FtempB).ToString();
                        else
                            strB = "";
                        FtempR = 0;
                        FtempG = 0;
                        FtempB = 0;
                        count = 8;
                    }
                }

                string[] tr = strR.Split('\0');
                string[] tg = strG.Split('\0');
                string[] tb = strG.Split('\0');
                for (int z = 0; z < tr.Count(); z++)
                {
                    if (tr[z].Length <=0)
                    {
                        continue;
                    }
                    else
                    {
                        FtempRL.Add(tr[z]);
                    }
                }
                for (int z = 0; z < tg.Count(); z++)
                {
                    if (tg[z].Length <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        FtempGL.Add(tg[z]);
                    }
                }
                for (int z = 0; z < tb.Count(); z++)
                {
                    if (tb[z].Length <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        FtempBL.Add(tb[z]);
                    }
                }
            }
         
            */
            /*
               int[] tempint =new int [3];
               StringBuilder[] tempstr = new StringBuilder[3] ;
               for (int i = 0; i < 3; i++)
               {
                   tempstr[i] = new StringBuilder();
               }
               int count = 8;
               List<string> RL = new List<string>(), GL = new List<string>(), BL = new List<string>();
               List<List<string>> LL = new List<List<string>>();
               LL.Add(RL);
               LL.Add(GL);
               LL.Add(BL);
               for (int i = 0; i < BMP.Height; i++)
               {
                   for (int j = 0; j < BMP.Width; j++)
                   {
                       count--;
                       tempstr[0].Append( (BMP.GetPixel(j, i).R % 2).ToString());
                       tempstr[1].Append((BMP.GetPixel(j, i).G % 2).ToString());
                       tempstr[2].Append((BMP.GetPixel(j, i).B % 2).ToString());

                       tempint[0] += (int)((BMP.GetPixel(j, i).R % 2) * Math.Pow(2, count));
                       tempint[1] += (int)((BMP.GetPixel(j, i).G % 2) * Math.Pow(2, count));
                       tempint[2] += (int)((BMP.GetPixel(j, i).B % 2) * Math.Pow(2, count));


                       if (count == 0)
                       {
                           for (int k = 0; k < 3; k++)
                           {
                               if (tempint[k] <= 127)
                               {
                                   LL[k].Add(((char)(tempint[k])).ToString());
                               }
                           }
                           count = 8;

                       }
                   }
               }
               string[] S = new string[3] { "", "", "" };
               for (int i = 0; i < 3; i++)
               {
                   LL[i].ForEach(x => S[i] += x);
                   if (S[i].Contains("hello"))
                   {

                   }
               }

               int A = tempstr[0].Length;
               int B = A % 8;
               */
            #endregion
            textBox2.Text = NAns;
        }


        bool t =  true;
        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            Path = (((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
            try
            {
                Run();
            }
            catch
            {
                if(t) MessageBox.Show("請拖入正確的檔案");
                t = !t;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
