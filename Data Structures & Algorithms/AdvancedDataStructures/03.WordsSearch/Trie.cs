using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WordsSearch
{
    class Trie
    {
        private Node root;

        public Trie()
        {
            root = new Node(' ');
        }

        public void Insert(string str)
        {
            char[] word = str.ToLower().ToCharArray();

            Node current = root;

            if (word.Length == 0)
            {
                current.Last = true;
            }

            for (int i = 0; i < str.Length; i++)
            {
                Node child = current.ChildNode(word[i]);
                if (child != null)
                {
                    current = child;
                }
                else
                {
                    current.Children.Add(word[i], new Node(word[i]));
                    current = current.ChildNode(word[i]);
                }

                if (i == word.Length - 1)
                {
                    current.Last = true;
                }
            }
        }

        public bool Search(string searchedString)
        {
            char[] word = searchedString.ToLower().ToCharArray();
            Node current = root;
            while (current != null)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (current.ChildNode(word[i]) == null)
                    {
                        return false;
                    }
                    else
                    {
                        current = current.ChildNode(word[i]);
                    }
                }

                if (current.Last == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
