using Aoc2018.Day06.Areas;
using Aoc2018.Day06.Coordinates;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Aoc2018.Day06.Tests.Areas
{
    public class AreaFillerTest
    {
        private readonly ITestOutputHelper _output;

        public AreaFillerTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void FillsArea()
        {
            var coordinates = new Coordinate[]
            {
                new Coordinate(0, 1, 1),
                new Coordinate(1, 1, 6),
                new Coordinate(2, 8, 3),
                new Coordinate(3, 3, 4),
                new Coordinate(4, 5, 5),
                new Coordinate(5, 8, 9),
            };

            var area = AreaFiller.Fill(coordinates);

            Assert.Equal(8, area.Width);

            Assert.Equal(9, area.Height);

            Assert.Equal(new Cell(0, 0), area.GetCell(0, 0));

            for (var y = 0; y < area.Height; y++)
            {
                var sb1 = new StringBuilder();
                var sb2 = new StringBuilder();

                for (var x = 0; x < area.Width; x++)
                {
                    var c = area.GetCell(x, y);

                    Assert.NotNull(c);

                    if (c.Coordinate == -1)
                    {
                        sb1.Append('.');
                    }
                    else if (c.Distance == 0)
                    {
                        sb1.Append((char)('A' + c.Coordinate));
                    }
                    else
                    {
                        sb1.Append((char)('a' + c.Coordinate));
                    }

                    sb2.Append(c.Distance);
                }

                _output.WriteLine(sb1.ToString() + " | " + sb2.ToString());
            }
        }
    }
}
