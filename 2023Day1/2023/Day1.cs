using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023Day1
{
    internal class Day1
    {
        public void Run()
        {
            var data = File.ReadAllLines("C:\\Users\\Filip\\Desktop\\AOC-2023\\Day1.txt");
            var result = 0;

            List<string> list = new List<string>();

            foreach (var line in data)
            {
                string outPut = string.Concat(line.Where(Char.IsDigit));
                var charArray = outPut.ToCharArray();

                string firstChar = charArray[0].ToString();
                string lastChar = charArray[charArray.Length - 1].ToString();

                var number = string.Concat(firstChar, lastChar);

                var intNumber = int.Parse(number);

                result += intNumber;
            }

            Console.WriteLine(result);
        }
    }
}
