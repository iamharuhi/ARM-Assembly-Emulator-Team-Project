using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utilities
{
    class Mul
    {
        public static void mul(WObj Object, int destReg, int mulReg1, int mulReg2)
        {
            RegisterClass.programCounter++;
            int x = Object.h.bitArrayToInt(Object.Registers.registerLocations[mulReg1]) * Object.h.bitArrayToInt(Object.Registers.registerLocations[mulReg2]);
            Object.Registers.registerLocations[destReg] = new BitArray(new[] { x });
        }

    }
}
