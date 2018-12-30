using System.Collections.Generic;

namespace Aoc2018.Day15.Paths
{
    public interface IGraph<T>
    {
        IEnumerable<T> GetVertexes();

        IEnumerable<Neighbour<T>> GetNeighbours(T vertex);
    }

    public struct Neighbour<T>
    {
        public T Vertex { get; }

        public int Distance { get; }

        public Neighbour(T vertex, int distance) : this()
        {
            Vertex = vertex;
            Distance = distance;
        }
    }
}
