using System;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Сlass describing a Binary Searching Tree (BST) node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract(IsReference = true)]
    public class Node<T> where T : IComparable
    {
        /// <summary>
        /// Parent node property
        /// </summary>
        [DataMember]
        public Node<T> ParentNode { get; set; }

        /// <summary>
        /// Left node property
        /// </summary>
        [DataMember]
        public Node<T> LeftNode { get; set; }

        /// <summary>
        /// Right node property
        /// </summary>
        [DataMember]
        public Node<T> RightNode { get; set; }

        /// <summary>
        /// Data of node property
        /// </summary>
        [DataMember]
        public T NodeData { get; set; }

        /// <summary>
        /// Constructor with parameter
        /// </summary>
        /// <param name="nodeData"></param>
        public Node(T nodeData)
        {
            NodeData = nodeData;
        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"NodeData-> {NodeData}";
        }
    }
}
