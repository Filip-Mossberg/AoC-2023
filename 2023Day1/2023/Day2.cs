using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2023Day1._2023
{
    internal class Day2
    {
        public void Run()
        {
            var data = File.ReadAllLines("C:\\Users\\Filip\\Desktop\\AOC-2023\\Day2.txt");

            var games = ModifyData(data);
            var result = GetResult(games);

            Console.WriteLine(result);
        }

        public List<Game> ModifyData(string[] data)
        {
            List<Game> games = new List<Game>();


            foreach (var line in data)
            {
                var game = new Game();
                var rounds = new List<Round>();

                var splittedData = line.Split(":");
                game.gameId = int.Parse(string.Concat(splittedData[0].Where(char.IsDigit)));


                foreach (var set in splittedData[1].Split(";"))
                {
                    var round = new Round();

                    foreach (var cubeColor in set.Split(","))
                    {
                        if (cubeColor.Contains("red"))
                        {
                            round.Red = int.Parse(string.Concat(cubeColor.Where(char.IsDigit)));
                        }

                        if (cubeColor.Contains("blue"))
                        {
                            round.Blue = int.Parse(string.Concat(cubeColor.Where(char.IsDigit)));
                        }

                        if (cubeColor.Contains("green"))
                        {
                            round.Green = int.Parse(string.Concat(cubeColor.Where(char.IsDigit)));
                        }
                    }

                    rounds.Add(round);
                }

                game.rounds = rounds;
                games.Add(game);
            }

            return games;
        }

        public int GetResult(List<Game> games)
        {
            int gameIdSum = 0;

            foreach (var game in games)
            {
                if (game.rounds.All(c => c.Red <= 12 && c.Green <= 13 && c.Blue <= 14))
                {
                    gameIdSum += game.gameId;
                }
            }

            return gameIdSum;
        }
    }

    public class Game()
    {
        public int gameId; 
        public List<Round> rounds;
    }

    public class Round()
    {
        public int Red;
        public int Green;
        public int Blue;     
    }
}
