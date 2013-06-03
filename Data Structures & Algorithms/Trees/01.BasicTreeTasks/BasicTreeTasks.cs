using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicTreeTasks
{
    public class BasicTreeTasks
    {
        private static List<int> path = new List<int>();

        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            List<Node<int>> nodes = CreateNodes(N);
            CreateLinks(N, nodes);

            //1.Find root.
            var root = FindRoot(nodes);
            Console.WriteLine("The root is: {0}", root.Value);

            //2.Find leafs.
            var leafs = FindLeafs(nodes);
            Console.WriteLine("The leafs are: {0}", string.Join(", ", leafs));

            //3.Find middle nodes.
            var middleNodes = FindMiddleNodes(nodes);
            Console.WriteLine("The middle nodes are: {0}", string.Join(", ", middleNodes));

            //4.Find longest path.
            var longestPath = FindLongestPath(root);
            Console.WriteLine("The longest path is: {0}", longestPath);

            //5.Find paths with given sum S of their nodes. From the root.
            int S = int.Parse(Console.ReadLine());
            Console.WriteLine("All paths with sum {0}", S);
            FindAllPathsOfGivenSum(root, S);
        }

        private static void CreateLinks(int N, List<Node<int>> nodes)
        {
            for (int i = 0; i < N - 1; i++)
            {
                string currDependence = Console.ReadLine();
                var parentAndChild = currDependence.Split(' ');

                var parent = int.Parse(parentAndChild[0]);
                var child = int.Parse(parentAndChild[1]);

                nodes[parent].Children.Add(nodes[child]);
                nodes[child].HasParent = true;
            }
        }

        private static List<Node<int>> CreateNodes(int N)
        {
            List<Node<int>> nodes = new List<Node<int>>();

            for (int i = 0; i < N; i++)
            {
                nodes.Add(new Node<int>(i));
                nodes[i].HasParent = false;
            }
            return nodes;
        }

        public static Node<int> FindRoot(List<Node<int>> nodes)
        {
            foreach (var node in nodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            return null;
        }

        public static List<int> FindLeafs(List<Node<int>> nodes)
        {
            List<int> leafs = new List<int>();
            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node.Value);
                }
            }

            return leafs;
        }

        public static List<int> FindMiddleNodes(List<Node<int>> nodes)
        {
            List<int> middleNodes = new List<int>();
            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middleNodes.Add(node.Value);
                }
            }

            return middleNodes;
        }

        public static int FindLongestPath(Node<int> node)
        {
            if (node.Children.Count == 0)
            {
                return 0;
            }

            var maxPath = 0;

            foreach (var childNode in node.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(childNode));
            }

            return maxPath + 1;
        }

        public static void FindAllPathsOfGivenSum(Node<int> node, int Sum)
        {
            path.Add(node.Value);

            if (Sum == path.Sum())
            {
                Console.WriteLine(string.Join(", ", path));
                path.RemoveRange(1, path.Count - 1);
                return;
            }

            foreach (var childNode in node.Children)
            {
                FindAllPathsOfGivenSum(childNode, Sum);
            }

            if (path.Count > 1)
            {
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
