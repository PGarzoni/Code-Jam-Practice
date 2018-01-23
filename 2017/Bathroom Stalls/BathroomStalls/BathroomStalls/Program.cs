using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BathroomStalls
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindBestStall("o..oo");

            BathroomStallSimulation(Path.GetFullPath(@"..\..\C-small-practice-1.in"), Path.GetFullPath(@"..\..\outSmall_1.txt"));

            //BathroomStallSimulation(Path.GetFullPath(@"..\..\C-small-practice-2.in"), Path.GetFullPath(@"..\..\outSmall_2.txt"));

            //BathroomStallSimulation(Path.GetFullPath(@"..\..\C-large-practice.in"), Path.GetFullPath(@"..\..\outLarge.txt"));
        }

        public static void BathroomStallSimulation(string inFile, string outFile)
        {
            StreamReader sr = new StreamReader(inFile);
            StreamWriter sw = new StreamWriter(outFile);
            string caseStr = sr.ReadLine();
            int totalCases = Int32.Parse(caseStr);

            for (int i = 1; i <= totalCases; i++)
            {
                caseStr = sr.ReadLine();
                int stalls = Int32.Parse(caseStr.Split(' ')[0]);
                int people = Int32.Parse(caseStr.Split(' ')[1]);
                sw.WriteLine(@"Case #{0}: {1}", i, CalcMinMax(stalls, people));
            }

            sr.Close();
            sw.Close();
        }

        public static string CalcMinMax(int stallCount, int numOfPeople)
        {
            string stalls = InitStalls(stallCount);
            int max = 0;
            int min = 0;

            for(int i = 0; i < numOfPeople; i++)
            {
                stalls = FindBestStall(stalls);

                string[] str = stalls.Split(' ');

                stalls = str[0];
                max = Int32.Parse(str[1]);
                min = Int32.Parse(str[2]);
            }

            return string.Format (@"{0} {1}", max, min);
        }

        public static string InitStalls(int stallCount)
        {
            string str = "o";
            for(int i = 0; i < stallCount; i++)
            {
                str += ".";
            }
            str += "o";
            return str;
        }

        public static string FindBestStall(string stalls)
        {
            List<string> list = SplitString(stalls);
            int? space = null;
            int pos = 0;
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].Contains("."))
                {
                    if(space == null)
                    {
                        space = list[i].Length;
                        pos = i;
                    }
                    else
                    {
                        if (space < list[i].Length)
                        {
                            space = list[i].Length;
                            pos = i;
                        }
                    }
                }
            }

            string str = "";
            string Max_Min = "";

            for(int i = 0; i < list.Count; i++)
            {
                if(i == pos)
                {
                    StringBuilder sb = new StringBuilder(list[i]);
                    sb[(int)(space - 1) / 2] = 'o';
                    list[i] = sb.ToString();

                    Max_Min = GetMaxAndMin(list[i].ToString());
                }

                str += list[i];
            }
            return str + Max_Min;
        }

        public static List<string> SplitString(string stalls)
        {
            List<string> list = new List<string>();
            int l = stalls.Length;

            for (int i = 0; i < l; i++)
            {
                if (stalls.ElementAt(i) == 'o')
                {
                    list.Add("o");
                }
                else
                {
                    string dot = "";
                    for (int j = i; j < l; j++)
                    {
                        if (stalls.ElementAt(j) == '.')
                        {
                            dot += ".";
                        }
                        else
                        {
                            list.Add(dot);
                            list.Add("o");
                            i = j;
                            j = l;
                        }
                    }
                }
            }

            return list;
        }

        public static string GetMaxAndMin(string stalls)
        {
            string[] str = stalls.Split('o');
            string min = "";
            string max = "";
            if(str[0].Length > str[1].Length)
            {
                max = str[0].Length.ToString();
                min = str[1].Length.ToString();
            }
            else
            {
                min = str[0].Length.ToString();
                max = str[1].Length.ToString();
            }

            return string.Format(@" {0} {1}", max, min);
        }
    }
}
