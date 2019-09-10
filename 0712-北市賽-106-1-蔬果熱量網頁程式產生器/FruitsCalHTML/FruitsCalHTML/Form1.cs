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

namespace FruitsCalHTML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2_Click(null, null);
        }
        string path = "水果類.txt";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
        }
        int width;
        int gap;
        int items;
        List<string[]> FruitList = new List<string[]>();
        private void button2_Click(object sender, EventArgs e)
        {
            width = int.Parse(textBox1.Text);
            gap = int.Parse(textBox2.Text);
            items = int.Parse(textBox3.Text);
            int Count = 0;
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    FruitList.Add(sr.ReadLine().Split('\t'));
                    Count += 1;
                }
            }
            Generation();

        }
        void Generation()
        {
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<!DOCTYPE html>");
            SB.AppendLine("<html>");
            SB.AppendLine("<head><title>顯示各類食材熱量</title>");
            SB.AppendLine("<style>img {width:100%;height:auto}</style>");
            SB.AppendLine("</head>");
            SB.AppendLine("<body>");
            SB.AppendLine($"<table cellspacing = {gap} border = {width}>");
            int times = (int)Math.Ceiling(((double)FruitList.Count / (double)items));
            int lastlost = FruitList.Count % items;
            int Count=0;
            for (int i = 0; i < times; i++)//整體要跑幾次
            {
                SB.AppendLine("<tr>");
                //名稱 圈數少於等於items
                for (int j = Count; j < items; j++)
                {
                    if (j >= FruitList.Count)
                    {
                        SB.AppendLine($"<td style=\"background-color:lightgray\"><br></td>");
                        continue;
                    }
                    SB.AppendLine($"<td style=\"background-color:lightgray\">{FruitList[j][0]}<br>{FruitList[j][1]}</td>");
                }
                SB.AppendLine("</tr>");
                SB.AppendLine("<tr>");

                //圖片
                for (int j = Count; j < items; j++)
                {
                    if (j >= FruitList.Count) continue;
                    SB.AppendLine($"<td><img src=\"{FruitList[j][0]}.JPG\"</td>");
                }
                SB.AppendLine("</tr>");

                Count += items;
                items += items;
            }

            
            SB.Append("</table>");
            SB.Append("</body></html>");
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.html|*html";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                   sw.WriteLine( SB.ToString());
                   sw.Flush();
                }
            }
           
        }
    }
    class HTML
    {


    }
}
