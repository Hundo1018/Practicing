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
namespace Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1_Click(null, null);
            button1.Text = "讀檔";
            button2.Text = "計算";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recu(CNL.First(), 0, "", "0");
            int minindex = AllPath.FindIndex(y => y.cost == AllPath.Min(x => x.cost));
            textBox2.Text = $"最低成本值總和：{AllPath[minindex].cost}\r\n路徑次序：{AllPath[minindex].citypath}\r\n連線數值：{AllPath[minindex].costpath}";
        }
        List<Data> AllPath = new List<Data>();

        void Recu(CityNode nownode, int cost_t, string citypath, string costpath)
        {
            citypath += $" {nownode.ID}";
            if (nownode.Child.Count == 0)
            {
                AllPath.Add(new Data() { cost = cost_t, citypath = citypath.ToString(), costpath = costpath.ToString() });
                return;
            }
            for (int i = 0; i < nownode.Child.Count; i++)
            {
                Recu(nownode.Child[i].Child,
                    cost_t + nownode.Child[i].Cost,
                   citypath,
                   costpath +" "+ nownode.Child[i].Cost.ToString());
            }
        }

        List<CityNode> CNL = new List<CityNode>();
        List<Bridge> BL = new List<Bridge>();
        string path = "data.txt";
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
            else
            {
                return;
            }
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] str = sr.ReadLine().Split(' ');
                    textBox1.Text += str[0] + " " + str[1] + " " + str[2] + "\r\n";
                    int ida = int.Parse(str[0]);
                    int idb = int.Parse(str[1]);
                    if (CNL.FindIndex(x => (x.ID == ida)) == -1)
                    {
                        CNL.Add(new CityNode(ida));
                    }
                    if (CNL.FindIndex(x => (x.ID == idb)) == -1)
                    {
                        CNL.Add(new CityNode(idb));
                    }
                    int cost = int.Parse(str[2]);
                    BL.Add(new Bridge(cost,
                        CNL[ida - 1],
                        CNL[idb - 1]
                        ));
                    CNL[ida - 1].Child.Add( BL.Last());
                    CNL[idb - 1].Parent.Add( BL.Last());
                }
            }
        }
    }
    class Data
    {
        public string citypath,costpath;
        public int cost;
    }
    /// <summary>
    /// 城市 包含與之連結的橋
    /// </summary>
    class CityNode
    {
        public int ID;
        public List<Bridge> Parent = new List<Bridge>(), Child = new List<Bridge>();
        public CityNode(int id)
        {
            ID = id;
        }
    }
    /// <summary>
    /// 橋 一個城市到另一個城市的路 包含cost
    /// </summary>
    class Bridge
    {
        public CityNode Parent, Child;
        public int Cost;
        public Bridge(int cost, CityNode a, CityNode b)
        {
            Cost = cost;
            Parent = a;
            Child = b;
        }
    }
}
