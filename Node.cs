﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinariTreeTest
{
    public class Node
    {
        public Node Right { get; set; }
        public Node Left { get; set; }
        
        public ModelNode Value { get; set; }

        public Node(ModelNode modelNode)
        {
            Value = modelNode;
        }

    }
}
