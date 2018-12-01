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

        [Theory]
        [InlineData(new int[] { 1, -1 }, 0)]
        [InlineData(new int[] { 3, 3, 4, -2, -4 }, 10)]
        [InlineData(new int[] { -6, 3, 8, 5, -6 }, 5)]
        [InlineData(new int[] { 7, 7, -2, -7, -4 }, 14)]
        public void GetsFirstDuplicateFrequency(int[] frequencies, int expected)
        {
            var actual = FrequencyCalibrator.GetFirstDuplicateFrequency(frequencies);

            Assert.Equal(expected, actual);
        }
    }
}
