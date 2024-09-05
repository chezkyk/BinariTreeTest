using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BinariTreeTest.Models;

namespace BinariTreeTest
{
    public class DefenceStrategiesBST
    {
        public Node root;

        public DefenceStrategiesBST()
        {
            root = null;
        }

        public void Insert(ModelNode value)
        {
            root = InsertRecursion(root, value);

        }

        // O(n) worst case
        // O(log(n)) mid case
        private Node InsertRecursion(Node node, ModelNode value)
        {
            if (node == null)
            {
                return new Node(value);
            }
            if (value.MinSeverity < node.Value.MinSeverity)
            {
                node.Left = InsertRecursion(node.Left, value);
            }
            else if (value.MinSeverity > node.Value.MinSeverity)
            {
                node.Right = InsertRecursion(node.Right, value);
            }
            return node;
        }


        // O(n)
        public void recursivePreorder(Node node)
        {
            Console.Write(node.Value.MinSeverity.ToString() + " ");
            Console.Write(node.Value.MaxSeverity.ToString() + " ");
            if (node.Left != null)
            {
                recursivePreorder(node.Left);
            }
            if (node.Right != null)
            {
                recursivePreorder(node.Right);
            }
        }

        
        public void preorderTraversal()
        {
            if (root != null)
            {
                recursivePreorder(root);
            }
            else
            {
                Console.WriteLine("There is no tree to process");
            }

        }


        public void PrintTree(Node node)
        {
            PrintTreeRec(node, "", true);
        }


        // O(n)
        private void PrintTreeRec(Node node, string indent, bool last)
        {
            if (node != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("Right----");
                    indent += "   ";
                }
                else
                {
                    Console.Write("Left----");
                    indent += "|  ";
                }
                Console.WriteLine($"{node.Value.MinSeverity} {node.Value.MaxSeverity}");
                PrintTreeRec(node.Left, indent, false);
                PrintTreeRec(node.Right, indent, true);
            }
        }



        // O(n) worst case
        // O(log(n)) mid case
        public int FindValueInTree(int value)
        {
            int ans = PreorderFindValueRecursion(root, value);
            return ans;
        }
        private int PreorderFindValueRecursion(Node node, int value)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.Value.MinSeverity == value || node.Value.MaxSeverity == value)
            {
                return value;
            }

            if (value < node.Value.MinSeverity)
            {
                return PreorderFindValueRecursion(node.Left, value);
            }
            else
            {
                return PreorderFindValueRecursion(node.Right, value);
            }

        }


        public Node GetMin()
        {
            if (root == null)
            {
                return null;
            }
            return GetMinRecursion(root);
        }

        // O(log(n)) (because its a balanced tree).
        // if not balanced O(n).
        public Node GetMinRecursion(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }
            return GetMinRecursion(node.Left);
        }
    }
}
