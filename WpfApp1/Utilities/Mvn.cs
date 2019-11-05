using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utilities
{
    class Mvn
    {
        public static void mvn(WObj Object, int destReg, BitArray value)
        {
            value[0] = true;
            Object.Registers.registerLocations[destReg] = value;
        }

    }
}
