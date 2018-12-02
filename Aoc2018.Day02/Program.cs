using System;
using System.IO;

namespace Aoc2018.Day02
{
    static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();
        }

        static void Puzzle1()
        {
            var ids = File.ReadAllLines("input.txt");

            var checksum = ChecksumCalculator.CalculateChecksum(ids);

            Console.WriteLine($"Day 02 - Puzzle 1: {checksum}");
        }
    }
}
