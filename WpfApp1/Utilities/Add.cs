using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utilities
{
    class Add
    {

        public static void add(WObj Object, int destReg, int addReg1, int addReg2)
        {
            RegisterClass.programCounter++;
            int x = Object.h.bitArrayToInt(Object.Registers.registerLocations[addReg1]) + Object.h.bitArrayToInt(Object.Registers.registerLocations[addReg2]);
            Object.Registers.registerLocations[destReg] = new BitArray(new[] { x });
        }

    }
}
