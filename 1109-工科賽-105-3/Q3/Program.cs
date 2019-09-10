using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\r");
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("請選擇操作項目：");
                    Console.WriteLine("      <1>輸入二點座標<x1,y1>, <x2,y2>繪一線：");
                    Console.WriteLine("      <2>輸入三個頂點座標<x1,y1>, <x2,y2>, <x3,y3>繪三角形：");
                    Console.WriteLine("      <3>上題三角形水平翻轉：");
                    int mode = int.Parse(Console.ReadLine());
                    switch (mode)
                    {
                        case 1:
                            A();
                            break;
                        case 2:
                            B();
                            break;
                        case 3:
                            Reverse();
                            break;
                        default:
                            break;
                    }
                    Show();
                    Console.WriteLine("繼續：請按1，結束：請按0：");
                    if (int.Parse(Console.ReadLine()) == 0)
                    {
                        return;
                    }
                }
            }
        }
        static bool[,] matrix;
        static double x1, y1, x2, y2, x3, y3, m, xmax, ymax;
        static void A()
        {
            Console.Write("x1,y1 x2,y2:");
            string[] tempstr = Console.ReadLine().Split(' ');
            x1 = double.Parse(tempstr[0]);
            y1 = double.Parse(tempstr[1]);
            x2 = double.Parse(tempstr[2]);
            y2 = double.Parse(tempstr[3]);
            xmax = Math.Max(x1, x2) + 1 + Math.Min(x1, Math.Min(x2, x3)); ;
            ymax = Math.Max(y1, y2) + 1;
            matrix = new bool[(int)xmax, (int)ymax];
            DrawLine(x1, x2, y1, y2, matrix);
            return;
        }
        static void B()
        {
            Console.Write("x1,y1 x2,y2 x3,y3:");
            string[] tempstr = Console.ReadLine().Split(' ');
            x1 = double.Parse(tempstr[0]);
            y1 = double.Parse(tempstr[1]);
            x2 = double.Parse(tempstr[2]);
            y2 = double.Parse(tempstr[3]);
            x3 = double.Parse(tempstr[4]);
            y3 = double.Parse(tempstr[5]);
            xmax = Math.Max(x1, Math.Max(x2, x3)) + 1 + Math.Min(x1, Math.Min(x2, x3));
            ymax = Math.Max(y1, Math.Max(y2, y3)) + 1;
            matrix = new bool[(int)xmax, (int)ymax];
            DrawLine(x1, x2, y1, y2, matrix);
            DrawLine(x2, x3, y2, y3, matrix);
            DrawLine(x1, x3, y1, y3, matrix);
            return;
        }
        static void Reverse()
        {
            bool[,] nm = new bool[(int)xmax, (int)ymax];
            for (int i = 0; i < ymax; i++)
            {
                int index = 0;
                for (int j = (int)xmax - 1; j >= 0; j--)
                {
                    nm[j, i] = matrix[index++, i];
                }
            }
            matrix = nm;
        }
        static void DrawLine(double x1, double x2, double y1, double y2, bool[,] matrix)
        {
            if (x2 < x1)
            {
                double temp;
                temp = x1;
                x1 = x2;
                x2 = temp;
                temp = y1;
                y1 = y2;
                y2 = temp;
            }
            m = (y2 - y1) / (x2 - x1);
            int step = (int)((y2 - y1) < 0 ? -1 : 1);
            if (x2 - x1 == 0)//沒有斜率(直線)
            {
                int temp = (int)y1;
                matrix[(int)x1, temp] = true;
                while (temp != y2)
                {
                    temp += step;
                    matrix[(int)x1, temp] = true;
                }
            }
            else
            {
                double y = y1;
                matrix[(int)x1, (int)y] = true;
                for (int x = (int)x1; x < x2; x++)
                {
                    int tempy = (int)y;
                    matrix[x, (int)y] = true;
                    y += m;
                    for (int i = (int)tempy; i < y - 1; i++)
                    {
                        if (i > y2) break;
                        matrix[x, i] = true;
                    }
                    for (int i = (int)(tempy - 1); i >= y; i--)
                    {
                        if (i < y2) break;
                        matrix[x + 1, i] = true;
                    }
                }
            }
        }
        static void Show()
        {
            for (double i = ymax - 1; i >= 0; i--)
            {
                for (double j = 0; j < xmax; j++)
                {
                    if (matrix[(int)j, (int)i]) Console.Write("●");
                    else Console.Write("○");
                }
                Console.WriteLine("");
            }
        }
    }
}
