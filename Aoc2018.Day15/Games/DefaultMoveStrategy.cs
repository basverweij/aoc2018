using Aoc2018.Day15.Areas;
using Aoc2018.Day15.Common;
using Aoc2018.Day15.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day15.Games
{
    public class DefaultMoveStrategy :
        IMoveStrategy
    {
        public Location? Move(Unit unit, Area area, IEnumerable<Location> targets)
        {
            if (targets
                .Intersect(UnitsUtil.LocationsInRange(unit.Location, area.Width, area.Height))
                .Any())
            {
                // don't move if already adjacent to a target
                return null;
            }

            var inRangeLocations = targets
                .SelectMany(l => UnitsUtil.LocationsInRange(l, area.Width, area.Height))
                .Distinct()
                .Where(l => !area.IsWall(l.X, l.Y)) // not a wall
                .Where(l => area.GetUnit(l.X, l.Y) == null) // not a unit
                .ToArray();

            // flood fill area to determine path distances
            var pathDistances = Fill(area, unit.Location, 0);

            // determine leading target in range location
            var distances = inRangeLocations
                .Select(l => pathDistances[l.X, l.Y])
                .ToArray();

            int minDistance;

            try
            {
                minDistance = distances
                    .Where(d => d > 0)
                    .Min();
            }
            catch (InvalidOperationException)
            {
                return null;
                //throw new NoTargetsReachableException($"from: {unit}");
            }

            var leadingInRangeLocation = inRangeLocations
                .Where((_, i) => distances[i] == minDistance)
                .OrderBy(l => l.Y)
                .ThenBy(l => l.X)
                .First();

            // determine leading shortest path
            pathDistances = Fill(area, leadingInRangeLocation, 1);

            return UnitsUtil.LocationsInRange(unit.Location, area.Width, area.Height)
                .Where(l => pathDistances[l.X, l.Y] == minDistance) // shortest paths
                .OrderBy(l => l.Y) // resolve ties by reading order
                .ThenBy(l => l.X) // resolve ties by reading order
                .FirstOrDefault();
        }

        struct Node
        {
            public readonly Location Location;
            public readonly int Distance;

            public Node(Location location, int distance)
            {
                Location = location;
                Distance = distance;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Node))
                {
                    return false;
                }

                var node = (Node)obj;

                return Distance == node.Distance &&
                    Location.Equals(node.Location);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Location, Distance);
            }
        }

        class NodeComparer :
            IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                if (x.Distance != y.Distance)
                {
                    return x.Distance - y.Distance;
                }

                if (x.Location.Y != y.Location.Y)
                {
                    return x.Location.Y - y.Location.Y;
                }

                return x.Location.X - y.Location.X;
            }
        }

        private static int[,] NewPathDistances(Area area)
        {
            var d = new int[area.Width, area.Height];

            for (var i = 0; i < area.Width; i++)
            {
                for (var j = 0; j < area.Height; j++)
                {
                    d[i, j] = int.MinValue;
                }
            }

            return d;
        }

        private static int[,] Fill(Area area, Location source, int distance)
        {
            var pathDistances = NewPathDistances(area);

            // mark source node as visited
            pathDistances[source.X, source.Y] = distance;

            // create node queue
            var q = new SortedSet<Node>(new NodeComparer());

            // add source node neighbours
            ProcessNeighbours(area, pathDistances, q, new Node(source, distance));

            // loop while queue is not empty
            while (q.Count > 0)
            {
                // get and remove the node with the smallest distance
                var node = q.Min;
                q.Remove(node);

                // save the distance for this node
                pathDistances[node.Location.X, node.Location.Y] = node.Distance;

                // process neighbours
                ProcessNeighbours(area, pathDistances, q, node);
            }

            return pathDistances;
        }

        private static void ProcessNeighbours(Area area, int[,] pathDistances, SortedSet<Node> q, Node node)
        {
            foreach (var l in UnitsUtil.LocationsInRange(node.Location, area.Width, area.Height))
            {
                if (IsValidNode(area, pathDistances, l))
                {
                    q.Add(new Node(l, node.Distance + 1));
                }
                else if (pathDistances[l.X, l.Y] == int.MinValue)
                {
                    // mark unvisited invalid node as visited
                    pathDistances[l.X, l.Y] = int.MaxValue;
                }
            }
        }

        private static bool IsValidNode(Area area, int[,] pathDistances, Location location)
        {
            if (pathDistances[location.X, location.Y] != int.MinValue)
            {
                // already visited
                return false;
            }

            if (area.IsWall(location.X, location.Y))
            {
                // walls can't be visited
                return false;
            }

            // units can't be visited
            return area.GetUnit(location.X, location.Y) == null;
        }
    }
}
