using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("請選擇操作項目");
                Console.WriteLine("       <1>輸入模型資料：");
                Console.WriteLine("       <2>計算平均相似度");
                Console.WriteLine("       <3>顯示各資料相似度");
                Console.Write("請選擇：");
                int mod = int.Parse(Console.ReadLine());
                Console.WriteLine("　");
                switch (mod)
                {
                    case 1:
                        A();
                        break;
                    case 2:
                        B();
                        break;
                    case 3:
                        C();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("");
                Console.Write("繼續：請按1，結束：請按0：");
                int con = int.Parse(Console.ReadLine());
                if (con == 1) continue;
                else return;
            }
        }
        static List<modeldata> MDL;
        static void A()
        {
            bool debug = true;
            MDL = new List<modeldata>();
            string xA = "";
            string t = "";
            string m = "";
            string b = "";
            using (StreamReader sr = new StreamReader("data.txt"))
            {
                xA = sr.ReadLine();
                t = sr.ReadLine();
                m = sr.ReadLine();
                b = sr.ReadLine();
            }
            List<float> xdl = xA.Split(' ').ToList().ConvertAll<float>(float.Parse).ToList();
            List<float> tdl = t.Split(' ').ToList().ConvertAll<float>(float.Parse).ToList();
            List<float> mdl = m.Split(' ').ToList().ConvertAll<float>(float.Parse).ToList();
            List<float> bdl = b.Split(' ').ToList().ConvertAll<float>(float.Parse).ToList();
            for (int i = 0; i < xdl.Count; i++)
            {
                MDL.Add(new modeldata(xdl[i], tdl[i], mdl[i], bdl[i]));
            }
            Console.WriteLine($"輸入模型資料，總筆數為{xdl.Count}");
            Console.WriteLine("");
            Console.Write("　　序列< x軸>：");
            xdl.ForEach(x => Console.Write(x.ToString().PadLeft(3)));
            Console.WriteLine("");
            Console.Write("數值串列<上限>：");
            tdl.ForEach(x => Console.Write(x.ToString().PadLeft(3)));
            Console.WriteLine("");
            Console.Write("數值串列<中心>：");
            mdl.ForEach(x => Console.Write(x.ToString().PadLeft(3)));
            Console.WriteLine("");
            Console.Write("數值串列<下限>：");
            bdl.ForEach(x => Console.Write(x.ToString().PadLeft(3)));
            Console.WriteLine("");
        }
        static void B()
        {
            Console.Write("請輸入「資料串列」檔名：");
            string path = Console.ReadLine();
            Console.WriteLine($"已開啟「資料串列」檔名：{path}");
            Console.WriteLine("");
            string data = "";
            using (StreamReader sr = new StreamReader(path))
            {
                data = sr.ReadLine();
            }
            List<float> idl = data.Split(' ').ToList().ConvertAll<float>(float.Parse);
            for (int i = 0; i < MDL.Count; i++)
            {
                MDL[i].Input(idl[i]);
            }
            Console.WriteLine("");
            float ave = MDL.Average(x => x.likerate);
            Console.WriteLine($"平均相似度為 {ave.ToString("0.000000")}");
        }
        static void C()
        {
            Console.WriteLine("");
            MDL.ForEach(x => Console.Write(x.XA.ToString().PadLeft(5)));
            Console.WriteLine("");
            MDL.ForEach(x =>Console.Write( x.likerate.ToString("0.00").PadLeft(5)));
            Console.WriteLine("");
        }
    }
    class modeldata
    {
        public float XA = 0;
        float Max = 0;
        float Mid = 0;
        float Min = 0;
        float input = 0;
        public float likerate = 0;
        public modeldata(float xa, float max, float mid, float min)
        {
            XA = xa;
            Max = max;
            Mid = mid;
            Min = min;
        }
        public void Input(float inp)
        {
            input = inp;
            if (input - Mid > 0)
            {
                likerate = 1 - ((input - Mid) / (Max - Mid));
            }
            else if (input - Mid < 0)
            {
                likerate = ((input - Min) / (Mid - Min));
            }
            else if (input == Mid)
            {
                likerate = 1;
            }
            if (likerate < 0) likerate = 0;
        }
    }
}
