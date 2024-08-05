using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2023Day1._2023
{
    internal class Day3
    {
        public void TaskA()
        {
            var data = File.ReadAllLines("C:\\Users\\Filip\\Desktop\\AOC-2023\\Day3.txt");

            var sum = 0;
            var index = 0;

            List<string> list = new List<string>();

            for (int i = 0; i < data.Length; i++)
            {
                // Change the index to 1 after first row has been done
                if (i > 0 && index != 1)
                {
                    index = 1;
                }

                // Add previous element if not the first element
                if (i > 0)
                {
                    list.Add(data[i - 1]);
                }

                list.Add(data[i]);

                // Add the next element if not the last element
                if (i < data.Length - 1)
                {
                    list.Add(data[i + 1]);
                }

                sum += IdentifyEngineSymbolsByRow(list, index);
                list.Clear();
            }

            Console.WriteLine(sum);
        }

        public int IdentifyEngineSymbolsByRow(List<string> rows, int index)
        {
            char[] engineSymbol = new char[] { '#', '+', '@', '&', '*', '%', '-', '/', '=', '$' };
            List<string> checkForSymbolString = new List<string>();
            Regex rg = new Regex(@"\d+");

            var rowCount = 0;
            var matches = rg.Matches(rows[index]);

            foreach (Match match in matches)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    checkForSymbolString.Add(rows[i].Substring((match.Index - 1) >= 0 ? match.Index - 1 : match.Index, (match.Index + (match.Length + 2)) <= 139 ? match.Length + 2 : match.Length + 1));
                }

                foreach (var stringRow in checkForSymbolString)
                {
                    if (engineSymbol.Any(symbol => stringRow.Contains(symbol)))
                    {
                        rowCount += int.Parse(match.Value);

                        break;
                    }
                }

                checkForSymbolString.Clear(); 
            }

            return rowCount;
        }
    }

}
