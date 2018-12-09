using Aoc2018.Day08.Trees;
using Xunit;

namespace Aoc2018.Day08.Tests.Trees
{
    public class TreeAnalyzerTest
    {
        [Fact]
        public void GetsMetadataSum()
        {
            var data = new int[] { 2, 3, 0, 3, 10, 11, 12, 1, 1, 0, 1, 99, 2, 1, 1, 2 };

            var root = TreeBuilder.Build(data);

            Assert.Equal(138, TreeAnalyzer.GetMetadataSum(root));
        }

        [Fact]
        public void GetsNodeValue()
        {
            var data = new int[] { 2, 3, 0, 3, 10, 11, 12, 1, 1, 0, 1, 99, 2, 1, 1, 2 };

            var root = TreeBuilder.Build(data);

            Assert.Equal(66, TreeAnalyzer.GetNodeValue(root));
        }
    }
}
