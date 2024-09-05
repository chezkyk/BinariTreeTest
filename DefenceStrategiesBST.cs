using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
    }
}
