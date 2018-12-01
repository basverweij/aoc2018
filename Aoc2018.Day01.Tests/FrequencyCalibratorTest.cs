using Xunit;

namespace Aoc2018.Day01.Tests
{
    public class FrequencyCalibratorTest
    {
        [Fact]
        public void CalculatesFrequency()
        {
            var frequencies = new int[]
            {
                1,
                -2,
                3,
                1,
            };

            var actual = FrequencyCalibrator.CalculateFrequency(frequencies);

            Assert.Equal(3, actual);
        }
    }
}
