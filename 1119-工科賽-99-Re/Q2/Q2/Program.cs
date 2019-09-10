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
                int N = int.Parse(Console.ReadLine());
                Console.WriteLine(Find(N));

            }
        }
        static int Find(int N)
        {
            int index = 0;
            int count = 1;
            int M = 7;
            while (true)
            {
                index = 0;
                count = 1;
                List<int> Block = Enumerable.Range(1, N).ToList();
                Block.RemoveAt(0);
                index++;
                count++;
                while (true)
                {
                    index %= Block.Count;

                    if (Block.Count == 1)
                    {
                        if (Block[0] == 13)
                            return M;
                        else
                            break;
                    }
                    if (count == M)
                    {
                        if (Block[index] == 13)
                            break;
                        Block.RemoveAt(index--);
                        count = 0;
                    }
                    count++;
                    index++;
                }
                M++;
            }
        }
    }
}
