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
        public static List<People> PPL = new List<People>();
        public static Dictionary<string, Project> PJ_Dic = new Dictionary<string, Project>();
        static void Main(string[] args)
        {
            string[] party = "大隊接力,一顆球的距離,天旋地轉,滾大球袋鼠跳,牽手同心".Split(',');
            string[] person = "100公尺,400公尺接力,800公尺,跳高".Split(',');
            char ac = 'a';
            for (int i = 0; i < 5; i++)
            {
                PJ_Dic.Add(party[i], new Project(party[i], 1));
                PJ_Dic.Add(ac.ToString(), new Project(party[i], 1));
                ac++;
            }
            for (int i = 0; i < 4; i++)
            {
                PJ_Dic.Add(person[i], new Project(person[i], 1));
                PJ_Dic.Add(ac.ToString(), new Project(person[i], 0));
                ac++;
            }
            while (true)
            {
                Console.WriteLine("請選擇操作項目：");
                Console.WriteLine("     <1>批次輸入：");
                Console.WriteLine("     <2>選手查詢：");
                Console.WriteLine("     <3>刪除：");
                Console.WriteLine("     <4>逐筆輸入：");
                Console.WriteLine("     <5>顯示所有資料：");
                Console.Write("請選擇：");
                int controlmode = int.Parse(Console.ReadLine());
                switch (controlmode)
                {
                    case 1:
                        AllInput();
                        break;
                    case 2:
                        Search();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        OneInput();
                        break;
                    case 5:
                        AllShow();
                        break;
                    default:
                        break;
                }
            }
        }
        static void AllShow()
        {
            foreach (var item in PPL)
            {
                    Console.WriteLine($"{item.Class} {item.Number} {item.Name} {item.Sex} {item.JoinPJ[0].Name}");
            }
        }
        static void OneInput()
        {
            Console.WriteLine("逐筆輸入，");
            Console.Write("請輸入 班級、學號、姓名及性別：");
            string[] temp = Console.ReadLine().Split(' ');
            Console.WriteLine("報名項目：");
            char a = 'a';
            for (int i = 0; i < PJ_Dic.Count / 2; i++)
            {
                Console.WriteLine($"{a}：{PJ_Dic[a.ToString()].Name}");
                a++;
            }
            Console.Write("請選擇：");
            string temp2 = Console.ReadLine();
            Console.WriteLine($"輸入班級：{temp[0]}、學號：{temp[1]}、姓名：{temp[2]}、性別：{temp[3]}、報名項目：{PJ_Dic[temp2].Name}");
            int partycount = 0, personcount = 0, sum = 0, firsttype = -1;

            bool flag = true, haveperson = false, haveparty = false;
            foreach (var item in PPL)
            {
                if (item.Class == temp[0] && item.Number == temp[1] && item.Name == temp[2])
                {
                    Console.WriteLine($"{item.Class} {item.Number} {item.Name} {item.Sex} {item.JoinPJ[0].Name}");

                    if (item.JoinPJ[0].Type == 0)
                    {
                        haveperson = true;
                        personcount++;
                        if (flag)
                        {
                            firsttype = 0;
                            flag = false;
                        }
                    }
                    else
                    {
                        haveparty = true;
                        partycount++;
                        if (flag)
                        {
                            firsttype = 1;
                            flag = false;
                        }
                    }
                    sum++;
                }
            }
            if (haveperson && sum >= 2) Console.WriteLine("已報名個人賽，不能再報名超過兩項");
            else if (haveparty && sum >= 2) Console.WriteLine("已報名團體賽，不能再報名超過兩項");
            else
            {
                if (haveperson && PJ_Dic[temp2].Type == 1) Console.WriteLine("已報名個人賽，不能再報名團體賽");
                else if (haveparty && PJ_Dic[temp2].Type == 0) Console.WriteLine("已報名團體賽，不能再報名個人賽");
                else
                {
                    People p = new People(temp[0], temp[1], temp[2], temp[3], PJ_Dic[temp2]);
                    PPL.Add(p);
                }
            }
        }
        static void Delete()
        {
            Console.WriteLine("刪除資料，");
            Console.Write("請輸入 班級、學號、姓名及報名項目：");
            string[] temp = Console.ReadLine().Split(' ');
            for (int i = 0; i < PPL.Count; i++)
            {
                if (PPL[i].Class == temp[0] && PPL[i].Number == temp[1] && PPL[i].Name == temp[2] && PPL[i].JoinPJ[0].Name == temp[3])
                {
                    Console.WriteLine($"被刪除的選手資料：{PPL[i].Class} {PPL[i].Number} {PPL[i].Name} {PPL[i].Sex} {PPL[i].JoinPJ[0].Name}");
                    PPL.RemoveAt(i);
                    return;
                }
            }
        }
        static void Search()
        {
            Console.WriteLine("選手查詢，");
            Console.Write("請輸入 班級、學號、姓名：");
            string[] temp = Console.ReadLine().Split(' ');
            //int PersonCount = 0, PartyCount = 0;
            foreach (var item in PPL)
            {
                if (item.Class == temp[0] && item.Number == temp[1] && item.Name == temp[2])
                {
                    Console.WriteLine($"{item.Class} {item.Number} {item.Name} {item.Sex} {item.JoinPJ[0].Name}");
                }
            }
        }
        static void AllInput()
        {
            using (StreamReader sr = new StreamReader("pach_test.txt", Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string[] temp = sr.ReadLine().Split(' ');
                    People p = new People(temp[0], temp[1], temp[2], temp[3], PJ_Dic[temp[4]]);
                    PPL.Add(p);
                }
            }
        }
    }
    class People
    {
        public string Class, Number, Name, Sex;
        public List<Project> JoinPJ = new List<Project>();
        public People(string cla, string num, string name, string sex, Project Pro)
        {
            Class = cla;
            Number = num;
            Name = name;
            Sex = sex;
            JoinPJ.Add(new Project(Pro));
        }
        public People(string cla, string num, string name, string sex)
        {
            Class = cla;
            Number = num;
            Name = name;
            Sex = sex;
        }
    }
    class Project
    {
        public string Name;
        public int Type;
        public Project(Project p)
        {
            Name = p.Name;
            Type = p.Type;
        }
        public Project(string name)
        {
            Name = name;
        }
        public Project(string name,int type)
        {
            Name = name;
            Type = type;
        }
    }
}