using System;
using System.Collections.Generic;

namespace Aoc2018.Day15.Paths
{
    public class Dijkstra<T>
    {
        private readonly IGraph<T> _graph;

        public Dijkstra(IGraph<T> graph)
        {
            _graph = graph ?? throw new ArgumentNullException(nameof(graph));
        }

        public IEnumerable<T> GetShortestPath(T from, T to)
        {
            return null;
        }
    }
}
