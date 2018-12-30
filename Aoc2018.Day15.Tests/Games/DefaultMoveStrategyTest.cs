using Aoc2018.Day15.Common;
using Aoc2018.Day15.Games;
using Aoc2018.Day15.Units;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Aoc2018.Day15.Tests.Games
{
    public class DefaultMoveStrategyTest
    {
        private readonly ITestOutputHelper _output;

        public DefaultMoveStrategyTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Moves()
        {
            var area = InputParser.Parse(
                new string[]
                {
                    "#######",
                    "#E..G.#",
                    "#...#.#",
                    "#.G.#G#",
                    "#######",
                });

            var game = new Game(area, new DefaultMoveStrategy(), new NullAttackStrategy());

            game.Turn();

            var unit = game.Area.GetUnit(2, 1);

            Assert.NotNull(unit);
            Assert.Equal(UnitTypes.Elf, unit.UnitType);
        }

        [Fact]
        public void SelectsCorrectShortestPath()
        {
            var area = InputParser.Parse(
                new string[]
                {
                    "#######",
                    "#.E...#",
                    "#.....#",
                    "#...G.#",
                    "#######",
                });

            var game = new Game(area, new DefaultMoveStrategy(), new NullAttackStrategy());

            game.Turn();

            var unit = game.Area.GetUnit(3, 1);

            Assert.NotNull(unit);
            Assert.Equal(UnitTypes.Elf, unit.UnitType);
        }

        [Fact]
        public void MultipleTurns()
        {
            var area = InputParser.Parse(
                new string[]
                {
                    "#########",
                    "#G..G..G#",
                    "#.......#",
                    "#.......#",
                    "#G..E..G#",
                    "#.......#",
                    "#.......#",
                    "#G..G..G#",
                    "#########",
                });

            var game = new Game(area, new DefaultMoveStrategy(), new NullAttackStrategy());

            _output.WriteLine("Initially:");
            _output.WriteLine(game.Area.ToString());

            game.Turn();

            _output.WriteLine("After 1 round:");
            _output.WriteLine(game.Area.ToString());

            var round1 = string.Join(
                Environment.NewLine,
                new string[]
                {
                    "#########",
                    "#.G...G.#",
                    "#...G...#",
                    "#...E..G#",
                    "#.G.....#",
                    "#.......#",
                    "#G..G..G#",
                    "#.......#",
                    "#########",
                }) +
                Environment.NewLine;

            Assert.Equal(round1, game.Area.ToString());
        }
    }
}
