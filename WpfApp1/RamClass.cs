using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class RamClass
    {
        public Dictionary<int, BitArray> RamLocations { get; set; }

        public RamClass()
        {
            RamLocations = new Dictionary<int, BitArray>();
        }
    }
}
