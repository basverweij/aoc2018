using System;

namespace Aoc2018.Day08.Trees
{
    public static class TreeBuilder
    {
        public static Node Build(int[] data)
        {
            var offset = 0;

            var root = BuildNode(data, ref offset);

            return root;
        }

        private static Node BuildNode(int[] data, ref int offset)
        {
            var node = new Node()
            {
                ChildNodes = new Node[data[offset++]],
                Metadata = new int[data[offset++]],
            };

            // process children
            for (var i = 0; i < node.ChildNodes.Length; i++)
            {
                node.ChildNodes[i] = BuildNode(data, ref offset);
            }

            // copy metadata
            Array.Copy(data, offset, node.Metadata, 0, node.Metadata.Length);

            offset += node.Metadata.Length;

            return node;
        }
    }
}
