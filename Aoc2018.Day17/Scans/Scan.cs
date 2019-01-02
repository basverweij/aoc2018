using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2018.Day17.Scans
{
    public class Scan
    {
        public IEnumerable<ScanLine> ScanLines { get; }

        private readonly int _minY;
        private readonly int _maxY;
        private readonly int _minX;
        private readonly int _maxX;

        public CellTypes[,] Cells { get; }

        public int WaterCellsCount => Enumerable
            .Range(0, _maxY - _minY + 1)
            .Sum(y => Enumerable.Range(0, _maxX - _minX + 1).Sum(x => Cells[y, x].IsWater() ? 1 : 0));

        public int SettledWaterCellsCount => Enumerable
            .Range(0, _maxY - _minY + 1)
            .Sum(y => Enumerable.Range(0, _maxX - _minX + 1).Sum(x => Cells[y, x] == CellTypes.SettledWater ? 1 : 0));

        public Scan(IEnumerable<ScanLine> scanLines)
        {
            ScanLines = scanLines ?? throw new ArgumentNullException(nameof(scanLines));

            _minY = ScanLines
                .Select(l => l.Orientation == ScanLineOrientations.Vertical ? l.From : l.At)
                .Min();

            _maxY = ScanLines
                .Select(l => l.Orientation == ScanLineOrientations.Vertical ? l.To : l.At)
                .Max();

            _minX = ScanLines
                .Select(l => l.Orientation == ScanLineOrientations.Horizontal ? l.From : l.At)
                .Min() - 1;

            _maxX = ScanLines
                .Select(l => l.Orientation == ScanLineOrientations.Horizontal ? l.To : l.At)
                .Max() + 1;

            Cells = new CellTypes[_maxY - _minY + 1, _maxX - _minX + 1];

            foreach (var scanLine in ScanLines)
            {
                if (scanLine.Orientation == ScanLineOrientations.Horizontal)
                {
                    for (var x = scanLine.From; x <= scanLine.To; x++)
                    {
                        Cells[scanLine.At - _minY, x - _minX] = CellTypes.Clay;
                    }
                }
                else
                {
                    for (var y = scanLine.From; y <= scanLine.To; y++)
                    {
                        Cells[y - _minY, scanLine.At - _minX] = CellTypes.Clay;
                    }
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var row = new char[_maxX - _minX + 1];

            for (var y = 0; y <= _maxY - _minY; y++)
            {
                for (var x = 0; x <= _maxX - _minX; x++)
                {
                    row[x] = Cells[y, x].ToCellChar();
                }

                sb.AppendLine(new string(row));
            }

            return sb.ToString();
        }

        public void AddWater(int x)
        {
            AddWater(x - _minX, -1);
        }

        private void AddWater(int x, int y)
        {
            while (y < _maxY - _minY)
            {
                if (Cells[y + 1, x] == CellTypes.Sand)
                {
                    Cells[y + 1, x] = CellTypes.MovingWater;
                }
                else if (y >= 0 && Cells[y + 1, x].IsClayOrSettled())
                {
                    // check for left clay border
                    var i = x;
                    while (i > 0 && Cells[y + 1, i - 1].IsClayOrSettled() && !Cells[y, i - 1].IsClay()) { i--; }

                    // check for right clay border
                    var j = x;
                    while (j < _maxX - _minX && Cells[y + 1, j + 1].IsClayOrSettled() && !Cells[y, j + 1].IsClay()) { j++; }

                    var type = Cells[y, i - 1] != CellTypes.Clay || Cells[y, j + 1] != CellTypes.Clay ?
                        CellTypes.MovingWater :
                        CellTypes.SettledWater;

                    for (var k = i; k <= j; k++)
                    {
                        Cells[y, k] = type;

                        if (y < _maxY - _minY &&
                            Cells[y + 1, k] == CellTypes.MovingWater)
                        {
                            Cells[y + 1, k] = CellTypes.SettledWater;
                        }
                    }

                    if (Cells[y, i - 1] != CellTypes.Clay)
                    {
                        // overflow left
                        AddWater(i - 1, y - 1);
                    }

                    if (Cells[y, j + 1] != CellTypes.Clay)
                    {
                        // overflow right
                        AddWater(j + 1, y - 1);
                    }

                    if (type == CellTypes.MovingWater)
                    {
                        // done: left and/or right overflow have been added
                        return;
                    }

                    if (--y < 0)
                    {
                        // done: cannot go back up further to settle
                        return;
                    }

                    continue;
                }

                y++;
            }

            // water flowing of the bottom of the scan
            return;
        }
    }

    public enum CellTypes
    {
        Sand,
        Clay,
        MovingWater,
        SettledWater,
    }

    public static class CellTypesExtensions
    {
        public static char ToCellChar(this CellTypes cellType)
        {
            switch (cellType)
            {
                case CellTypes.Clay:
                    return '#';

                case CellTypes.MovingWater:
                    return '|';

                case CellTypes.SettledWater:
                    return '~';
            }

            return '.';
        }

        public static bool IsWater(this CellTypes cellType)
        {
            return cellType == CellTypes.MovingWater || cellType == CellTypes.SettledWater;
        }

        public static bool IsClayOrSettled(this CellTypes cellType)
        {
            return cellType == CellTypes.Clay || cellType == CellTypes.SettledWater;
        }

        public static bool IsClay(this CellTypes cellType)
        {
            return cellType == CellTypes.Clay;
        }
    }

    public class ScanLine
    {
        public ScanLineOrientations Orientation { get; }

        public int At { get; }

        public int From { get; }

        public int To { get; }

        public ScanLine(ScanLineOrientations scanLineOrientation, int at, int from, int to)
        {
            Orientation = scanLineOrientation;
            At = at;
            From = from;
            To = to;
        }
    }

    public enum ScanLineOrientations
    {
        Horizontal,
        Vertical,
    }
}
