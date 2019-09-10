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
namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Dic.Add("蕃茄雞肉義大利麵",75);
            var a = Directory.EnumerateFiles("food").ToList();
            label1.Text = "";
            label2.Text = "";
            groupBox1.Text = "A客人";
            groupBox2.Text = "B客人";
            button1.Text = "點餐";
            button2.Text = "點餐";
            foreach (var item in a)
            {
                string temp = item.Split('\\')[1];
                string Item = temp.Split('(')[0];
                int Cost = int.Parse(temp.Split('(')[1].Replace("元).bmp", ""));
                Dic.Add(Item, Cost);
                Dic_GetPath.Add(Item, item);
            }
            AOrderPic = new PictureBox[2, 2];
            AOrderLab = new Label[2, 2];
            BOrderPic = new PictureBox[2,2];
            BOrderLab = new Label[2,2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    AOrderPic[i, j] = new PictureBox()
                    {
                        Location = new Point(17 + j * 120, 62 + i * 120),
                        Size = new Size(100, 100),
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    AOrderLab[i, j] = new Label()
                    {
                        Location = new Point(17 + j * 120, 45 + i * 120)
                        ,
                        Text = "X"
                    };
                    BOrderPic[i, j] = new PictureBox()
                    {
                        Location = new Point(17 + j * 120, 62 + i * 120),
                        Size = new Size(100, 100),
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    BOrderLab[i, j] = new Label()
                    {
                        Location = new Point(17 + j * 120, 45 + i * 120)
                        ,
                        Text = "X"
                    };
                    groupBox1.Controls.Add(AOrderPic[i, j]);
                    groupBox1.Controls.Add(AOrderLab[i, j]);
                    groupBox2.Controls.Add(BOrderPic[i, j]);
                    groupBox2.Controls.Add(BOrderLab[i, j]);
                }
            }
            At = new List<int>() { 0,0,0,0};
            Bt = new List<int>() { 0,0,0,0};
        }
        PictureBox[,] AOrderPic;
        Label[,] AOrderLab;
        PictureBox[,] BOrderPic;
        Label[,]        BOrderLab;
        List<int> At = new List<int>();
        List<int> Bt = new List<int>();
        Dictionary<string, string> Dic_GetPath = new Dictionary<string, string>();
        Dictionary<string, int> Dic = new Dictionary<string, int>();
        bool AOrder = true;
        void total()
        {
            if (AOrder) label1.Text = "總價：" + At.Sum() + "元";
            else label2.Text = "總價：" + Bt.Sum() + "元";
        }
        void Main(string str)
        {
            if (AOrder)
            {
                AOrderLab[0, 0].Text = str;
                AOrderPic[0, 0].ImageLocation = Dic_GetPath[str];
                At[0] = Dic[str];
            }
            else
            {
                BOrderLab[0, 0].Text = str;
                BOrderPic[0, 0].ImageLocation = Dic_GetPath[str];
                Bt[0] = Dic[str];
            }
            total();
        }
        void Sala(string str)
        {
            if (AOrder)
            {
                AOrderLab[0, 1].Text = str;
                AOrderPic[0, 1].ImageLocation = Dic_GetPath[str];
                At[1] = Dic[str];
            }
            else
            {
                BOrderLab[0, 1].Text = str;
                BOrderPic[0, 1].ImageLocation = Dic_GetPath[str];
                Bt[1] = Dic[str];
            }
            total();
        }
        void Soup(string str)
        {
            if (AOrder)
            {
                AOrderLab[1, 0].Text = str;
                AOrderPic[1, 0].ImageLocation = Dic_GetPath[str];
                At[2] = Dic[str];
            }
            else
            {
                BOrderLab[1, 0].Text = str;
                BOrderPic[1, 0].ImageLocation = Dic_GetPath[str];
                Bt[2] = Dic[str];
            }
            total();
        }
        void Sn(string str)
        {
            if (AOrder)
            {
                AOrderLab[1, 1].Text = str;
                AOrderPic[1, 1].ImageLocation = Dic_GetPath[str];
                At[3] = Dic[str];
            }
            else
            {
                BOrderLab[1, 1].Text = str;
                BOrderPic[1, 1].ImageLocation = Dic_GetPath[str];
                Bt[3] = Dic[str];
            }
            total();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AOrder = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AOrder = false;
        }
        private void 蕃茄雞肉義大利麵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main(sender.ToString());
        }
        private void 羅勒海鮮義大利麵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main(sender.ToString());
        }
        private void 奶油燻雞義大利麵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main(sender.ToString());
        }
        private void 白酒蛤蠣義大利麵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main(sender.ToString());
        }
        private void 水果優格沙拉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sala(sender.ToString());
        }
        private void 生春捲沙拉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sala(sender.ToString());
        }
        private void 筊白筍青蔬沙拉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sala(sender.ToString());
        }
        private void 牛蕃茄沙拉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sala(sender.ToString());
        }
        private void 大蒜蛤蠣湯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Soup(sender.ToString());
        }
        private void 蕃茄海鮮湯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Soup(sender.ToString());
        }
        private void 吟釀味噌湯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Soup(sender.ToString());
        }
        private void 元氣牛肉湯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Soup(sender.ToString());
        }
        private void 原燒冰淇淋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sn(sender.ToString());
        }
        private void 桂花紅豆湯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sn(sender.ToString());
        }
        private void 白玉紫米ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sn(sender.ToString());
        }
        private void 黑糖奶酪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sn(sender.ToString());
        }
    }
}
