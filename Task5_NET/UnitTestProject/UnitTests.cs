using System;
using ClassLibrary;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void AddNodeAndCountNodesTestMethod()
        {
            BinarySearchTree<StudentsTest> binarySearchTree = new BinarySearchTree<StudentsTest>();
            binarySearchTree.AddNode(new StudentsTest("Student1", 6, ".NET", DateTime.Now));
            binarySearchTree.AddNode(new StudentsTest("Student2", 5, ".NET", DateTime.Now));
            binarySearchTree.AddNode(new StudentsTest("Student3", 3, ".NET", DateTime.Now));
            binarySearchTree.AddNode(new StudentsTest("Student4", 7, ".NET", DateTime.Now));
            binarySearchTree.AddNode(new StudentsTest("Student5", 9, ".NET", DateTime.Now));


            Assert.IsTrue(binarySearchTree.CountNodes == 5);
        }

        [TestMethod]
        public void FindNodeByNodeDataRemoveNodeAndCountNodesTestMethod()
        {
            StudentsTest student1 = new StudentsTest("Student1", 6, ".NET", DateTime.Now);
            StudentsTest student2 = new StudentsTest("Student2", 5, ".NET", DateTime.Now);
            StudentsTest student3 = new StudentsTest("Student3", 3, ".NET", DateTime.Now);
            StudentsTest student4 = new StudentsTest("Student4", 7, ".NET", DateTime.Now);
            StudentsTest student5 = new StudentsTest("Student5", 9, ".NET", DateTime.Now);

            BinarySearchTree<StudentsTest> binarySearchTree = new BinarySearchTree<StudentsTest>();
            binarySearchTree.AddNode(student1);
            binarySearchTree.AddNode(student2);
            binarySearchTree.AddNode(student3);
            binarySearchTree.AddNode(student4);
            binarySearchTree.AddNode(student5);

            //search node by node data and then remove node
            binarySearchTree.RemoveNode(student1);


            Assert.IsTrue(binarySearchTree.CountNodes == 4);
        }

        [TestMethod]
        public void FillListOfNodesInAscendingOrderTestMethod()
        {
            BinarySearchTree<StudentsTest> binarySearchTree = new BinarySearchTree<StudentsTest>();

            Node<StudentsTest> Node1 = binarySearchTree.AddNode(new StudentsTest("Student1", 6, ".NET", DateTime.Now));
            Node<StudentsTest> Node2 = binarySearchTree.AddNode(new StudentsTest("Student2", 5, ".NET", DateTime.Now));
            Node<StudentsTest> Node3 = binarySearchTree.AddNode(new StudentsTest("Student3", 3, ".NET", DateTime.Now));
            Node<StudentsTest> Node4 = binarySearchTree.AddNode(new StudentsTest("Student4", 7, ".NET", DateTime.Now));
            Node<StudentsTest> Node5 = binarySearchTree.AddNode(new StudentsTest("Student5", 9, ".NET", DateTime.Now));


            List<Node<StudentsTest>> listOfNodes = new List<Node<StudentsTest>>
            {
                Node3,
                Node2,
                Node1,
                Node4,
                Node5
            };

            List<Node<StudentsTest>> resultListOfNodes = new List<Node<StudentsTest>>();
            binarySearchTree.FillListOfNodesInAscendingOrder(Node1, resultListOfNodes);



            Assert.IsTrue(listOfNodes[0].NodeData == resultListOfNodes[0].NodeData &&
                          listOfNodes[1].NodeData == resultListOfNodes[1].NodeData &&
                          listOfNodes[2].NodeData == resultListOfNodes[2].NodeData &&
                          listOfNodes[3].NodeData == resultListOfNodes[3].NodeData &&
                          listOfNodes[4].NodeData == resultListOfNodes[4].NodeData);
        }

        [TestMethod]
        public void BuildBalancedTreeWithStudentTypeTestMethod()
        {
            StudentsTest student1 = new StudentsTest("Student1", 6, ".NET", DateTime.Now);
            StudentsTest student2 = new StudentsTest("Student2", 5, ".NET", DateTime.Now);
            StudentsTest student3 = new StudentsTest("Student3", 3, ".NET", DateTime.Now);
            StudentsTest student4 = new StudentsTest("Student4", 7, ".NET", DateTime.Now);
            StudentsTest student5 = new StudentsTest("Student5", 9, ".NET", DateTime.Now);

            BinarySearchTree<StudentsTest> binarySearchTree = new BinarySearchTree<StudentsTest>();
            Node<StudentsTest> Node1 = binarySearchTree.AddNode(student1);
            Node<StudentsTest> Node2 = binarySearchTree.AddNode(student2);
            Node<StudentsTest> Node3 = binarySearchTree.AddNode(student3);
            Node<StudentsTest> Node4 = binarySearchTree.AddNode(student4);
            Node<StudentsTest> Node5 = binarySearchTree.AddNode(student5);

            binarySearchTree.BuildBalancedTree();

            //Expected result
            //                         6                    Node1
            //                       /   \                /       \
            //                     3       9        Node3           Node5
            //                       \   /                \       /
            //                        5 7               Node2   Node4
            //
            //

            Assert.IsTrue(Node1.ParentNode == null && Node1.LeftNode == Node3 && Node1.RightNode == Node5 &&

                          Node3.ParentNode == Node1 && Node3.LeftNode == null && Node3.RightNode == Node2 &&

                          Node5.ParentNode == Node1 && Node5.LeftNode == Node4 && Node5.RightNode == null &&

                          Node2.ParentNode == Node3 && Node2.LeftNode == null && Node2.RightNode == null &&

                          Node4.ParentNode == Node5 && Node4.LeftNode == null && Node4.RightNode == null &&

                          Node1.NodeData == student1 && Node2.NodeData == student2 &&
                          Node3.NodeData == student3 && Node4.NodeData == student4 &&
                          Node5.NodeData == student5);
        }

        [TestMethod]
        public void SerializeTo_DeserializeForm_XmlFile()
        {
            StudentsTest student1 = new StudentsTest("Student1", 6, ".NET", DateTime.Now);
            StudentsTest student2 = new StudentsTest("Student2", 5, ".NET", DateTime.Now);
            StudentsTest student3 = new StudentsTest("Student3", 3, ".NET", DateTime.Now);
            StudentsTest student4 = new StudentsTest("Student4", 7, ".NET", DateTime.Now);
            StudentsTest student5 = new StudentsTest("Student5", 9, ".NET", DateTime.Now);

            BinarySearchTree<StudentsTest> binarySearchTree = new BinarySearchTree<StudentsTest>();
            Node<StudentsTest> Node1 = binarySearchTree.AddNode(student1);
            Node<StudentsTest> Node2 = binarySearchTree.AddNode(student2);
            Node<StudentsTest> Node3 = binarySearchTree.AddNode(student3);
            Node<StudentsTest> Node4 = binarySearchTree.AddNode(student4);
            Node<StudentsTest> Node5 = binarySearchTree.AddNode(student5);


            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t"
            };
            XmlWriter xmlWriter = XmlWriter.Create("binarySearchTree.xml", xmlWriterSettings);
            DataContractSerializer toXmlFile = new DataContractSerializer(typeof(BinarySearchTree<StudentsTest>));
            toXmlFile.WriteObject(xmlWriter, binarySearchTree);
            xmlWriter.Close();


            FileStream fileStream = new FileStream("binarySearchTree.xml", FileMode.Open);
            DataContractSerializer fromXmlFile = new DataContractSerializer(typeof(BinarySearchTree<StudentsTest>));
            BinarySearchTree<StudentsTest> deserializedBinarySearchTree = (BinarySearchTree<StudentsTest>)fromXmlFile.ReadObject(fileStream);
            fileStream.Close();


            Node<StudentsTest> ResultNode1 = deserializedBinarySearchTree.FindNode(student1);
            Node<StudentsTest> ResultNode2 = deserializedBinarySearchTree.FindNode(student2);
            Node<StudentsTest> ResultNode3 = deserializedBinarySearchTree.FindNode(student3);
            Node<StudentsTest> ResultNode4 = deserializedBinarySearchTree.FindNode(student4);
            Node<StudentsTest> ResultNode5 = deserializedBinarySearchTree.FindNode(student5);

            //Debug.WriteLine(ResultNode1.NodeData);



            Assert.IsTrue(Node1.NodeData == ResultNode1.NodeData &&
                          Node2.NodeData == ResultNode2.NodeData &&
                          Node3.NodeData == ResultNode3.NodeData &&
                          Node4.NodeData == ResultNode4.NodeData &&
                          Node5.NodeData == ResultNode5.NodeData);
        }
    }
}
