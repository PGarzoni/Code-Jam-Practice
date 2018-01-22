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
            BathroomStallSimulation(Path.GetFullPath(@"..\..\C-small-practice-1"), Path.GetFullPath(@"..\..\outSmall_1.txt"));

            //BathroomStallSimulation(Path.GetFullPath(@"..\..\C-small-practice-2"), Path.GetFullPath(@"..\..\outSmall_2.txt"));

            //BathroomStallSimulation(Path.GetFullPath(@"..\..\C-large-practice"), Path.GetFullPath(@"..\..\outLarge.txt"));
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
            return "";
        }
    }
}
