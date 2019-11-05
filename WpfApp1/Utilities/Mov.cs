using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utilities
{
    class Mov
    {

        public static void mov(WObj Object, int destReg, BitArray value)
        {
            Object.Registers.registerLocations[destReg] = value;
        }

    }
}
