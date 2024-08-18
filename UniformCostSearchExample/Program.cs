using System;
using System.Collections.Generic;

namespace UniformCostSearchExample
{
    class Node
    {
        public string Name { get; set; }
        public Dictionary<Node, int> Neighbors { get; set; } = new Dictionary<Node, int>();

        public Node(string name)
        {
            Name = name;
        }
    }

    class UniformCostSearch
    {
        public static List<Node> Search(Node start, Node goal)
        {
            var frontier = new PriorityQueue<Node, int>();
            var cameFrom = new Dictionary<Node, Node>();
            var costSoFar = new Dictionary<Node, int>();

            frontier.Enqueue(start, 0);
            cameFrom[start] = null;
            costSoFar[start] = 0;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();

                if (current == goal)
                {
                    break;
                }

                foreach (var neighbor in current.Neighbors)
                {
                    int newCost = costSoFar[current] + neighbor.Value;
                    if (!costSoFar.ContainsKey(neighbor.Key) || newCost < costSoFar[neighbor.Key])
                    {
                        costSoFar[neighbor.Key] = newCost;
                        frontier.Enqueue(neighbor.Key, newCost);
                        cameFrom[neighbor.Key] = current;
                    }
                }
            }

            return ReconstructPath(cameFrom, start, goal);
        }

        private static List<Node> ReconstructPath(Dictionary<Node, Node> cameFrom, Node start, Node goal)
        {
            var path = new List<Node>();
            var current = goal;
            while (current != start)
            {
                path.Add(current);
                current = cameFrom[current];
            }
            path.Add(start);
            path.Reverse();
            return path;
        }
    }

    class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
    {
        private List<(TElement Element, TPriority Priority)> elements = new List<(TElement Element, TPriority Priority)>();

        public int Count => elements.Count;

        public void Enqueue(TElement element, TPriority priority)
        {
            elements.Add((element, priority));
            elements.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }

        public TElement Dequeue()
        {
            var element = elements[0].Element;
            elements.RemoveAt(0);
            return element;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create nodes
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");
            var e = new Node("E");

            // Connect nodes with costs
            a.Neighbors[b] = 2;
            a.Neighbors[c] = 4;
            b.Neighbors[c] = 1;
            b.Neighbors[d] = 7;
            c.Neighbors[e] = 3;
            d.Neighbors[e] = 1;

            // Perform the search
            var path = UniformCostSearch.Search(a, e);

            // Output the path
            Console.WriteLine("Path found:");
            foreach (var node in path)
            {
                Console.Write(node.Name + " ");
            }
            Console.WriteLine();
        }
    }
}
