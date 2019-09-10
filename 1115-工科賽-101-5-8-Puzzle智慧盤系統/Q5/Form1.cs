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
namespace Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GenAnsList();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    TBX[i, j] = new TextBox()
                    {
                        Text = "",
                        Size = new Size(22, 22),
                        Location = new Point(12 + j * 25, 12 + i * 25)
                    };
                    Controls.Add(TBX[i, j]);
                }
            }
        }
        TextBox[,] TBX = new TextBox[3, 3];
        int[,] Matrix = new int[3, 3];
        private void button1_Click(object sender, EventArgs e)
        {
            List<int> TempL = new List<int>();
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 1; i < 9; i++) TempL.Add(i);
            for (int i = 0; i < 8; i++)
            {
                int index = rdm.Next(0, 8);
                int temp = TempL[i];
                TempL[i] = TempL[index];
                TempL[index] = temp;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!(i == 1 && j == 1))
                    {
                        Matrix[i, j] = TempL.First();
                        TempL.RemoveAt(0);
                    }
                }
            }
            ShowM(Matrix);
        }
        void ShowM(int[,] now)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    TBX[i, j].Text = now[i, j].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process();
            ShowM(AnsList.Last().Last());
            Application.DoEvents();
            Thread.Sleep(100);
        }
        void Process()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Matrix[i, j] = int.Parse(TBX[i, j].Text);
                }
            }
            int step = 0;
            while (true)
            {
                Recu(Matrix, new Point(1, 1), new Point(1, 1), new List<int[,]>(), step);
                if (AnsList.Count > 0) break;
                step += 1;
            }
            textBox1.Text = step.ToString();
        }
        List<List<int[,]>> AnsList = new List<List<int[,]>>();
        List<int[,]> WrongPath = new List<int[,]>();
        bool find = false;

        void Recu(int[,] NowPuzzle, Point P, Point MoveTo, List<int[,]> StatePath, int step)
        {
            if (find) return;
            if (MoveTo.X < 0 || MoveTo.X > 2 || MoveTo.Y < 0 || MoveTo.Y > 2 || step < 0)
            {
                return;
            }
            int temp = NowPuzzle[P.Y, P.X];
            NowPuzzle[P.Y, P.X] = NowPuzzle[MoveTo.Y, MoveTo.X];
            NowPuzzle[MoveTo.Y, MoveTo.X] = temp;

            P = MoveTo;

            if (Contains(StatePath, NowPuzzle))
            {
                return;
            }
            WrongPath.Add((int[,])(NowPuzzle).Clone());
            StatePath.Add((int[,])(NowPuzzle).Clone());
            if ((P.X == 1 && P.Y == 1) && Contains(CheckList, NowPuzzle))
            {
                AnsList.Add(StatePath);
                find = true;
                return;
            }
            Recu((int[,])NowPuzzle.Clone(), new Point(P.X, P.Y), new Point(P.X + 1, P.Y), new List<int[,]>(StatePath), step - 1);
            Recu((int[,])NowPuzzle.Clone(), new Point(P.X, P.Y), new Point(P.X, P.Y + 1), new List<int[,]>(StatePath), step - 1);
            Recu((int[,])NowPuzzle.Clone(), new Point(P.X, P.Y), new Point(P.X - 1, P.Y), new List<int[,]>(StatePath), step - 1);
            Recu((int[,])NowPuzzle.Clone(), new Point(P.X, P.Y), new Point(P.X, P.Y - 1), new List<int[,]>(StatePath), step - 1);
        }

        string tostr(int[,] ina)
        {
            string temp = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    temp += ina[i, j].ToString();
                }
            }
            return temp;
        }

        bool Contains(List<int[,]> A, int[,] B)
        {
            List<string> NA = new List<string>();
            for (int k = 0; k < A.Count; k++)
            {
                NA.Add(tostr(A[k]));
            }
            string NB = tostr(B);
            return (NA.Contains(NB));
        }

        List<int[,]> CheckList = new List<int[,]>();
        void GenAnsList()
        {
            CheckList = new List<int[,]>();
            int[,] ans = new int[3, 3] {
                { 1, 2, 3 },
                { 8, 0, 4 },
                { 7, 6, 5 } };
            for (int k = 0; k < 8; k++)
            {
                ans = RingAdd(ans);
                CheckList.Add((int[,])ans.Clone());
            }
            ans = new int[3, 3] {
                { 3, 2, 1 },
                { 4, 0, 8 },
                { 5, 6, 7 } };
            for (int k = 0; k < 8; k++)
            {
                ans = RingAdd(ans);
                CheckList.Add((int[,])ans.Clone());
            }
        }
        int[,] RingAdd(int[,] A)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!(i == 1 && j == 1))
                    {
                        A[i, j] %= 8;
                        A[i, j]++;
                    }
                }
            }
            return A;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Process();
            for (int i = 0; i < AnsList.Last().Count; i++)
            {
                ShowM(AnsList.Last()[i]);

                Application.DoEvents();
                Thread.Sleep(500);
            }
            
        }
    }
}
