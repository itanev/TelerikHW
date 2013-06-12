using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WordsSearch
{
    public class Node
    {
        private char letter;
        private bool last;
        private Dictionary<char, Node> children;

        protected Node() { }

        public Node(char c)
        {
            children = new Dictionary<char, Node>();
            last = false;
            letter = c;
        }

        public char Letter
        {
            get { return this.letter; }
            set { this.letter = value; }
        }

        public bool Last
        {
            get { return this.last; }
            set { this.last = value; }
        }

        public Dictionary<char, Node> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        public Node ChildNode(char c)
        {
            if (Children != null)
            {
                if (Children.ContainsKey(c))
                {
                    return Children[c];
                }
            }
            return null;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            return Equals(obj);
        }

        public bool Equals(Node obj)
        {
            if (obj != null
                && obj.Letter == this.Letter)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + this.Letter.GetHashCode();
            return hash;
        }
    }
}
