using System;

namespace ClassLibrary
{
    public class Node<T> where T : IComparable
    {
        public Node<T> ParentNode { get; set; }

        public Node<T> LeftNode { get; set; }

        public Node<T> RightNode { get; set; }

        public T NodeData { get; set; }

        public Node(T nodeData)
        {
            NodeData = nodeData;
        }

        public override string ToString()
        {
            return $"NodeData-> {NodeData}";
        }
    }
}
