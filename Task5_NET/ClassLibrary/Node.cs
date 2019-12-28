using System;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    [DataContract(IsReference = true)]
    public class Node<T> where T : IComparable
    {
        [DataMember]
        public Node<T> ParentNode { get; set; }

        [DataMember]
        public Node<T> LeftNode { get; set; }

        [DataMember]
        public Node<T> RightNode { get; set; }

        [DataMember]
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
