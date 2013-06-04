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
            Console.Write("Enter sum: ");
            int S = int.Parse(Console.ReadLine());
            Console.WriteLine("All paths with sum {0}", S);
            FindAllPathsOfGivenSum(root, S);

            //6. Find all subtrees with given sum S of their nodes. 
            // Not my own implimentation
            Console.Write("Enter sum: ");
            int sum = int.Parse(Console.ReadLine());
            List<Node<int>> subTrees = new List<Node<int>>();
            SubTreeWithSum(root, subTrees, sum);

            foreach (var node in subTrees)
            {
                Console.WriteLine(node.Value);
            }
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

        public static void FindAllPathsOfGivenSum(Node<int> node, int sum)
        {
            path.Add(node.Value);

            if (sum == path.Sum())
            {
                Console.WriteLine(string.Join(", ", path));
                path.RemoveRange(1, path.Count - 1);
                return;
            }

            foreach (var childNode in node.Children)
            {
                FindAllPathsOfGivenSum(childNode, sum);
            }

            if (path.Count > 1)
            {
                path.RemoveAt(path.Count - 1);
            }
        }

        private static void SubTreeWithSum(Node<int> root, List<Node<int>> listOfSubTrees, int targetSum)
        {
            foreach (var child in root.Children)
            {
                if (targetSum == CheckSubTreeSum(child, child.Value))
                {
                    listOfSubTrees.Add(child);
                }
                SubTreeWithSum(child, listOfSubTrees, targetSum);
            }
        }

        private static int CheckSubTreeSum(Node<int> subRoot, int sum)
        {
            foreach (var node in subRoot.Children)
            {
                sum += CheckSubTreeSum(node, node.Value);
            }
            return sum;
        }
    }
}
