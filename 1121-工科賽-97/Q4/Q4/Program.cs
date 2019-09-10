using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("線性回歸 (Linear Regression)");
                Console.WriteLine("利用最小平方方法讓一條直線來逼近一些點");
                Console.Write("請輸入資料總點數：");
                int N = int.Parse(Console.ReadLine());
                int T, L;
                List<PointF> PL = new List<PointF>();
                for (int i = 0; i < N; i++)
                {
                    Console.Write("請輸入每一點資料的x，y座標[x y]： [");
                    T = Console.CursorTop;
                    L = Console.CursorLeft;
                    string temp = Console.ReadLine();
                    Console.CursorTop = T;
                    Console.CursorLeft = L + temp.Length;
                    Console.WriteLine("]");
                    var a = temp.Split(' ').ToList().ConvertAll<float>(float.Parse).ToList();
                    PL.Add(new PointF(a[0], a[1]));
                }
                Process(PL);
                
            }
        }
        static void Process(List<PointF> PL)
        {
            double Ave_x = PL.Average(x => x.X),
                Ave_y = PL.Average(x => x.Y);
            double Sum_x = PL.Sum(x => x.X);
            double Sum_x2 = 0, Sum_xy = 0;
            PL.ForEach(x => Sum_x2 += (x.X * x.X));
            PL.ForEach(x => Sum_xy += (x.X * x.Y));
            double m = (Sum_xy - Sum_x * Ave_y) / (Sum_x2 - Sum_x * Ave_x);
            double b = Ave_y - m * Ave_x;
            double min_x = Math.Floor(PL.Min(x => x.X));
            double max_x = Math.Ceiling(PL.Max(x => x.X));
            double min_y = m * min_x + b;
            double max_y = m * max_x + b;
            PointF P1 = new PointF((float)min_x, (float)min_y),
                    P2 = new PointF((float)max_x, (float)max_y);
            Console.WriteLine("最小平方值線的回歸係數：");
            Console.WriteLine($"  斜率（m）      ＝　　{m.ToString("0.000")}");
            Console.WriteLine($"  截距（b）      ＝　　{b.ToString("0.000")}");
            Console.WriteLine($"  總資料點數     ＝　　{PL.Count}");
            Console.WriteLine("");
            Form1 f1 = new Form1(P1, P2, PL);
        }
    }
}
