using System;

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
            //если оба дочерних присутствуют, 
            //то правый становится на место удаляемого,
            //а левый вставляется в правый
            else
            {
                if (node.ParentNode == null)
                {
                    node.RightNode.ParentNode = null;
                    RootNode = node.RightNode;
                    AddNode(node.LeftNode, RootNode);
                }
                /// <summary> if this node is in the left branch of the parent node. </summary>
                else if (node == node.ParentNode.LeftNode)
                //if (nodeSide == Side.Left)
                {
                    /// <summary>  </summary>
                    node.ParentNode.LeftNode = node.RightNode;
                    node.RightNode.ParentNode = node.ParentNode;
                    AddNode(node.LeftNode, node.RightNode);
                }
                else// if (node == node.ParentNode.RightNode)
                //else if (nodeSide == Side.Right)
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
                /// <summary> 
                /// If the left child of the start node is empty, we stop the search. Return null.
                /// Otherwise, the function is called recursively to advance in the branch.
                /// </summary>
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
    }
}
