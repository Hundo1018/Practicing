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
using System.Threading;
namespace DataXYInAndOut

{
    
    public partial class Form1 : Form
    {
        int DataCount;
        List<List<DataPoint>> Datas = new List<List<DataPoint>>();
        Dictionary<int, string> DD = new Dictionary<int, string>();
        public Form1()
        {
            InitializeComponent();
            using (StreamReader SR = new StreamReader("DataXY.txt"))
            {
                while (!SR.EndOfStream)
                {
                    string temp = SR.ReadLine();
                    if (!string.IsNullOrEmpty(temp))
                    {
                        string temp2 = temp.Split(' ')[0];
                        comboBox1.Items.Add(temp2);
                        List<DataPoint> TEMP = new List<DataPoint>();
                        int count = 0;
                        List<string> STRTEMP = new List<string>(temp.Split(' '));
                        for (int i = 2; i < STRTEMP.Count; i += 3)
                        {
                            DataPoint DP = new DataPoint()
                            {
                                X = int.Parse(STRTEMP[i]),
                                Y = int.Parse(STRTEMP[i + 1]),
                                Class = int.Parse(STRTEMP[i + 2])
                            };
                            TEMP.Add(DP);
                        }
                        TEMP = TEMP.OrderBy(x => x.X).ToList();
                        Datas.Add(new List<DataPoint>(TEMP));
                    }
                }
            }
            List<DataPoint> TEMP2 = new List<DataPoint>();
            for (int i = 0; i < Datas.Count; i++)
            {
                for (int j = 2; j < Datas[i].Count; j++)
                {
                    TEMP2.Add(Datas[i][j]);
                }
            }
            Datas.Add(TEMP2);

            comboBox1.Items.Add("all");

            DD.Add(1, "ｏ");
            DD.Add(0, "＊");
            comboBox1.SelectedIndex = 0;
            ShowAllData_BTN_Click(null, null);
        }

        private void NextData_BTN_Click(object sender, EventArgs e)
        {

        }
        Graphics G;
        Bitmap BMP;
        int fix = 25;
        private void NextPartData_BTN_Click(object sender, EventArgs e)
        {
            
        }


        private void ShowAllData_BTN_Click(object sender, EventArgs e)
        {
            BMP = new Bitmap(panel1.Width, panel1.Height);
            G = Graphics.FromImage(BMP);
            G.TranslateTransform(0, BMP.Height);

            int index = comboBox1.SelectedIndex;
            double xmax = Datas[index].Max(x => x.X);
            double ymax = Datas[index].Max(y => y.Y);
            int W = panel1.Width/* + fix*/;
            int H = panel1.Height/* - fix*/;
            foreach (var item in Datas[index])
            {
                G.DrawString(DD[item.Class], comboBox1.Font, (item.Class == 1 ? Brushes.Red : Brushes.Blue),
                    new Point((int)(((double)item.X / xmax) * (double)(W)) - 5 + fix,
                         (int)(-1 * (((double)item.Y / ymax) * (double)(H)) + 5 + fix)
                    ));
            }
            int Xcount = 10 + 1, Ycount = 10 + 1;
            double xadd = xmax / Xcount;
            double yadd = ymax / Ycount;
            //橫
            G.DrawLine(new Pen(Color.Black, 2f), new Point(0, -fix), new Point(panel1.Width, -fix));
            for (int i = 1; i <= Xcount; i++)
            {
                double indextemp = xadd * i;
                double xtemp = (int)((double)fix + (((double)i / (double)Xcount) * (double)W)) - 5;
                G.DrawString(((int)indextemp).ToString(), comboBox1.Font, Brushes.Black, new Point((int)xtemp, -fix));
            }
            //縱
            G.DrawLine(new Pen(Color.Black, 2f), new Point(fix, 0), new Point(fix, -panel1.Height));
            for (int i = 1; i <= Ycount; i++)
            {
                double indextemp = yadd * i;
                double ytemp = -(int)((double)fix + (((double)i / (double)Ycount) * (double)H)) + 5;
                G.DrawString(((int)indextemp).ToString(), comboBox1.Font, Brushes.Black, new Point(fix - 5 * 4, (int)ytemp));
            }
            panel1.BackgroundImage = BMP;
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ShowAllAllData_Click(object sender, EventArgs e)
        {

        }
    }
    class DataPoint
    {
        public int X, Y, Class;
    }
}
