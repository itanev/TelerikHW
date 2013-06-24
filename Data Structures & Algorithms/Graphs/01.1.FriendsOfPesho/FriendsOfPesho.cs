using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._1.FriendsOfPesho
{
    class FriendsOfPesho
    {
        static void Main()
        {
            #region Read Input
            var firstLine = Console.ReadLine();
            var firstLineParts = firstLine.Split(' ');
            var numNodes = int.Parse(firstLineParts[0]);
            var numStreets = int.Parse(firstLineParts[1]);
            var numHospitals = int.Parse(firstLineParts[2]);

            var secondLine = Console.ReadLine();
            var secondLineParts = secondLine.Split(' ');
            bool[] hospitals = new bool[numNodes + 1];
            for (int i = 0; i < numHospitals; i++)
            {
                var currHospital = int.Parse(secondLineParts[i]);
                hospitals[currHospital] = true;
            }

            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();
            List<Node> nodes = new List<Node>();

            for (int i = 1; i <= numNodes; i++)
            {
                var node = new Node(i);
                node.DijkstraDistance = int.MaxValue;
                node.IsHospital = hospitals[i];
                nodes.Add(node);
                graph.Add(nodes[i-1], new List<Connection>());
            }

            for (int i = 0; i < numStreets; i++)
            {
                var currConnection = Console.ReadLine().Split(' ');
                var currNode = int.Parse(currConnection[0]);
                var to = int.Parse(currConnection[1]);
                var distance = int.Parse(currConnection[2]);

                graph[nodes[currNode - 1]].Add(new Connection(nodes[to - 1], distance));
                graph[nodes[to- 1]].Add(new Connection(nodes[currNode - 1], distance));
            }
            #endregion;

            #region Get Nearest Hospital
            var hospitalPath = double.PositiveInfinity;
            for (int i = 1; i < hospitals.Length; i++)
            {
                if (hospitals[i])
                {
                    var currPath = 0d;
                    DijkstraAlgorithm(graph, nodes[i-1]);

                    for (int j = 0; j < nodes.Count; j++)
                    {
                        if (!hospitals[j + 1])
                        {
                            currPath += nodes[j].DijkstraDistance;
                        }
                    }

                    if (currPath < hospitalPath)
                    {
                        hospitalPath = currPath;
                    }
                }
            }
            #endregion;

            Console.WriteLine(hospitalPath);
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
