using System;
using System.IO;
using System.Linq;
using System.Text;

namespace OversizedPancakeFlipper
{
    class Program
    {
        static void Main(string[] args)
        {
            OversizedPancakeFlipperSimulation(Path.GetFullPath(@"..\..\A-small-practice.in"), Path.GetFullPath(@"..\..\outSmall.txt"));

            OversizedPancakeFlipperSimulation(Path.GetFullPath(@"..\..\A-large-practice.in"), Path.GetFullPath(@"..\..\outLarge.txt"));
        }

        public static void OversizedPancakeFlipperSimulation(string inFile, string outFile)
        {
            StreamReader sr = new StreamReader(inFile);
            StreamWriter sw = new StreamWriter(outFile);
            string caseStr = sr.ReadLine();
            int totalCases = Int32.Parse(caseStr);

            for(int i = 1; i <= totalCases; i++)
            {
                caseStr = sr.ReadLine();
                string pancakeLine = caseStr.Split(' ')[0];
                int flipSize = Int32.Parse(caseStr.Split(' ')[1]);
                sw.WriteLine(CalcFlips(i, pancakeLine, flipSize));
            }

            sr.Close();
            sw.Close();
        }

        public static string CalcFlips(int caseNum, string pancakeLine, int flipSize)
        {
            int flipCounter = 0;
            bool checkStr = false;
            if (!IsLineHappy(pancakeLine))
            {
                for (int i = 0; i <= (pancakeLine.Length - flipSize); i++)
                {
                    if (pancakeLine.ElementAt(i) == '-')
                    {
                        pancakeLine = PancakeFlip(pancakeLine, i, flipSize);
                        flipCounter++;
                    }
                }
                checkStr = true;
            }
            return Results(checkStr, caseNum, pancakeLine, flipCounter);
        }

        public static bool IsLineHappy(string pancakeStr)
        {
            foreach(char c in pancakeStr)
            {
                if (c == '-')
                    return false;
            }
            return true;
        }

        public static string PancakeFlip(string pancakeLine, int pos, int flipperSize)
        {
            StringBuilder sb = new StringBuilder(pancakeLine);
            for(int i = 0; i < flipperSize; i++)
            {
                if(sb[pos + i] == '-')
                    sb[pos + i] = '+';
                else
                    sb[pos + i] = '-';
            }
            return sb.ToString();
        }

        public static string Results(bool checkRequired, int caseNum, string pancakeLine, int flipCount)
        {
            if (checkRequired && !IsLineHappy(pancakeLine))
                return String.Format("Case #{0}: IMPOSSIBLE", caseNum);
            else
                return String.Format("Case #{0}: {1}", caseNum, flipCount);
        }
    }
}
