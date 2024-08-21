using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2023Day1._2023
{
    internal class Day4
    {

        public void TaskA()
        {
            var data = File.ReadAllLines("C:\\Users\\Filip\\Desktop\\AOC-2023\\Day4.txt").ToList();
            int sum = 0;

            foreach (var ticket in data)
            {
                var ticketStrings = ticket.Split(new char[] { ':', '|'});

                var myNumbers = ticketStrings[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var winningNumbers = ticketStrings[2].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var ticketPointsCount = 0;

                foreach (var wNumbers in winningNumbers)
                {
                    foreach (var mNumbers in myNumbers)
                    {
                        if(wNumbers == mNumbers)
                        {
                            ticketPointsCount = ticketPointsCount == 0 ? 1 : ticketPointsCount * 2;
                        }
                    }
                }
                sum += ticketPointsCount;
            }

            Console.WriteLine(sum);
        }
    }
}
