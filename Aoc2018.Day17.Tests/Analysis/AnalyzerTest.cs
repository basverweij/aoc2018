using Aoc2018.Day17.Analysis;
using Aoc2018.Day17.Scans;
using Xunit;
using Xunit.Abstractions;

namespace Aoc2018.Day17.Tests.Analysis
{
    public class AnalyzerTest
    {
        private readonly ITestOutputHelper _output;

        public AnalyzerTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void AnalyzesReachableWaterTiles()
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

            _output.WriteLine(scan.ToString());

            var actual = Analyzer.GetReachableWaterCellsCount(scan);

            _output.WriteLine(scan.ToString());

            Assert.Equal(57, actual);
        }
    }
}
