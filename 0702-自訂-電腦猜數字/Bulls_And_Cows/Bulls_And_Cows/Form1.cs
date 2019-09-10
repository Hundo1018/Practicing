using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulls_And_Cows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        char[] QA = new char[4];
        char[] Past = new char[4] {'N','N','N','N'};
        List<string> AnsTable = new List<string>();
        List<string> AnsTableTemp = new List<string>();
        bool DonewFlag = false;
        int Count=0;
        double BC = 0,BT=0;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 我猜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            
                listBox1.Items.Add(Check(textBox1.Text));
            
            
        }

        /// <summary>
        /// 你猜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>     
        private void button2_Click(object sender, EventArgs e)
        {
            Count = 0;
            listBox1.Items.Clear();
            for (int i = 0; i < 4; i++) Past[i] = 'N';
            DonewFlag = false;
            while (!DonewFlag)
            {
                listBox1.Items.Add(Check(Guess()));
                Count++;
            }
            listBox2.Items.Add(Count + "\r\r" + AnsTable.Count);
            listBox1.SelectedIndex = listBox1.Items.Count-1;
            listBox2.SelectedIndex = listBox2.Items.Count-1;

            BT += Count;
            BC += 1;
            label2.Text = (BT / BC).ToString(); 
        }
        /// <summary>
        ///  利用現有A,B,Past來回傳答案字串
        /// </summary>
        /// <returns>一個4位答案字串</returns>
        string Guess()
        {
            bool FirstGuess = false;
            foreach (var item in Past) if (item == 'N') FirstGuess = true;
            if (FirstGuess)
            {
                char[] TEMP = RDNNumber();
                CreateTable();
                //return "0123";
                return (TEMP[0].ToString() + TEMP[1].ToString() + TEMP[2].ToString() + TEMP[3].ToString());
            }
            else
            {
                AnsTableTemp = new List<string>();
                foreach (var item in AnsTable)
                {
                    //bool Added = false;
                    int Count = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (item.Contains(Past[i]) && (item.IndexOf(Past[i])!=i))
                        {
                            Count += 1;
                            //Added = true;
                        }
                    }
                    if (Count == B) AnsTableTemp.Add(item);
                }
                AnsTable = AnsTableTemp;
                AnsTableTemp = new List<string>();
                if (A == 0)
                {
                    foreach (var item in AnsTable)
                    {
                        bool Added = false;
                        for (int i = 0; i < 4; i++)
                        {
                            int temp = item.IndexOf(Past[i]);
                            if (!Added && temp != i)
                            {
                                Added = true;
                                AnsTableTemp.Add(item);
                            }
                        }
                    }
                }
                else
                {
                    foreach (var item in AnsTable)
                    {
                        int j = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            if (item[i] == Past[i])
                                j++;
                        }
                        if (j >= A)
                            AnsTableTemp.Add(item);
                    }
                }
                AnsTable = AnsTableTemp;
                Random RDM = new Random(Guid.NewGuid().GetHashCode());
                RDM.Next(0, AnsTable.Count + 1);
                return AnsTable[RDM.Next(0, AnsTable.Count)];
            }
        }

        void CreateTable()
        {
            for (int i = 123; i <= 9876; i++)
            {
                string temp = i.ToString();
                if (temp.Length < 4) temp = "0" + temp;
                bool ShouldContinue = false;
                for (int j = 0; j < 4; j++)
                {
                    if (ShouldContinue) break;
                    char tempc= temp[j];
                    for (int k = 0; k < 4; k++)
                    {
                        if(j!=k)
                        {
                            if (tempc == temp[k])
                            {
                                ShouldContinue = true;
                                break;
                            } 
                        }
                    }
                }
                if (ShouldContinue) continue;
                AnsTable.Add(temp);
            }
        }











        /*
        /// <summary>
        /// 將四個變數除了原有排列組合外，將心的排列組合加入B4中
        /// </summary>
        /// <param name="B1"></param>
        /// <param name="B2"></param>
        /// <param name="B3"></param>
        /// <param name="B4"></param>
        void B4Order(string B1, string B2, string B3, string B4)
        {
            //FB.Add(B1 + B2 + B3 + B4);
            FB.Add(B1 + B2 + B4 + B3);
            FB.Add(B1 + B3 + B2 + B4);
            FB.Add(B1 + B3 + B4 + B2);
            FB.Add(B1 + B4 + B2 + B3);
            FB.Add(B1 + B4 + B3 + B2);
            FB.Add(B2 + B1 + B3 + B4);
            FB.Add(B2 + B1 + B4 + B3);
            FB.Add(B2 + B3 + B1 + B4);
            FB.Add(B2 + B3 + B4 + B1);
            FB.Add(B2 + B4 + B1 + B3);
            FB.Add(B2 + B4 + B3 + B1);
            FB.Add(B3 + B1 + B2 + B4);
            FB.Add(B3 + B1 + B4 + B2);
            FB.Add(B3 + B2 + B1 + B4);
            FB.Add(B3 + B2 + B4 + B1);
            FB.Add(B3 + B4 + B1 + B2);
            FB.Add(B3 + B4 + B2 + B1);
            FB.Add(B4 + B1 + B2 + B3);
            FB.Add(B4 + B1 + B3 + B2);
            FB.Add(B4 + B2 + B1 + B3);
            FB.Add(B4 + B2 + B3 + B1);
            FB.Add(B4 + B3 + B1 + B2);
        }
        */


        /// <summary>
        /// 隨機4位數字
        /// </summary>
        /// <returns></returns>
        char[] RDNNumber()
        {
            char[] Temp = new char[10];
            
            for (int i = 0; i < 10; i++) Temp[i] = i.ToString()[0];
            for (int i = 0; i < 10; i++)
            {
                Random rdm = new Random(Guid.NewGuid().GetHashCode());
                int tempint = rdm.Next(0, 10);
                char tempcr = Temp[i];
                Temp[i] = Temp[tempint];
                Temp[tempint] = tempcr;
            }
            return Temp;
        }

        /// <summary>
        /// 你出題
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            button5_Click(null, null);
            char[] Temp = new char[10];
            Temp = RDNNumber();
            for (int i = 0; i < 4; i++) QA[i] = Temp[i];
            label1.Text = Temp[0].ToString() + Temp[1].ToString() + Temp[2].ToString() + Temp[3].ToString();
        }

        /// <summary>
        /// 我出題
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
           // button5_Click(null, null);
            QA[0] = textBox1.Text[0];
            QA[1] = textBox1.Text[1];
            QA[2] = textBox1.Text[2];
            QA[3] = textBox1.Text[3];
            A = 0;
            B = 0;
            label1.Text = QA[0].ToString() + QA[1].ToString() + QA[2].ToString() + QA[3].ToString();
            char[] Past = new char[4] { 'N', 'N', 'N', 'N' };
        }

        /// <summary>
        /// 輸入欲猜數字 回傳幾A幾B的字串
        /// </summary>
        /// <param name="In"></param>
        /// <returns></returns>
        int A = 0,Aa=0;
        int B = 0,Bb=0;
        string Check(string In)
        {
            Aa = 0;
            Bb = 0;
            for (int i = 0; i < 4; i++)
            {
                string QT = QA[0].ToString() + QA[1].ToString() + QA[2].ToString() + QA[3].ToString();
                int temp = QT.IndexOf(In[i]);
                if(temp != -1)
                {
                    if (temp == i) Aa++;
                    else Bb++;
                }
            }
            A = Aa;
             B = Bb;
            if (A == 4)
                DonewFlag = true;
            /*
            List<int> AL = new List<int>();
            //A
            for (int i = 0; i < 4; i++)
            {
                if (In[i] == QA[i])
                {
                    //AL.Add(i);//答案位置
                    A++;
                }
            }
            //B
            for (int i = 0; i < 4; i++)
            {
                char temp = QA[i];
                bool Jump = false;
                for (int z = 0; z < AL.Count; z++)
                {
                    if (i == AL[z]) Jump = true;
                }
                if (Jump) continue;
                for (int j = 0; j < 4; j++)
                {
                    if (In[j] == temp) B++;
                }
            }
            for (int i = 0; i < 4; i++) Past[i] = In[i];
            if (A == 4)
            {
                MessageBox.Show("你贏ㄌ");
            }
            */
            for (int i = 0; i < 4; i++) Past[i] = In[i];
            return In +"\r\r"+(A + "A" + B +"B");
        }

        /// <summary>
        /// 重開
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Restart();
            return;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            QA = new char[4];
            label1.Text = "";
            textBox1.Text = "";
            char[] Past = new char[4] { 'N', 'N', 'N', 'N' };
            /*
            OKList = new List<int>();
            NOKList = new List<int>();
            FBStep = 0;
            FBFlag = false;
            */
        }
    }
}
