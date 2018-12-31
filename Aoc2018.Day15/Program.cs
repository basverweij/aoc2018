using Aoc2018.Core.Puzzles;
using Aoc2018.Day15.Common;
using Aoc2018.Day15.Games;
using Aoc2018.Day15.Units;
using System;
using System.IO;
using System.Linq;

namespace Aoc2018.Day15
{
    static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();

            Puzzle2();
        }

        [Puzzle]
        private static void Puzzle1()
        {
            var input = File.ReadAllLines("input-2018-15.txt");

            var area = InputParser.Parse(input);

            Console.WriteLine(area);

            var game = new Game(area, new DefaultMoveStrategy(), new DefaultAttackStrategy());

            while (game.Turn()) ;

            Console.WriteLine(area);

            Console.WriteLine($"Day 15 - Puzzle 1: {game.Score}");
        }

        [Puzzle]
        private static void Puzzle2()
        {
            for (var attackPower = 4; ; attackPower++)
            {
                Console.WriteLine($"Elf attack power: {attackPower}");

                var input = File.ReadAllLines("input-2018-15.txt");

                var area = InputParser.Parse(input, attackPower);

                Console.WriteLine(area);

                var game = new Game(area, new DefaultMoveStrategy(), new DefaultAttackStrategy());

                while (game.Turn()) ;

                Console.WriteLine(area);

                if (game.Units.Where(u => u.UnitType == UnitTypes.Elf).All(u => u.IsAlive))
                {
                    Console.WriteLine($"Day 15 - Puzzle 2: {game.Score}");

                    break;
                }
            }
        }
    }
}
