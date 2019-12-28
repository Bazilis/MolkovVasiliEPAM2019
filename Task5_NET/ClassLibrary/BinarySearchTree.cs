using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public Node<T> RootNode { get; private set; }

        public int CountNodes { get; private set; }

        public Node<T> AddNode(T nodeData)
        {
            return AddNode(new Node<T>(nodeData));
        }

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

        public void RemoveNode(T nodeData)
        {
            Node<T> foundNode = FindNode(nodeData);
            RemoveNode(foundNode);
        }

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

        public void FillListOfNodesInAscendingOrder(Node<T> node, List<Node<T>> listOfNodes)
        {
            if (node != null)
            {
                FillListOfNodesInAscendingOrder(node.LeftNode, listOfNodes);

                listOfNodes.Add(node);

                FillListOfNodesInAscendingOrder(node.RightNode, listOfNodes);
            }
        }

        private void RemoveChildNodes(List<Node<T>> listOfNodes)
        {
            foreach (Node<T> node in listOfNodes)
            {
                node.LeftNode = null;
                node.RightNode = null;
            }
        }

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
