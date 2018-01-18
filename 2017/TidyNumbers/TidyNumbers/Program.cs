using System;
using System.IO;
using System.Linq;

namespace TidyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            TidyNumbersSimulation(Path.GetFullPath(@"..\..\B-small-practice.in"), Path.GetFullPath(@"..\..\outSmall.txt"));

            TidyNumbersSimulation(Path.GetFullPath(@"..\..\B-large-practice.in"), Path.GetFullPath(@"..\..\outLarge.txt"));
        }

        public static void TidyNumbersSimulation(string inFile, string outFile)
        {
            StreamReader sr = new StreamReader(inFile);
            StreamWriter sw = new StreamWriter(outFile);
            string caseStr = sr.ReadLine();
            int totalCases = Int32.Parse(caseStr);

            for (int i = 1; i <= totalCases; i++)
            {
                caseStr = sr.ReadLine();
                long tidyNum = GetHighestTidyNumber(long.Parse(caseStr));
                sw.WriteLine("Case #{0}: {1}", i, tidyNum);
            }

            sr.Close();
            sw.Close();
        }

        public static bool IsTidyNumber(long num)
        {
            string number = num.ToString();
            bool flag = false;

            if (number.Length == 1)
                return true;
            else
            {
                for (int i = 0; i + 1 < number.Length; i++)
                {
                    int a = number.ElementAt(i);
                    int b = number.ElementAt(i + 1);

                    if (a <= b)
                        flag = true;
                    else
                        return false;
                }
            }
            return flag;
        }

        public static long GetHighestTidyNumber(long num)
        {
            long number = num;
            long mod = 10;

            while (!IsTidyNumber(number))
            {
                if (number % 10 == 0)
                    number--;
                else
                {
                    number -= (number % mod) + 1;
                    mod *= 10;
                }
            }
            return number;
        }
    }
}
