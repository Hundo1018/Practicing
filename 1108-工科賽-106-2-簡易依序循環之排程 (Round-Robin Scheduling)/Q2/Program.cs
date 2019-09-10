using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    class Program
    {
        static List<Process> pl = new List<Process>();
        static void Main(string[] args)
        {
            Console.Write("請輸入行程processes數量(MAX 5)：");
            
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("請輸入每個行程的執行時間burst_time...");
            //List<int> tp = new List<int>() { 21, 3, 9 };
            for (int i = 1; i <= p; i++)
            {
                Console.Write($"P{i}：");
                //while (true)
                //{

                //}
                pl.Add(new Process(i, int.Parse(Console.ReadLine())));
            }

            
            Console.WriteLine("");
            Console.Write("請輸入時間配額time_quantum：");
            int time_qua = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            int timeline = 0;
            Console.WriteLine("各行程processes執行順序為...");
            while (pl.Sum(x => x.work) > 0)
            {
                for (int i = 0; i < p; i++)
                {
                    if (pl[i].work > 0)
                        Console.Write(timeline.ToString().PadLeft(2, '0') + $"{pl[i].tag}   ");
                    for (int j = 0; pl[i].work > 0 && j < time_qua; j++)
                    {
                        timeline++;
                        pl[i].work--;
                        foreach (var item in pl)
                        {
                            if (pl[i].tag != item.tag && item.work != 0)
                            {
                                item.wait++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"{timeline.ToString().PadLeft(2, '0')}");
            Console.WriteLine("");
            for (int i = 0; i < pl.Count; i++)
            {
                Console.Write($"{pl[i].tag}等待時間：{pl[i].wait}　");
            }
            while (true)
            {

            }
        }
    }
    class Process
    {
        public string tag;
        public int work;
        public int wait;
        public Process(int t, int w)
        {
            tag = $"P{t}";
            work = w;
        }
    }
}
