using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arnoid
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Color[,] OldC = new Color[5, 5];
        Point[] OldP = new Point[5 * 5];
        #region 顏色相關
        bool Black = true;
        /// <summary>
        /// 白
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Black = false;
        }
        /// <summary>
        /// 黑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Black = true;
        }
        /// <summary>
        /// 設定顏色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SetColor(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = (Black ? Color.Black : Color.White);
        }
        #endregion

        bool GoOrBack = true;
        /// <summary>
        /// 執行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //if (GoOrBack)//打亂
            //{
                foreach (var item in this.Controls)
                {
                    if (item is Button)
                    {
                        Button BB =  (Button)item;
                        if (BB.Tag == ((object)"B"))
                        {
                            Point n = new Point(((BB.Location.X - 12) / 56),((BB.Location.Y - 12) / 56));
                            n = NewPoint(n, 5);
                            BB.Location = new Point(n.X*56+12,n.Y*56+12);
                            Application.DoEvents();
                        }
                    }
                }
                /*
           }
           else//復原
            {
                int a = 1;
                Button AA;
                AA = new Button();
                AA.Location = new Point(1, 1);
            }
            GoOrBack = !GoOrBack;*/
        }

        Point NewPoint(Point In, int N)
        {
            Point NP;
            NP = new Point(((1 * In.X + 1 * In.Y) % N ), ((1 * In.X + 2 * In.Y) % N ));
            return NP;
        }
    }

}
