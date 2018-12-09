using System.Linq;

namespace Aoc2018.Day08.Trees
{
    public static class TreeAnalyzer
    {
        public static int GetMetadataSum(Node root)
        {
            return
                root.Metadata.Sum() +
                root.ChildNodes.Sum(GetMetadataSum);
        }
    }
}
