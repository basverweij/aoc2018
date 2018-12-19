using Aoc2018.Day13.Common;
using Aoc2018.Day13.Tracks;
using Xunit;
using Xunit.Abstractions;

namespace Aoc2018.Day13.Tests.Tracks
{
    public class TrackTest
    {
        private readonly ITestOutputHelper _output;

        public TrackTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Ticks()
        {
            var sut = new Track(1, 7);

            for (var i = 0; i < 7; i++)
            {
                sut.AddSection(0, i, SectionTypes.Vertical);
            }

            sut.AddCart(0, 1, Directions.Down);

            sut.AddCart(0, 5, Directions.Up);

            try
            {
                while (true)
                {
                    _output.WriteLine(sut.ToString());

                    sut.Tick();
                }
            }
            catch (CartCollisionException ccex)
            {
                Assert.Equal(new Location(0, 3), ccex.Location);
            }
        }

        [Fact]
        public void TicksAdvanced()
        {
            var input = new string[]
            {
                "/->-\\        ",
                "|   |  /----\\",
                "| /-+--+-\\  |",
                "| | |  | v  |",
                "\\-+-/  \\-+--/",
                "  \\------/   ",
            };

            var sut = InputParser.Parse(input);

            try
            {
                while (true)
                {
                    _output.WriteLine(sut.ToString());

                    sut.Tick();
                }
            }
            catch (CartCollisionException ccex)
            {
                Assert.Equal(new Location(7, 3), ccex.Location);
            }
        }
    }
}
