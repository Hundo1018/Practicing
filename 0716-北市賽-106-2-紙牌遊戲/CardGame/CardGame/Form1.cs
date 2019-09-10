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

namespace CardGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2_Click(null,null);
        }
        public struct Card
        {
            public char Col;
            public int Num;
            public Bitmap BMP;
        }
        bool rd = true;
        string Path = "cards.png";
        Bitmap B;
        Card[] Cards = new Card[40]; //梅方心桃
        PictureBox[,] ABC;
        Size CardSize;
        private void button2_Click(object sender, EventArgs e)
        {
            ABC = new PictureBox[2, 5]
                {
                    {pictureBox1,pictureBox2,pictureBox3,pictureBox4,pictureBox5 },
                    {pictureBox6,pictureBox7,pictureBox8,pictureBox9,pictureBox10 }
                };
            B = new Bitmap(Path);
            //一張圖的寬為B.w/13
            //一張圖的高為B.h/4
            CardSize = new Size((B.Width / 13), (B.Height / 5));
            for (int i = 0; i < 40; i++)
            {
                Cards[i].BMP = new Bitmap(CardSize.Width, CardSize.Height);
            }
            int Z = 0;
            string Colo = "SDHC";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    
                    Point Start = new Point(j * CardSize.Width,i* CardSize.Height);
                    TextureBrush TB = new TextureBrush(B,new Rectangle(Start, CardSize));
                    Graphics G = Graphics.FromImage(Cards[Z].BMP);
                    G.FillRectangle(TB, 0, 0, CardSize.Width, CardSize.Height);
                    TB.Dispose();
                    G.Dispose();
                    Cards[Z].Col = Colo[i];
                    Cards[Z].Num = (j+1);
                    Z += 1;
                }
            }
            if (rd)
            {
                WashCard(0);
                WashCard(1);
                ShowACard2Label();
                Application.DoEvents();
                JG(Player5Cards);
            }
            else
            {
                WashCard(1);
                ShowACard2Label();
                Application.DoEvents();
                JG(Player5Cards);
            }
        }
        Card[,] Player5Cards = new Card[2, 5];
        void WashCard(int Who)
        {
            for (int i = 0; i < 5; i++)
            {
                Player5Cards[Who, i] = new Card() { BMP = new Bitmap(CardSize.Width, CardSize.Height) };
            }
            Card[] temps = Cards;
            for (int i = 0; i < 40; i++)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                Card temp = new Card();
                int rdm = random.Next(0, 40);
                temp = temps[rdm];
                temps[rdm] = temps[i];
                temps[i] = temp;
            }
            for (int i = 0; i < 5; i++)
            {
                Player5Cards[Who, i] = temps[i];
                ABC[Who, i].Image = Player5Cards[Who, i].BMP;
            }
            Application.DoEvents();
        }

        void ShowACard2Label()
        {
            label1.Text = "";
            for (int i = 0; i < 5; i++)
            {
                label1.Text += (Player5Cards[0, i].Col.ToString() + Player5Cards[0, i].Num + " ");
            }
        }

        void JG(Card[,] In)
        {
            string AType = "甲方類別:";
            int AScore = 0;
            string BType = "乙方類別:";
            int BScore = 0;
            List<int> ANumList = new List<int>();
            List<int> BNumList = new List<int>();
            List<char> AColList = new List<char>();
            List<char> BColList = new List<char>();
            for (int i = 0; i < 5; i++)
            {
                ANumList.Add(Player5Cards[0, i].Num);
                AColList.Add(Player5Cards[0, i].Col);
                BNumList.Add(Player5Cards[1, i].Num);
                BColList.Add(Player5Cards[1, i].Col);
            }
            var atemp = ANumList.GroupBy(x => x).ToList();
            var btemp = BNumList.GroupBy(x => x).ToList();
            if (atemp.Count ==2)//分成兩組 代表41 14 或 23 32
            {
                if ((atemp[0].Count() == 4 && atemp[1].Count() == 1)|| (atemp[0].Count() == 1 && atemp[1].Count() == 4))
                {
                    AType += "4張相同";
                    AScore = 10;
                }
                else if ((atemp[0].Count() == 2 && atemp[1].Count() == 3) || (atemp[0].Count() == 3 && atemp[1].Count() == 2))
                {
                    AType += "3+2相同";
                    AScore = 7;
                }
            }
            else if(atemp.Count == 3)//分成三組 代表(122 212 221 2+2) (311 313 113 三張相同)  
            {
                if (atemp[0].Count() == 3 || atemp[1].Count() == 3 ||atemp[2].Count() == 3)
                {
                    AType += "3張相同";
                    AScore = 5;
                }
                else
                {
                    AType += "2+2相同";
                    AScore = 4;
                }
            }
            else if (atemp.Count == 4)//分成四組 (2111)
            {
                AType += "2張相同";
                AScore = 2;
            }
            else if (atemp.Count ==5)//分成五組
            {
                if ((AColList.GroupBy(x=>x).Count() ==1))
                {
                    AType += "花色相同";
                    AScore = 1;
                }
                else
                {
                    AType += "其他";
                    AScore = 0;
                }
            }
            if (btemp.Count == 2)//分成兩組 代表41 14 或 23 32
            {
                if ((btemp[0].Count() == 4 && btemp[1].Count() == 1) || (btemp[0].Count() == 1 && btemp[1].Count() == 4))
                {
                    BType += "4張相同";
                    BScore = 10;
                }
                else if ((btemp[0].Count() == 2 && btemp[1].Count() == 3) || (btemp[0].Count() == 3 && btemp[1].Count() == 2))
                {
                    BType += "3+2相同";
                    BScore = 7;
                }
            }
            else if (btemp.Count == 3)//分成三組 代表(122 212 221 2+2) (311 313 113 三張相同)  
            {
                if (btemp[0].Count() == 3 || btemp[1].Count() == 3 || btemp[2].Count() == 3)
                {
                    BType += "3張相同";
                    BScore = 5;
                }
                else
                {
                    BType += "2+2相同";
                    BScore = 4;
                }
            }
            else if (btemp.Count == 4)//分成四組 (2111)
            {
                BType += "2張相同";
                BScore = 2;
            }
            else if (btemp.Count == 5)//分成五組
            {
                if ((BColList.GroupBy(x => x).Count() == 1))
                {
                    BType += "花色相同";
                    BScore = 1;
                }
                else
                {
                    BType += "其他";
                    BScore = 0;
                }
            }
            textBox2.Text = "";
            textBox2.Text += AType + "\r\n" + BType + "\r\n";
            if (AScore>BScore)
            {
                textBox2.Text += "甲方勝利";
            }
            else if (BScore > AScore)
            {
                textBox2.Text += "乙方勝利";
            }
            else
            {
                textBox2.Text += "和局";
            }
            Application.DoEvents();
        }
        //string[] AC;
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StringReader SR = new StringReader(ofd.FileName))
                {
                    AC =  SR.ReadLine().Split(' ');
                }
                    for (int i = 0; i < 5; i++)
                    {
                        Player5Cards[0, i] = new Card() { BMP = new Bitmap(CardSize.Width, CardSize.Height) };
                        //ABC[0, i].Image =
                    }

                ShowACard2Label();
            }
            */
        }
    }
}
