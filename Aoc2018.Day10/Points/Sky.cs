using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2018.Day10.Points
{
    public static class Sky
    {
        public static IEnumerable<Point> At(this IEnumerable<Point> points, int second)
        {
            foreach (var p in points)
            {
                yield return new Point(
                    p.X + second * p.VelocityX,
                    p.Y + second * p.VelocityY,
                    p.VelocityX,
                    p.VelocityY);
            }
        }

        public static void Draw(this IEnumerable<Point> points, int width, int height)
        {
            var minX = points.Min(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxX = points.Max(p => p.X);
            var maxY = points.Max(p => p.Y);

            var xScale = (double)width / (maxX - minX);
            var yScale = (double)height / (maxY - minY);

            var sky = new bool[width, height];

            foreach (var p in points)
            {
                var x = Math.Min(width - 1, Math.Max(0, (int)Math.Round((p.X - minX) * xScale)));
                var y = Math.Min(height - 1, Math.Max(0, (int)Math.Round((p.Y - minY) * yScale)));

                sky[x, y] = true;
            }

            for (var i = 0; i < height; i++)
            {
                var sb = new StringBuilder();

                for (var j = 0; j < width; j++)
                {
                    sb.Append(sky[j, i] ? '#' : '.');
                }

                Console.WriteLine(sb.ToString());
            }
        }
    }
}
