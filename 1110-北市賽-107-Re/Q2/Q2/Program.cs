using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("請輸入N人數：");
                int N = int.Parse(Console.ReadLine());
                Console.Write("請輸入M報數：");
                int M = int.Parse(Console.ReadLine());
                Console.Write("淘汰順序：");
                List<int> PL = Enumerable.Range(1, N).ToList();
                
                int index = 0, count =1;
                while (PL.Count > 1)
                {
                    index %= PL.Count;
                    if (count == M)
                    {
                        Console.Write($"{PL[index]} ");
                        PL.RemoveAt(index--);
                        count = 0;
                    }
                    index++;
                    count++;
                }
                Console.WriteLine("");
                Console.WriteLine($"最後贏家：{PL[0]}");
            }
        }
    }
}
