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
namespace 廣度與深度走迷宮
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AutoSize = true;
            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    var temp = sr.ReadLine().Split(' ').ToList();
                    temp.RemoveAll(x => x == "");
                    List<int> line = temp.ConvertAll<int>(int.Parse).ToList();
                    Map.Add(line.ToList());
                }
            }
            W = Map[0].Count;
            H = Map.Count;
            BTNS = new Button[W, H];
            for (int i = 0; i < Map.Count; i++)
            {
                for (int j = 0; j < Map[i].Count; j++)
                {
                    Color c = Color.White;
                    switch ((Map[i][j]))
                    {
                        case 0:
                            c = Color.White;
                            break;
                        case 1:
                            c = Color.Black;
                            break;
                        case 2:
                            Start = new Point(i, j);
                            c = Color.Blue;
                            break;
                        case 9:
                            End = new Point(i, j);
                            c = Color.Green;
                            break;
                        default:
                            break;
                    }
                    BTNS[i, j] = new Button()
                    {
                        Location = new Point(button1.Left + j * 55, button1.Bottom + 50 + i * 55),
                        Size = new Size(50, 50),
                        BackColor = c
                    };
                    this.Controls.Add(BTNS[i, j]);
                }
            }
        }
        Button[,] BTNS;
        string filepath = "Map.txt";
        List<List<int>> Map = new List<List<int>>();
        Point Start, End;
        int W, H;
        int Delay = 0;
        bool StopAtTouchEndPoint = false;
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            StopAtTouchEndPoint = checkBox2.Checked;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        void Distinct(List<List<Point>> PLL, List<Point> PL)
        {
            List<string> CheckList = new List<string>();
            List<string> CheckList2 = new List<string>();
            for (int i = 0; i < PLL.Count; i++)
            {
                string temp2 = $"{i}S";
                string temp = $"";
                foreach (var item in PLL[i])
                {
                    temp += item.ToString();
                    temp2 += item.ToString();
                }
                CheckList.Add(temp);
                CheckList2.Add(temp2);
            }
            CheckList = CheckList.Distinct().ToList();

            List<int> IndexList = new List<int>();

            CheckList.ForEach(x => { IndexList.Add(CheckList2.FindIndex(y => x == y.Split('S')[1])); });
            var a = PLL.ToList();
            var b = PL.ToList();
            PLL.Clear();
            PL.Clear();
            foreach (var item in IndexList)
            {
                PLL.Add(a[item]);
                PL.Add(b[item]);
            }

        }


        #region 圖像化顯示
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            flash = checkBox1.Checked;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = $"顯示延時{trackBar1.Value}";
            Delay = trackBar1.Value;
        }
        bool flash = false;
        void refresh()
        {
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    Color c = Color.White;
                    switch ((Map[i][j]))
                    {
                        case 0:
                            c = Color.White;
                            break;
                        case 1:
                            c = Color.Black;
                            break;
                        case 2:
                            Start = new Point(i, j);
                            c = Color.Blue;
                            break;
                        case 9:
                            End = new Point(i, j);
                            c = Color.Green;
                            break;
                        default:
                            break;
                    }
                    BTNS[i, j].BackColor =c;
                }
            }
        }
        void Draw(List<Point> DrawPath)
        {
            foreach (var p in DrawPath)
            {
                BTNS[p.X, p.Y].BackColor = Color.Red;
                Application.DoEvents();
                Thread.Sleep(Delay);
            }
        }
        #endregion
        #region 深度優先搜尋
        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
            DFS_Main();
        }
        void DFS_Main()
        {
            DFS_FinalPath = new List<List<Point>>();
            DFS_Recu(Start, new List<Point>());
        }
        void DFS_Recu(Point now, List<Point> NowPath)
        {
            if (StopAtTouchEndPoint && DFS_FinalPath.Count > 0)
                return;
            if (now.X < 0 || now.X >= W || now.Y < 0 || now.Y >= H) return;
            if (Map[now.X][now.Y] == 1) return;
            bool JumpFlag = false;
            NowPath.ForEach(x => { if (x.X == now.X && x.Y == now.Y) JumpFlag = true; });//走過了
            if (JumpFlag) return;


            if (flash) refresh();
            Draw(NowPath);
            if (Map[now.Y][now.X] == 0 && now.Y == End.Y && now.X == End.X)//終點
            {
                NowPath.Add(new Point(now.X, now.Y));
                DFS_FinalPath.Add(NowPath.ToList());
                if (flash) refresh();
                Draw(NowPath);
            }
            else//不是終點
            {
                NowPath.Add(now);

                DFS_Recu(new Point(now.X + 1, now.Y), NowPath.ToList());
                DFS_Recu(new Point(now.X, now.Y + 1), NowPath.ToList());
                DFS_Recu(new Point(now.X - 1, now.Y), NowPath.ToList());
                DFS_Recu(new Point(now.X, now.Y - 1), NowPath.ToList());

                DFS_Recu(new Point(now.X + 1, now.Y + 1), NowPath.ToList());
                DFS_Recu(new Point(now.X + 1, now.Y - 1), NowPath.ToList());
                DFS_Recu(new Point(now.X - 1, now.Y + 1), NowPath.ToList());
                DFS_Recu(new Point(now.X - 1, now.Y - 1), NowPath.ToList());
            }

        }
        List<List<Point>> DFS_FinalPath = new List<List<Point>>();
        #endregion
        #region 廣度優先搜尋
        #region BFS廣度優先搜尋1
        List<List<Point>> BFS_FinalPath = new List<List<Point>>();
        List<Point> BFS_StartPoint = new List<Point>();
        List<Point> BFS_TempStartPoint = new List<Point>();
        List<List<Point>> BFS_TempNowPath = new List<List<Point>>();
        List<List<Point>> BFS_NowPath = new List<List<Point>>();
        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
            BFS_Main();
        }
        void BFS_Main()
        {
            BFS_NowPath = new List<List<Point>>();
            BFS_StartPoint = new List<Point>();

            BFS_NowPath.Add(new List<Point>());
            BFS_StartPoint.Add(new Point(0, 0));

            for (int i = 0; i < W * H; i++)
            {
                for (int j = 0; j < BFS_StartPoint.Count; j++)
                {
                    BFS_Recu(new Point(BFS_StartPoint[j].X, BFS_StartPoint[j].Y), 1, BFS_NowPath[j].ToList());
                }
                BFS_NowPath = BFS_TempNowPath.ToList();
                BFS_StartPoint = BFS_TempStartPoint.ToList();
                Distinct(BFS_NowPath, BFS_StartPoint);
                for (int j = 0; j < BFS_NowPath.Count; j++)
                {
                    if (flash) refresh();
                    Application.DoEvents();
                    Thread.Sleep(Delay);
                    Draw(BFS_NowPath[j].ToList());
                }
            }
        }
        void BFS_Recu(Point now, int Step, List<Point> NowPath)
        {
            if (StopAtTouchEndPoint && BFS_FinalPath.Count > 0) return;
            if (now.X < 0 || now.X >= W || now.Y < 0 || now.Y >= H) return;
            if (Map[now.X][now.Y] == 1) return;
            if (Map[now.X][now.Y] == 0 && now.Y == End.Y && now.X == End.X)//終點
            {
                NowPath.Add(new Point(now.X, now.Y));
                BFS_FinalPath.Add(NowPath.ToList());
            }
            bool JumpFlag = false;
            NowPath.ForEach(x => { if (x.X == now.X && x.Y == now.Y) JumpFlag = true; });//走過了
            if (JumpFlag) return;
            else//不是終點
            {
                if (Step < 0)//走完這層了
                {
                    BFS_TempStartPoint.Add(new Point(now.X, now.Y));
                    BFS_TempNowPath.Add(NowPath.ToList());
                }
                else//還沒走完這層
                {
                    NowPath.Add(now);
                    BFS_Recu(new Point(now.X + 1, now.Y), Step - 1, NowPath.ToList());
                    BFS_Recu(new Point(now.X, now.Y + 1), Step - 1, NowPath.ToList());
                    BFS_Recu(new Point(now.X - 1, now.Y), Step - 1, NowPath.ToList());
                    BFS_Recu(new Point(now.X, now.Y - 1), Step - 1, NowPath.ToList());

                    BFS_Recu(new Point(now.X + 1, now.Y + 1), Step - 1, NowPath.ToList());
                    BFS_Recu(new Point(now.X + 1, now.Y - 1), Step - 1, NowPath.ToList());
                    BFS_Recu(new Point(now.X - 1, now.Y + 1), Step - 1, NowPath.ToList());
                    BFS_Recu(new Point(now.X - 1, now.Y - 1), Step - 1, NowPath.ToList());
                }
            }
        }
        #endregion
        
        #region 洪水
        private void button4_Click(object sender, EventArgs e)
        {
            refresh();
            M();
        }
        List<Point> StartPoint = new List<Point>();//開始
        List<Point> PastPoint = new List<Point>();//從前走過的路
        bool Touched = false;
        void M()
        {
            StartPoint.Add(new Point(0, 0));
            while (!Touched)
            {
                while (StartPoint.Count > 0)
                {
                    R(StartPoint[0], 1);
                    StartPoint.RemoveAt(0);
                    Draw(PastPoint.ToList());
                }
            }
        }
        void R(Point now, int Step)
        {
            if (now.X >= W || now.X < 0 || now.Y < 0 || now.Y >= H || Touched) return;
            if (Map[now.X][now.Y] == 1)
            {
                return;
            }
            if (now.X == End.X && now.Y == End.Y)
            {
                Touched = true;
                return;
            }
            else
            {
                bool jump = false;
                PastPoint.ForEach(x => { if (x.X == now.X && x.Y == now.Y) jump = true; });
                if (jump) return;
                if (Step <= 0)
                {
                    StartPoint.Add(new Point(now.X, now.Y));
                }
                else
                {
                    PastPoint.Add(new Point(now.X, now.Y));
                    R(new Point(now.X + 1, now.Y), Step - 1);
                    R(new Point(now.X, now.Y + 1), Step - 1);
                    R(new Point(now.X - 1, now.Y), Step - 1);
                    R(new Point(now.X, now.Y - 1), Step - 1);
                }
            }
        }
        #endregion
        #endregion
    }
}
