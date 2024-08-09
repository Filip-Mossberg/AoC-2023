using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                // Change the index to 1 after first row is done
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

        public void TaskB()
        {
            var data = File.ReadAllLines("C:\\Users\\Filip\\Desktop\\AOC-2023\\Day3.txt");

            var sum = 0;
            var index = 0;

            List<string> list = new List<string>();

            for (int i = 0; i < data.Length; i++)
            {
                // Change the index to 1 after first row is done
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

                sum += IdentifyEngineGearRatioByRow(list, index);
                list.Clear();
            }

            Console.WriteLine(sum);
        }

        public int IdentifyEngineGearRatioByRow(List<string> rows, int index)
        {
            List<string> gearRatioStrings = new List<string>(); 

            Regex rg = new Regex(@"[*]");
            Regex rgNumber = new Regex(@"\d+");

            var foundGearRatio = 0;
            var matches = rg.Matches(rows[index]);

            foreach (Match match in matches)
            {
                ValuesToMultiply valuesToMultiply = new ValuesToMultiply();

                for (int i = 0; i < rows.Count; i++)
                {
                    var negative = 0;
                    var posivive = 0;

                    for (int v = 0; v < 4; v++)
                    {
                        if (match.Index - v >= 0)
                        {
                            negative = v;
                        }

                        if (match.Index + v <= rows[i].Length)
                        {
                            posivive = v + 1;
                        }
                    }

                    gearRatioStrings.Add(rows[i].Substring(match.Index - negative, negative + posivive));

                }

                foreach (var s in gearRatioStrings)
                {
                    var foundNumbers = rgNumber.Matches(s);

                    foreach (Match number in foundNumbers)
                    {
                        for (int i = 0; i < number.Length; i++)
                        {

                            int charOriginalIndex = number.Index + i;

                            if(charOriginalIndex == 2 ||  charOriginalIndex == 3 || charOriginalIndex == 4)
                            {
                                if (valuesToMultiply.Value1 == 0)
                                {
                                    valuesToMultiply.Value1 = int.Parse(number.Value);
                                }
                                else
                                {
                                    valuesToMultiply.Value2 = int.Parse(number.Value);
                                }
 
                                break;
                            }
                        }
                    }
                }

                foundGearRatio += (valuesToMultiply.Value1 * valuesToMultiply.Value2);

                gearRatioStrings.Clear();
            }

            return foundGearRatio;
        }
    }

    public class ValuesToMultiply()
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }
}
