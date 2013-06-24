using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TVCompany
{
    class TVCompany
    {
        static void Main()
        {
            // The input is entered in same format as the prev task ( Pesho's friends )
            // example:
            //8 9
            //1 2 20
            //1 7 2
            //7 8 6
            //7 6 3
            //6 2 1
            //6 5 1
            //5 3 4
            //3 4 8
            //3 2 5

            #region Read Input
            var firstLine = Console.ReadLine();
            var firstLineParts = firstLine.Split(' ');
            var numNodes = int.Parse(firstLineParts[0]);
            var numStreets = int.Parse(firstLineParts[1]);

            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();
            List<Node> nodes = new List<Node>();

            for (int i = 1; i <= numNodes; i++)
            {
                var node = new Node(i);
                node.DijkstraDistance = int.MaxValue;
                nodes.Add(node);
                graph.Add(nodes[i - 1], new List<Connection>());
            }

            for (int i = 0; i < numStreets; i++)
            {
                var currConnection = Console.ReadLine().Split(' ');
                var currNode = int.Parse(currConnection[0]);
                var to = int.Parse(currConnection[1]);
                var distance = int.Parse(currConnection[2]);

                graph[nodes[currNode - 1]].Add(new Connection(nodes[to - 1], distance));
                graph[nodes[to - 1]].Add(new Connection(nodes[currNode - 1], distance));
            }
            #endregion;

            #region Get Optimal Path
            var optimalPath = double.PositiveInfinity;
            var source = -1;
            for (int i = 1; i < numNodes; i++)
            {
                var currPath = 0d;
                DijkstraAlgorithm(graph, nodes[i - 1]);

                for (int j = 0; j < nodes.Count; j++)
                {
                    currPath += nodes[j].DijkstraDistance;
                }

                if (currPath < optimalPath)
                {
                    source = i;
                    optimalPath = currPath;
                }
            }
            #endregion;

            // optional
            #region Print optimal path
            //Console.WriteLine(optimalPath);
            //Console.WriteLine(source);

            //DijkstraAlgorithm(graph, nodes[source - 1]);

            //for (int i = 0; i < nodes.Count; i++)
            //{
            //    Console.Write("Distance from {0} to {1} ", source, i + 1);
            //    Console.WriteLine(nodes[i].DijkstraDistance);
            //}
            #endregion
        }

        static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                if (source.ID != node.Key.ID)
                {
                    node.Key.DijkstraDistance = double.PositiveInfinity;
                    queue.Enqueue(node.Key);
                }
            }

            source.DijkstraDistance = 0.0d;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                Node currentNode = queue.Peek();

                if (currentNode.DijkstraDistance == double.PositiveInfinity)
                {
                    break;
                }

                foreach (var neighbour in graph[currentNode])
                {
                    double potDistance = currentNode.DijkstraDistance + neighbour.Distance;

                    if (potDistance < neighbour.To.DijkstraDistance)
                    {
                        neighbour.To.DijkstraDistance = potDistance;
                    }
                }

                queue.Dequeue();
            }
        }
    }
}
