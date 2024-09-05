using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinariTreeTest
{
    public class ModelNode
    {
        public int MaxSeverity { get; set; }
        public int MinSeverity { get; set; }
        public List<string> Defenses { get; set; }
    }
}
