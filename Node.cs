using System;
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
        public int MaxSeverity { get; set; }
        public int MinSeverity { get; set; }
        public List<string> Defenses { get; set; }

        public Node(int maxSeverity,int minSeverity)
        {
            MaxSeverity = maxSeverity;
            MinSeverity = minSeverity;
            Defenses = new List<string>();
        }

    }
}
