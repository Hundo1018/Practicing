using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("記憶體管理程式-最適配置法(Best Fit)");
                Console.Write("請輸入記憶體區塊數(<6)：");
                int BC = int.Parse(Console.ReadLine());
                Console.Write("請輸入程序數(<6)：");
                int PC = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("請輸入各區塊大小(<10)---");
                List<Block> BL = new List<Block>();
                List<Process> PL = new List<Process>();

                int L = Console.CursorLeft, T = Console.CursorTop;
                for (int i = 0; i < BC; i++)
                {
                    Console.Write($"區塊{i + 1}：");
                    L = Console.CursorLeft;
                    T = Console.CursorTop;
                    Block temp = new Block((i + 1), int.Parse(Console.ReadLine()));
                    BL.Add(temp);
                    Console.CursorTop = T;
                    Console.CursorLeft = L + 1;
                    Console.Write(",　　");
                }

                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("請輸入各程序所需大小(<10)---");
                for (int i = 0; i < BC; i++)
                {
                    Console.Write($"程序{i + 1}：");
                    L = Console.CursorLeft;
                    T = Console.CursorTop;
                    Process temp = new Process((i + 1), int.Parse(Console.ReadLine()));
                    PL.Add(temp);
                    Console.CursorTop = T;
                    Console.CursorLeft = L + 1;
                    Console.Write(",　　");
                }
                Doit(PL, BL);
                ShowA(PL, BL);
                ShowB(PL, BL);
                Console.WriteLine("");
            }
        }
        static void ShowB(List<Process> PLIn, List<Block> BLIn)
        {
            BLIn = BLIn.OrderBy(x => x.ID).ToList();
            Bitmap bmp = new Bitmap(BLIn.Sum(x => x.Memory) + BLIn.Count + 1 + 6, 5);
            Graphics G = Graphics.FromImage(bmp);
            G.Clear(Color.White);
            Point p = new Point(6, 0);
            for (int i = 0; i < BLIn.Count; i++)
            {
                Size s = new Size(BLIn[i].Memory + 1, 4);
                Rectangle r = new Rectangle(p, s);
                G.DrawRectangle(new Pen(Color.Black, 1), r);
                p.X += s.Width;
            }
            ShowC(bmp);
            ShowD("程序配置前");
            for (int i = 0; i < BLIn.Count; i++)
            {
                for (int j = 1; j <= BLIn[i].Memory; j++)
                {
                    Console.Write($"{j}-");
                }
                Console.CursorLeft += 2;
            }
            Console.WriteLine("");
            ShowC(bmp);
            ShowD("程序配置後");
            Console.CursorTop -= 3;
            for (int i = 0; i < BLIn.Count; i++)
            {
                for (int j = 0; j < BLIn[i].pl.Count; j++)
                {
                    Console.Write($"P{BLIn[i].pl[j].ID}");
                    for (int k = 1; k < BLIn[i].pl[j].Memory; k += 1)
                    {
                        Console.Write("==");
                    }
                    Console.CursorLeft += 2;
                    Console.CursorLeft += BLIn[i].LessMemory * 2;
                }
            }
            Console.CursorTop += 3;
            Console.CursorLeft = 0;
        }
        static void ShowD(string str)
        {
            Console.CursorLeft = 0;
            Console.CursorTop -= 3;
            Console.Write(str);
            Console.CursorLeft += 4;
            Console.CursorTop += 3;
        }
        static void ShowC(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    if (bmp.GetPixel(j, i).GetBrightness() < 0.5f)
                    {
                        Console.Write("●");
                    }
                    else
                    {
                        Console.Write("○");
                    }
                }
                Console.WriteLine("");
            }
        }
        static void ShowA(List<Process> PLIn, List<Block> BLIn)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            PLIn = PLIn.OrderBy(x => x.ID).ToList();
            Console.WriteLine("程序編號　　　　所需大小　　　　區塊編號　　　　區塊大小　　　　剩餘空間");
            for (int i = 0; i < PLIn.Count; i++)
            {
                Console.WriteLine($"{PLIn[i].ID.ToString().PadRight(16)}{PLIn[i].Memory.ToString().PadRight(16)}{PLIn[i].BlockID.ToString().PadRight(16)}{PLIn[i].BlockMemory.ToString().PadRight(16)}{PLIn[i].BlockLessMemory.ToString().PadRight(16)}");
            }
            Console.WriteLine("");
        }
        static void Doit(List<Process> PLIn, List<Block> BLIn)
        {
            PLIn = PLIn.OrderByDescending(x => x.Memory).ToList();
            for (int i = 0; i < PLIn.Count; i++)
            {
                BLIn = BLIn.OrderBy(x => x.LessMemory).ToList();
                for (int j = 0; j < BLIn.Count; j++)
                {
                    if (BLIn[j].LessMemory >= PLIn[i].Memory)
                    {
                        BLIn[j].Add(PLIn[i]);
                    }
                }
            }
        }
    }
    public class Process
    {
        public int ID;
        public int Memory;
        public int BlockID;
        public int BlockMemory;
        public int BlockLessMemory;
        public Process(int id, int memory)
        {
            ID = id;
            Memory = memory;
        }
    }
    class Block
    {
        public int ID;
        public int Memory;
        public int LessMemory;
        public List<Process> pl;
        public Block(int id, int memory)
        {
            ID = id;
            Memory = memory;
            LessMemory = memory;
            pl = new List<Process>();
        }
        public void Add(Process P)
        {
            P.BlockID = ID;
            pl.Add(P);
            LessMemory -= P.Memory;
            foreach (var item in pl)
            {
                item.BlockMemory = Memory;
                item.BlockLessMemory = LessMemory;
            }
        }
    }
}
