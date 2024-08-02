using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023Day1
{
    internal class Day1
    {
        public void TaskA()
        {
            var data = File.ReadAllLines("C:\\Users\\Filip\\Desktop\\AOC-2023\\Day1.txt");
            var result = 0;

            foreach (var line in data)
            {
                var outPut = string.Concat(line.Where(Char.IsDigit)).ToCharArray();

                string firstChar = outPut[0].ToString();
                string lastChar = outPut[outPut.Length - 1].ToString();

                var number = string.Concat(firstChar, lastChar);

                var intNumber = int.Parse(number);

                result += intNumber;
            }

            Console.WriteLine(result);
        }

        public void TaskB()
        {
            var data = File.ReadAllLines("C:\\Users\\Filip\\Desktop\\AOC-2023\\Day1.txt");
            var result = 0;

            string[] numbers = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            foreach (var line in data)
            {
                List<int> foundNumbers = new List<int>();
                var charList = line.ToCharArray();
                var stringNumber = string.Empty;

                foreach (var c in charList)
                {
                    if (Char.IsDigit(c))
                    {
                        foundNumbers.Add(c - '0');
                        stringNumber = string.Empty;
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder(stringNumber);
                        sb.Append(c);

                        stringNumber = sb.ToString();

                        foreach (var n in numbers)
                        {
                            if (stringNumber.Contains(n))
                            {
                                foundNumbers.Add(StringToInt(n));
                                stringNumber = c.ToString();
                            }
                        }
                    }
                }

                var concatenatedNumber = int.Parse(foundNumbers[0].ToString() + foundNumbers[foundNumbers.Count - 1].ToString());
                result += concatenatedNumber;

                Console.WriteLine(concatenatedNumber);
            }

            Console.WriteLine(result);
        }

        public int StringToInt(string number)
        {
            switch (number)
            {
                case "one":
                    return 1;
                    break;
                case "two":
                    return 2;
                    break;
                case "three":
                    return 3;
                    break; 
                case "four":
                    return 4;
                    break;
                case "five":
                    return 5;
                    break;
                case "six":
                    return 6;
                    break;
                case "seven":
                    return 7;
                case "eight":
                    return 8;
                    break;
                case "nine":
                    return 9;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}
