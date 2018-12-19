using Aoc2018.Core.Puzzles;
using Aoc2018.Day14.Recipes;
using System;

namespace Aoc2018.Day14
{
    static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();

            Puzzle2();
        }

        [Puzzle]
        static void Puzzle1()
        {
            var num = 793031;

            var sut = new Kitchen();

            while (sut.Cook() < num + 10) { }

            var result = sut.Recipes(num, 10);

            Console.WriteLine($"Day 14 - Puzzle 1: {result}");
        }

        [Puzzle]
        static void Puzzle2()
        {
            var scores = new int[] { 7, 9, 3, 0, 3, 1 };

            var sut = new Kitchen();

            int num;

            while ((num = sut.NumRecipesBeforeEndsWith(scores)) < 0)
            {
                sut.Cook();
            }

            Console.WriteLine($"Day 14 - Puzzle 2: {num}");
        }
    }
}
