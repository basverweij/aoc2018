using Aoc2018.Day08.Trees;
using Xunit;

namespace Aoc2018.Day08.Tests.Trees
{
    public class TreeBuilderTest
    {
        [Fact]
        public void BuildsTreeFromData()
        {
            var data = new int[] { 2, 3, 0, 3, 10, 11, 12, 1, 1, 0, 1, 99, 2, 1, 1, 2 };

            var root = TreeBuilder.Build(data);

            Assert.NotNull(root);
        }
    }
}
