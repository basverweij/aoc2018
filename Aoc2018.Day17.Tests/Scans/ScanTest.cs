using Aoc2018.Day17.Scans;
using System;
using Xunit;

namespace Aoc2018.Day17.Tests.Scans
{
    public class ScanTest
    {
        [Fact]
        public void ToStringIsCorrect()
        {
            var scan = new Scan(
                new ScanLine[]
                {
                    new ScanLine(ScanLineOrientations.Vertical, 495, 2, 7),
                    new ScanLine(ScanLineOrientations.Horizontal, 7, 495, 501),
                    new ScanLine(ScanLineOrientations.Vertical, 501, 3, 7),
                    new ScanLine(ScanLineOrientations.Vertical, 498, 2, 4),
                    new ScanLine(ScanLineOrientations.Vertical, 506, 1, 2),
                    new ScanLine(ScanLineOrientations.Vertical, 498, 10, 13),
                    new ScanLine(ScanLineOrientations.Vertical, 504, 10, 13),
                    new ScanLine(ScanLineOrientations.Horizontal, 13, 498, 504),
                });

            var expected =
                "............#." + Environment.NewLine +
                ".#..#.......#." + Environment.NewLine +
                ".#..#..#......" + Environment.NewLine +
                ".#..#..#......" + Environment.NewLine +
                ".#.....#......" + Environment.NewLine +
                ".#.....#......" + Environment.NewLine +
                ".#######......" + Environment.NewLine +
                ".............." + Environment.NewLine +
                ".............." + Environment.NewLine +
                "....#.....#..." + Environment.NewLine +
                "....#.....#..." + Environment.NewLine +
                "....#.....#..." + Environment.NewLine +
                "....#######..." + Environment.NewLine;

            Assert.Equal(expected, scan.ToString());
        }
    }
}
