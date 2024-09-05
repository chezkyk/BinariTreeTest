﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public void recursivePreorder(Node node)
        {
            Console.Write(node.Value.MinSeverity.ToString() +" ");
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
    }
}
