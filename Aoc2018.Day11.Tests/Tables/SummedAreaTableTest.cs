﻿using Aoc2018.Day11.Tables;
using Xunit;

namespace Aoc2018.Day11.Tests.Tables
{
    public class SummedAreaTableTest
    {
        private readonly int[,] MAGIC_SQUARE = new int[6, 6]
        {
            { 31, 2, 4, 33, 5, 36 },
            { 12, 26, 9, 10, 29, 25 },
            { 13, 17, 21, 22, 20, 18 },
            { 24, 23, 15, 16, 14, 19 },
            { 30, 8, 28, 27, 11, 7 },
            { 1, 35, 34, 3, 32, 6 },
        };

        [Fact]
        public void FillsCorrectly()
        {
            var sut = new SummedAreaTable(6, 6);

            sut.Fill((x, y) => MAGIC_SQUARE[y, x]);

            Assert.Equal(31, sut.GetAreaSum(0, 0, 0, 0));

            Assert.Equal(111, sut.GetAreaSum(2, 3, 4, 4));
        }
    }
}
