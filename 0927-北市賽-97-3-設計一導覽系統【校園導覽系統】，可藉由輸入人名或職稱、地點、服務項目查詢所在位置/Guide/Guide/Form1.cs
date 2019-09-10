using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guide
{
    public partial class Form1 : Form
    {
        Button[] BTN = new Button[6];

        public Form1()
        {
            InitializeComponent();
            BTN[0] = button1;
            BTN[1] = button2;
            BTN[2] = button3;
            BTN[3] = button4;
            BTN[4] = button5;
            BTN[5] = button6;
            LL = new List<string>();
            LL.Add("行政中心");
            LL.Add("教學大樓");
            LL.Add("資訊大樓");
            LL.Add("學生宿舍區");
            LL.Add("體育場");
            LL.Add("學生運動中心");

            Atype_dic.Add("教務長", 0);
            Atype_dic.Add("網管", 2);
            Atype_dic.Add("KIMI", 3);
            Atype_dic.Add("ALONSO", 1);
            Atype_dic.Add("學生會會長", 5);
            Atype_dic.Add("教練", 4);

            Btype_dic.Add("行政中心", 0);
            Btype_dic.Add("教學大樓", 1);
            Btype_dic.Add("資訊大樓", 2);
            Btype_dic.Add("學生宿舍區", 3);
            Btype_dic.Add("體育場", 4);
            Btype_dic.Add("學生運動中心", 5);

            Ctype_dic.Add("游泳", 4);
            Ctype_dic.Add("成績查詢", 0);
            Ctype_dic.Add("社團活動", 5);
            Ctype_dic.Add("用餐", 3);
            Ctype_dic.Add("列印輸出", 2);
            Ctype_dic.Add("上課", 1);


        }
        Dictionary<int, Button> IBD = new Dictionary<int, Button>();
        List<string> LL = new List<string>();
        Dictionary<string, int> Atype_dic = new Dictionary<string, int>();
        Dictionary<string, int> Btype_dic = new Dictionary<string, int>();
        Dictionary<string, int> Ctype_dic = new Dictionary<string, int>();

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (var item in BTN)
            {
                item.BackColor = SystemColors.Control;
            }
            List<int> search = new List<int>();
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                search.Add(Atype_dic[textBox1.Text]);
            }
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                search.Add(Btype_dic[textBox2.Text]);
            }
            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                search.Add(Ctype_dic[textBox3.Text]);
            }
            for (int i = 0; i < search.Count; i++)
            {
                BTN[search[i]].BackColor = Color.Red;
            }
        }
    }
}
