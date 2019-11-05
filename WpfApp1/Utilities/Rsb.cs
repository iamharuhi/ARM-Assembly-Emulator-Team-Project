using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utilities
{
    class Rsb
    {
        public static void rsb(WObj Object, int destReg, int addReg1, int addReg2)
        {
            int x = Object.h.bitArrayToInt(Object.Registers.registerLocations[addReg2]) - Object.h.bitArrayToInt(Object.Registers.registerLocations[addReg1]);
            Object.Registers.registerLocations[destReg] = new BitArray(new[] { x });
        }

    }
}
