using System.Linq;

namespace Aoc2018.Day08.Trees
{
    public static class TreeAnalyzer
    {
        public static int GetMetadataSum(Node node)
        {
            return
                node.Metadata.Sum() +
                node.ChildNodes.Sum(GetMetadataSum);
        }

        public static int GetNodeValue(Node node)
        {
            if (node.ChildNodes.Length == 0)
            {
                return node.Metadata.Sum();
            }

            return node
                .Metadata
                .Select(m => m - 1) // make zero-based
                .Where(m => m >= 0 && m < node.ChildNodes.Length) // only valid indexes
                .Select(m => GetNodeValue(node.ChildNodes[m]))
                .Sum();
        }
    }
}
