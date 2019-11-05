using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utilities
{
    class Teq
    {

        public static void teq(WObj Object, int reg1, int reg2, int shift)
        {
            int x = Object.h.bitArrayToInt(Object.Registers.registerLocations[reg1]);
            int y = Object.h.bitArrayToInt(Object.Registers.registerLocations[reg2]);
            if(x == y)
            {
                Flags.flagsRay[0] = 0;
                Flags.flagsRay[1] = 1;
            }
            else
            {
                Flags.flagsRay[0] = 0;
                Flags.flagsRay[1] = 0;
            }
        }

    }
}
