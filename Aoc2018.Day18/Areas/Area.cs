using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2018.Day18.Areas
{
    public class Area
    {
        public int Width { get; }

        public int Height { get; }

        private LandType[,] _acres;

        public int ResourceValue => Enumerable
            .Range(0, Width)
            .Sum(x => Enumerable.Range(0, Height).Sum(y => _acres[x, y] == LandType.Lumberyard ? 1 : 0)) * Enumerable
            .Range(0, Width)
            .Sum(x => Enumerable.Range(0, Height).Sum(y => _acres[x, y] == LandType.Trees ? 1 : 0));

        public Area(int width, int height)
        {
            Width = width;
            Height = height;

            _acres = new LandType[Width, Height];
        }

        public void SetLandType(int x, int y, LandType landType)
        {
            _acres[x, y] = landType;
        }

        public void Grow()
        {
            var acres = new LandType[Width, Height];

            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    var counts = GetAdjancentAcres(x, y)
                        .GroupBy(t => t)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Count());

                    var acre = _acres[x, y];

                    switch (acre)
                    {
                        case LandType.Open:
                            acres[x, y] = counts.ContainsKey(LandType.Trees) && counts[LandType.Trees] >= 3 ? LandType.Trees : acre;
                            break;

                        case LandType.Trees:
                            acres[x, y] = counts.ContainsKey(LandType.Lumberyard) && counts[LandType.Lumberyard] >= 3 ? LandType.Lumberyard : acre;
                            break;

                        case LandType.Lumberyard:
                            acres[x, y] = counts.ContainsKey(LandType.Lumberyard) && counts.ContainsKey(LandType.Trees) ? LandType.Lumberyard : LandType.Open;
                            break;
                    }
                }
            }

            _acres = acres;
        }

        public IEnumerable<LandType> GetAdjancentAcres(int x, int y)
        {
            if (x > 0)
            {
                if (y > 0)
                {
                    yield return _acres[x - 1, y - 1];
                }

                yield return _acres[x - 1, y];

                if (y < Height - 1)
                {
                    yield return _acres[x - 1, y + 1];
                }
            }

            if (y > 0)
            {
                yield return _acres[x, y - 1];
            }

            if (y < Height - 1)
            {
                yield return _acres[x, y + 1];
            }

            if (x < Width - 1)
            {
                if (y > 0)
                {
                    yield return _acres[x + 1, y - 1];
                }

                yield return _acres[x + 1, y];

                if (y < Height - 1)
                {
                    yield return _acres[x + 1, y + 1];
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var row = new char[Width];

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    row[x] = _acres[x, y] == LandType.Lumberyard ?
                        '#' :
                        _acres[x, y] == LandType.Trees ? '|' : '.';
                }

                sb.AppendLine(new string(row));
            }

            return sb.ToString();
        }
    }

    public enum LandType
    {
        Open,
        Trees,
        Lumberyard,
    }
}
