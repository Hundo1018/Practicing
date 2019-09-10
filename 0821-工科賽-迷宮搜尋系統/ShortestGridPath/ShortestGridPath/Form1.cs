using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace ShortestGridPath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Act = new Point[4];
            Act[0] = new Point(-1, 0);
            Act[1] = new Point(1, 0);
            Act[2] = new Point(0, -1);
            Act[3] = new Point(0, 1);
        }
        Maze maze;
        List<List<Point>> OKPath = new List<List<Point>>();
        Point[] Act;
        bool Finded = false;
        private void button1_Click(object sender, EventArgs e)
        {
            maze = new Maze(9, 9, panel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maze.ShowObstacles(int.Parse(textBox1.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            maze.RDMSetST();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Application.DoEvents();
            List<Point> paths = new List<Point>();
            FindPath(-1, maze.S, paths, maze.Obstacles);
            label1.Text = (Finded ? "Yes" : "No");
            if (Finded)
            {
                int min = maze.H * maze.W;
                int index = 0;
                for (int i = 0; i < OKPath.Count; i++)
                {
                    if (OKPath[i].Count <= min)
                    {
                        index = i;
                        min = OKPath[i].Count;
                    }
                }
                for (int i = 0; i < OKPath[index].Count; i++)
                {
                    maze.BTN[OKPath[index][i].X, OKPath[index][i].Y].BackColor = Color.Gray;
                }
                maze.BTN[maze.S.X, maze.S.Y].Text = "S";
                maze.BTN[maze.T.X, maze.T.Y].Text = "T";
            }
        }
        void FindPath(int ACT, Point P, List<Point> Paths, List<Point> OB)
        {
            List<Point> temp = new List<Point>(Paths);
            List<Point> temp2 = new List<Point>(OB);

            int check = maze.WalkCheck(P, temp2);
            if (check == -1)
            {
                return;
            }
            temp.Add(P);
            temp2.Add(P);
            maze.BTN[P.X, P.Y].Text = "P";
            

            Application.DoEvents();
            //Thread.Sleep(250);
            maze.BTN[P.X, P.Y].Text = "";
            maze.BTN[maze.S.X, maze.S.Y].Text = "S";
            maze.BTN[maze.T.X, maze.T.Y].Text = "T";
            if (check == 1)
            {
                OKPath.Add(new List<Point>(temp));
                Finded = true;
            }

            //List<Point> temp = new List<Point>(Paths);
            //List<Point> temp2 = new List<Point>(OB);

            FindPath(0, new Point(P.X - 1, P.Y), temp, temp2);
            FindPath(1, new Point(P.X + 1, P.Y), temp, temp2);
            FindPath(2, new Point(P.X, P.Y - 1), temp, temp2);
            FindPath(3, new Point(P.X, P.Y + 1), temp, temp2);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
    class Maze
    {
        public int[,] Map;
        public Point S, T;
        public  List<Point> Obstacles;
       public int W, H;
        public Button[,] BTN;
        Form1 F = new Form1();
        public int WalkCheck(Point In,List<Point>OB)
        {
            if (In == T)
            {
                return 1;
            }
            if (In.X < 0 || In.Y < 0 || In.X >= H || In.Y >= W || OB.FindIndex(x => x == In) >= 0)
            {
                return -1;
            }
            return 0;
        }


        public Maze(int X, int Y, Panel Z)
        {
            W = X;
            H = Y;
            Map = new int[Y, X];
            BTN = new Button[H, W];
            int zoo = 35;
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    BTN[i, j] = new Button();
                    BTN[i, j].Size = new Size(zoo, zoo);
                    BTN[i, j].Location = new Point(15 + zoo * j, 15 + zoo * i);
                    BTN[i, j].BackColor = Color.White;
                    Z.Controls.Add(BTN[i, j]);
                }
            }
            Z.BorderStyle = BorderStyle.FixedSingle;
        }
        public void ShowObstacles(int Count)
        {
            List<Point> Temp = new List<Point>();
            Random TempRD = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    Temp.Add(new Point(i, j));
                }
            }
            for (int i = 0; i < H * W; i++)
            {
                int RD = TempRD.Next(0, H * W);
                Point temptemp = Temp[RD];
                Temp[RD] = Temp[i];
                Temp[i] = temptemp;
            }
            Obstacles = new List<Point>();
            for (int i = 0; i < Count; i++)
            {
                Obstacles.Add(Temp[i]);
                BTN[Temp[i].X, Temp[i].Y].BackColor = Color.Black;
            }

        }
        public void RDMSetST()
        {
            foreach (var item in BTN)
            {
                item.Text = "";
            }
            Random RDM = new Random(Guid.NewGuid().GetHashCode());
            do
            {
                S = new Point(RDM.Next(0, H), RDM.Next(0, W));
                do
                {
                    T = new Point(RDM.Next(0, H), RDM.Next(0, W));
                } while (T == S);
            } while (Obstacles.FindIndex(x => x == S) != -1 || Obstacles.FindIndex(x => x == T) != -1);

            BTN[S.X, S.Y].Text = "S";
            BTN[S.X, S.Y].ForeColor = Color.Blue;
            BTN[T.X, T.Y].Text = "T";
            BTN[T.X, T.Y].ForeColor = Color.Red;

        }
    }
}

