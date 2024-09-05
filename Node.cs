using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinariTreeTest
{
    public class Node
    {
        public Node MaxSeverity { get; set; }
        public Node MinSeverity { get; set; }
        public List<string> Defenses { get; set; }

        public Node()
        {
            Defenses = new List<string>();
        }

    }
}
