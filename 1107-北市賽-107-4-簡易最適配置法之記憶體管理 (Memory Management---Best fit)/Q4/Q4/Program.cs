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
        static List<Memory> Memoryl = new List<Memory>();
        static List<Process> Processl = new List<Process>();
        static void Main(string[] args)
        {
            //test();
            //Draw(false);
            //Draw(true);
            int MC = -1;
            int PC = -1;
            Console.WriteLine("簡易最適記憶體配置(Best-fit):");
            int L = Console.CursorLeft;
            int T = Console.CursorTop;
            Console.Write("請輸入記憶體區塊數量(<6):");
            while (MC <= 0) MC = int.Parse(Console.ReadLine());
            Console.Write("請輸入程序數量(<6)");
            while (PC <= 0) PC = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            for (int i = 0; i < MC; i++)
            {
                Memoryl.Add(new Memory(-1, i));
            }
            for (int i = 0; i < PC; i++)
            {
                Processl.Add(new Process(-1, i, -1));
            }
            Console.WriteLine("請依序輸入記憶體區塊大小(<10)---");
            for (int i = 0; i < MC; i++)
            {
                string Ti = $"區塊{i + 1}:";
                Console.Write($"{Ti}");
                L = Console.CursorLeft;
                T = Console.CursorTop;
                while (Memoryl[i].len < 0)
                {
                    Memoryl[i] = new Memory(int.Parse(Console.ReadLine()), i + 1);
                }
                Console.SetCursorPosition(L + 1, T);
                Console.Write(",");
            }
            Console.WriteLine("\r\n");

            Console.WriteLine("請依序輸入程序大小(<10)---");
            for (int i = 0; i < PC; i++)
            {
                string Ti = $"程序{i + 1}:";
                Console.Write($"{Ti}");
                L = Console.CursorLeft;
                T = Console.CursorTop;
                while (Processl[i].count < 0)
                {
                    Processl[i] = new Process(i + 1, int.Parse(Console.ReadLine()), 1);
                }
                Console.SetCursorPosition(L + 1, T);
                Console.Write(",");
            }

            Memoryl = Memoryl.OrderBy(x => x.len).ToList();
            Processl = Processl.OrderBy(x => x.len).ToList();
            Processl.Reverse();

            for (int i = 0; i < Processl.Count; i++)
            {
                for (int j = 0; j < Memoryl.Count; j++)
                {
                    if (Memoryl[j].lesslen >= Processl[i].len && Processl[i].count >= 1)
                    {
                        Memoryl[j].ADD(Processl[i]);
                    }
                }
            }


            Console.WriteLine("");
            Writedata();


            Memoryl = Memoryl.OrderBy(x => x.id).ToList();
            Console.WriteLine("");
            Draw(false);
            Console.WriteLine("");
            Draw(true);
            //T = Console.CursorTop;
            //L = Console.CursorLeft;
            fillblock();

            while (true) { }
        }
        static void Writedata()
        {
            Console.WriteLine("");
            Console.WriteLine("程序編號　　　　所需大小　　　　區塊編號　　　　區塊大小　　　　剩餘空間");
            string temp = "";
            Processl = Processl.OrderBy(x => x.id).ToList();
            for (int i = 0; i < Processl.Count; i++)
            {
                temp = "";
                temp += Processl[i].id.ToString().PadRight(16);
                temp += Processl[i].len.ToString().PadRight(16);
                temp += Processl[i].forwho.ToString().PadRight(16);
                foreach (var item in Memoryl)
                {
                    if (item.id == Processl[i].forwho)
                    {
                        temp += item.len.ToString().PadRight(16);
                    }
                }
                foreach (var item in Memoryl)
                {
                    if (item.id == Processl[i].forwho)
                    {
                        temp += item.lesslen.ToString().PadRight(16);
                    }
                }
                Console.WriteLine(temp);
            }
        }
        static void Draw(bool aft)
        {
            int we = Memoryl.Sum(x => x.len) + Memoryl.Count + 3;
            Bitmap bmp = new Bitmap(we, 7);
            Graphics G = Graphics.FromImage(bmp);
            G.Clear(Color.White);
            Point start = new Point(1, 1);
            for (int i = 0; i < Memoryl.Count; i++)
            {
                Rectangle rtg = new Rectangle(start, new Size(Memoryl[i].len + 1, 4));
                G.DrawRectangle(new Pen(Color.Black, 1f), rtg);
                start.X += rtg.Width;
            }
            string STR = "配置程序前 ";
            if (aft) STR = "配置程序後 ";
            for (int y = 0; y < bmp.Height; y++)
            {
                if (y == 3)
                {
                    Console.Write(STR);
                }
                else Console.Write("".PadLeft(STR.Length * 2 - 1));
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (bmp.GetPixel(x, y).GetBrightness() < 0.5)
                    {
                        Console.Write("█");
                    }
                    else
                    {
                        Console.Write("　");
                    }
                }
                Console.WriteLine("");
            }
        }
        static void fillblock()
        {
            Console.CursorTop -= 4;
            Console.CursorLeft += 15;
            int t = Console.CursorTop;
            int l = Console.CursorLeft;
            for (int i = 0; i < Memoryl.Count; i++)
            {
                if (Memoryl[i].PL.Count > 0)
                {
                    for (int j = 0; j < Memoryl[i].PL.Count; j++)
                    {
                        for (int k = 0; k < Memoryl[i].PL[j].len; k++)
                        {
                            if (k == 0)
                            {
                                Console.Write($"P{Memoryl[i].PL[j].id}");
                            }
                            else
                            {
                                Console.Write("==");
                            }
                        }
                    }
                }
                Console.CursorLeft += (Memoryl[i].lesslen * 2 + 2);
            }

            Console.CursorTop = t-4;
            Console.CursorLeft = l;
            writenumber();

        }
        static void writenumber()
        {
            for (int i = 0; i < Memoryl.Count; i++)
            {
                if (Memoryl[i].PL.Count > 0)
                {
                    for (int j = 0; j < Memoryl[i].PL.Count; j++)
                    {
                        for (int k = 0; k < Memoryl[i].len; k++)
                        {
                            Console.Write($"{k + 1}-");
                        }
                    }
                }
                Console.CursorLeft += (+2);
            }
        }
        static void test()
        {
            Memoryl.Add(new Memory() { id = 0, len = 7, lesslen = 7 });
            Memoryl.Add(new Memory() { id = 1, len = 5, lesslen = 5 });
            Memoryl.Add(new Memory() { id = 2, len = 9, lesslen = 9 });
            Processl.Add(new Process(0, 5, 1));
            Processl.Add(new Process(1, 6, 1));
            Processl.Add(new Process(2, 8, 1));

            Memoryl = Memoryl.OrderBy(x => x.len).ToList();
            Processl = Processl.OrderBy(x => x.len).ToList();
            Processl.Reverse();

            for (int i = 0; i < Processl.Count; i++)
            {
                for (int j = 0; j < Memoryl.Count; j++)
                {
                    if (Memoryl[j].lesslen >= Processl[i].len && Processl[i].count >= 1)
                    {
                        Memoryl[j].ADD(Processl[i]);
                    }
                }
            }
            int we = Memoryl.Sum(x => x.len) + Memoryl.Count + 3;
            Bitmap bmp = new Bitmap(we, 7);
            Graphics G = Graphics.FromImage(bmp);
            G.Clear(Color.White);
            Point start = new Point(1, 1);
            for (int i = 0; i < Memoryl.Count; i++)
            {
                Rectangle rtg = new Rectangle(start, new Size(Memoryl[i].len + 1, 4));
                G.DrawRectangle(new Pen(Color.Black, 1f), rtg);
                start.X += rtg.Width ;
            }
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (bmp.GetPixel(x, y).GetBrightness() < 0.5) Console.Write("●");
                    else Console.Write("○");
                }
                Console.WriteLine("");
            }
        }
    }
    class Process
    {
        public int len;
        public int id;
        public int count;
        public Process(int i, int l, int c)
        {
            id = i;
            len = l;
            count = c;
        }
        public int forwho = -1;
        public Process(Process i)
        {
            len = i.len;
            id = i.id;
            count = i.count;
        }
    }
    class Memory
    {
        public int len;
        public int lesslen;
        public int id;
        public List<Process> PL = new List<Process>();
        public Memory()
        {

        }
        public Memory(int l, int i)
        {
            len = l;
            lesslen = l;
            id = i;
            PL = new List<Process>();
        }
        public void ADD(Process i)
        {
            PL.Add(new Process(i));
            lesslen -= i.len;
            i.count -= 1;
            i.forwho = id;
        }
    }
}
