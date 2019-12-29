using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Сlass describing a Binary Search Tree (BST)
    /// </summary>
    /// <typeparam name="T">Type supporting comparisons</typeparam>
    [DataContract(IsReference = true)]
    public class BinarySearchTree<T> where T : IComparable
    {
        /// <summary>
        /// Root node property
        /// </summary>
        [DataMember]
        public Node<T> RootNode { get; private set; }

        /// <summary>
        /// Count of nodes property
        /// </summary>
        [DataMember]
        public int CountNodes { get; private set; }

        /// <summary>
        /// Method for adding a node using T-type data
        /// </summary>
        /// <param name="nodeData"></param>
        /// <returns></returns>
        public Node<T> AddNode(T nodeData)
        {
            return AddNode(new Node<T>(nodeData));
        }

        /// <summary>
        /// Recursive method for adding a node with its parent node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private Node<T> AddNode(Node<T> node, Node<T> parentNode = null)
        {
            if (RootNode == null)
            {
                CountNodes++;
                node.ParentNode = null;
                return RootNode = node;
            }

            if (parentNode == null)
            {
                parentNode = RootNode;
            }

            node.ParentNode = parentNode;

            int compareResult = node.NodeData.CompareTo(parentNode.NodeData);

            if (compareResult >= 0)
            {
                if (parentNode.RightNode == null)
                {
                    CountNodes++;
                    return parentNode.RightNode = node;
                }
                else
                {
                    return AddNode(node, parentNode.RightNode);
                }
            }
            else
            {
                if (parentNode.LeftNode == null)
                {
                    CountNodes++;
                    return parentNode.LeftNode = node;
                }
                else
                {
                    return AddNode(node, parentNode.LeftNode);
                }
            }
        }

        /// <summary>
        /// Method for removing node using T-type data
        /// </summary>
        /// <param name="nodeData"></param>
        public void RemoveNode(T nodeData)
        {
            Node<T> foundNode = FindNode(nodeData);
            RemoveNode(foundNode);
        }

        /// <summary>
        /// Method for removing node
        /// </summary>
        /// <param name="node"></param>
        private void RemoveNode(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentException("The node is null");
            }

            if (node.LeftNode == null && node.RightNode == null)
            {
                if (node.ParentNode == null)
                {
                    RootNode = null;
                }
                else if (node == node.ParentNode.LeftNode)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }
                CountNodes--;
            }

            else if (node.LeftNode == null)
            {
                if (node.ParentNode == null)
                {
                    RootNode = node.RightNode;
                }
                else if (node == node.ParentNode.LeftNode)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                    node.RightNode.ParentNode = node.ParentNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                    node.RightNode.ParentNode = node.ParentNode;
                }
                CountNodes--;
            }

            else if (node.RightNode == null)
            {
                if (node.ParentNode == null)
                {
                    RootNode = node.LeftNode;
                }
                else if (node == node.ParentNode.LeftNode)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                    node.LeftNode.ParentNode = node.ParentNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                    node.LeftNode.ParentNode = node.ParentNode;
                }
                CountNodes--;
            }

            else
            {
                if (node.ParentNode == null)
                {
                    node.RightNode.ParentNode = null;
                    RootNode = node.RightNode;
                    AddNode(node.LeftNode, RootNode);
                }
                else if (node == node.ParentNode.LeftNode)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                    node.RightNode.ParentNode = node.ParentNode;
                    AddNode(node.LeftNode, node.RightNode);
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                    node.RightNode.ParentNode = node.ParentNode;
                    AddNode(node.LeftNode, node.RightNode);
                }
                CountNodes -= 2;
            }
        }

        /// <summary>
        /// Recursive method for finding node by its data
        /// </summary>
        /// <param name="nodeData"></param>
        /// <param name="startNode"></param>
        /// <returns></returns>
        public Node<T> FindNode(T nodeData, Node<T> startNode = null)
        {
            if (startNode == null)
            {
                startNode = RootNode;
            }

            int compareResult = nodeData.CompareTo(startNode.NodeData);

            if (compareResult == 0) return startNode;

            else if (compareResult < 0)
            {
                if (startNode.LeftNode == null)
                {
                    return null;
                }
                else
                {
                    return FindNode(nodeData, startNode.LeftNode);
                }
            }

            else
            {
                if (startNode.RightNode == null)
                {
                    return null;
                }
                else
                {
                    return FindNode(nodeData, startNode.RightNode);
                }
            }
        }

        /// <summary>
        /// Method for building balanced binary search tree
        /// </summary>
        public void BuildBalancedTree()
        {
            List<Node<T>> listOfNodes = new List<Node<T>>();

            FillListOfNodesInAscendingOrder(RootNode, listOfNodes);

            RemoveChildNodes(listOfNodes);

            RootNode = null;

            int count = CountNodes;
            CountNodes = 0;

            BuildBalancedTree(0, count - 1, listOfNodes);
        }

        /// <summary>
        /// Recursive method for filling list of nodes in ascending order
        /// </summary>
        /// <param name="node"></param>
        /// <param name="listOfNodes"></param>
        public void FillListOfNodesInAscendingOrder(Node<T> node, List<Node<T>> listOfNodes)
        {
            if (node != null)
            {
                FillListOfNodesInAscendingOrder(node.LeftNode, listOfNodes);

                listOfNodes.Add(node);

                FillListOfNodesInAscendingOrder(node.RightNode, listOfNodes);
            }
        }

        /// <summary>
        /// Method for removing links to nodes from other nodes
        /// </summary>
        /// <param name="listOfNodes"></param>
        private void RemoveChildNodes(List<Node<T>> listOfNodes)
        {
            foreach (Node<T> node in listOfNodes)
            {
                node.LeftNode = null;
                node.RightNode = null;
            }
        }

        /// <summary>
        /// Recursive method for building balanced binary search tree from list of nodes
        /// </summary>
        /// <param name="firstNodeIndex"></param>
        /// <param name="lastNodeIndex"></param>
        /// <param name="listOfNodes"></param>
        private void BuildBalancedTree(int firstNodeIndex, int lastNodeIndex, List<Node<T>> listOfNodes)
        {
            if (firstNodeIndex <= lastNodeIndex)
            {
                int middleNodeIndex = (int)Math.Round((double)(firstNodeIndex + lastNodeIndex) / 2);

                AddNode(listOfNodes[middleNodeIndex]);

                BuildBalancedTree(firstNodeIndex, middleNodeIndex - 1, listOfNodes);

                BuildBalancedTree(middleNodeIndex + 1, lastNodeIndex, listOfNodes);
            }
        }
    }
}
